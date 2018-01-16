using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entity
{
    [Table("Menu")]
    public partial class Menu : BaseEntity
    {
        public Menu()
        {
            Children = new HashSet<Menu>();
            Permission = new HashSet<Permission>();
        }

        [Display(Name = "�˵�����")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "�˵�·��")]
        [Required, DefaultValue("/")]
        public string Url { get; set; }

        [Display(Name = "ͼ��URL��ַ")]
        public string IconUrl { get; set; }

        [Display(Name = "class��ʽ")]
        public string CssStyle { get; set; }

        /// <summary>
        /// �Ƿ����
        /// </summary>
        [Required]
        public string IsAvailable { get; set; }

        /// <summary>
        /// �����˵�
        /// </summary>
        public int? ParentId { get; set; }

        public int ClientAppId { get; set; }

        public virtual ClientApp ClientApp { get; set; }

        public virtual ICollection<Menu> Children { get; set; }

        public virtual Menu Parent { get; set; }

        public virtual ICollection<Permission> Permission { get; set; }
    }
}