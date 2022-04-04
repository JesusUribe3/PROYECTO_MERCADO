using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PROYECTO_MERCADO.Datos
{
    class Conexion
    {
        SqlConnection con;

        public Conexion() 
        {
            con = new SqlConnection("Server=PC; Database=mercado_db;integrated security=true"); 
        }

        public SqlConnection conectar() 
        {
            try
            {
                con.Open();
                return con;
            } catch (Exception e)
            {
                return null;
            }
            
        }
        public bool desconectar()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
