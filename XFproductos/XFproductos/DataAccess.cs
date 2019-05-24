using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;
using System.IO;
using System.Net;
namespace XFproductos
{
    class DataAccess : IDisposable
    {
        public SQLiteConnection connections;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connections = new SQLiteConnection(config.Plataforma, Path.Combine(config.DirectorioDB,"Producto.db3"));
            connections.CreateTable<Producto>();
        }

        public void InsertProducto(Producto producto)
        {
            connections.Insert(producto);
        }


        public void UpdateProducto(Producto producto)
        {
            connections.Update(producto);
        }

        public void DeleteProducto(Producto producto)
        {
            connections.Delete(producto);
        }

        public Producto GetProducto(int IDventa)
        {
            return connections.Table<Producto>().FirstOrDefault(c => c.IDventa == IDventa);
        }


        public List<Producto> GetProductos()
        {
            return connections.Table<Producto>().ToList();
        }

        public void Dispose()
        {
            connections.Dispose();
        }
    }
}
