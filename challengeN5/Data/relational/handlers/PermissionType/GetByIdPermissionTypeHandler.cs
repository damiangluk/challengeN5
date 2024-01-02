using challengeN5.Data.interfaces.repositories;
using challengeN5.Data.relational.queries;
using challengeN5.Models;
using MediatR;

namespace challengeN5.Data.relational.handlers
{
    public class GetByIdPermissionTypeHandler : IRequestHandler<GetByIdPermissionTypeQuery, PermissionType>
    {
        private readonly IPermissionTypeRepository _permissionTypeRepository;

        public GetByIdPermissionTypeHandler(IPermissionTypeRepository permissionTypeRepository)
        {
            _permissionTypeRepository = permissionTypeRepository;
        }

        public async Task<PermissionType> Handle(GetByIdPermissionTypeQuery request, CancellationToken cancellationToken)
        {
            return await _permissionTypeRepository.GetByIdAsync(request.PermissionTypeId, cancellationToken);
        }
    }
}