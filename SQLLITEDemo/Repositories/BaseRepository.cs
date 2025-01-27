

using SQLite;
using SQLLITEDemo.Abstractions;
using System.Linq;
using System.Linq.Expressions;

namespace SQLLITEDemo.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
    {

        private SQLiteConnection _conn = new SQLiteConnection(
           Constants.DatabasePath,
           Constants.Flags
           );
        public string StatusMessage { get; set; } = string.Empty;

        public BaseRepository()
        {
            _conn.CreateTable<T>();
        }
        public void Delete(T item)
        {
            try
            {
                int rows = _conn.Delete(item);
                // int rows = _conn.Delete<T>(item.Id);
                StatusMessage = $"{rows} records deleted";
            }
            catch (Exception ex)
            {
                 
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public void Dispose()
        {
            _conn.Close();
        }

        public List<T> GetAll()
        {
            return _conn.Table<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _conn.Table<T>().Where(predicate).ToList();
        }

        public T? GetByExpression(Expression<Func<T, bool>> predicate)
        {
            return _conn.Table<T>().Where(predicate).FirstOrDefault();  
        }

        public T? GetById(int id)
        {
            return _conn.Table<T>().FirstOrDefault(c => c.Id == id);
        }

        public void Save(T item)
        {
            try
            {
                if (item.Id == 0)
                {
                    int rows = _conn.Insert(item);
                    //Esto nos devuelve un entero y ese entero es el que inserta el objeto, el valor que retorna es el valor de filas que se añaden a la tabla
                    StatusMessage = $"{rows} records added";
                }
                else
                {
                    int rows = _conn.Update(item);
                    StatusMessage = $"{rows} records updated";

                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
    }
}
