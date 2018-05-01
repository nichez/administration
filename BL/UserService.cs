using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.BL.Interfaces;
using Itc.Am.DL;
using Itc.Am.DL.Infrastructure;
using Itc.Am.DL.Repositories;
using Itc.Am.Common.Models;
using Itc.Am.DL.Interfaces;

namespace Itc.Am.BL
{
    

    public class UserService : IUserService
    {
        private readonly IUserRepository usersRepository;
   

        public UserService(IUserRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IEnumerable<UserModel> Getusers()
        {
            var users = usersRepository.GetAll();
            return users;
        }

        public UserModel GetUser(int id)
        {
            var user = usersRepository.GetById(id);
            return user;
        }

        public UserModel GetUsername(string username)
        {
            var user = usersRepository.GetUserByUsername(username);
            return user;
        }

        public UserModel GetEmail(string email)
        {
            var user = usersRepository.GetUserByEmail(email);
            return user;
        }

        public void CreateUser(UserModel user)
        {
            usersRepository.NewUser(user);
        }

        public void Update(UserModel user)
        {
            usersRepository.UpdateUser(user);
        }
    }

}
