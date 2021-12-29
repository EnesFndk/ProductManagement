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

            var address = new HttpClient { BaseAddress = new Uri("http://localhost:14701") };

            var result = await _httpclient.PostAsync("/api/Users/add", new StringContent(JsonConvert.SerializeObject(address)));
            var resultContent = await result.Content.ReadAsStringAsync();

            return View(userList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _httpclient.PostAsync("/api/Users/add", new StringContent(JsonConvert.SerializeObject(new User()
                    {
                        FirstName = user.FirstName, LastName = user.LastName, Mail = user.Mail, Status = user.Status
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
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _httpclient.PutAsync("/api/Users/put", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
                    var resultContent = await result.Content.ReadAsStringAsync();

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "Yanlış { ex.Message}");
                }
            }
            ModelState.AddModelError(string.Empty, "Yanlış");
            return View(user);
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
                    var result = await _httpclient.DeleteAsync("/api/Users/delete/?id=" + id);
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