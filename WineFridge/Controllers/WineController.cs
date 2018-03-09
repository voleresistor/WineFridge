using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WineFridge.Data;
using WineFridge.Models;
using WineFridge.ViewModels;

namespace WineFridge.Controllers
{
    public class WineController : Controller
    {
        private WineDbContext context;

        public WineController(WineDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            IList<Wine> wines = context.Wines.Where(w => w.InStock == true).ToList();

            return View(wines);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new AddWineViewModel());
        }

        [HttpPost]
        public IActionResult Add(AddWineViewModel newWineModel)
        {
            if (ModelState.IsValid)
            {
                Wine newWine = new Wine
                {
                    Name = newWineModel.Name,
                    Description = newWineModel.Description,
                    Notes = newWineModel.Notes,
                    InStock = true
                };

                context.Wines.Add(newWine);
                context.SaveChanges();

                return Redirect("/Wine");
            }

            return View(newWineModel);
        }

        [HttpGet]
        public IActionResult ViewWine(int id)
        {
            // Get wine from database by ID
            // Wine viewWine = context.Wines.SingleOrDefault(w => w.ID == id)
            return View();
        }
    }
}