using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookstore.Infrastructure;
using OnlineBookstore.Models;

namespace OnlineBookstore.Pages
{
    public class PurchaseModel : PageModel
    {
        private IOnlineBookstoreRepository repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public PurchaseModel(IOnlineBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

        }

        public IActionResult OnPost(int bookID, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookID);

            basket.AddItem(b, 1);


            return RedirectToPage(new { ReturnUrl = returnUrl });

        }

        public IActionResult OnPostRemove(int bookID, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookID).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

    }
}
