

using System.Linq.Expressions;

namespace SQLLITEDemo.Abstractions
{
    //Al poner la <T> le estamos aplicando un "generico" que haremos en vez de ponerle directamente un generico concreto como <Customer>
    //La interface IBaseRepository cuando se cree el tipo que se ponga entre <> tiene que HEREDAR de TableData con constructor vacío
    public interface IBaseRepository<T> : IDisposable where T : TableData, new()
    {
        //Se refiere a AddOrUpdate
        void Save(T item);
        void Delete(T item);
        T? GetById(int id);
        List<T> GetAll();
        T? GetByExpression(Expression<Func<T, bool>> predicate);
        List<T> GetAll(Expression<Func<T, bool>> predicate);
    }
}
