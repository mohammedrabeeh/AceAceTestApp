using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.ViewModels
{
    public class OneSignalAppListViewModel
    {
        public IEnumerable<OneSignalApp> OneSignalApps { get; set; }
    }
}
