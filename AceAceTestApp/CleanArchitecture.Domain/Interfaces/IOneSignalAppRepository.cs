using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IOneSignalAppRepository
    {
        Task<IEnumerable<OneSignalApp>> ViewAllApps();
        Task<OneSignalApp> ViewApp(string id);
        void CreateApp(OneSignalApp oneSignalApp);
        void UpdateApp(OneSignalApp oneSignalApp);
    }
}
