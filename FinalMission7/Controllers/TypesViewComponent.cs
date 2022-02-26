using FinalMission7.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalMission7.Controllers
{
    public class TypesViewComponent :ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        public TypesViewComponent (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            var types = repo.Books
                .Select(x => x.Classification)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }


    }
}
