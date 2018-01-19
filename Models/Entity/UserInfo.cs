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
            RegisterTime = DateTime.Now;
            LastLoginTime = RegisterTime;
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
        [Display(Name = "�ֻ�����")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Display(Name = "��������")]
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

        /// <summary>
        /// ����״̬
        /// </summary>
        [DefaultValue(false)]
        public bool Locked { get; set; }

        /// <summary>
        /// �û�ͷ��
        /// </summary>
        public string Avatar { get; set; }


        /// <summary>
        /// ע��ʱ��
        /// </summary>
        public DateTime RegisterTime { get; set; }

        /// <summary>
        /// ����¼ʱ��
        /// </summary>
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// AccessKey
        /// </summary>
        public string AccessKey { get; set; }

        public virtual ICollection<ClientApp> ClientApp { get; set; }

        public virtual ICollection<UserPermission> UserPermission { get; set; }

        public virtual ICollection<Role> Role { get; set; }

        public virtual ICollection<UserGroup> UserGroup { get; set; }
        public virtual ICollection<LoginRecord> LoginRecords { get; set; }
    }
}