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
    public class CategoryController : ControllerAdmin
    {
        public CategoryController(): base()
        {

        }
        public async Task<IActionResult> Index()
        {
            
            var response = await _httpclient.GetAsync("/api/Categories/getall");
            var responseContent = await response.Content.ReadAsStringAsync();
            var categoryList = JsonConvert.DeserializeObject<List<Category>>(responseContent);

            var address = new HttpClient { BaseAddress = new Uri("http://localhost:14701") };

            var result = await _httpclient.PostAsync("/api/Categories/add", new StringContent(JsonConvert.SerializeObject(address)));
            var resultContent = await result.Content.ReadAsStringAsync();

            return View(categoryList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _httpclient.PostAsync("/api/Categories/add", new StringContent(JsonConvert.SerializeObject(new Category() { Name = category.Name }), Encoding.UTF8, "application/json"));
                    var resultContent = await result.Content.ReadAsStringAsync();

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "Yanlış { ex.Message}");
                }
            }
            ModelState.AddModelError(string.Empty, "Yanlış");
            return View(category);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _httpclient.PutAsync("/api/Categories/put", new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json"));
                    var resultContent = await result.Content.ReadAsStringAsync();

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "Yanlış { ex.Message}");
                }
            }
            ModelState.AddModelError(string.Empty, "Yanlış");
            return View(category);
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
                    var result = await _httpclient.DeleteAsync("/api/Categories/delete/?id=" + id);
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
