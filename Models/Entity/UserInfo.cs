using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entity
{
    [Table("UserInfo")]
    public class UserInfo
    {
        public UserInfo()
        {
            UserPermission = new HashSet<UserPermission>();
            Role = new HashSet<Role>();
            UserGroup = new HashSet<UserGroup>();
            Id = Guid.NewGuid();
            LastLoginTime = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        [Display(Name = "�û���"), Required(ErrorMessage = "�û�������Ϊ�գ�")]
        public string Username { get; set; }

        [Display(Name = "����"), Required(ErrorMessage = "��¼���벻��Ϊ�գ�")]
        public string Password { get; set; }

        [Required]
        public string SaltKey { get; set; }

        [Display(Name = "�ֻ�����"), Required(ErrorMessage = "�ֻ����벻��Ϊ�գ�")]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        [Display(Name = "��������"), Required(ErrorMessage = "�����ַ����Ϊ�գ�")]
        public string Email { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public virtual ICollection<UserPermission> UserPermission { get; set; }

        public virtual ICollection<Role> Role { get; set; }

        public virtual ICollection<UserGroup> UserGroup { get; set; }
    }
}