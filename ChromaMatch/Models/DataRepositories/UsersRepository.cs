using ChromaMatch.Models.Database;
using System.Linq;

namespace ChromaMatch.Models.DataRepositories
{
    public class UsersRepository
    {
        private readonly ChromaMatchDbEntities _dataContext = new ChromaMatchDbEntities();

        public bool DoesAdminExist()
        {
            var userRoles = _dataContext.AspNetUsers.Where(u => u.AspNetRoles.Any(r => r.Name == "canManageUsers"));
            var result = userRoles.Any();
            return result;
        }
    }
}