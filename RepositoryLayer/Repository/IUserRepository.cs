using DomainLayer.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public interface IUserService
    {
        void RegisterUser(User user);
        User GetUserById(int id);
        // Define other service methods as needed
        public List<User> GetAllUsers();

    }
}
