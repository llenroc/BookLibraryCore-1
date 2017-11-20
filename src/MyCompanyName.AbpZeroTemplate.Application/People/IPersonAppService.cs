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
    }
}
