using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectX.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.UI.Controllers
{
    public class BrandController : ControllerAdmin
    {
        

        public BrandController() : base()
        {
            
        }

        public async Task<IActionResult> IndexAsync()
        {
   
            //ui 'ı ayağa kaldırmak için multiple startup projects ile api tarafını ve ui tarafını çalıştırmamız lazım Daha sonra zaten view tarafında direk çekebiliyoruz.

            //get
            var response = await _httpclient.GetAsync("/api/Brands/getall");
            var responseContent = await response.Content.ReadAsStringAsync();
            var brandList = JsonConvert.DeserializeObject<List<Brand>>(responseContent);

            //post
            var adress = new HttpClient { BaseAddress = new Uri("http://localhost:14701") };

            var result = await _httpclient.PostAsync("/api/Brands/add", new StringContent(JsonConvert.SerializeObject(adress))); //, Encoding.UTF8, "application/json" address'den sonra eklersen bunu otomatik ekleme oluyor.
            var resultContent = await result.Content.ReadAsStringAsync();

            return View(brandList);
        }


    }
}
