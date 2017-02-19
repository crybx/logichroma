using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pyrotechnics.Models.Database;

namespace Pyrotechnics.Models.DataRepositories
{
    public class UsersRepository
    {
        private readonly PyrotechnicsDbEntities _dataContext = new PyrotechnicsDbEntities();

        public bool DoesAdminExist()
        {
            var userRoles = _dataContext.AspNetUsers.Where(u => u.AspNetRoles.Any(r => r.Name == "canManageUsers"));
            return userRoles.Any();
        }
    }
}