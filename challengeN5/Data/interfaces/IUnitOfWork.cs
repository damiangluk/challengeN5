using challengeN5.Data.interfaces.repositories;

namespace challengeN5.Data.interfaces
{
    public interface IUnitOfWork
    {
        IPermissionRepository PermissionRepository { get; }
        IPermissionTypeRepository PermissionTypeRepository { get; }

        Task CompleteAsync();
    }
}
