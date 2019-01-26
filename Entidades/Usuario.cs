using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public string Nick { get; set; }

        public string Password { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public List<Rol> Roles { get; set; } = new List<Rol>();

        public int Id { get; set; }

        public DateTime? Creado { get; set; }

        public DateTime? Modificado { get; set; }

        public bool Activo { get; set; }
    }
}
