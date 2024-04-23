using System;
using System.Data.SqlClient;

namespace Incercare.domain
{
    public class User: Entity<int>
    {
        public string username { get; set; }
        public string password { get; set; }

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