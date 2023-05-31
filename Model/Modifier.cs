using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace MauiApp3
{
    [Table("Modifiers")]
    public class Modifier
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
