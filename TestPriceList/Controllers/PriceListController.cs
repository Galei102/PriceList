using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TestPriceList.Data;
using TestPriceList.Models;
using TestPriceList.ViewModels;

namespace TestPriceList.Controllers
{
    public class PriceListController : Controller
    {
        private readonly Db db;

        public PriceListController(Db _db)
        {
            db = _db;
        }

        public IActionResult Index(List<PriceList> pricesList) 
        {
            pricesList = db.PricesList.ToList();
            return View(pricesList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PriceListViewModel model, int? id)
        {
            if (ModelState.IsValid)
            {
                var priceList = new PriceList
                {
                    Name = model.Name
                };
                db.PricesList.Add(priceList);
                db.SaveChanges();               
                if (model.Columns != null)
                {
                    var columns = new List<Column>();
                    foreach (var columnViewModel in model.Columns)
                    {
                        var column = new Column
                        {
                            Name = columnViewModel.Name,
                            Types = columnViewModel.Types,
                            PriceListId = priceList.Id
                        };
                        columns.Add(column);
                    }
                    db.Columns.AddRange(columns);
                    db.SaveChanges();
                }
                id = priceList.Id;
                ViewBag.PriceListId = priceList.Name;
                return RedirectToAction("Create", "Tovars", new {id});
            }
            return View(model);
        }
    }
}
