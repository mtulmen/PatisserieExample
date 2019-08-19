using BussinessLayer;
using DataAccessLayer;
using DataAccessLayer.MyEntities;
using DataAccessLayer.Repositories;
using myPatisserie.CustomActionFilters;
using myPatisserie.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myPatisserie.Controllers
{
    [LogAction]
    public class PatisserieController : Controller
    {

        PatisserieRepository _repository;
        IUserRepository _repUser;
        CommentRepository _repComment;
        

        public PatisserieController(PatisserieRepository repository, IUserRepository userRepository, CommentRepository commentRepository)
        {
            _repository = repository;
            _repUser = userRepository;
            _repComment = commentRepository;
        }

        public ActionResult Index()
        {
            return View();
        }



        [MyExceptionFilter]
        [CheckLogin]
        public ActionResult Detail(int id)
        {
            Cake entity = _repository.Find(id);

            MyMapper<CakeViewModel, Cake> _mapper = new MyMapper<CakeViewModel, Cake>();
            CakeViewModel model = _mapper.castTo(entity);
       
            return View(model);
        }
        
        public ActionResult CommentsPartial(int id)
        {
            
            var repository = new PatisserieRepository();
            Cake entity = _repository.Find(id);

            MyMapper<CakeViewModel, Cake> _mapper=new MyMapper<CakeViewModel, Cake>();
            CakeViewModel model = _mapper.castTo(entity);
            
            return View(model);
        }

        [HttpPost]
        public JsonResult AddComment(int CakeId,string CommentStr)
        {
           
            Comment cmntEntity = new Comment();
            cmntEntity.CommentStr = CommentStr;

            int UserId = Convert.ToInt32(Session["UserId"]);
            
            _repComment.Add(cmntEntity, CakeId, UserId);

            JsonResult res = new JsonResult();
            res.Data = new { CommentStr = cmntEntity.CommentStr };

            return res;
        }

       
        public ActionResult Cakes()
        {
            List<Cake> patList =  _repository.List();

            return View(patList);
        }

        public ActionResult AddCakes()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCakesData(CakeViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);


            MyMapper<Cake, CakeViewModel> _mapper = new MyMapper<Cake, CakeViewModel>();
            Cake cakeDataModel = _mapper.castTo(model);

            _repository.Add(cakeDataModel);

            string imageUrl = model.Name + "_" + cakeDataModel.Id + ".jpg";
            string fileName = Server.MapPath("../images/"+ imageUrl);

            var file = Request.Files["myimage"];

            file.SaveAs(fileName);

            cakeDataModel.ImageUrl = imageUrl;

            _repository.Update(cakeDataModel);

            return RedirectToAction("Index");
        }

    }
}