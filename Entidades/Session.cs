using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Session
    {
        public static Usuario UsuarioActual { get; set; }
        public static List<string> Permisos { get; set; } = new List<string>();
    }
}
