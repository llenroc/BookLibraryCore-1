using Abp.Runtime.Validation;
using MyCompanyName.AbpZeroTemplate.People;
using MyCompanyName.AbpZeroTemplate.People.Dto;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MyCompanyName.AbpZeroTemplate.Tests.People
{
    public class PersonAppService_Tests:AppTestBase
    {
        private readonly IPersonAppService _personAppService;

        public PersonAppService_Tests()
        {
            _personAppService = Resolve<IPersonAppService>();

        }

        [Fact]
        public void Should_Get_All_People_Without_Any_Filter()
        {
            var persons = _personAppService.GetPeople(new GetPeopleInput());
            persons.Items.Count.ShouldBe(2);
        }
        [Fact]
        public void Should_Get_People_With_Filter()
        {
            var persons = _personAppService.GetPeople(
                new GetPeopleInput
                {
                    Filter = "adams"
                }
                );

            persons.Items.Count.ShouldBe(1);
            persons.Items[0].Name.ShouldBe("Douglas");
            persons.Items[0].SurName.ShouldBe("Adams");
        }
        [Fact]
        public async void Should_Create_Person_With_Valid_Arguments()
        {
            await _personAppService.CreatePerson(
                new CreatePersonInput
                {
                    Name="John",
                    SurName="Nash",
                    EmailAddress="john.nash@126.com"
                });

            UsingDbContext(
                context =>
                {
                    var john = context.Persons.FirstOrDefault(p => p.EmailAddress == "john.nash@126.com");
                    john.ShouldNotBe(null);
                    john.Name.ShouldBe("John");
                });
        }

        public async void Should_Not_Create_Person_With_Invalid_Arguments()
        {
            await Assert.ThrowsAsync<AbpValidationException>(
                async () =>
                {
                    await _personAppService.CreatePerson(
                        new CreatePersonInput
                        {
                            Name = "John"
                        }
                        );
                }
                );
        }
    }
}
