using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class ItemController : Controller
    {
        private ApplicationDbContext _context;

        public ItemController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var viewModel = new ItemFormViewModel {
                items = _context.Itens.ToList()
            };

            return View(viewModel);
        }

        public ViewResult New()
        {
            var viewModel = new ItemFormViewModel
            {
                Item = new Item()
            };
            return View("ItemForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var item = _context.Itens.SingleOrDefault(c => c.Id == id);

            if (item == null)
                return HttpNotFound();

            var viewModel = new ItemFormViewModel(item)
            {
                Item = item
            };

            return View("ItemForm", viewModel);
        }


        public ActionResult Details(int id)
        {
            var item = _context.Itens.SingleOrDefault(m => m.Id == id);

            if (item == null)
                return HttpNotFound();

            return View(item);

        }

        public ActionResult Delete(int id)
        {
            
            var item = _context.Itens.SingleOrDefault(m => m.Id == id);

            _context.Itens.Remove(item);

            _context.SaveChanges();

            return RedirectToAction("Index", "Item");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Item item)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ItemFormViewModel(item)
                {

                };

                return View("ItemForm", viewModel);
            }

            if (item.Id == 0)
            {
                _context.Itens.Add(item);
            }
            else
            {
                var itemInDb = _context.Itens.Single(c => c.Id == item.Id);
                itemInDb.Nome = item.Nome;
                itemInDb.Categoria = item.Categoria;
                itemInDb.Data = item.Data;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Item");
        }

        public bool IsNomeInUse(string Nome)
        {
            return _context.Itens.Where(e => e.Nome.Equals(Nome)).Count() > 0;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult NomeValidator(string Nome)
        {
            try
            {
                if (IsNomeInUse(Nome))
                {
                    return Json(new { result = "fail", msg = "Nome já utilizado. Por favor, informe outro nome." });
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return Json("");
        }
    }
}