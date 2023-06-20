using AJAX.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AJAX.Controllers
{
    public class AjaxController : Controller
    {
        private readonly NorthwindContext _db;
        public AjaxController(NorthwindContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JavaScriptGreet()
        {
            return View();
        }
        public IActionResult jQueryGreet()
        {
            return View();
        }
        public IActionResult FetchGreet()
        {
            return View();
        }
        public IActionResult JavaScriptGreetCheckName()
        {
            return View();
        }
        public IActionResult jQueryCheckName()
        {
            return View();
        }
        public IActionResult FetchCheckName()
        {
            return View();
        }
        //動詞HttpGet、HttpPost和Action 要其中一個不同
        [HttpGet]
        public string Greet(string Name)
        {
            //延遲
            Thread.Sleep(3000);
            return $"Hello:{Name}";
        }
        [HttpPost,ActionName("Greet")]
        public string PostGreet(string Name)
        {
            Thread.Sleep(3000);
            return $"Hello:{Name}";
        }
        [HttpPost]
        public string FetchPostGreet([FromBody]Parameter p) 
        {
            Thread.Sleep(3000);

            return $"Hello:{p.Name}";

        }
        [HttpPost]
        public string CheckName(string FirstName)
        {
            bool Exists=_db.Employees.Any(x => x.FirstName == FirstName);
            return Exists ? "true" : "false";
        }
        [HttpPost]
        public string FetchCheckName([FromBody]Employees p)
        {
            bool Exists = _db.Employees.Any(x => x.FirstName == p.FirstName);
            return Exists ? "true" : "false";
        }
    }
}
