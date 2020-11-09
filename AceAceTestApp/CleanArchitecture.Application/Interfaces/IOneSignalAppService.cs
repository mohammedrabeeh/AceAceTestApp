using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IOneSignalAppService
    {
        public Task<OneSignalAppListViewModel> ViewAllApps();
        public Task<OneSignalAppViewModel> ViewApp(string id);
        public void CreateApp(OneSignalApp OneSignalApps);
        public void UpdateApp(OneSignalApp OneSignalApps);
    }
}
