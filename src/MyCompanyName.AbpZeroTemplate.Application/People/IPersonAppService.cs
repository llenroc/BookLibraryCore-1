using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.People.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.People
{
    public interface IPersonAppService:IApplicationService
    {
        /// <summary>
        /// 根据参数获取people集合
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        ListResultDto<PersonListDto> GetPeople(GetPeopleInput input);

        /// <summary>
        /// 添加一个Person
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreatePerson(CreatePersonInput input);

        /// <summary>
        /// 删除一个Person
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeletePerson(EntityDto input);

        /// <summary>
        /// 删除一个Phone
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeletePhone(EntityDto<long> input);
        /// <summary>
        /// 添加一个电话号码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PhoneInPersonListDto> AddPhone(AddPhoneInput input);
    }
}
