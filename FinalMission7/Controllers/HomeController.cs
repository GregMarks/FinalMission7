using FinalMission7.models;
using FinalMission7.Models;
using FinalMission7.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
namespace FinalMission7.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;
        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }
        
        public IActionResult Index(string Category, int pageNum = 1)
        {
            int pageSize = 5;
            //It looks like for some reason when I try to actually use this, it just steps right through. It doesn't even stop. Not quite sure why.... This makes it so the filter by book category doesn't 
            // by book category doesn't actually work.
            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(c => c.Category == Category || Category == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum

                }
            };
            return View(x);
        }
    }
}
