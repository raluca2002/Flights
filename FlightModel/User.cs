using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace MPP_Csharp_Server_Client.FlightModel.domain
{
    [Serializable]
    
    public class User: Entity<int>
    {
        
        public string username { get; set; }
        
        public string password { get; set; }

        public User(): base(-1)
        {
            
        }
        public User(int newId, string username, string password) : base(newId)
        {
            this.username = username;
            this.password = password;
        }

        public override string to_string()
        {
            return username + password;
        }
        
    }
}