using NewsPortal.Core.Infrastructure;
using NewsPortal.Core.Repository;
using NewsPortal.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var usr = _userRepository.GetMany(x => x.Email == user.Email && x.Password == user.Password && x.IsActive).SingleOrDefault();
            if (usr != null)
            {
                if (usr.Role.RoleName == "Admin")
                {
                    Session["UserEmail"] = usr.Email;
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.Message = "Unauthorized user!!!";
                return View();
            }
            ViewBag.Message = "User can not find!!!";
            return View();
        }
    }
}