using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WineFridge.Data;
using WineFridge.Models;
using WineFridge.ViewModels;

namespace WineFridge.Controllers
{
    public class WineTypeController : Controller
    {
        private WineDbContext context;

        public WineTypeController(WineDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            IList<WineType> wineTypes = context.WineTypes.ToList();
            IList<WineTypeViewModel> wineTypesVm = new List<WineTypeViewModel>();

            foreach (WineType wt in wineTypes)
            {
                wineTypesVm.Add(new WineTypeViewModel
                {
                    Name = wt.Name,
                    Description = wt.Description
                });
            }
            return View(wineTypesVm);
        }

        public IActionResult Add()
        {
            return View(new WineTypeViewModel());
        }

        [HttpPost]
        public IActionResult Add(WineTypeViewModel nt)
        {
            if (ModelState.IsValid)
            {
                WineType newType = new WineType
                {
                    Name = nt.Name,
                    Description = nt.Description
                };

                context.WineTypes.Add(newType);
                context.SaveChanges();

                return Redirect("/WineType");
            }

            return View(nt);
        }

        //TODO: Add view with list of associated wines
        //TODO: Add edit option
        //TODO: Add remove option
    }
}