using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.People
{
    [Table("BLPersons")]
    public class Person :FullAuditedEntity
    {
        public const int MaxNameLength = 32;
        public const int MaxSurnameLength = 32;
        public const int MaxEmailAddressLength = 255;

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(MaxNameLength)]
        public virtual string Name { get; set; }

        /// <summary>
        /// SruName
        /// </summary>
        [Required]
        [MaxLength(MaxSurnameLength)]
        public virtual string SurName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [MaxLength(MaxEmailAddressLength)]
        public virtual string EmailAddress { get; set; }

        /// <summary>
        /// 电话号码列表
        /// </summary>
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
