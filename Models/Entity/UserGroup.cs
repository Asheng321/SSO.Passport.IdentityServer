using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entity
{
    [Table("UserGroup")]
    public class UserGroup
    {
        public UserGroup()
        {
            UserGroupPermission = new HashSet<UserGroupPermission>();
            UserInfo = new HashSet<UserInfo>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string GroupName { get; set; }

        public int? ParentId { get; set; }


        public virtual ICollection<UserGroupPermission> UserGroupPermission { get; set; }


        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}