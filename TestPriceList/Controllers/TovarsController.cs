#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TestPriceList.Data;
using TestPriceList.Models;
using TestPriceList.ViewModels;

namespace TestPriceList.Controllers
{
    public class TovarsController : Controller
    {
        private readonly Db _context;

        public TovarsController(Db context)
        {
            _context = context;
        }


        public IActionResult Index(int id)
        {
            var priceList = _context.PricesList.FirstOrDefault(x => x.Id == id);
            if (priceList == null)
            {
                return NotFound();
            }
            var columns = _context.Columns.GroupBy(x => x.);
            var tovars = _context.Tovars.Include(t => t.Values).Where(t => t.PriceListId == id).ToList();
            var pricelistDetails = new PricelistDetailViewModel
            {
                
                Tovars = tovars,               
            };     
            ViewData["Message"] = priceList.Name;
            ViewBag.PriceListId = id;
            return View(pricelistDetails);
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            var columns = _context.Columns.Where(p => p.PriceListId == id).ToList();
            ColumnTovarViewModel model = new ColumnTovarViewModel
            {
                Columns = columns
            };                                 
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ColumnTovarViewModel model, int? id)
        {
            var tovar = new Tovar
            {
                Name = model.AddTovarValueColumn.TovarName,
                KodTovar = model.AddTovarValueColumn.KodTovar,
                PriceListId = (int)id
            };
            _context.Tovars.Add(tovar);
            _context.SaveChanges();
            if (model.AddTovarValueColumn.ColumnValues != null)
            {
                var valueColumns = new List<ValueColumn>();
                foreach (var valueColumnViewModel in model.AddTovarValueColumn.ColumnValues)
                {
                    var value = new ValueColumn
                    {
                        Name = valueColumnViewModel.Value,
                        TovarId = tovar.Id,
                        ColumnId = valueColumnViewModel.ColumnId
                    };
                    valueColumns.Add(value);
                }
                _context.ValuesColumn.AddRange(valueColumns);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Tovars", new { id });
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Tovar tovar = _context.Tovars.Find(id);
            var valueColumb = _context.ValuesColumn.Where(x => x.TovarId == id).ToList();
            var column = _context.Columns.Where(x => x.PriceListId == tovar.PriceListId).ToList();
            var model = new ListEditTovarValuesViewModel
            {
               Tovars = tovar,               
               ValueColumns = valueColumb,
               Column = column
            };            
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ListEditTovarValuesViewModel model )
        {
            var tovar = new Tovar
            {
                Id = id,
                Name = model.Tovars.Name,
                KodTovar = model.Tovars.KodTovar,
                PriceListId = model.Tovars.PriceListId,     
            };
            _context.Tovars.Update(tovar);
            _context.SaveChanges();
            if (model.ValueColumns != null)
            {
                foreach (var valueColumnViewModel in model.ValueColumns)
                {
                    var valueColumn = new ValueColumn
                    {
                        Id = valueColumnViewModel.Id,
                        Name = valueColumnViewModel.Name,
                        TovarId = id,
                        ColumnId = valueColumnViewModel.ColumnId
                    };
                    _context.Update(valueColumn);
                    _context.SaveChanges();
                }
                
            }
            id = tovar.PriceListId;
            return RedirectToAction("Index", "Tovars", new {id});
        }

        public IActionResult Delete(int? id)
        {
            var priceList = _context.PricesList.FirstOrDefault(x => x.Id == id);
            var tovar = _context.Tovars.Find(id);
            _context.Tovars.Remove(tovar);
            var valueColumb = _context.ValuesColumn.Where(x => x.TovarId == id).ToList();
            _context.ValuesColumn.RemoveRange(valueColumb);
            _context.SaveChanges();
            TempData["SM"] = "Вы удалили страницу!";
            id = tovar.PriceListId;
            return RedirectToAction("Index", "Tovars", new { id });
        }

        [HttpPost]
        public ActionResult EditByPropertyName(int tovarId, string propertyName, string value)
        {
            var status = false;
            if (tovarId == null)
            {
                return View(tovarId);
            }
            var intValue = Convert.ToInt32(value);
            var tovar = _context.Tovars.Find(tovarId);
            _context.Entry(tovar).Property(propertyName).CurrentValue = intValue;
            _context.SaveChanges();
            return Content(intValue.ToString());

        }

        [HttpPost]
        public ActionResult EditValue(int valueId, string value)
        {
            if(valueId == null)
            {
                return View(valueId);
            }
            var valueColumn = _context.ValuesColumn.FirstOrDefault(s => s.Id == valueId);
            valueColumn.Name = value;
            _context.Entry(valueColumn).State = EntityState.Modified;
            _context.SaveChanges();
            return Content(valueColumn.Name);
        }
    }
}
