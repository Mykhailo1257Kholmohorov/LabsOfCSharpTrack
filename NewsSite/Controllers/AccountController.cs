using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NewsSite.Models;

namespace NewsSite.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                Author user = null;
                using (AuthorContext db = new AuthorContext())
                {
                    user = db.Authors.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("AddArticle", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Your password or login is incorrect");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Author user = null;
                using (AuthorContext db = new AuthorContext())
                {
                    user = db.Authors.FirstOrDefault(u => u.Email == model.Name);
                }
                if (user == null)
                {
                    // создаем нового пользователя
                    using (AuthorContext db = new AuthorContext())
                    {
                        if (model.Email != null && model.Name != null && model.Password != null)
                        {
                            db.Authors.Add(new Author
                                {Email = model.Email, Name = model.Name, Password = model.Password});
                            db.SaveChanges();
                            user = db.Authors.Where(u => u.Email == model.Email && u.Password == model.Password)
                                .FirstOrDefault();
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please, enter registration data");
                        }
                    }
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("AddArticle", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "This login already exists in another user");
                }
            }

            return View(model);
        }
    }
}