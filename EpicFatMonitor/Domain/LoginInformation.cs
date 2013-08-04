using System;
using System.Collections.Generic;
using EpicFatMonitor.Domain.Models;

namespace EpicFatMonitor.Domain
{
    public class LoginInformation : ILoginInformation
    {
        public User CurrentUser()
        {
            var user = new User { Email = "savolainen.pekka@gmail.com", Measurements = new List<Measurement>() };
            user.AddMeasurement(new Measurement { Time = DateTime.Now, Weight = 120 });
            user.AddMeasurement(new Measurement { Time = DateTime.Now.AddDays(-1), Weight = 119.5 });
            user.AddMeasurement(new Measurement { Time = DateTime.Now.AddDays(-2), Weight = 119.2 });

            return user;
        }
    }
}