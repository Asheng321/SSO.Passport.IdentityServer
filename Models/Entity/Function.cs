using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Enum;

namespace Models.Entity
{
    [Table("Function")]
    public class Function
    {
        public Function()
        {
            IsAvailable = true;
        }
        [Key]
        public int Id { get; set; }

        [Display(Name = "��������")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "����������")]
        [Required]
        public string Controller { get; set; }

        [Display(Name = "��������")]
        [Required]
        public string Action { get; set; }

        [Display(Name = "ͼ��URL��ַ")]
        public string IconUrl { get; set; }

        [Display(Name = "class��ʽ")]
        public string CssStyle { get; set; }

        [Display(Name = "HTTP����ʽ")]
        [Required]
        public HttpMethod HttpMethod { get; set; }

        public bool IsAvailable { get; set; }

        public int ParentId { get; set; }

        [Display(Name = "����Ȩ��")]
        [ForeignKey("Permission")]
        public int PermissionId { get; set; }

        [Display(Name = "Ȩ������")]
        public FunctionType FunctionType { get; set; }

        public virtual Permission Permission { get; set; }
    }
}