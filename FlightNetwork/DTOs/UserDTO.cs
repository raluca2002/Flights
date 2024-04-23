using System;

namespace FlightNetwork.DTOs
{
    [Serializable]
    public class UserDTO
    {
        public int id { get; set; }
        public string password { get; set; }
        public string username { get; set; }

        public UserDTO(int id, string password, string username)
        {
            this.id = id;
            this.password = password;
            this.username = username;
        }
    }
}