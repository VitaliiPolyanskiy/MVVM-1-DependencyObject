using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MVVM
{
    class MainWindowViewModel : DependencyObject
    {
        private static readonly DependencyProperty NameProperty;
        private static readonly DependencyProperty SurnameProperty;
        private static readonly DependencyProperty IsButtonEnabledProperty;
        private static readonly DependencyProperty PersonsProperty;

        static MainWindowViewModel()
        {
            NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(MainWindowViewModel));
            SurnameProperty = DependencyProperty.Register("Surname", typeof(string), typeof(MainWindowViewModel));
            IsButtonEnabledProperty = DependencyProperty.Register("IsButtonEnabled", typeof(bool), typeof(MainWindowViewModel));
            PersonsProperty = DependencyProperty.Register("Persons", typeof(ObservableCollection<Person>), typeof(MainWindowViewModel));
        }

        public MainWindowViewModel()
        {
            Name = "Имя";
            Surname = "Фамилия";
            IsButtonEnabled = true;
            Persons = new ObservableCollection<Person>();
    }

        public string Surname
        {
            get { return (string)GetValue(SurnameProperty); }
            set { SetValue(SurnameProperty, value); }
        }

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public bool IsButtonEnabled
        {
            get { return (bool)GetValue(IsButtonEnabledProperty); }
            set { SetValue(IsButtonEnabledProperty, value); }
        }

        public ObservableCollection<Person> Persons
        {
            get { return (ObservableCollection<Person>)GetValue(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }
      

        private DelegateCommand _AddCommand;
        public ICommand ButtonClick
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new DelegateCommand(Add, CanAdd);
                }
                return _AddCommand;
            }
        }
        private void Add(object o)
        {
            Persons.Add(new Person() { Name = this.Name, Surname = this.Surname });
            Name = string.Empty;
            Surname = string.Empty;
        }

        private bool CanAdd(object o)
        {
            if (Name == "" || Surname == "")
                return false;
            return true;
        }
    }
}
