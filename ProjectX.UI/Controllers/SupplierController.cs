using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.UI.Controllers
{
    public class SupplierController : ControllerAdmin
    {
        public SupplierController() : base()
        {

        }
        public async Task<IActionResult> Index()
        {

            var response = await _httpclient.GetAsync("/api/Suppliers/getall");
            var responseContent = await response.Content.ReadAsStringAsync();
            var supplierList = JsonConvert.DeserializeObject<List<Supplier>>(responseContent);

            var address = new HttpClient { BaseAddress = new Uri("http://localhost:14701") };

            var result = await _httpclient.PostAsync("/api/Suppliers/add", new StringContent(JsonConvert.SerializeObject(address)));
            var resultContent = await result.Content.ReadAsStringAsync();

            return View(supplierList);
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
        public async Task<IActionResult> Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _httpclient.PostAsync("/api/Suppliers/add", new StringContent(JsonConvert.SerializeObject(new Supplier()
                    {
                        Name = supplier.Name, Address = supplier.Address, PhoneNumber = supplier.PhoneNumber, 
                        Email = supplier.Email, Status = supplier.Status,  CityId = supplier.CityId,
                    }), Encoding.UTF8, "application/json"));
                    var resultContent = await result.Content.ReadAsStringAsync();

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "Yanlış { ex.Message}");
                }
            }
            ModelState.AddModelError(string.Empty, "Yanlış");
            return View(supplier);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var response = await _httpclient.GetAsync("/api/Suppliers/getbyid/?id=" + id);
            var responseContent = await response.Content.ReadAsStringAsync();
            var supplier = JsonConvert.DeserializeObject<Supplier>(responseContent);

            var response2 = await _httpclient.GetAsync("/api/Cities/getall");
            var responseContent2 = await response2.Content.ReadAsStringAsync();
            var cities = JsonConvert.DeserializeObject<List<City>>(responseContent2);
            ViewBag.CityList = new SelectList(cities, "Id", "Name", supplier.CityId);

            return View(supplier);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Supplier supplier)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _httpclient.PutAsync("/api/Suppliers/put", new StringContent(JsonConvert.SerializeObject(supplier), Encoding.UTF8, "application/json"));
                    var resultContent = await result.Content.ReadAsStringAsync();

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "Yanlış { ex.Message}");
                }
            }
            ModelState.AddModelError(string.Empty, "Yanlış");
            return View(supplier);
        }

      
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _httpclient.DeleteAsync("/api/Suppliers/delete/?id=" + id);
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