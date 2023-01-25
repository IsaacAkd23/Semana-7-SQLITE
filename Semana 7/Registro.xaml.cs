using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana_7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            var datos = new Estudiante
            {
                Nombre = txtNombre.Text,
                Usuario = txtUsuario.Text,
                Contraseña = txtContraseña.Text
            };
            con.InsertAsync(datos);
            txtNombre.Text = "";
            txtContraseña.Text = "";
            txtUsuario.Text = "";
            Navigation.PushAsync(new Login());
        }
    }
}