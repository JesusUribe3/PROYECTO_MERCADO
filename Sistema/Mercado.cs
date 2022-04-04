using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_MERCADO.Sistema
{
    class Mercado
    {
        private string codigo;
        private string nombre_producto;
        private string marca;
        private int cantidad;
        private float precio;
        private string tienda;
        private string fecha_date;

        public Mercado()
        {
            this.codigo = "";
            this.nombre_producto = "";
            this.marca = "";
            this.cantidad = 0;
            this.precio = 0;
            this.tienda = "";
            this.fecha_date = "";

        }

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre_producto { get => nombre_producto; set => nombre_producto = value; }
        public string Marca { get => marca; set => marca = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public float Precio { get => precio; set => precio = value; }
        public string Tienda { get => tienda; set => tienda = value; }
        public string Fecha_date { get => fecha_date; set => fecha_date = value; }
    }
}
