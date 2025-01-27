using SQLLITEDemo.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLITEDemo.MVVM.Model
{
    public class Order : TableData
    {

        
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
