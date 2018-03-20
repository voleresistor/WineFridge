using System.Collections.Generic;
using System.Linq;
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
                    Description = wt.Description,
                    TypeID = wt.ID
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

        public IActionResult Edit(int id)
        {
            WineType wineType = context.WineTypes.SingleOrDefault(wt => wt.ID == id);

            if (wineType != null)
            {
                WineTypeViewModel wt = new WineTypeViewModel
                {
                    Name = wineType.Name,
                    Description = wineType.Description,
                    TypeID = wineType.ID
                };

                return View(wt);
            }

            return Redirect("/WineType");
        }

        [HttpPost]
        public IActionResult Edit (WineTypeViewModel wineType)
        {
            if (ModelState.IsValid)
            {
                WineType editType = context.WineTypes.SingleOrDefault(wt => wt.ID == wineType.TypeID);
                if (editType != null)
                {
                    editType.Name = wineType.Name;
                    editType.Description = wineType.Description;

                    context.SaveChanges();
                    return Redirect("/WineType/ViewType/" + wineType.TypeID);
                };
            }

            return View(wineType);
        }

        public IActionResult ViewType(int id)
        {
            WineType wineType = context.WineTypes.SingleOrDefault(wt => wt.ID == id);

            if (wineType != null)
            {
                WineTypeViewModel wt = new WineTypeViewModel
                {
                    Name = wineType.Name,
                    Description = wineType.Description,
                    TypeID = wineType.ID
                };

                return View(wt);
            }

            return Redirect("/WineType");
        }

        public IActionResult WinesOfThisType(int id)
        {
            WineType wineType = context.WineTypes.SingleOrDefault(wt => wt.ID == id);

            if (wineType != null)
            {
                List<Wine> wineList = context.Wines.Where(w => w.TypeID == id).ToList();
                WineListViewModel wines = new WineListViewModel(wineList, wineType);
                return View(wines);
            }

            return Redirect("/WineType");
        }

        public IActionResult Remove(int id)
        {
            WineType wineType = context.WineTypes.SingleOrDefault(wt => wt.ID == id);

            if (wineType != null)
            {
                context.WineTypes.Remove(wineType);
                context.SaveChanges();

                return Redirect("/WineType");
            }

            return Redirect("/WineType/ViewType/" + id);
        }
    }
}