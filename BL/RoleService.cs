using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.BL.Interfaces;
using Itc.Am.Common.Models;
using Itc.Am.DL.Interfaces;

namespace Itc.Am.BL
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public void RoleAdd(Role role)
        {
            roleRepository.AddRole(role);
        }
    }
}
