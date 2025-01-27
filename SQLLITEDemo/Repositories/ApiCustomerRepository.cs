
using SQLLITEDemo.Abstractions;
using SQLLITEDemo.MVVM.Model;
using System.Linq.Expressions;

namespace SQLLITEDemo.Repositories
{
    public class ApiCustomerRepository<T> : IBaseRepository<Customer> where T : TableData, new()
    {
        private _baseUrl = ;
        public void Delete(Customer item)
        {
           
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Customer? GetByExpression(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Customer? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
