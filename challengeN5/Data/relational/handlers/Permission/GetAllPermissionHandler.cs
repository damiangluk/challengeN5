using challengeN5.Data.interfaces.repositories;
using challengeN5.Data.relational.commands;
using challengeN5.Data.relational.queries;
using challengeN5.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace challengeN5.Data.relational.handlers
{
    public class GetAllPermissionHandler : IRequestHandler<GetAllPermissionQuery, IEnumerable<Permission>>
    {
        private readonly IPermissionRepository _permissionRepository;

        public GetAllPermissionHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<IEnumerable<Permission>> Handle(GetAllPermissionQuery request, CancellationToken cancellationToken)
        {
            return await _permissionRepository.GetAllAsync(cancellationToken);
        }
    }
}
