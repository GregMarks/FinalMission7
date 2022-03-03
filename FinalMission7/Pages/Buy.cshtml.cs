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
        public BuyModel (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet (string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(string isbn, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.Isbn == isbn);

            basket = HttpContext.Session.GetJson<Basket>("Basket") ?? new Basket();
            basket.AddItem(b, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
