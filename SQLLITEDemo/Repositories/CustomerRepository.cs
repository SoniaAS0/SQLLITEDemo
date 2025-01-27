using SQLite;
using SQLLITEDemo.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SQLLITEDemo.Repositories
{
    public class CustomerRepository
    {
        private SQLiteConnection _conn = new SQLiteConnection(
            Constants.DatabasePath,
            Constants.Flags
            );

        public string StatusMessage { get; set; } = string.Empty;
        public CustomerRepository()
        {
            _conn.CreateTable<Customer>();

        }


        //Creamos los metodos CRUD
        public void AddOrUpdate(Customer customer)
        {
            //Si la base de datos se corrompiese o diese error interno no nos enterariamos por nuestro codigo ya que no lo controlamos nosotros
            //Por eso todo lo que no controlamso se devuelve con una excepcion
           try
           { 
                if (customer.Id == 0)
                {
                    int rows = _conn.Insert(customer);
                    //Esto nos devuelve un entero y ese entero es el que inserta el objeto, el valor que retorna es el valor de filas que se añaden a la tabla
                    StatusMessage = $"{rows} records added";
                } else
                    {
                      int rows = _conn.Update(customer);
                      StatusMessage=$"{rows} records updated";
                
                     }
            }
            catch (Exception ex)
                {
                    StatusMessage = $"Error: {ex.Message}";
                }
        } 
        public List<Customer> GetAll()
        {
            return _conn.Table<Customer>().ToList();
        }
        //Con lo que se pone entre parentesis pedimos una sentencia sql de lo que quieres que genere en concreto.
        public List<Customer> GetAll(Expression<Func<Customer, bool>>predicate)
        {
            return _conn.Table<Customer>().Where(predicate).ToList();
        }
        public List<Customer> GetByQuery()
        {
            return _conn.Query<Customer>("SELECT * FROM Customers");
        }
        public Customer GetById(int id)
        {   
            //se está devolviendo el primero o nulo donde coincida que el id del customer de la tabla sea igual que el id que le paso como parametro
            return _conn.Table<Customer>().FirstOrDefault(c=>c.Id == id);
        }
        public void Delete(int id)
        {
            try 
            {
                int rows= _conn.Delete<Customer>(id);
                StatusMessage = $"{rows} records deleted";
            }
            catch (Exception ex)
            {

                StatusMessage=$"Error: {ex.Message}";
            }
        }
    }
}

