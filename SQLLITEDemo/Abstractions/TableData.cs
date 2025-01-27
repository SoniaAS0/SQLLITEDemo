using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLITEDemo.Abstractions
{
    //Hago esta clase abstracta por que no quiero que nadie haga instancias de TableData por que se supone que solo sirve para heredar de ella
    public abstract class TableData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

    }
}
