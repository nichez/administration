using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.Common.Models;

namespace Itc.Am.DL
{
    public class StoreEntities : DbContext
    {
        public StoreEntities() : base("StoreEntities") { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<WorktimeRecord> WorktimeRecords { get; set; }
        public DbSet<Vacation> Vacations { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
