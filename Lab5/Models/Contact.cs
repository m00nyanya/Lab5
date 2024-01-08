using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Contact: ObservableObject
    {
        private string nickname;
        public string Nickname
        {

            get { return nickname; }
            set { OnPropertyChanged(ref nickname, value); }
        }
        private string name;
        public string Name
        {

            get { return name; }
            set { OnPropertyChanged(ref name, value); }
        }
        private string surname;
        public string Surname
        {

            get { return surname; }
            set { OnPropertyChanged(ref surname, value); }
        }
        private string phone;
        public string Phone
        {

            get { return phone; }
            set { OnPropertyChanged(ref phone, value); }
        }
        private string email;
        public string Email
        {

            get { return email; }
            set { OnPropertyChanged(ref email, value); }
        }
        private string bday;
        public string Bday
        {

            get { return bday.ToString(); }
            set { OnPropertyChanged(ref bday, value); }
        }

    }
}
