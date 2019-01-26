using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Labo3Tienda.Acceso;
using Labo3Tienda.Productos;
using Labo3Tienda.Usuarios;

namespace Labo3Tienda
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
//            Application.Run(new LoginForm());
            Application.Run(new CatalogoForm());
        }
    }
}
