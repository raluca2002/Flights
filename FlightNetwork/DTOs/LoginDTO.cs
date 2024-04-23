using System;

namespace FlightNetwork.DTOs
{
    [Serializable]
    public class LoginDTO
    {
        public string username
        {
            get;
            set;
        }
       public string password { get; set; }

        public LoginDTO(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}