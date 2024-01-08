using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModels;
using WpfApp1.Services;

namespace WpfApp1
{
    public class AppViewModel : ObservableObject
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }

        private NotebookViewModel _bookVM;
        public NotebookViewModel BookVM
        {
            get { return _bookVM; }
            set { OnPropertyChanged(ref _bookVM, value); }
        }

        public AppViewModel()
        {
            var dataService = new MockDataService();
            BookVM = new NotebookViewModel(dataService);
            CurrentView = BookVM;
        }
    }
}
