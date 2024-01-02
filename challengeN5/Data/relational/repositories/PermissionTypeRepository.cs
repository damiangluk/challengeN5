using challengeN5.Data.interfaces.repositories;
using challengeN5.Data.relational.common;
using challengeN5.Models;

namespace challengeN5.Data.relational.repositories
{
    public class PermissionTypeRepository : GenericRepository<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
