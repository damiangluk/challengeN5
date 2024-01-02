using challengeN5.Models;
using Nest;

namespace challengeN5.Data.norelational.mapping
{
    public static class Mapping
    {
        public static void ConfigureMapping(ElasticClient _elasticClient)
        {

        }

        public static CreateIndexDescriptor PermissionMapping(this CreateIndexDescriptor descriptor)
        {
            return descriptor.Map<Permission>(m => m.Properties(p => p
                .Keyword(k => k.Name(n => n.Id))
                .Text(k => k.Name(n => n.EmployeeName))
                .Text(k => k.Name(n => n.EmployeeSurname))
                .Date(k => k.Name(n => n.PermissionDate))
                .Number(k => k.Name(n => n.PermissionTypeId))
                .Object<PermissionType>(o => o.Name(n => n.PermissionType))));
        }
    }
}
