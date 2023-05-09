using DomainLayer.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        //private readonly AppDbContext _dbContext;

        //public UserRepository(AppDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
