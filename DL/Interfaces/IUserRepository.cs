using Itc.Am.Common.Models;

namespace Itc.Am.DL.Interfaces
{
    public interface IUserRepository : IRepository<UserModel>
    {
        UserModel GetUserById(int id);
        UserModel GetUserByUsername(string username);
        UserModel GetUserByEmail(string email);
        UserModel NewUser(UserModel user);
        void UpdateUser(UserModel user);
    }
}