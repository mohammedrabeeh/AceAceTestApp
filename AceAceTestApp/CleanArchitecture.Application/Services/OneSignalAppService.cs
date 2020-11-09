using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class OneSignalAppService : IOneSignalAppService
    {
        public IOneSignalAppRepository _oneSignalAppRepository;
        public OneSignalAppService(IOneSignalAppRepository oneSignalRepository)
        {
            _oneSignalAppRepository = oneSignalRepository;
        }

        public void CreateApp(OneSignalApp OneSignalApps)
        {
            _oneSignalAppRepository.CreateApp(OneSignalApps);
        }

        public void UpdateApp(OneSignalApp OneSignalApps)
        {
            _oneSignalAppRepository.UpdateApp(OneSignalApps);
        }

        public async Task<OneSignalAppListViewModel> ViewAllApps()
        {
            return new OneSignalAppListViewModel()
            {
                OneSignalApps = await _oneSignalAppRepository.ViewAllApps()
            };
        }

        public async Task<OneSignalAppViewModel> ViewApp(string id)
        {
            return new OneSignalAppViewModel()
            {
                OneSignalApps = await _oneSignalAppRepository.ViewApp(id)
            };
        }
    }
}
