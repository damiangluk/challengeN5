using challengeN5.Models;
using MediatR;

namespace challengeN5.Data.relational.queries
{
    public record GetByIdPermissionTypeQuery(int PermissionTypeId) : IRequest<PermissionType>;
}
