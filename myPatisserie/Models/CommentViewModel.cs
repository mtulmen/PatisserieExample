using DataAccessLayer.MyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myPatisserie.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string CommentStr { get; set; }

        public User User { get; set; }

        public CakeViewModel Cake { get; set; }


    }
}