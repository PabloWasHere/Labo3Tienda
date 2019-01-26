using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class OrdenCodigoEstado
    {
        private int id;
        private string codigo;
        private string descripcion;

        public OrdenCodigoEstado() { }

        public OrdenCodigoEstado(int id, string codigo, string descripcion)
        {
            this.id = id;
            this.codigo = codigo;
            this.descripcion = descripcion;
        }

        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
