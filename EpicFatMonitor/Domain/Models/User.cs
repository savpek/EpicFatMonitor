using System.Collections.Generic;

namespace EpicFatMonitor.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public List<Measurement> MesMeasurements {get; set; }
    }
}