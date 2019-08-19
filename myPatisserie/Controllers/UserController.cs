using DataAccessLayer;
using DataAccessLayer.MyEntities;
using DataAccessLayer.Repositories;
using myPatisserie.CustomActionFilters;
using myPatisserie.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myPatisserie.Controllers
{
    
    public class UserController : Controller
    {
        // GET: User
        //[OutputCache(Duration =60)]

        IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [LogAction]
        [CheckLogin(tip:1)]
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        [LogAction]
        [CheckLogin(tip:1)]
        public ActionResult Index(string filterName,string filterEmail)
        {
            var ctx = new Model1();

            List<User> result = _userRepository.List().Where(c => c.UserName.Contains(filterName) && c.Email.Contains(filterEmail)).ToList();

            return View(result);
        }

        //[OutputCache(Duration =300)]
        public ActionResult UserListPartial(string filterName, string filterEmail)
        {
           
            if (filterName == null)
                filterName = "";
            if (filterEmail == null)
                filterEmail = "";
            List<User> result = _userRepository.List().Where(c => c.UserName.Contains(filterName) && c.Email.Contains(filterEmail)).OrderByDescending(c => c.Id).ToList();
            if (filterEmail == "" && filterName == "")
                result = _userRepository.List().OrderByDescending(c => c.Id).ToList();

            return PartialView(result);
        }

        public PartialViewResult UsrPartialVol1(string filterName, string filterEmail)
        {
           
            if (filterName == null)
                filterName = "";
            if (filterEmail == null)
                filterEmail = "";
            List<User> result = _userRepository.List().Where(c => c.UserName.Contains(filterName) && c.Email.Contains(filterEmail)).OrderByDescending(c=>c.Id).ToList();
            if (filterEmail == "" && filterName == "")
                result = _userRepository.List();

            return PartialView(result);
        }

        [LogAction]
        public ViewResult AddUser()
        {
            return View();
        }

       

        [HttpPost]
        public JsonResult AddUser(UserViewModel usr)
        {
            AjaxRes result = new AjaxRes();
            if (!ModelState.IsValid)
            {
                string errorMessages = "";

                foreach (var item in ModelState.Values)
                {
                   foreach(var er in item.Errors)
                    errorMessages+= er.ErrorMessage+"\r\n";
                }
                
                result.Result = 0;
                result.Message = errorMessages;
               
                return Json(result);
            //return new JsonResult { Data = new { Result = 0, Message = "model valid değil" } };
            }
               

           
            User userEntity = JsonConvert.DeserializeObject<User>(JsonConvert.SerializeObject(usr));
            userEntity.UserType = 0;

            _userRepository.Add(userEntity);

            
            result.Result = 1;
            result.Message = "işlem başarılı";

          

            var usrlist = _userRepository.List().OrderByDescending(c => c.Id).ToList();
           

            return Json(result);

            //return new JsonResult { Data = new { Result = 1, Message = "işlem başarılı" } };
        }

        public int AddUserAsyn(User usr)
        {
            return 0;
        }

        public ActionResult Update(int id)
        {

            var model = _userRepository.Find(id);
            return View(model);
        }


        [HttpPost]
        public ActionResult Update(User usr)
        {

            if(ModelState.IsValid==false)
            {
                return View(usr);
            }
            var ctx = new Model1();

            var model = ctx.Users.Where(c => c.Id == usr.Id).FirstOrDefault();

            ctx.Entry(model).CurrentValues.SetValues(usr);
           
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

      
        public ActionResult Delete(int id)
        {
            var ctx = new Model1();
            var usrToDelete = ctx.Users.Where(c => c.Id == id).FirstOrDefault();
            ctx.Users.Remove(usrToDelete);

            ctx.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}