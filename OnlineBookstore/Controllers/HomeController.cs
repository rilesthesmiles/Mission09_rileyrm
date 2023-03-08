using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Models;
using OnlineBookstore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Controllers
{

    public class HomeController : Controller
    {
        private IOnlineBookstoreRepository repo;

        //Using the repository instead of the context file driectly
        public HomeController(IOnlineBookstoreRepository temp)
        {
            repo = temp;
        }
       
        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 10;

            //Passing in both the info in the models as well as the page info
            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(p => p.Category == bookCategory || bookCategory == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {

                    TotalNumBooks = (bookCategory == null ? repo.Books.Count() : repo.Books.Where(x=>x.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum

                }
            };


            return View(x);
        }
    }
}
