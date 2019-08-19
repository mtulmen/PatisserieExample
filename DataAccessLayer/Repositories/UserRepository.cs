using DataAccessLayer.MyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository:IUserRepository
    {
        public User Find(int id)
        {
            Model1 ctx = new Model1();
            return ctx.Set<User>().Find(id);
        }

        public List<User> List()
        {
            Model1 ctx = new Model1();
            return ctx.Set<User>().ToList();
        }

        public void Add(User entity)
        {
            Model1 ctx = new Model1();
            ctx.Set<User>().Add(entity);
            ctx.SaveChanges();
        }
        
    }
}
