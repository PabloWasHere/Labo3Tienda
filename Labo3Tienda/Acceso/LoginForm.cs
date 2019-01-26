using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controladores;
using Entidades;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Labo3Tienda.Acceso
{
    public partial class LoginForm : MaterialForm
    {
        private UsuarioController usuarioController = new UsuarioController();

        public LoginForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Ingresar_Click(object sender, EventArgs e)
        {
            string username = tbUsuario.Text;
            string password = tbPassword.Text;

            Usuario usuario = usuarioController.GetUsuarioByLogin(username, password);

            if (usuario != null)
            {
                Session.UsuarioActual = usuario;

                foreach (Rol rol in usuario.Roles)
                {
                    foreach (Permiso permiso in rol.Permisos)
                    {
                        Session.Permisos.Add(permiso.Codigo);
                    }
                }

//                Form menuForm = new menu.Menu(); ;
//                menuForm.Show();
                MessageBox.Show("Login correcto");
            }
            else
            {
                MessageBox.Show("El usuario y contraseña ingresados no coinciden con una cuenta valida.");
            }
        }
    }
}
