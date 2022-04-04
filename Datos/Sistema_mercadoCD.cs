using PROYECTO_MERCADO.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace PROYECTO_MERCADO.Datos
{
    class Sistema_mercadoCD
    {
        public static bool crear(Mercado e) 
        
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "insert into tb_sistem_mercado values ('"+e.Codigo+"', '"+e.Nombre_producto+"', '"+e.Marca+"', "+e.Cantidad+", "+e.Precio+", '"+e.Tienda+"', '"+e.Fecha_date+"')";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    return true;
                }
                else return false;

                con.desconectar();

                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }
        public static bool editar (Mercado e)

        {
            try
            {
                Conexion con = new Conexion();
                string sql = "UPDATE tb_sistem_mercado SET codigo =  '" + e.Codigo + "', nombre_product = '" + e.Nombre_producto + "', marca = '" + e.Marca + "',cantidad = " + e.Cantidad + ", precio = " + e.Precio + ", tienda = '" + e.Tienda + "', fecha = '" + e.Fecha_date + "'WHERE codigo ='"+e.Codigo + "'";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    con.desconectar();
                    return true;
                }
                else
                {

                    con.desconectar();
                    return false;
                }
                    

                

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool eliminar (string codigo)

        {
            try
            {
                Conexion con = new Conexion();
                string sql = "DELETE tb_sistem_mercado WHERE codigo ='" + codigo+ "'";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    con.desconectar();
                    return true;
                }
                else
                {

                    con.desconectar();
                    return false;
                }




                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static DataTable listar()

        {
            try
            {
                Conexion con = new Conexion();
                string sql = "SELEC * FROM tb_sistem_mercado";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dt = new DataTable();
                dt.Load(dr);

                
                con.desconectar();

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Mercado consultar(string codigo)

        {
            try
            {
                Conexion con = new Conexion();
                string sql = "SELEC * FROM tb_sistem_mercado WHERE codigo = '"+codigo+"'";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                SqlDataReader dr = comando.ExecuteReader();
                Mercado em = new Mercado();
                if (dr.Read())
                {
                    em.Codigo = dr["codigo"].ToString();
                    em.Nombre_producto = dr["nombre_producto"].ToString();
                    em.Marca = dr["marca"].ToString();
                    em.Cantidad = Convert.ToInt32 (dr["codigo"].ToString());
                    em.Precio = Convert.ToInt32(dr["codigo"].ToString());
                    em.Tienda = dr["tienda"].ToString();
                    em.Fecha_date = dr["fecha"].ToString();
                    con.desconectar();
                    return em;
                }
                else
                {
                    con.desconectar();
                    return null;
                }
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
