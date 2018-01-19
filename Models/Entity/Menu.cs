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
            IsAvailable = true;
        }

        /// <summary>
        /// �˵���
        /// </summary>
        [Display(Name = "�˵�����")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// �˵�URL
        /// </summary>
        [Display(Name = "�˵�Url")]
        [DefaultValue("/")]
        public string Url { get; set; }

        /// <summary>
        /// ǰ��·�ɣ�Ϊangular��vue���ṩ
        /// </summary>
        [Display(Name = "ǰ��·�ɣ�Ϊangular��vue���ṩ")]
        public string Route { get; set; }

        /// <summary>
        /// ǰ��·������Ϊangular��vue���ṩ
        /// </summary>
        [Display(Name = "ǰ��·������Ϊangular��vue���ṩ")]
        public string RouteName { get; set; }

        /// <summary>
        /// ͼ��URL��ַ
        /// </summary>
        [Display(Name = "ͼ��URL��ַ")]
        public string IconUrl { get; set; }

        /// <summary>
        /// class��ʽ
        /// </summary>
        [Display(Name = "class��ʽ")]
        public string CssStyle { get; set; }

        /// <summary>
        /// �Ƿ����
        /// </summary>
        [Required]
        public bool IsAvailable { get; set; }

        /// <summary>
        /// �����
        /// </summary>
        public int Sort { get; set; }

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