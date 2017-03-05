using NewsPortal.Admin.Filters;
using NewsPortal.Admin.Helper;
using NewsPortal.Core.Infrastructure;
using NewsPortal.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
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

    }

}
