using Logichroma.Database;
using Logichroma.Models.DataRepositoryInterfaces;
using System.Linq;

namespace Logichroma.Models.DataRepositories
{
    public class UsersRepository : IUsersRepository
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