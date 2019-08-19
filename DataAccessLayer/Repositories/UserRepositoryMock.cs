using DataAccessLayer.MyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepositoryMock : IUserRepository
    {
        static List<User> users;

        public UserRepositoryMock()
        {
            users = new List<User>();
        }

        public User Find(int id)
        {

            return users.Where(c => c.Id == id).FirstOrDefault();
        }

        public List<User> List()
        {
            return users;
            
        }

        public void Add(User entity)
        {
            users.Add(entity);
        }
    }
}
