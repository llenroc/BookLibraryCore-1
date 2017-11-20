using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.People.Dto
{
    [AutoMapTo(typeof(Person))]
    public class CreatePersonInput
    {
        [Required]
        [MaxLength(Person.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(Person.MaxSurnameLength)]
        public string SurName { get; set; }

        [Required]
        [MaxLength(Person.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}
