using DataAccessLayer.MyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ActionLogRepository
    {
        Model1 _ctx;
        public ActionLogRepository()
        {
            _ctx = new Model1();
        }

        public void Insert(ActionLog entity)
        {
            _ctx.ActionLogs.Add(entity);
            _ctx.SaveChanges();
        }

    }
}
