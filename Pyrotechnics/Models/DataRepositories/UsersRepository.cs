using Pyrotechnics.Models.Database;
using System.Linq;

namespace Pyrotechnics.Models.DataRepositories
{
    public class UsersRepository
    {
        private readonly PyrotechnicsDbEntities _dataContext = new PyrotechnicsDbEntities();

        public bool DoesAdminExist()
        {
            var userRoles = _dataContext.AspNetUsers.Where(u => u.AspNetRoles.Any(r => r.Name == "canManageUsers"));
            var result = userRoles.Any();
            return result;
        }
    }
}