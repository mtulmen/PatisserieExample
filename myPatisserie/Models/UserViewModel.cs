using DataAccessLayer.MyEntities;
using myPatisserie.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myPatisserie.Models
{
    public class UserViewModel
    {
        [DisplayName("User Name")]
        [Required]
        [UniqUserName]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        
        public int UserType { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}