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
    public class CategoryController : BaseController
    {

        #region Create Category

        [HttpGet] 
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] 
        public ActionResult Create(CreateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.Name = model.Name;
                category.Description = model.Description;
                db.Categories.Add(category);
                db.SaveChanges();
                ViewBag.ProcessStatus = 1;
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.ProcessStatus = 2;
                return View(model);
            }
        }
        #endregion

        #region List
        [HttpGet]
        public ActionResult List()
        {
            var categoryList = db.Categories.Where(x => x.Status != Status.Passive).ToList();
            return View(categoryList);
        }
        #endregion

        #region Update Category
        [HttpGet]
        public ActionResult Update(int id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.Id == id);
            UpdateCategoryDTO model = new UpdateCategoryDTO();
            model.Id = category.Id;
            model.Name = category.Name;
            model.Description = category.Description;
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UpdateCategoryDTO model)
        {
            Category category = db.Categories.FirstOrDefault(x => x.Id == model.Id);
            if (ModelState.IsValid)
            {
                category.Name = model.Name;
                category.Description = model.Description;
                category.UpdateDate = DateTime.Now;
                category.Status = Status.Modified;
                db.SaveChanges();
                ViewBag.ProcessStatus = 1;
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.ProcessStatus = 2;
                return View(model);
            }
        }
        #endregion

        #region Delete Category
        public JsonResult Delete(int id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.Id == id);
            category.Status = Status.Passive;
            category.DeleteDate = DateTime.Now;
            db.SaveChanges();
            ViewBag.ProcessStatus = 1;
            return Json("");
        }
        #endregion

        #region Category Details
        public ActionResult Detail(int id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.Id == id);
            return View(category);
        }
        #endregion
    }
}