using System.Collections.Generic;

namespace EpicFatMonitor.Domain.Models
{
    public class User
    {
        public User()
        {
            Measurements = new List<Measurement>();
        }

        public virtual string Email { get; set; }
        public virtual IList<Measurement> Measurements { get; set; }

        public virtual void AddMeasurement(Measurement measurement)
        {
            measurement.User = this;
            Measurements.Add(measurement);
        }
    }
}