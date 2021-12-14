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
    public class UnitController:ControllerAdmin
    {
        public UnitController() : base()
        {

        }
        public async Task<IActionResult> Index()
        {

            var response = await _httpclient.GetAsync("/api/Units/getall");
            var responseContent = await response.Content.ReadAsStringAsync();
            var unitList = JsonConvert.DeserializeObject<List<Unit>>(responseContent);

            var adress = new HttpClient { BaseAddress = new Uri("http://localhost:14701") };

            var result = await _httpclient.PostAsync("/api/Units/add", new StringContent(JsonConvert.SerializeObject(adress)));
            var resultContent = await result.Content.ReadAsStringAsync();

            return View(unitList);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}