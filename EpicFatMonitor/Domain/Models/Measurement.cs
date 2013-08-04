using System;
using System.Runtime.Serialization;

namespace EpicFatMonitor.Domain.Models
{
    public class Measurement
    {
        [IgnoreDataMember]
        public virtual int Id { get; set; }
        
        [IgnoreDataMember]
        public virtual User User { get; set; }

        public virtual DateTime Time { get; set; }
        public virtual double Weight { get; set; }
    }
}