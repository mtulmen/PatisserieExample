using DataAccessLayer.MyEntities;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    public interface IUserRepository
    {
        User Find(int id);
        List<User> List();
        void Add(User entity);
       
    }
}