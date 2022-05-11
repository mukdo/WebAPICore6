using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace WebAPICore6.Controllers
{
    public class TestController : Controller
    {
        // GET: TestController
        public ActionResult Index()
        {
            const string _apiUrl = "https://localhost:7261/api/Note";
            List<Notepad> notepad = new List<Notepad>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_apiUrl);
            request.Timeout = 100000;
            request.Method = "GET";
            request.ContentType = "application/json";

            try
            {
                using (var res = (HttpWebResponse)request.GetResponse())
                {
                    using (var stream = res.GetResponseStream())
                    {
                        var reader = new StreamReader(stream);
                        var response = reader.ReadToEnd();
                        notepad = JsonConvert.DeserializeObject<List<Notepad>>(response);
                    }
                }
                return View(notepad);
            }
            catch
            {
                return View();
            }
           
        }

        // GET: TestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
