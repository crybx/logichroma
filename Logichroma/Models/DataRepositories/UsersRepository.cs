using Logichroma.Database;
using System.Linq;

namespace Logichroma.Models.DataRepositories
{
    public class UsersRepository
    {
        private readonly LogichromaDbEntities _dataContext = new LogichromaDbEntities();

        public bool DoesAdminExist()
        {
            var userRoles = _dataContext.AspNetUsers.Where(u => u.AspNetRoles.Any(r => r.Name == "canManageUsers"));
            var result = userRoles.Any();
            return result;
        }
    }
}