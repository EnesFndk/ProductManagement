using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

            var address = new HttpClient { BaseAddress = new Uri("http://localhost:14701") };

            var result = await _httpclient.PostAsync("/api/Units/add", new StringContent(JsonConvert.SerializeObject(address)));
            var resultContent = await result.Content.ReadAsStringAsync();

            return View(unitList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Unit unit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _httpclient.PostAsync("/api/Units/add", new StringContent(JsonConvert.SerializeObject(new Unit()
                    {
                        Name = unit.Name
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
            return View(unit);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Unit unit)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _httpclient.PutAsync("/api/Units/put", new StringContent(JsonConvert.SerializeObject(unit), Encoding.UTF8, "application/json"));
                    var resultContent = await result.Content.ReadAsStringAsync();

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "Yanlış { ex.Message}");
                }
            }
            ModelState.AddModelError(string.Empty, "Yanlış");
            return View(unit);
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
                    var result = await _httpclient.DeleteAsync("/api/Units/delete/?id=" + id);
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