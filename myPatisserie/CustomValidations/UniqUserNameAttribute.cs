using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myPatisserie.CustomValidations
{
    public class UniqUserNameAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var ctx = new Model1();
            var existing = ctx.Users.Where(c => c.UserName == value.ToString()).ToList();
            if (existing.Count > 0)
            {
                ErrorMessage = "User Name is Exist";
                return false;
            }
            return true;
        }
    }
}