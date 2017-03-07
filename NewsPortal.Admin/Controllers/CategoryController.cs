using NewsPortal.Admin.Filters;
using NewsPortal.Admin.Helper;
using NewsPortal.Core.Infrastructure;
using NewsPortal.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace NewsPortal.Admin.Controllers
{
    public class CategoryController : Controller
    {
        #region Category Operations
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion

        [HttpGet]
        public ActionResult Index(int p = 1)
        {
            return View(_categoryRepository.GetAll().OrderByDescending(x => x.CategoryId).ToPagedList(p, 10));
        }

        [HttpGet]
        public ActionResult Add()
        {
            SetCategoryList();
            return View();
        }

        [HttpPost]
        public JsonResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoryRepository.Insert(category);
                    _categoryRepository.Save();
                    return Json(new ResultJson { Success = true, Message = "Category Added Successfully." });
                }
                catch (Exception)
                {
                    return Json(new ResultJson { Success = false, Message = "Category couldnt be added!!!" });
                }
            }
            return Json(new ResultJson { Success = false, Message = "You must fill the blank fields..." });
        }

        [HttpGet]
        public ActionResult Update(int CategoryId)
        {
            Category cat = _categoryRepository.GetById(CategoryId);
            if (cat == null)
            {
                throw new Exception("category not found!!!");
            }
            SetCategoryList();
            return View();
        }

        [HttpPost]
        public JsonResult Update(Category category)
        {
            return Json(1);
        }

        [HttpPost]
        public JsonResult Delete(int ID)
        {
            Category cat = _categoryRepository.GetById(ID);
            if (cat == null)
            {
                return Json(new ResultJson { Success = false, Message = "Category could not deleted!!!" });
            }
            _categoryRepository.Delete(ID);
            _categoryRepository.Save();

            return Json(new ResultJson { Success = true, Message = "Category deleted successfully..." });

        }


        public void SetCategoryList()
        {
            var categoryList = _categoryRepository.GetMany(x => x.ParentCategoryId == 0).ToList();
            ViewBag.CategoryList = categoryList;
        }

    }

}
