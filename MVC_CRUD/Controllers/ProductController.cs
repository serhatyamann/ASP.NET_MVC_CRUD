using MVC_CRUD.Models.DataTransferObjects;
using MVC_CRUD.Models.Entities.Abstract;
using MVC_CRUD.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD.Controllers
{
    public class ProductController : BaseController
    {
        [HttpGet]
        public ActionResult Create()
        {
            CreateProductDTO model = new CreateProductDTO();
            model.Categories = db.Categories.Where(x => x.Status != Status.Passive).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateProductDTO model)
        {
            model.Categories = db.Categories.Where(x => x.Status != Status.Passive).ToList();
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product.Name = model.Name;
                product.Description = model.Description;
                product.UnitPrice = model.UnitPrice;
                product.UnitInStock = model.UnitInStock;
                product.CategoryId = model.CategoryId;
                db.Products.Add(product);
                db.SaveChanges();
                ViewBag.ProcessStatus = 1;
                return View(model);
            }
            else
            {
                ViewBag.ProcessStatus = 2;
                return View(model);
            }
        }

        public ActionResult List()
        {
            return View(db.Products.Where(x => x.Status != Status.Passive).ToList());
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == id);
            UpdateProductDTO model = new UpdateProductDTO();
            model.Id = product.Id;
            model.Name = product.Name;
            model.Description = product.Description;
            model.UnitPrice = product.UnitPrice;
            model.UnitInStock = product.UnitInStock;
            model.Categories = db.Categories.Where(x => x.Status != Status.Passive).ToList();
            model.CategoryId = product.CategoryId;
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UpdateProductDTO model)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == model.Id);
            model.Categories = db.Categories.Where(x => x.Status != Status.Passive).ToList();
            if (ModelState.IsValid)
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.UnitPrice = model.UnitPrice;
                product.UnitInStock = model.UnitInStock;
                product.CategoryId = model.CategoryId;
                product.Status = Status.Modified;
                product.UpdateDate = DateTime.Now;
                db.SaveChanges();
                ViewBag.ProcessStatus = 1;
                return View(model);
            }
            else
            {
                ViewBag.ProcessStatus = 2;
                return View(model);
            }
        }

        public ActionResult Detail(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }

    }
}