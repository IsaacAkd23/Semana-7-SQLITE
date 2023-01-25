using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana_7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection cont;
        public Login()
        {
            InitializeComponent();
            cont = DependencyService.Get<Database>().GetConnection();
        }

        public static IEnumerable<Estudiante> Select_Where(SQLiteConnection db, string usuario, string contraseña)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where usuario=? and Contraseña=?",usuario, contraseña);
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = Select_Where(db, txtUsuario.Text, txtContraseña.Text);
                if(resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "Usuario o Contraseña Incorrectos", "Cerrar");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message,"Cerrar");
            }
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}