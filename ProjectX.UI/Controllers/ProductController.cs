using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectX.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.UI.Controllers
{
    public class ProductController:ControllerAdmin
    {
        public ProductController() : base()
        {

        }
        public async Task<IActionResult> Index()
        {
            var response = await _httpclient.GetAsync("/api/Products/getall");
            var responseContent = await response.Content.ReadAsStringAsync();
            var productList = JsonConvert.DeserializeObject<List<Product>>(responseContent);

            var address = new HttpClient { BaseAddress = new Uri("http://localhost:14701") };

            var result = await _httpclient.PostAsync("/api/Products/add", new StringContent(JsonConvert.SerializeObject(address)));
            var resultContent = await result.Content.ReadAsStringAsync();

            return View(productList);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var response = await _httpclient.GetAsync("/api/Cities/getall");
            var responseContent = await response.Content.ReadAsStringAsync();
            var cities = JsonConvert.DeserializeObject<List<City>>(responseContent);
            ViewBag.CityList = new SelectList(cities, "Id", "Name"); 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _httpclient.PostAsync("/api/Products/add", new StringContent(JsonConvert.SerializeObject(new Product() 
                    { Name = product.Name, Price = product.Price, Stock = product.Stock, 
                      Description = product.Description, Image = product.Image, Status = product.Status,
                      CategoryId = product.CategoryId, BrandId = product.BrandId, UnitId = product.UnitId }), Encoding.UTF8, "application/json"));
                    var resultContent = await result.Content.ReadAsStringAsync();

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "Yanlış { ex.Message}");
                }
            }
            ModelState.AddModelError(string.Empty, "Yanlış");
            return View(product);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _httpclient.PutAsync("/api/Products/put", new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json"));
                    var resultContent = await result.Content.ReadAsStringAsync();

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "Yanlış { ex.Message}");
                }
            }
            ModelState.AddModelError(string.Empty, "Yanlış");
            return View(product);
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
                    var result = await _httpclient.DeleteAsync("/api/Products/delete/?id=" + id);
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