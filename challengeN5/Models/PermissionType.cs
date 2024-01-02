using System.ComponentModel.DataAnnotations.Schema;

namespace challengeN5.Models
{
    public class PermissionType : Identificable
    {
        #region constructores

        public PermissionType() { }

        #endregion

        #region propiedades

        public string Description { get; set; }

        #endregion
    }
}