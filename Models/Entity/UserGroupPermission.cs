using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entity
{
    [Table("UserGroupPermission")]
    public partial class UserGroupPermission : BaseEntity
    {
        /// <summary>
        /// �Ƿ���Ȩ��
        /// </summary>
        public bool HasPermission { get; set; }

        [ForeignKey("UserGroup")]
        public int UserGroupId { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual UserGroup UserGroup { get; set; }
    }
}
