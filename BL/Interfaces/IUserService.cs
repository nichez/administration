using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.Common.Models;

namespace Itc.Am.BL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserModel> Getusers();
        UserModel GetUser(int id);
        UserModel GetUsername(string username);
        UserModel GetEmail(string email);
        void CreateUser(UserModel user);
        void Update(UserModel user);
    }
}
