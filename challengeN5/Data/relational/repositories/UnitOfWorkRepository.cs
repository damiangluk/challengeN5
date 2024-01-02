using challengeN5.Data.interfaces;
using challengeN5.Data.interfaces.repositories;
using challengeN5.Data.relational.common;
using challengeN5.Models;

namespace challengeN5.Data.relational.repositories
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        public IPermissionRepository PermissionRepository { get; private set; }
        public IPermissionTypeRepository PermissionTypeRepository { get; private set; }


        private readonly ApplicationContext Context;

        public UnitOfWorkRepository(ApplicationContext context, IPermissionRepository permissionRepository, IPermissionTypeRepository permissionTypeRepository)
        {
            Context = context;
            PermissionRepository = permissionRepository;
            PermissionTypeRepository = permissionTypeRepository;
        }

        public async Task CompleteAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
