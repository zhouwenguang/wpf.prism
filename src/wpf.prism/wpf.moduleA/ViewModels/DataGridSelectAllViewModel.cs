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
        private ICommand _rowSelectionChangedCommand;

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
        public ICommand RowSelectionChangedCommand => _rowSelectionChangedCommand ??= new DelegateCommand<Person>(OnRowSelectionChanged);

        public DataGridSelectAllViewModel()
        {
            People = new ObservableCollection<Person>
            {
                new Person { Name = "John Doe", Age = 30, Email = "john.doe@example.com" , IsSelected=false },
                new Person { Name = "Jane Smith", Age = 25, Email = "jane.smith@example.com", IsSelected=false }
            };

            SelectedPeople = new ObservableCollection<Person>();

            SelectAllCommand = new DelegateCommand(SelectAll);
        }

        private void SelectAll()
        {
            SelectedPeople.Clear();

            foreach (Person person in People)
            {
                person.IsSelected = true;
                SelectedPeople.Add(person);
            }

            MessageBox.Show(string.Join(",", SelectedPeople.Select(_ => _.Name)));
            // Here, you would implement the logic to select all rows.
            // In this example, we don't need to do anything because the command is used
            // to trigger the selection in the view.
        }

        private void OnRowSelectionChanged(Person person)
        {
            foreach (Person personItem in People)
            {
                personItem.IsSelected = false;
                SelectedPeople.Add(personItem);
            }
            // 处理行选择变化的逻辑
            // 在这里可以根据需要更新其他视图或执行其他操作
        }
    }


}

public class Person : BindableBase
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    private bool _isSelected;
    public bool IsSelected
    {
        get => _isSelected;
        set => SetProperty(ref _isSelected, value);
    }
}