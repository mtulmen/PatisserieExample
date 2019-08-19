using myPatisserie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myPatisserie.Controllers
{
    public class DataTransferController : Controller
    {
        // GET: DataTransfer
        public ActionResult Index()
        {
            return View(0);
        }
        [HttpPost]
        public ActionResult Index(int sayi)
        {
            return View(sayi * sayi);
        }

        public ActionResult AjaxIndex()
        {
            return View(0);
        }

        [HttpPost]
        public int AjaxIndex(int sayi)
        {
            return sayi * sayi;
        }

        public int AjaxReq(int karesiAlinacakSayi,string name)
        {
            return karesiAlinacakSayi* karesiAlinacakSayi;
        }

        public ActionResult AjaxreqWithJsonResult()
        {
            LoginItem result = new LoginItem();
            result.UserName = "ibrahim";
            result.Password = "yzc";
            return Json(result);
        }
    }
}