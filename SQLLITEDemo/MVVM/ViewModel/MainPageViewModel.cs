using Bogus;
using PropertyChanged;
using SQLLITEDemo.MVVM.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;



namespace SQLLITEDemo.MVVM.ViewModel
{

    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel
    {
        public ObservableCollection<Customer> Customers{ get; set; }=new ObservableCollection<Customer>();

        public Customer CurrentCustomer{ get; set; }

        public MainPageViewModel()
        {
            
            CurrentCustomer = GenerateNewCustomer();
            Refresh();
        }
        public Customer GenerateNewCustomer()
        {
           return new Faker<Customer>()
                .RuleFor(c => c.Name, f => f.Person.FullName)
                .RuleFor(c => c.Address, f => f.Person.Address.Street)
                .RuleFor(c=>c.Phone, f=> f.Person.Phone)
                .Generate();
        }

        public ICommand AddorUpdateCommand => new Command(() =>
        {
            App.CustomerRepository.Save(CurrentCustomer);
            App.OrderRepository.Save(new Order { CustomerId = CurrentCustomer.Id, OrderDate = DateTime.Now });
            var orders = App.OrderRepository.GetAll();
            Refresh();
            CurrentCustomer = GenerateNewCustomer();
        });
        private void Refresh()
        {
           
            //Es un metodo que saca los datos de la base de datos y los mete en la lista
            var customersDB = App.CustomerRepository.GetAll();

            Customers.Clear();
            customersDB.ForEach(c=>Customers.Add(c));
            
            //Esto se utilizaria si fuera una List<> Customers.AddRange(custome rsDB);
        }
        public ICommand DeleteCommand => new Command(() =>
        {
            App.CustomerRepository.Delete(CurrentCustomer);
            Refresh();
            CurrentCustomer = GenerateNewCustomer();
           
        });
    }
}
