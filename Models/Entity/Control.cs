using System.Collections.Generic;
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
        }


        [Display(Name = "��������")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "����������")]
        [Required]
        public string Controller { get; set; }

        [Display(Name = "��������")]
        [Required]
        public string Action { get; set; }

        [Display(Name = "HTTP����ʽ")]
        [Required]
        public HttpMethod HttpMethod { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        public virtual ICollection<Permission> Permission { get; set; }
    }
}
