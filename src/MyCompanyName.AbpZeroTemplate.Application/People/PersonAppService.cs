using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Microsoft.EntityFrameworkCore;
using MyCompanyName.AbpZeroTemplate.Authorization;
using MyCompanyName.AbpZeroTemplate.People.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.People
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook)]//20171124添加权限验证
    public class PersonAppService : AbpZeroTemplateAppServiceBase, IPersonAppService
    {
        
        private readonly IRepository<Person> _personRepository;//Person仓储
        private readonly IRepository<Phone,long> _phoneRepository;//Phone仓储

        public PersonAppService(IRepository<Person> personRepository,IRepository<Phone,long> phoneRepository)
        {
            _personRepository = personRepository;//属性注入
            _phoneRepository = phoneRepository;
        }

        public async Task<PhoneInPersonListDto> AddPhone(AddPhoneInput input)
        {
            var person = _personRepository.Get(input.PersonId);
            await _personRepository.EnsureCollectionLoadedAsync(person, p => p.Phones);//确保person的phones导航属性从数据库中加载

            var phone = ObjectMapper.Map<Phone>(input);
            person.Phones.Add(phone);

            //Get auto increment Id of the new Phone by saving to database
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<PhoneInPersonListDto>(phone);

        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_CreatePerson)]
        public async Task CreatePerson(CreatePersonInput input)
        {
            var person = ObjectMapper.Map<Person>(input);
            await _personRepository.InsertAsync(person);
        }
        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_DeletePerson)]
        public async Task DeletePerson(EntityDto input)
        {
            await _personRepository.DeleteAsync(input.Id);
        }

        public async Task DeletePhone(EntityDto<long> input)
        {
            await _phoneRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 根据过滤参数获取People
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ListResultDto<PersonListDto> GetPeople(GetPeopleInput input)
        {
            var people = _personRepository.GetAll()
                .Include(p=>p.Phones)
                .WhereIf(
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
