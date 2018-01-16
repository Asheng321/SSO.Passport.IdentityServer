using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entity
{
    [Table("LoginRecord")]
    public class LoginRecord : BaseEntity
    {
        /// <summary>
        /// �ͻ���IP��ַ
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// ��¼ʱ��
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// ��¼����ʡ��
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// ��ϸ�����ַ
        /// </summary>
        public string PhysicAddress { get; set; }

        [ForeignKey("UserInfo")]
        public Guid UserInfoId { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}