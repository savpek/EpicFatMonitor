using FluentNHibernate.Mapping;

namespace EpicFatMonitor.Domain.Models.Maps
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.Email);
            HasMany(x => x.Measurements).Cascade.All();
        }
    }
}