

using SQLite;

namespace SQLLITEDemo.MVVM.Model
{
    [Table("Customer")]
    public class Customer
    {
        [ Column("id"), PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [Column ("Name"), Indexed]
        public string Name { get; set; }=string.Empty;
        [Column("address"), MaxLength (100)]
        public string Address { get; set; } = string.Empty;
        [Column("phone"), Unique]
        public string Phone { get; set; } = string.Empty;
        [Column("age")]
        public int Age { get; set; }
        //El Ignore lo que hace es que no se incluya en la base de datos
        [Ignore]
        public bool IsYoung => Age < 18;
    }
}
