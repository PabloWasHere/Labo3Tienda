using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductoTipo : Estado
    {
        private ProductoTipo productoTipoPadre;
        private string codigo;
        private string descripcion;

        public ProductoTipo() { }

        public ProductoTipo(ProductoTipo productoTipoPadre, string codigo, string descripcion)
        {
            this.productoTipoPadre = productoTipoPadre;
            this.codigo = codigo;
            this.descripcion = descripcion;
        }

        public ProductoTipo ProductoTipoPadre { get => productoTipoPadre; set => productoTipoPadre = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
