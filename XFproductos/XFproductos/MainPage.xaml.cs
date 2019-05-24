using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite.Net;
namespace XFproductos
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            nuevoButton.Clicked += NuevoButton_Clicked;
            using (var datos = new DataAccess())
            {
                datosListView.ItemsSource = datos.GetProductos();
            }
        }

        public  void NuevoButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProductoVendidoEntry.Text))
            {
                
                ProductoVendidoEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TotalEntry.Text))
            {

                TotalEntry.Focus();
                return;
            }
            Producto producto = new Producto
            {
                ProductoVendido = ProductoVendidoEntry.Text,
                Total = decimal.Parse(TotalEntry.Text),
                Fecha = FechaDatePicker.Date

            };


            using (var datos = new DataAccess())
            {
                datos.InsertProducto(producto);
                datosListView.ItemsSource = datos.GetProductos();
            }

               ProductoVendidoEntry.Text = string.Empty;
               TotalEntry.Text = string.Empty;
               FechaDatePicker.Date = DateTime.Now;



        }
    }
}
