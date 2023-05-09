using DomainLayer.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUserById(int id);
    }
}
