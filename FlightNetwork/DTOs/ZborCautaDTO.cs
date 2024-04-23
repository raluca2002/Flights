using System;

namespace FlightNetwork.DTOs
{
    [Serializable]
    public class ZborCautaDTO
    {
        public string destination { get; set; }
        public DateTime departureDateTime { get; set; }

        public ZborCautaDTO(string destination, DateTime departureDateTime)
        {
            this.destination = destination;
            this.departureDateTime = departureDateTime;
        }
    }
}