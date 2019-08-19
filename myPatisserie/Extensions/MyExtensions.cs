using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myPatisserie.Extensions
{
    public static class MyExtensions
    {
        public static int ToInt(this object ob,int defVal=0)
        {

            int resut = 0;
            try
            {
                resut = Convert.ToInt32(ob);
            }
            catch
            {
                resut = defVal;
            }
            return resut;
        }

        public static string ToControlledString(this object o,string defVal="boş")
        {
            if (o == null)
            {
                return defVal;
            }
            else
                return o.ToString();
        }
    }
}