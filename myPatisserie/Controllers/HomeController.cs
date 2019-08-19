using DataAccessLayer;
using DataAccessLayer.Repositories;
using myPatisserie.CustomActionFilters;
using myPatisserie.Extensions;
using myPatisserie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myPatisserie.Controllers
{
    public class HomeController : Controller
    {
        CommentRepository _commentRepository;
        public HomeController(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public ActionResult Error()
        {
            return View();
            
        }

        [HttpGet]
        public JsonResult purePage()
        {
            string res = "web result";

            return Json(new { asd=123,denemestr="bu bir json",talepEden="erdal"}, JsonRequestBehavior.AllowGet);
            
        }

        [MyExceptionFilter]
        public ActionResult Index()
        {

            //string asd = "55";

            //int a = asd.ToInt(-1);


            object x=null;

            string asd = x.ToControlledString("null");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["userName"] = null;
            Session["UserId"] = null;
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginItem lg)
        {
            Model1 ctx = new Model1();

            var loggedUSer = ctx.Users.Where(c => c.UserName == lg.UserName && c.Password == lg.Password).FirstOrDefault();

            if (loggedUSer == null)
            {
                ViewBag.hatali = 1;
                return View();
            }
            else
            {

                Session["userName"] = loggedUSer.UserName;
                Session["UserId"] = loggedUSer.Id;
                return RedirectToAction("Index", "Patisserie");
            }
        }
    }
}