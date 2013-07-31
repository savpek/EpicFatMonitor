using System;

namespace EpicFatMonitor.Domain.Models
{
    public class Measurement
    {
        public virtual int Id { get; set; }
        public virtual DateTime Time { get; set; }
        public virtual float Weight { get; set; }
    }
}