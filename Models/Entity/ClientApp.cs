using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entity
{
    [Table("ClientApp")]
    public partial class ClientApp : BaseEntity
    {
        public ClientApp()
        {
            UserGroup = new HashSet<UserGroup>();
            UserInfo = new HashSet<UserInfo>();
            Controls = new HashSet<Control>();
            Menus = new HashSet<Menu>();
            Permissions = new HashSet<Permission>();
            Roles = new HashSet<Role>();
            Available = true;
        }

        /// <summary>
        /// �ͻ�����ϵͳ����
        /// </summary>
        [Required]
        public string AppName { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// �ͻ�����ϵͳΨһ��ʶ
        /// </summary>
        [Required]
        public string AppId { get; set; }

        /// <summary>
        /// �ͻ�����ϵͳ��Կ
        /// </summary>
        [Required]
        public string AppSecret { get; set; }

        /// <summary>
        /// �Ƿ����
        /// </summary>
        [DefaultValue(true)]
        public bool Available { get; set; }

        /// <summary>
        /// �Ƿ���Ԥ��
        /// </summary>
        [DefaultValue(false)]
        public bool Preset { get; set; }

        public virtual ICollection<UserGroup> UserGroup { get; set; }
        public virtual ICollection<Control> Controls { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}