using MediatR;
using challengeN5.Models;

namespace challengeN5.Data.relational.commands
{
    public record CreatePermissionCommand(string EmployeeName, string EmployeeSurname, DateTime PermissionDate, int PermissionTypeId) : IRequest<Permission>;
}
