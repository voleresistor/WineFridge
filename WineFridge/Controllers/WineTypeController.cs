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
                    return Redirect("/WineType/View/" + wineType.TypeID);
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
            IList<Wine> wines = context.Wines.Where(w => w.TypeID == id).ToList();

            if (wineType != null)
            {

            }
        }

        //TODO: Add view with list of associated wines
        //TODO: Add edit option
        //TODO: Add remove option
    }
}