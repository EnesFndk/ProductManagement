using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectX.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectX.UI.Controllers
{
    public class CountryController: ControllerAdmin
    {
        public CountryController() : base()
        {

        }
        public async Task<IActionResult> Index()
        {

            var response = await _httpclient.GetAsync("/api/Countries/getall");
            var responseContent = await response.Content.ReadAsStringAsync();
            var countryList = JsonConvert.DeserializeObject<List<Country>>(responseContent);

            var adress = new HttpClient { BaseAddress = new Uri("http://localhost:14701") };

            var result = await _httpclient.PostAsync("/api/Countries/add", new StringContent(JsonConvert.SerializeObject(adress)));
            var resultContent = await result.Content.ReadAsStringAsync();

            return View(countryList);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}