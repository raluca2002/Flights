using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MPP_Csharp_Server_Client.FlightModel.domain;
using log4net;

namespace MPP_Csharp_Server_Client.FlightPersistence.repository
{
   /* public class UserRepositoryORM : Repository<int, User>
    {
        private static readonly ILog log = LogManager.GetLogger("UserRepository");
        private readonly myDBEntities context;

        public UserRepositoryORM(myDBEntities context)
        {
            log.Info("Creating UserRepository");
            this.context = context;
        }

        public List<User> findAll()
        {
            return context.Set<User>().ToList();
        }

        public User findOne(int id)
        {
            return context.Set<User>().Find(id);
        }

        public User findByName(string name)
        {
            return context.Set<User>().SingleOrDefault(u => u.username == name);
        }

        public User findByDestination(string destinatie, DateTime data)
        {
            // Implement your custom logic to find a user by destination and date
            throw new NotImplementedException();
        }

        public User save(User entity)
        {
            context.Set<User>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public User update(User entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }
    }*/
}