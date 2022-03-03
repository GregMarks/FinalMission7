using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalMission7.Infrastructure;
using FinalMission7.models;
using FinalMission7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalMission7.Pages
{
    public class BuyModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        public BuyModel (IBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet (string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            
        }

        public IActionResult OnPost(string isbn, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.Isbn == isbn);

            basket.AddItem(b, 1);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove (string Isbn, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.Isbn == Isbn).Book);
            return RedirectToPage( new { ReturnUrl = returnUrl });
        }
    }
}
