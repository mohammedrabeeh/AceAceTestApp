using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AceAceTestApp.MVC.Controllers
{
    [Authorize]
    public class OneSignalAppController : Controller
    {
        private IOneSignalAppService _OneSignalAppService;

        public OneSignalAppController(IOneSignalAppService oneSignalAppService)
        {
            _OneSignalAppService = oneSignalAppService;
        }
        public async Task<IActionResult> Index()
        {
            OneSignalAppListViewModel oneSignalApps = await _OneSignalAppService.ViewAllApps();
            return View(oneSignalApps);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OneSignalAppViewModel oneSignalAppViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _OneSignalAppService.CreateApp(oneSignalAppViewModel.OneSignalApps);
                    ViewData["Msg"] = "One Signal App Created Successfully!!!";
                }
                catch (Exception ex)
                {
                    ViewData["Msg"] = ex.Message;
                }
            }
            return View();
        }


        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(string id)
        {
            OneSignalAppViewModel oneSignalApps = await _OneSignalAppService.ViewApp(id);
            return View(oneSignalApps);
        }

        [HttpPost]
        public IActionResult Update(OneSignalAppViewModel oneSignalAppViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _OneSignalAppService.UpdateApp(oneSignalAppViewModel.OneSignalApps);
                    ViewData["Msg"] = "One Signal App Updated Successfully!!!";
                }
                catch (Exception ex)
                {
                    ViewData["Msg"] = ex.Message;
                }
            }
            return View();
        }
    }
}
