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

namespace Labo3Tienda.Usuarios
{
    public partial class CreateUsuarioForm : MaterialForm
    {
        private RolController rolController = new RolController();
        private UsuarioController usuarioController = new UsuarioController();
        private MainUsuarioForm formUsuario;

        public CreateUsuarioForm(MainUsuarioForm abmUsuarios)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            formUsuario = abmUsuarios;

            clbRoles.DisplayMember = "Descripcion";
            clbRoles.ValueMember = "Id";

            List<Rol> roles = rolController.GetAll();
            foreach (Rol rol in roles)
            {
                clbRoles.Items.Add(rol, CheckState.Unchecked);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Nick = tbUsername.Text;
            usuario.Nombre = tbNombre.Text;
            usuario.Apellido = tbApellido.Text;
            usuario.Password = tbPassword.Text;

            foreach (object item in clbRoles.CheckedItems)
            {
                Rol rol = (Rol)item;
                usuario.Roles.Add(rolController.GetRol(Convert.ToInt32(rol.Id)));
            }

            try
            {
                usuarioController.Save(usuario);

                formUsuario.UpdateUsuarioGrid();

                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
