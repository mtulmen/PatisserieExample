using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DataAccessLayer.MyEntities
{
   public class Comment:BaseEntity
    {
        public string CommentStr { get; set; }

        [ScriptIgnore]
        public virtual User User { get; set; }

        [ScriptIgnore]
        public virtual Cake Cake { get; set; }
    }
}
