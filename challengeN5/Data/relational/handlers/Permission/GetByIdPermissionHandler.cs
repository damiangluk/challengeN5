using challengeN5.Data.interfaces.repositories;
using challengeN5.Data.relational.queries;
using challengeN5.Models;
using MediatR;

namespace challengeN5.Data.relational.handlers
{
    public class GetByIdPermissionHandler : IRequestHandler<GetByIdPermissionQuery, Permission>
    {
        private readonly IPermissionRepository _permissionRepository;

        public GetByIdPermissionHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<Permission> Handle(GetByIdPermissionQuery request, CancellationToken cancellationToken)
        {
            return await _permissionRepository.GetByIdAsync(request.PermissionId, cancellationToken);
        }
    }
}
