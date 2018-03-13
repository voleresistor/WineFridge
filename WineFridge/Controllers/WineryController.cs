using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WineFridge.Data;
using WineFridge.Models;
using WineFridge.ViewModels;

namespace WineFridge.Controllers
{
    public class WineryController : Controller
    {
        private WineDbContext context;

        public WineryController(WineDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            IList<Winery> wineries = context.Wineries.ToList();
            IList<WineryViewModel> wineriesVm = new List<WineryViewModel>();

            foreach (Winery w in wineries)
            {
                wineriesVm.Add(new WineryViewModel
                {
                    Name = w.Name,
                    Address = w.Address,
                    WineryID = w.ID
                });
            }
            return View(wineriesVm);
        }

        public IActionResult Add()
        {
            return View(new WineryViewModel());
        }

        [HttpPost]
        public IActionResult Add(WineryViewModel nw)
        {
            if (ModelState.IsValid)
            {
                Winery newWinery = new Winery
                {
                    Name = nw.Name,
                    Address = nw.Address,
                    Phone = nw.Phone,
                    Email = nw.Email,
                    Website = nw.Website,
                    Notes = nw.Notes
                };

                if (!newWinery.Website.StartsWith("http://") || !newWinery.Website.StartsWith("https://"))
                {
                    newWinery.Website = "http://" + newWinery.Website;
                }

                context.Wineries.Add(newWinery);
                context.SaveChanges();

                return Redirect("/Winery");
            }

            return View(nw);
        }

        public IActionResult ViewWinery(int id)
        {
            Winery winery = context.Wineries.Single(w => w.ID == id);
            List<Wine> wines = context.Wines.Where(w => w.WineryID == id).ToList();
            WineryViewModel wvm = new WineryViewModel
            {
                WineryID = id,
                Name = winery.Name,
                Address = winery.Address,
                Phone = winery.Phone,
                Email = winery.Email,
                Website = winery.Website,
                Notes = winery.Notes
            };

            return View(wvm);
        }
    }
}