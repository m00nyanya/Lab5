using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class ContactsViewModel: ObservableObject
    {
        private Contact selected;
        public ICommand EditCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public Contact SelectedContact
        {
            get { return selected; }
            set{OnPropertyChanged(ref selected, value);}
        }
        private bool _isEditMode;
        public bool IsEditMode
        {
            get { return _isEditMode; }
            set
            {
                OnPropertyChanged(ref _isEditMode, value);
                OnPropertyChanged("IsDisplayMode");
            }
        }

        public bool IsDisplayMode
        {
            get { return !_isEditMode; }
        }

        public ObservableCollection<Contact> Contacts { get; private set; }
        private List<Contact> _contacts;
        private IContactDataService service;

        public ContactsViewModel(IContactDataService dataService)
        {
            service = dataService;
            _contacts = dataService.GetContacts().ToList();
            EditCommand = new RelayCommand(Edit, CanEdit);
            SaveCommand = new RelayCommand(Save, IsEdit);
            AddCommand = new RelayCommand(Add);
        }
        private bool IsEdit()
        {
            return IsEditMode;
        }
        private void Save()
        {
            service.Save(Contacts);
            IsEditMode = false;
            OnPropertyChanged("SelectedContact");
        }
        private void Add()
        {
            var newContact = new Contact
            {
                Nickname = "Nick",
                Name = "Name",
                Phone = "00-000-000",
                Email = "namesurname@gmail.com",
                Bday = " "
            };

            Contacts.Add(newContact);
            _contacts.Add(newContact);
            SelectedContact = newContact;
            CanEdit();
        }

        private bool CanEdit()
        {
            if (SelectedContact == null)
                return false;

            return !IsEditMode;
        }

        private void Edit()
        {
            IsEditMode = true;
        }
        public void LoadContacts(IEnumerable<Contact> contacts)
        {
            Contacts = new ObservableCollection<Contact>(contacts);
            OnPropertyChanged("Contacts");
        }

    }
}
