using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using DAL.Abstract;
using DAL.DataModel;

namespace WebApplication.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IDataRepository repository;

        public UserController(IDataRepository repository)
        {
            this.repository = repository;
        }

        // GET: User
        public ActionResult Index()
        {
            var user = repository.FindUser(HttpContext.User.Identity.Name);
            if (user == null)
            {
                return RedirectToAction("Create");
            }
            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            ModelState.Remove("Name");
            if (ModelState.IsValid)
            {
                user.Name = HttpContext.User.Identity.Name;
                repository.SaveUser(user);
                return RedirectToAction("Index");
            }

            
            return View(user);
        }

        public ActionResult Edit(string userName)
        {
            User user = repository.FindUser(userName);
            string loggedUser = HttpContext.User.Identity.Name;
            string nameToCompare = user.Name.Substring(0, loggedUser.Length);
            if (nameToCompare.Equals(loggedUser))
            {
                return View(user);
            }
            return HttpNotFound("You can not edit other users!");
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            ModelState.Remove("Name");
            if (ModelState.IsValid)
            {
                repository.SaveUser(user);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            User user = repository.FindUser(id);
            return View(user);
        }
    }
}