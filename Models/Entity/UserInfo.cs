using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entity
{
    [Table("UserInfo")]
    public partial class UserInfo
    {
        public UserInfo()
        {
            Id = Guid.NewGuid();
            UserPermission = new HashSet<UserPermission>();
            Role = new HashSet<Role>();
            UserGroup = new HashSet<UserGroup>();
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// �û���
        /// </summary>
        [Display(Name = "�û���"), Required(ErrorMessage = "�û�������Ϊ�գ�")]
        public string Username { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Display(Name = "����"), Required(ErrorMessage = "��¼���벻��Ϊ�գ�")]
        public string Password { get; set; }

        /// <summary>
        /// ���������
        /// </summary>
        [Required]
        public string SaltKey { get; set; }

        /// <summary>
        /// �ֻ�����
        /// </summary>
        [StringLength(11)]
        [Display(Name = "�ֻ�����"), Required(ErrorMessage = "�ֻ����벻��Ϊ�գ�")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Display(Name = "��������"), Required(ErrorMessage = "�����ַ����Ϊ�գ�")]
        public string Email { get; set; }

        /// <summary>
        /// �Ƿ���Ԥ���˻�
        /// </summary>
        [DefaultValue(false)]
        public bool IsPreset { get; set; }

        /// <summary>
        /// �Ƿ������ù���Ա
        /// </summary>
        [DefaultValue(false)]
        public bool IsMaster { get; set; }

        public int ClientAppId { get; set; }

        [ForeignKey("ClientAppId")]
        public virtual ClientApp ClientApp { get; set; }

        public virtual ICollection<UserPermission> UserPermission { get; set; }

        public virtual ICollection<Role> Role { get; set; }

        public virtual ICollection<UserGroup> UserGroup { get; set; }
        public virtual ICollection<LoginRecord> LoginRecords { get; set; }
    }
}