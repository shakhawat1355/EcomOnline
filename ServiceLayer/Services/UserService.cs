using DomainLayer.DomainModel;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService()
        {
            
        }
        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User GetUserById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public void RegisterUser(User user)
        {
            throw new NotImplementedException();
        }


        public List<User> GetAllUsers()
        {
            var AllUsers = _dbContext.Users.ToList();
            return AllUsers;
        }
    }
}

