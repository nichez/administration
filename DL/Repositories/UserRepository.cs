using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.Common.Models;
using Itc.Am.DL.Infrastructure;
using Itc.Am.DL.Interfaces;

namespace Itc.Am.DL.Repositories
{
    public class UserRepository : RepositoryBase<UserModel>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory) { }
    
        public UserModel GetUserById(int id)
        {
            var user = DbContext.Users.Where(c => c.UserId == id).FirstOrDefault();

            return user;
        }

        public UserModel GetUserByUsername(string username)
        {
            var user = DbContext.Users.Where(c => c.Username == username).FirstOrDefault();

            return user;
        }

        public UserModel GetUserByEmail(string email)
        {
            var user = DbContext.Users.Where(c => c.Email == email).FirstOrDefault();

            return user;
        }

        public UserModel NewUser(UserModel user)
        {
            DbContext.Users.Add(user);
            DbContext.Commit();

            return user;
        }

        public void UpdateUser(UserModel entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            entity.DateUpdated = DateTime.Now;
            Update(entity);
            DbContext.Commit();
        }

    }

}
