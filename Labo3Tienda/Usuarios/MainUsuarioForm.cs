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
    public partial class MainUsuarioForm : MaterialForm
    {
        UsuarioController usuarioController = new UsuarioController();
        private List<Usuario> usuarios;

        public MainUsuarioForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            UpdateUsuarioGrid();
        }

        public void UpdateUsuarioGrid()
        {
            dgvUsuarios.Rows.Clear();

            usuarios = usuarioController.GetAll();
            usuarios.Sort((p, q) => p.Nick.CompareTo(q.Nick));
            foreach (Usuario u in usuarios)
            {
                dgvUsuarios.Rows.Add(u.Id, u.Creado?.ToString("dd/MM/yyyy"), u.Nick, u.Nombre, u.Apellido, (u.Activo ? "Activo" : "Inactivo"));
            }

            UpdateRolGrid();
        }

        public void UpdateRolGrid()
        {
            dgvRoles.Rows.Clear();

            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["id"].Value);

                List<Rol> roles = usuarios.Find(x => x.Id == idUsuario).Roles;

                foreach (Rol r in roles)
                {
                    dgvRoles.Rows.Add(r.Codigo, r.Descripcion);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CreateUsuarioForm formCreateUsuario = new CreateUsuarioForm(this);
            formCreateUsuario.ShowDialog();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvRoles.Rows.Clear();

            UpdateRolGrid();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                Usuario usuario =
                    usuarioController.GetUsuario(Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["id"].Value));

                EditUsuarioForm formUpdateUsuario = new EditUsuarioForm(usuario, this);

                formUpdateUsuario.ShowDialog();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Esta seguro que desea continuar?", "Esta a punto de eliminar un usuario", MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["id"].Value);
                    usuarioController.Delete(idUsuario);

                    UpdateUsuarioGrid();
                }
            }
        }
    }
}
