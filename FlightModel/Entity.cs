using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPP_Csharp_Server_Client.FlightModel.domain
{
    [Serializable]
    public abstract class Entity<ID>
    {
        public ID id { get; set;}

        public Entity(ID newId)
        {
            id = newId;
        }

        public abstract string to_string();
    }
}