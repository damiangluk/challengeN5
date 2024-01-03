using challengeN5.Data.interfaces.repositories;
using challengeN5.Data.relational.commands;
using challengeN5.Data.relational.queries;
using challengeN5.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace challengeN5.Data.relational.handlers
{
    public class GetAllPermissionTypeHandler : IRequestHandler<GetAllPermissionTypeQuery, IEnumerable<PermissionType>>
    {
        private readonly IPermissionTypeRepository _permissionTypeRepository;

        public GetAllPermissionTypeHandler(IPermissionTypeRepository permissionTypeRepository)
        {
            _permissionTypeRepository = permissionTypeRepository;
        }

        public async Task<IEnumerable<PermissionType>> Handle(GetAllPermissionTypeQuery request, CancellationToken cancellationToken)
        {
            return await _permissionTypeRepository.GetAllAsync(cancellationToken);
        }
    }
}
