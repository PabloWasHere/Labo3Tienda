using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto : Estado
    {
        private ProductoTipo productoTipo;
        private int stock;
        private string nombre;
        private float precio;
        private string descripcion;
        private string otrosDetalles;

        public Producto() { }

        public Producto(ProductoTipo productoTipo, int stock, string nombre, float precio, string descripcion, string otrosDetalles)
        {
            this.productoTipo = productoTipo;
            this.stock = stock;
            this.nombre = nombre;
            this.precio = precio;
            this.descripcion = descripcion;
            this.otrosDetalles = otrosDetalles;
        }

        public ProductoTipo ProductoTipo { get => productoTipo; set => productoTipo = value; }
        public int Stock { get => stock; set => stock = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public float Precio { get => precio; set => precio = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string OtrosDetalles { get => otrosDetalles; set => otrosDetalles = value; }
    }
}
