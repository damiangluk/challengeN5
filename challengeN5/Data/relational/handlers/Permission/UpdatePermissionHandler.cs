using challengeN5.Data.interfaces.repositories;
using challengeN5.Data.relational.commands;
using challengeN5.Data.relational.common;
using challengeN5.Models;
using MediatR;

namespace challengeN5.Data.relational.handlers
{
    public class UpdatePermissionHandler : IRequestHandler<UpdatePermissionCommand, Permission>
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IPermissionTypeRepository _permissionTypeRepository;

        public UpdatePermissionHandler(IPermissionRepository permissionRepository, IPermissionTypeRepository permissionTypeRepository)
        {
            _permissionRepository = permissionRepository;
            _permissionTypeRepository = permissionTypeRepository;
        }

        public async Task<Permission> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await _permissionRepository.GetByIdAsync(request.Id, cancellationToken);
            var permissionType = await _permissionTypeRepository.GetByIdAsync(request.PermissionTypeId, cancellationToken);

            if (permission == null || permissionType == null)
            {
                return null;
            }

            permission.EmployeeName = request.EmployeeName;
            permission.EmployeeSurname = request.EmployeeSurname;
            permission.PermissionDate = request.PermissionDate;
            permission.PermissionTypeId = request.PermissionTypeId;
            permission.PermissionType = permissionType;

            return permission;
        }
    }
}
