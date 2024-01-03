using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace challengeN5.Models
{
    public class PermissionType : Identificable
    {
        #region constructors

        public PermissionType() { }

        #endregion

        #region properties

        public string Description { get; set; }

        #endregion

        #region methods
        public object FormatForFront()
        {
            return new
            {
                id = Id,
                text = Description
            };
        }
        #endregion
    }
}