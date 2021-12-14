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
    public class CategoryController : ControllerAdmin
    {
        public CategoryController(ILogger<CategoryController> logger): base()
        {

        }
        public async Task<IActionResult> Index()
        {
            
            var response = await _httpclient.GetAsync("/api/Categories/getall");
            var responseContent = await response.Content.ReadAsStringAsync();
            var categoryList = JsonConvert.DeserializeObject<List<Category>>(responseContent);

            var adress = new HttpClient { BaseAddress = new Uri("http://localhost:14701") };

            var result = await _httpclient.PostAsync("/api/Categories/add", new StringContent(JsonConvert.SerializeObject(adress)));
            var resultContent = await result.Content.ReadAsStringAsync();

            return View(categoryList);
        }
    }
}
