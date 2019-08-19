using DataAccessLayer;
using DataAccessLayer.MyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myPatisserie.CustomActionFilters
{
    public class LogActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ActionLogRepository rep = new ActionLogRepository();
            ActionLog actionLog = new ActionLog();
            actionLog.Controller = filterContext.RouteData.Values["controller"].ToString();
            actionLog.Action = filterContext.RouteData.Values["action"].ToString();
            actionLog.RequestDate = DateTime.Now;

            if (filterContext.ActionParameters.Count() > 0)
            {
               if(filterContext.ActionParameters.ContainsKey("id"))
                actionLog.DetailId = Convert.ToInt32(filterContext.ActionParameters["id"]);
                
            }

            rep.Insert(actionLog);


        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}