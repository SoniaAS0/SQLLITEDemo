using SQLLITEDemo.MVVM.View;
using SQLLITEDemo.Repositories;

namespace SQLLITEDemo
{
    public partial class App : Application
    {
        public static CustomerRepository CustomerRepository { get; set; }
        public App(CustomerRepository cr)
        {
            InitializeComponent();

            //al meter en mauiProgram el builder.Services.AddSingleton<CustomerRepository>(); directamente crea una instancia
            CustomerRepository = cr;

            MainPage = new MainPage();
        } 
    }
}
