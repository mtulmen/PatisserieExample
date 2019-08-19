using DataAccessLayer.MyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CommentRepository
    {
        public Comment Find(int id)
        {
            Model1 ctx = new Model1();
            return ctx.Set<Comment>().Find(id);
        }

        public List<Comment> List()
        {
            Model1 ctx = new Model1();
            return ctx.Set<Comment>().ToList();
        }

        public void Add(Comment entity, int UserId, int CakeId)
        {
            Model1 ctx = new Model1();

            entity.User = ctx.Set<User>().Find(UserId);
            entity.Cake = ctx.Set<Cake>().Find(CakeId);


            ctx.Set<Comment>().Add(entity);
            ctx.SaveChanges();
        }
        
    }
}
