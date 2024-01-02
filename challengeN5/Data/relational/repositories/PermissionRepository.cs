using challengeN5.Data.interfaces.repositories;
using challengeN5.Data.relational.common;
using challengeN5.Models;

namespace challengeN5.Data.relational.repositories
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
