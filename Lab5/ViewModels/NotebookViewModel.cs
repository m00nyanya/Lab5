using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class NotebookViewModel: ObservableObject
    {
        private IContactDataService _service;
        private ContactsViewModel contactsvm;
        public ContactsViewModel ContactsVM
        {
            get { return contactsvm; }
            set { OnPropertyChanged(ref contactsvm, value); }
        }
        public ICommand LoadContactsCommand { get; private set; }
        public NotebookViewModel(IContactDataService service)
        {
            ContactsVM = new ContactsViewModel(service);
            _service = service;
            LoadContactsCommand = new RelayCommand(LoadContacts);
        }

        private void LoadContacts()
        {
            ContactsVM.LoadContacts(_service.GetContacts());
        }
    }
}
