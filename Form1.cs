using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PROYECTO_MERCADO
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("server=PC ; database = PROYECTO ; integrated security = true");
        private void btnlogin_Click(object sender, EventArgs e)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SELECT USUARIO, PASSWORD FROM password WHERE USUARIO = @vusuario AND PASSWORD = @vpassword", conexion);
            comando.Parameters.AddWithValue("@vusuario",txtusuario.Text);
            comando.Parameters.AddWithValue("@vpassword", txtpassword.Text);

            SqlDataReader lector = comando.ExecuteReader();
            if (lector.Read())
            {
                //conexion.Close();
                Frmprincipal pantalla = new Frmprincipal();
                pantalla.Show();
                MessageBox.Show("Bienvenido");
            }
            
                
            else if (txtusuario.Text == "" || txtpassword.Text == "")
            {
                MessageBox.Show("No se aceptan campos vacios");
            }
            else
                MessageBox.Show("Usuario o contraseña incorrectas", "valide de nuevo");
        }
    }
}
