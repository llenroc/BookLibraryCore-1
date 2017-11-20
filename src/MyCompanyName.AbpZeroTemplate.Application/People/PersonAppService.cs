using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using MyCompanyName.AbpZeroTemplate.People.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.People
{
    public class PersonAppService : AbpZeroTemplateAppServiceBase, IPersonAppService
    {
        
        private readonly IRepository<Person> _personRepository;//Person仓储

        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;//属性注入
        }

        public async Task CreatePerson(CreatePersonInput input)
        {
            var person = ObjectMapper.Map<Person>(input);
            await _personRepository.InsertAsync(person);
        }

        /// <summary>
        /// 根据过滤参数获取People
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ListResultDto<PersonListDto> GetPeople(GetPeopleInput input)
        {
            var people = _personRepository.GetAll().WhereIf(
                !input.Filter.IsNullOrEmpty(),
                p => p.Name.Contains(input.Filter) ||
                p.SurName.Contains(input.Filter) ||
                p.EmailAddress.Contains(input.Filter)
                )
                .OrderBy(p => p.Name)
                .ThenBy(p => p.SurName)
                .ToList();

            return new ListResultDto<PersonListDto>(ObjectMapper.Map<List<PersonListDto>>(people));
        }
    }
}
