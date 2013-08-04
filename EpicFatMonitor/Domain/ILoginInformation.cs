using EpicFatMonitor.Domain.Models;

namespace EpicFatMonitor.Domain
{
    public interface ILoginInformation
    {
        User CurrentUser();
    }
}