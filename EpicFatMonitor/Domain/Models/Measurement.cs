using System;
using System.Runtime.Serialization;

namespace EpicFatMonitor.Domain.Models
{
    public class Measurement
    {
        public virtual int Id { get; set; }
        
        public virtual User User { get; set; }

        public virtual DateTime Time { get; set; }
        public virtual double Weight { get; set; }
    }
}