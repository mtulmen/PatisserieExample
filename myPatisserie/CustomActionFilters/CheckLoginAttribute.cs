using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myPatisserie.CustomActionFilters
{
    public class CheckLoginAttribute : ActionFilterAttribute
    {
        int _tip;
        public CheckLoginAttribute(int tip = 0)
        {
            _tip = tip;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Session["UserId"] == null)
            {
                filterContext.RequestContext.HttpContext.Response.Redirect("/Home/Login");
            }
            else
            {
                if (_tip == 1)
                {
                    int userId = Convert.ToInt32(filterContext.RequestContext.HttpContext.Session["UserId"]);
                    Model1 ctx = new Model1();
                    var usr = ctx.Users.Where(c => c.Id == userId).FirstOrDefault();

                    if (usr.UserType == 0)
                        filterContext.RequestContext.HttpContext.Response.Redirect("/Home/Login");
                }


            }
        }
    }
}