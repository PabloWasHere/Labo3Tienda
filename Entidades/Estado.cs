using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estado
    {
        public int Id { get; set; }
        public DateTime Creado { get; set; }
        public DateTime? Modificado { get; set; }
        public bool Activo { get; set; }
        public Usuario Usuario { get; set; }
    }
}
