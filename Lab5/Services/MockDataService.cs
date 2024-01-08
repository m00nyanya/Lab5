using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class MockDataService : IContactDataService
    {
        private IEnumerable<Contact> contacts;

        public MockDataService()
        {
            contacts = new List<Contact>()
            {
                new Contact
                {
                    Nickname = "Linnie",
                    Name = "Linna",
                    Surname = "Clarks",
                    Phone = "33-999-111",
                    Email = "linnieclark@gmail.com",
                    Bday = "04.11.1990"
                },
                new Contact
                {
                    Nickname = "Hel",
                    Name = "Helen",
                    Surname = "Cox",
                    Phone = "66-966-121",
                    Email = "helen_lovedogs@gmail.com",
                    Bday = "10.10.1997"
                },
                new Contact
                {
                    Nickname = "Wife",
                    Name = "Victoria",
                    Surname = "Brandt",
                    Phone = "69-700-173",
                    Email = "iwont_answer_tothis@gmail.com",
                    Bday = "08.07.1999"
                }
            };
        }
        public IEnumerable<Contact> GetContacts()
        {
            return contacts;
        }

        public void Save(IEnumerable<Contact> contacts)
        {
            this.contacts = contacts;
        }
    }
}
