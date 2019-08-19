using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MyEntities
{
    public class ActionLog:BaseEntity
    {
        public string Controller { get; set; }

        public string Action { get; set; }

        public int? DetailId { get; set; }

        public DateTime RequestDate { get; set; }

    }
}
