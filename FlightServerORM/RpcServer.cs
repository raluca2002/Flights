﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using log4net;
using System.Xml;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using FlightNetwork.utils;
using FlightPersistenceORM;
using Microsoft.EntityFrameworkCore;
using MPP_Csharp_Server_Client.FlightModel.domain;
using MPP_Csharp_Server_Client.FlightServerORM;
using MPP_Csharp_Server_Client.FlightsServices;
using BiletRepository = FlightPersistenceORM.BiletRepository;
using UserRepository = FlightPersistenceORM.UserRepository;
using ZborRepository = FlightPersistenceORM.ZborRepository;

namespace MPP_Csharp_Server_Client.FlightServerORM
{
    internal class RpcServer
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(RpcServer));

        public static void SetupLogger()
        {
            User u = new User(0,"username", "password");
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(new MemoryStream(), u);

            var configFilePath = "C:\\Documente\\GitHub\\proiect-csharp\\MPP_Csharp_Server_Client\\FlightServer\\CustomLogConfig.xml";
            var log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(configFilePath));

            var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            var log4NetXml = log4netConfig["MyCustomSetting"]["log4net"];
            log4net.Config.XmlConfigurator.Configure(repo, log4NetXml);

            //log4net.Config.XmlConfigurator.Configure();

        }
        
        static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

        private static void Main(string[] args)
        {
            SetupLogger();
           // IDictionary<String, string> props = new SortedList<String, String>();
            //props.Add("ConnectionString", GetConnectionStringByName("SqliteKey"));
            //myDBEntities dbContext = new myDBEntities();
            //UserRepository userRepository = new UserRepository(props);
            //ZborRepository zborRepository = new ZborRepository(props);
            //BiletRepository biletRepository = new BiletRepository(props);
            //BiletTuristRepository biletTuristiRepository = new BiletTuristRepository(props);

            UserRepository userRepository = new UserRepository();
            ZborRepository zborRepository = new ZborRepository();
            BiletRepository biletRepository = new BiletRepository();
           // BiletTuristiRepository biletTuristiRepository = new BiletTuristiRepository();
            var contextOptions  = new DbContextOptionsBuilder<DBContext>()
                .UseSqlite("Data Source=C:\\Users\\40771\\RiderProjects\\MPP_CSHarp_Interfata\\zboruri.db")
                .Options;
            var context = new DBContext(contextOptions );

            IService serverImpl = new Service(context);
            
            AbstractServer server = new RpcConcurrentServer("127.0.0.1", 57777, serverImpl);
            server.Start();
            Console.WriteLine("Server started ...");
            //Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();
        }
    }
}