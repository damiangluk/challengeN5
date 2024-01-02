using challengeN5.Models;
using MediatR;

namespace challengeN5.Data.relational.commands
{
    public record UpdatePermissionCommand(int Id, string EmployeeName, string EmployeeSurname, DateTime PermissionDate, int PermissionTypeId) : IRequest<Permission>;
}
