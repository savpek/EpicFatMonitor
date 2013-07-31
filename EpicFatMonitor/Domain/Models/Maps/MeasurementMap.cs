using FluentNHibernate.Mapping;

namespace EpicFatMonitor.Domain.Models.Maps
{
    public class MeasurementMap : ClassMap<Measurement>
    {
        public MeasurementMap()
        {
            Id(x => x.Id);
            Map(x => x.Time);
            Map(x => x.Weight);
        }
    }
}