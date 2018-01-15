using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entity
{
    [Table("UserGroup")]
    public partial class UserGroup : BaseEntity
    {
        public UserGroup()
        {
            UserGroupPermission = new HashSet<UserGroupPermission>();
            UserInfo = new HashSet<UserInfo>();
        }

        [Required, Display(Name = "�û���")]
        public string GroupName { get; set; }

        [Display(Name = "����id")]
        public int? ParentId { get; set; }

        //[ForeignKey("ClientAppId")]
        public int ClientAppId { get; set; }

        public virtual ClientApp ClientApp { get; set; }

        public virtual ICollection<UserGroupPermission> UserGroupPermission { get; set; }

        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}
