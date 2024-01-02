using challengeN5.Models;
using MediatR;

namespace challengeN5.Data.relational.queries
{
    public record GetAllPermissionQuery() : IRequest<IEnumerable<Permission>>;
}
