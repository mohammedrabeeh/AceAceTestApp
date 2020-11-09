using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public class OneSignalAppRepository : IOneSignalAppRepository
    {
        public OneSignalAppRepository(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public IConfiguration Configuration { get; }

        public async void CreateApp(OneSignalApp oneSignalApp)
        {
            string strPayload = JsonConvert.SerializeObject(oneSignalApp);
            HttpContent appContent = new StringContent(strPayload, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Configuration.GetValue<string>("AuthScheme"), Configuration.GetValue<string>("AuthParam"));
                using (var response = await httpClient.PostAsync(Configuration.GetValue<string>("OneSignalEndPoint"), appContent))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if(response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        throw new Exception("Error!! Unable to create App!!");
                    }
                }
            }
        }

        public async void UpdateApp(OneSignalApp oneSignalApp)
        {
            string strPayload = JsonConvert.SerializeObject(oneSignalApp);
            HttpContent appContent = new StringContent(strPayload, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Configuration.GetValue<string>("AuthScheme"), Configuration.GetValue<string>("AuthParam"));
                using (var response = await httpClient.PutAsync(Configuration.GetValue<string>("OneSignalEndPoint") + "/" + oneSignalApp.id, appContent))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        throw new Exception("Error!! Unable to update App!!");
                    }
                }
            }
        }

        public async Task<IEnumerable<OneSignalApp>> ViewAllApps()
        {
            IEnumerable<OneSignalApp> appList;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Configuration.GetValue<string>("AuthScheme"), Configuration.GetValue<string>("AuthParam"));
                using (var response = await httpClient.GetAsync(Configuration.GetValue<string>("OneSignalEndPoint")))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    appList = JsonConvert.DeserializeObject<IEnumerable<OneSignalApp>>(apiResponse);
                }
            }
            return appList;

        }

        public async Task<OneSignalApp> ViewApp(string id)
        {
            OneSignalApp oneSignalApp;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Configuration.GetValue<string>("AuthScheme"), Configuration.GetValue<string>("AuthParam"));
                using (var response = await httpClient.GetAsync(Configuration.GetValue<string>("OneSignalEndPoint") + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    oneSignalApp = JsonConvert.DeserializeObject<OneSignalApp>(apiResponse);
                }
            }
            return oneSignalApp;
        }
    }
}
