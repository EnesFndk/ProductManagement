using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProjectX.UI.Controllers
{
    public class ControllerAdmin : Controller
    {
        protected readonly HttpClient _httpclient;

        public ControllerAdmin()
        {

            _httpclient = new HttpClient();
            _httpclient.BaseAddress = new Uri("http://localhost:56715");
            _httpclient.DefaultRequestHeaders.Accept.Clear();
            _httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //Logger'ı burda yaptığımızda kendini tekrarlıyor o sebeple logger'ı controller'ların içerisinde yapmak gerekli. 
        //protected readonly ILogger<***Controller> _logger; deyip constructor oluşturduktan sonra onu dependency injection eşitliyoruz. _logger = logger; sonra controller'da kullanabiliriz.
        //public SupplierController(ILogger<SupplierController> logger) : base(logger)
    }
}
