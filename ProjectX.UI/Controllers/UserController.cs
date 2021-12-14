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
    public class UserController:ControllerAdmin
    {
        public UserController() : base()
        {

        }
        public async Task<IActionResult> Index()
        {

            var response = await _httpclient.GetAsync("/api/Users/getall");
            var responseContent = await response.Content.ReadAsStringAsync();
            var userList = JsonConvert.DeserializeObject<List<User>>(responseContent);

            var adress = new HttpClient { BaseAddress = new Uri("http://localhost:14701") };

            var result = await _httpclient.PostAsync("/api/Users/add", new StringContent(JsonConvert.SerializeObject(adress)));
            var resultContent = await result.Content.ReadAsStringAsync();

            return View(userList);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}