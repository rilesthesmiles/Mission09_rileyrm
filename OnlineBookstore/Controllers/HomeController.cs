using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Controllers
{

    public class HomeController : Controller
    {
        private IOnlineBookstoreRepository repo;

        public HomeController(IOnlineBookstoreRepository temp)
        {
            repo = temp;
        }
       
        public IActionResult Index()
        {
            var blah = repo.Books.ToList();
            return View(blah);
        }
    }
}
