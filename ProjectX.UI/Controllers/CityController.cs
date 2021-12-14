using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectX.UI.Controllers
{
    public class CityController : ControllerAdmin
    {
        public CityController() : base()
        {

        }
        public async Task<IActionResult> Index()
        {
            var response = await _httpclient.GetAsync("/api/Cities/getall");
            var responseContent = await response.Content.ReadAsStringAsync();
            var cityList = JsonConvert.DeserializeObject<List<City>>(responseContent);

            //post
            var adress = new HttpClient { BaseAddress = new Uri("http://localhost:14701") };

            var result = await _httpclient.PostAsync("/api/Cities/add", new StringContent(JsonConvert.SerializeObject(adress))); //, Encoding.UTF8, "application/json" address'den sonra eklersen bunu otomatik ekleme oluyor.
            var resultContent = await result.Content.ReadAsStringAsync();

            return View(cityList);
        }
    }

}
