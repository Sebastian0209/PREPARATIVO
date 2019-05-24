using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;
using System.Linq;
using System.Threading.Tasks;


namespace XFproductos
{
    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int IDventa { get; set; }
        public string ProductoVendido { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }



        // Para que lisste los productos

        public override string ToString()
        {
            return string.Format(" {0} {1} {2} {3} ", IDventa, ProductoVendido, Total, Fecha);

        }

    }
}
