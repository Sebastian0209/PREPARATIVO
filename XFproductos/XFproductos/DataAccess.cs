using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;
using System.IO;

namespace XFproductos
{
    class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DirectorioDB, "Productos.db3"));
            connection.CreateTable<Producto>();
        }

        public void InsertProducto(Producto producto)
        {
            connection.Insert(producto);
        }


        public void UpdateProducto(Producto producto)
        {
            connection.Update(producto);
        }

        public void DeleteProducto(Producto producto)
        {
            connection.Delete(producto);
        }

        public Producto GetProducto(int IDventa)
        {
            return connection.Table<Producto>().FirstOrDefault(c => c.IDventa == IDventa);
        }


        public List<Producto> GetProductos()
        {
            return connection.Table<Producto>().ToList();
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
