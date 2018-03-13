using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
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
            IList<WineViewModel> winesVm = new List<WineViewModel>();

            foreach (Wine w in wines)
            {
                winesVm.Add(new WineViewModel
                {
                    WineID = w.ID,
                    Name = w.Name,
                    Description = w.Description,
                    Notes = w.Notes,
                    Winery = context.Wineries.Single(wn => wn.ID == w.WineryID),
                    Type = context.WineTypes.Single(t => t.ID == w.TypeID),
                    Rating = w.Rating,
                    Count = w.Count,
                    InStock = w.InStock
                });
            }

            return View(winesVm);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new WineViewModel(context.Wineries.ToList(), context.WineTypes.ToList()));
        }

        [HttpPost]
        public IActionResult Add(WineViewModel newWineModel)
        {
            if (ModelState.IsValid)
            {
                Wine newWine = new Wine
                {
                    Name = newWineModel.Name,
                    Description = newWineModel.Description,
                    Notes = newWineModel.Notes,
                    Rating = newWineModel.Rating,
                    WineryID = newWineModel.WineryID,
                    TypeID = newWineModel.TypeID,
                    InStock = false
                };

                context.Wines.Add(newWine);
                context.SaveChanges();

                return Redirect("/Wine");
            }

            return View(newWineModel);
        }

        public IActionResult Edit(int id)
        {
            Wine editWine = context.Wines.SingleOrDefault(w => w.ID == id);
            WineViewModel wine = new WineViewModel(context.Wineries.ToList(), context.WineTypes.ToList())
            {
                WineID = editWine.ID,
                Name = editWine.Name,
                Description = editWine.Description,
                Notes = editWine.Notes,
                Winery = context.Wineries.Single(wn => wn.ID == editWine.WineryID),
                Type = context.WineTypes.Single(t => t.ID == editWine.TypeID),
                Rating = editWine.Rating,
                Count = editWine.Count,
                InStock = editWine.InStock
            };

            return View(wine);
        }

        [HttpPost]
        public IActionResult Edit(WineViewModel editedWine)
        {
            if (ModelState.IsValid)
            {
                Wine wine = context.Wines.SingleOrDefault(w => w.ID == editedWine.WineID);
                if (wine != null)
                {
                    wine.Name = editedWine.Name;
                    wine.Description = editedWine.Description;
                    wine.Notes = editedWine.Notes;
                    wine.WineryID = editedWine.WineryID;
                    wine.TypeID = editedWine.TypeID;
                    wine.Rating = editedWine.Rating;

                    context.SaveChanges();
                }

                return Redirect("/Wine/ViewWine/" + wine.ID);
            }
            return View(editedWine);
        }

        [HttpGet]
        public IActionResult ViewWine(int id)
        {
            // Get wine from database by ID
            Wine wine = context.Wines.SingleOrDefault(w => w.ID == id);
            WineViewModel viewWine = new WineViewModel
            {
                WineID = wine.ID,
                Name = wine.Name,
                Description = wine.Description,
                Notes = wine.Notes,
                Winery = context.Wineries.Single(w => w.ID == wine.WineryID),
                Type = context.WineTypes.Single(t => t.ID == wine.TypeID),
                Rating = wine.Rating,
                Count = wine.Count,
                InStock = wine.InStock
            };

            TryValidateModel(viewWine);
            if (ModelState.IsValid)
            {
                return View(viewWine);
            }
            return Redirect("/Wine");
        }

        public IActionResult ViewAll()
        {
            IList<Wine> wines = context.Wines.ToList();
            IList<WineViewModel> winesVm = new List<WineViewModel>();

            foreach (Wine w in wines)
            {
                winesVm.Add(new WineViewModel
                {
                    WineID = w.ID,
                    Name = w.Name,
                    Description = w.Description,
                    Notes = w.Notes,
                    Winery = context.Wineries.Single(wn => wn.ID == w.WineryID),
                    Type = context.WineTypes.Single(t => t.ID == w.TypeID),
                    Rating = w.Rating,
                    Count = w.Count,
                    InStock = w.InStock
                });
            }

            return View(winesVm);
        }

        public IActionResult AddBottle()
        {
            List<Wine> wineList = context.Wines.ToList();
            return View(new AddBottleViewModel(wineList));
        }

        [HttpPost]
        public IActionResult AddBottle(AddBottleViewModel addTo)
        {
            Wine wine = context.Wines.SingleOrDefault(w => w.ID == addTo.WineID);
            if (wine != null)
            {
                wine.Count += 1;

                if (!wine.InStock)
                {
                    wine.InStock = true;
                }

                context.SaveChanges();

                return Redirect("/Wine");
            }

            return View();
        }

        public IActionResult WinesFromThisWinery(int id)
        {
            List<Wine> wineList = context.Wines.Where(w => w.WineryID == id).ToList();
            Winery winery = context.Wineries.SingleOrDefault(wn => wn.ID == id);

            WinesFromThisWineryViewModel wines = new WinesFromThisWineryViewModel(wineList, winery);

            return View(wines);
        }
    }
}