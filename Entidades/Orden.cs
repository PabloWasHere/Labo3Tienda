using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Orden : Estado
    {
        private Cliente cliente;
        private OrdenCodigoEstado codigoEstado;
        private DateTime fechaPedido;
        private string detalles;
        private List<ItemOrden> items = new List<ItemOrden>();

        public Orden() { }

        public Orden(Cliente cliente, OrdenCodigoEstado codigoEstado, DateTime fechaPedido, string detalles)
        {
            this.cliente = cliente;
            this.codigoEstado = codigoEstado;
            this.fechaPedido = fechaPedido;
            this.detalles = detalles;
        }

        public Cliente Cliente { get => cliente; set => cliente = value; }
        public OrdenCodigoEstado CodigoEstado { get => codigoEstado; set => codigoEstado = value; }
        public DateTime FechaPedido { get => fechaPedido; set => fechaPedido = value; }
        public string Detalles { get => detalles; set => detalles = value; }
        public List<ItemOrden> Items { get => items; set => items = value; }
    }
}
