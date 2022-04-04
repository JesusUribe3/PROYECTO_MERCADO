using PROYECTO_MERCADO.Datos;
using PROYECTO_MERCADO.Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_MERCADO
{
    public partial class Frmprincipal : Form
    {
        public Frmprincipal()
        {
            InitializeComponent();
        }

        private void lblprincipal_Click(object sender, EventArgs e)
        {

        }

        private void btncrear_Click(object sender, EventArgs e)
        {
            int cantidad = 0;
            float precio = 0;
            if (txtcodigo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un codigo");

            }
            else if (txtproducto.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un producto");
            }
            else if (txtmarca.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una marca");
            }
            

            else if (!int.TryParse(txtcantidad.Text,out cantidad) && (txtcantidad.Text == ""))
            {
                MessageBox.Show("Debe ingresar un valor numerico o campo vacio");
            }
            else if (!float.TryParse(txtprecio.Text, out precio) && (txtprecio.Text == ""))
            {
                MessageBox.Show("Debe ingresar un valor numerico o campo vacio");
            }
            else if (txttienda.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una tienda");
            }
            else 
            {
                try { 
                Mercado em = new Mercado();
                em.Codigo = txtcodigo.Text.Trim().ToUpper();
                em.Nombre_producto = txtproducto.Text.Trim().ToUpper();
                em.Marca = txtmarca.Text.Trim().ToUpper();
                em.Cantidad = Convert.ToInt32(txtcantidad.Text.Trim());
                em.Precio = Convert.ToInt32(txtprecio.Text.Trim());
                em.Tienda = txttienda.Text.Trim().ToUpper();
                    em.Fecha_date = datefecha.Value.Year + "-" + datefecha.Value.Month + "-" + datefecha.Value.Day;

                    if (Sistema_mercadoCD.crear(em))
                    {
                        llenarGrid();
                        limpiarcampos();
                        MessageBox.Show("Producto guardado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("El producto no se pudo guardar");
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void llenarGrid()
        {
            DataTable datos =  Sistema_mercadoCD.listar();
            if(datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            } 
            else
            {
                dglista.DataSource = datos.DefaultView;
            }
        }
        private void limpiarcampos()
        {
            txtcodigo.Text = "";
            txtproducto.Text = "";
            txtmarca.Text = "";
            txtcantidad.Text = "";
            txtprecio.Text = "";
            txttienda.Text = "";
            datefecha.Text = "";
        }
        private void Frmprincipal_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        bool consultado = false;
        private void btnconsultar_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un codigo");

            }
            else 
            {
                Mercado mer = Sistema_mercadoCD.consultar(txtcodigo.Text.Trim());
                if (mer== null)
                {
                    MessageBox.Show("No existe el producto con codigo"+txtcodigo.Text);
                    limpiarcampos();
                    consultado = false;
                }
                else
                {
                    txtcodigo.Text = mer.Codigo ;
                    txtproducto.Text = mer.Nombre_producto;
                    txtmarca.Text = mer.Marca;
                    txtcantidad.Text = mer.Cantidad.ToString();
                    txtprecio.Text = mer.Precio.ToString();
                    txttienda.Text = mer.Tienda;
                    datefecha.Text = mer.Fecha_date ;
                    consultado = true;
                }
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            
                int cantidad = 0;
                float precio = 0;
            if (consultado == false)
            {
                MessageBox.Show("Debe consultar el producto");

            }
            else if (txtcodigo.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar un codigo");

                }
                else if (txtproducto.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar un producto");
                }
                else if (txtmarca.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar una marca");
                }


                else if (!int.TryParse(txtcantidad.Text, out cantidad) && (txtcantidad.Text == ""))
                {
                    MessageBox.Show("Debe ingresar un valor numerico o campo vacio");
                }
                else if (!float.TryParse(txtprecio.Text, out precio) && (txtprecio.Text == ""))
                {
                    MessageBox.Show("Debe ingresar un valor numerico o campo vacio");
                }
                else if (txttienda.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar una tienda");
                }
                else
                {
                    try
                    {
                        Mercado em = new Mercado();
                        em.Codigo = txtcodigo.Text.Trim().ToUpper();
                        em.Nombre_producto = txtproducto.Text.Trim().ToUpper();
                        em.Marca = txtmarca.Text.Trim().ToUpper();
                        em.Cantidad = Convert.ToInt32(txtcantidad.Text.Trim());
                        em.Precio = Convert.ToInt32(txtprecio.Text.Trim());
                        em.Tienda = txttienda.Text.Trim().ToUpper();
                        em.Fecha_date = datefecha.Value.Year + "-" + datefecha.Value.Month + "-" + datefecha.Value.Day;

                        if (Sistema_mercadoCD.editar(em))
                        {
                            llenarGrid();
                            limpiarcampos();
                            MessageBox.Show("Producto editar correctamente");
                            consultado = false;
                        }
                        else
                        {
                            MessageBox.Show("El producto no se pudo editar");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            int cantidad = 0;
            float precio = 0;
            if (consultado == false)
            {
                MessageBox.Show("Debe consultar el producto");

            }
            else if (txtcodigo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un codigo");

            }
            else if (txtproducto.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un producto");
            }
            else if (txtmarca.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una marca");
            }


            else if (!int.TryParse(txtcantidad.Text, out cantidad) && (txtcantidad.Text == ""))
            {
                MessageBox.Show("Debe ingresar un valor numerico o campo vacio");
            }
            else if (!float.TryParse(txtprecio.Text, out precio) && (txtprecio.Text == ""))
            {
                MessageBox.Show("Debe ingresar un valor numerico o campo vacio");
            }
            else if (DialogResult.Yes == MessageBox.Show(null,"¿Realmente desea eliminar el producto?","Confirmación", MessageBoxButtons.YesNo))
            {
                
                try
                {
                    

                    if (Sistema_mercadoCD.eliminar(txtcodigo.Text.Trim()))
                    {
                        llenarGrid();
                        limpiarcampos();
                        MessageBox.Show("Producto eliminado correctamente");
                        consultado = false;
                    }
                    else
                    {
                        MessageBox.Show("El producto no se pudo eliminar");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
