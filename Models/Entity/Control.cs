using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Enum;

namespace Models.Entity
{
    [Table("Control")]
    public partial class Control : BaseEntity
    {
        public Control()
        {
            Permission = new HashSet<Permission>();
            IsAvailable = true;
        }

        /// <summary>
        /// ���ʿ�����
        /// </summary>
        [Display(Name = "��������")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Display(Name = "����������")]
        public string Controller { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Display(Name = "��������")]
        public string Action { get; set; }

        /// <summary>
        /// ����·��
        /// </summary>
        [Display(Name = "����·��")]
        public string Path { get; set; }

        [Display(Name = "HTTP����ʽ")]
        [Required]
        public HttpMethod HttpMethod { get; set; }

        /// <summary>
        /// �Ƿ����
        /// </summary>
        [Required, DefaultValue(true)]
        public bool IsAvailable { get; set; }

        public int ClientAppId { get; set; }

        public virtual ClientApp ClientApp { get; set; }

        public virtual ICollection<Permission> Permission { get; set; }
    }
}