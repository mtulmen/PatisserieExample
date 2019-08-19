using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myPatisserie.MyHtmlExtensions
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString firstHelper(this HtmlHelper ob,string placeHolder)
        {
            string str = "<input type='text' placeholder='" + placeHolder + "'";
            return new MvcHtmlString(str);
        }

        public static MvcHtmlString myFormGroup(this HtmlHelper ob, string fieldName, string className)
        {
            string str = @"<div class='" + className + @"'>
           "+fieldName+@"
            <div class='col-md-10'>
                <input class='form-control' type = 'text' name='"+fieldName+@"' id='"+fieldName+@"' />
            </div>
        </div>";
            return new MvcHtmlString(str);
        }
    }
}