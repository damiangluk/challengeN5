using System.ComponentModel.DataAnnotations.Schema;

namespace challengeN5.Models
{
    [Serializable]
    public class Permission : Identificable
    {
        #region constructors

        public Permission() { }

        public Permission(string employeeName, string employeeSurname, int permissionTypeId)
        {
            EmployeeName = employeeName;
            EmployeeSurname = employeeSurname;
            PermissionTypeId = permissionTypeId;
        }

        #endregion

        #region properties

        public string EmployeeName { get; set; }

        public string EmployeeSurname { get; set; }

        public DateTime PermissionDate { get; set; }

        public int PermissionTypeId { get; set; }

        [ForeignKey("PermissionTypeId")]
        public virtual PermissionType? PermissionType { get; set; }

        #endregion

        #region methods

        public object FormatForElasticsearch()
        {
            return new
            {
                PermissionId = Id,
                EmployeeName = EmployeeName,
                EmployeeSurname = EmployeeSurname,
                PermissionTypeId = PermissionTypeId,
                PermissionType = PermissionType
            };
        }

        public object FormatForFront()
        {
            return new
            {
                id = Id,
                name = EmployeeName,
                surname = EmployeeSurname,
                date = PermissionDate,
                permissionType = new {
                    id = PermissionType.Id,
                    text = PermissionType.Description
                }
            };
        }

        #endregion
    }
}