using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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


            //get
            var response = await _httpclient.GetAsync("/api/Brands/getall");
            var responseContent = await response.Content.ReadAsStringAsync();
            var brandList = JsonConvert.DeserializeObject<List<Brand>>(responseContent);

            //post
            var address = new HttpClient { BaseAddress = new Uri("http://localhost:14701") };

            var result = await _httpclient.PostAsync("/api/Brands/add", new StringContent(JsonConvert.SerializeObject(address))); 

            return View(brandList);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _httpclient.PostAsync("/api/Brands/add", new StringContent(JsonConvert.SerializeObject(new Brand() { Name = brand.Name}), Encoding.UTF8, "application/json")); 
                    var resultContent = await result.Content.ReadAsStringAsync();

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "Yanlış { ex.Message}");
                }
            }
            ModelState.AddModelError(string.Empty, "Yanlış");
            return View(brand);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _httpclient.PutAsync("/api/Brands/put", new StringContent(JsonConvert.SerializeObject(brand), Encoding.UTF8, "application/json"));
                    var resultContent = await result.Content.ReadAsStringAsync();

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "Yanlış { ex.Message}");
                }
            }
            ModelState.AddModelError(string.Empty, "Yanlış");
            return View(brand);
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _httpclient.DeleteAsync("/api/Brands/delete/?id=" + id);
                    result.EnsureSuccessStatusCode();

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "Yanlış { ex.Message}");
                }
            }
            ModelState.AddModelError(string.Empty, "Yanlış");
            return View(id);
        }
    }
}
