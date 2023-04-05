using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataGridView.Model;

namespace DataGridView.ViewModel
{
    public class WinMainViewModel : ObservableObject
    {
        public WinMainViewModel()
        {
            employees = new List<Employee>(Employee.FakeMany(10));
            CollectionView = CollectionViewSource.GetDefaultView(employees);
            CollectionView.Filter = (item) =>
            {
                if (string.IsNullOrEmpty(FilterText)) return true;

                var em  = item as Employee;
                return em != null && (em.FirstName.Contains(FilterText) || em.LastName.Contains(FilterText));
            };
        }

        private readonly List<Employee> employees;
        
        private ICollectionView collectionView;
        public ICollectionView CollectionView
        {
            get { return collectionView; }
            set { SetProperty(ref collectionView, value); }
        }
        
        private string filterText;
        public string FilterText
        {
            get { return filterText; }
            set { SetProperty(ref filterText, value); }
        }

        public void OnFilterTextChanged()
        {
            CollectionView.Refresh();
        }

        public ICommand AddNewEmployeeCommand
        {
            get { return new RelayCommand(AddNewEmployee); }
        }
        
        public void AddNewEmployee()
        {
            employees.Add(Employee.FakeOne());
            CollectionView.Refresh();
        }
    }
}
