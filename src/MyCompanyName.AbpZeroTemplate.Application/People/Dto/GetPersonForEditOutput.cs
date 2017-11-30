using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.People.Dto
{
    [AutoMapFrom(typeof(Person))]
    public class GetPersonForEditOutput: FullAuditedEntityDto
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public string EmailAddress { get; set; }
        public Collection<PhoneInPersonListDto> Phones { get; set; }
    }
}
