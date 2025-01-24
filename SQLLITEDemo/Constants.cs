using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLITEDemo
{
    //Convertimos la clase en estatica, 
    //La clase estatica es la que se llama directamente con su nombre y no necesita un new, ademas sus metodos se pueden llamar directamente
    public static class Constants
    {
        public const string DatabaseFileName = "Sqlite.db3";

        //Esta seteando el comportamiento de la base de datos en la que se podrá hacer todas esas instrucciones
        //El codigo under serian binarios 0001 +0010+0100 los cuales se suman y al ser 1, 2, 4 nos darían 0111 o 7 que es como se comportará la base de datos
        public const SQLiteOpenFlags Flags = 
            SQLiteOpenFlags.Create | 
            SQLiteOpenFlags.ReadWrite | 
            SQLiteOpenFlags.SharedCache;
        public static string DatabasePath
        {
            get
            {
                return Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
            }
        }
    }
}
