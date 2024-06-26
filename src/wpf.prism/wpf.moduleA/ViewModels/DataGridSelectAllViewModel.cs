using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace wpf.moduleA.ViewModels
{
    public class DataGridSelectAllViewModel : BindableBase
    {
        private ObservableCollection<Person> _people;
        private ObservableCollection<Person> _selectedPeople;
        public ObservableCollection<Person> People
        {
            get => _people;
            set => SetProperty(ref _people, value);
        }
        public ObservableCollection<Person> SelectedPeople
        {
            get => _selectedPeople;
            set => SetProperty(ref _selectedPeople, value);
        }

        public ICommand SelectAllCommand { get; }

        public DataGridSelectAllViewModel()
        {
            People = new ObservableCollection<Person>
            {
                new Person { Name = "John Doe", Age = 30, Email = "john.doe@example.com" },
                new Person { Name = "Jane Smith", Age = 25, Email = "jane.smith@example.com" }
            };

            SelectedPeople = new ObservableCollection<Person>();
            SelectAllCommand = new DelegateCommand(SelectAll);
        }

        private void SelectAll()
        {
            MessageBox.Show(string.Join(",", SelectedPeople.Select(_ => _.Name)));
            // Here, you would implement the logic to select all rows.
            // In this example, we don't need to do anything because the command is used
            // to trigger the selection in the view.
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
