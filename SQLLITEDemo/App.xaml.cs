using SQLLITEDemo.Abstractions;
using SQLLITEDemo.MVVM.Model;
using SQLLITEDemo.MVVM.View;
using SQLLITEDemo.Repositories;

namespace SQLLITEDemo
{
    public partial class App : Application
    {
        // public static CustomerRepository CustomerRepository { get; set; }
        public static IBaseRepository<Customer> CustomerRepository { get; set; }
        public static IBaseRepository<Order> OrderRepository { get; set; }
        public App(IBaseRepository<Customer> cr,IBaseRepository<Order> or)
        {
            InitializeComponent();

            //al meter en mauiProgram el builder.Services.AddSingleton<CustomerRepository>(); directamente crea una instancia
            CustomerRepository = cr;
            OrderRepository = or;
            MainPage = new MainPage();
        } 
    }
}
