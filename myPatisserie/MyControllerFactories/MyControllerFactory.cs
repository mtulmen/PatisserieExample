using DataAccessLayer;
using DataAccessLayer.Repositories;
using myPatisserie.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace myPatisserie.MyControllerFactories
{
    public class MyControllerFactory:DefaultControllerFactory
    {
        static PatisserieRepository patRep;
        static IUserRepository userRep;
        static CommentRepository commentRep;
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if(patRep==null)
                patRep = new PatisserieRepository();
            if (userRep == null)
                userRep = new UserRepository();
            if (commentRep == null)
                commentRep = new CommentRepository();
            
            if (controllerName=="Patisserie")
            {
               var _PatController = new PatisserieController(patRep,userRep,commentRep);
               return _PatController;
            }
            else if(controllerName=="User")
            {
                IController cnt1 = new UserController(userRep);
                return cnt1;
            }
            else if(controllerName=="Home")
            {
                IController cnt1 = new HomeController(commentRep);
                return cnt1;
            }

            IController cnt= base.CreateController(requestContext, controllerName);
            return cnt;
        }
    }
}