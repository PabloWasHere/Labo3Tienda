using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ItemOrdenCodigoEstado
    {
        private int id;
        private string descripcion;

        public ItemOrdenCodigoEstado() { }

        public ItemOrdenCodigoEstado(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
