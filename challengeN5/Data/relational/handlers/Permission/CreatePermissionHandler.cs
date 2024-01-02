using challengeN5.Data.interfaces.repositories;
using challengeN5.Data.relational.commands;
using challengeN5.Data.relational.common;
using challengeN5.Data.relational.queries;
using challengeN5.Data.relational.repositories;
using challengeN5.Models;
using MediatR;

namespace challengeN5.Data.relational.handlers
{
    public class CreatePermissionHandler : IRequestHandler<CreatePermissionCommand, Permission>
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IPermissionTypeRepository _permissionTypeRepository;

        public CreatePermissionHandler(IPermissionRepository permissionRepository, IPermissionTypeRepository permissionTypeRepository)
        {
            _permissionRepository = permissionRepository;
            _permissionTypeRepository = permissionTypeRepository;
        }

        public async Task<Permission> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permissionType = await _permissionTypeRepository.GetByIdAsync(request.PermissionTypeId, cancellationToken);

            if(permissionType == null)
            {
                return null;
            }

            var permission = new Permission()
            {
                EmployeeName = request.EmployeeName,
                EmployeeSurname = request.EmployeeSurname,
                PermissionDate = request.PermissionDate,
                PermissionTypeId = permissionType.Id,
                PermissionType = permissionType
            };

            await _permissionRepository.InsertAsync(permission, cancellationToken);

            return permission;
        }
    }
}
