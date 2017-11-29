﻿using MyCompanyName.AbpZeroTemplate.EntityFrameworkCore;
using MyCompanyName.AbpZeroTemplate.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Migrations.Seed.Host
{
    public class InitialPeopleCreator
    {
        private readonly AbpZeroTemplateDbContext _context;

        public InitialPeopleCreator(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var douglas = _context.Persons.FirstOrDefault(p => p.EmailAddress == "douglas.adams@fortytwo.com");
            if(douglas==null)
            {
                _context.Persons.Add(new Person
                {
                    Name = "Douglas",
                    SurName = "Adams",
                    EmailAddress = "douglas.adams@fortytwo.com",
                    Phones = new List<Phone>
                                {
                                    new Phone {Type = PhoneType.Home, Number = "1112242"},
                                    new Phone {Type = PhoneType.Mobile, Number = "2223342"}
                                }

                });

            }

            var asimov = _context.Persons.FirstOrDefault(p => p.EmailAddress == "isaac.asimov@foundation.org");
            if (asimov == null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Isaac",
                        SurName = "Asimov",
                        EmailAddress = "isaac.asimov@foundation.org",
                        Phones = new List<Phone>
                                {
                                    new Phone {Type = PhoneType.Home, Number = "8889977"}
                                }

                    });
            }

        }
    }
}
