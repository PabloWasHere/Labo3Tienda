using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ItemOrden : Estado
    {
        private Producto producto;
        private ItemOrdenCodigoEstado codigoEstado;
        private int cantidad;
        private float precio;
        private string detalles;

        public ItemOrden() { }

        public ItemOrden(Producto producto, ItemOrdenCodigoEstado codigoEstado, int cantidad, float precio, string detalles)
        {
            Producto = producto;
            CodigoEstado = codigoEstado;
            Cantidad = cantidad;
            Precio = precio;
            Detalles = detalles;
        }

        public Producto Producto { get => producto; set => producto = value; }
        public ItemOrdenCodigoEstado CodigoEstado { get => codigoEstado; set => codigoEstado = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public float Precio { get => precio; set => precio = value; }
        public string Detalles { get => detalles; set => detalles = value; }
    }
}
