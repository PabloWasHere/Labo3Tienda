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
using Controles;
using Entidades;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Labo3Tienda.Productos
{
    public partial class CatalogoForm : MaterialForm
    {
        ProductoController productoController = new ProductoController();
        OrdenController ordenController = new OrdenController();

        public CatalogoForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            List<ProductoTipo> categoriasPadre = productoController.GetProductoTiposPadres();
            categoriasPadre.Insert(0, new ProductoTipo() { Id = 0, Descripcion = "Todas" });

            cbFiltroCategoria.DisplayMember = "Descripcion";
            cbFiltroCategoria.DataSource = categoriasPadre;
            cbFiltroCategoria.SelectedIndex = 0;

            List<Producto> productos = productoController.GetProductos(null, null);
            LlenarCatalogo(productos);

            // TODO: Llenar select de estados de orden, llenar grilla de ordenes y filtrar

            List<OrdenCodigoEstado> ordenCodigoEstados = ordenController.GetAllOrdenCodigoEstado();
            ordenCodigoEstados.Insert(0, new OrdenCodigoEstado() { Id = 0, Descripcion = "Todos" });

            cbMPEstado.DisplayMember = "Descripcion";
            cbMPEstado.DataSource = ordenCodigoEstados;
            cbMPEstado.SelectedIndex = 0;

            List<Orden> ordenes = FiltrarOrdenes();
        }

        private void cbFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoTipo categoriaPadre = (ProductoTipo)cbFiltroCategoria.SelectedItem;
            if (categoriaPadre.Id != 0)
            {
                List<ProductoTipo> categoriasHijo = productoController.GetProductoTiposHijos(categoriaPadre.Id);
                categoriasHijo.Insert(0, new ProductoTipo() { Id = 0, Descripcion = "Todos" });

                cbFiltroCategoria2.DisplayMember = "Descripcion";
                cbFiltroCategoria2.DataSource = categoriasHijo;
                cbFiltroCategoria2.SelectedIndex = 0;

                List<Producto> productos = productoController.GetProductos(tbFiltroNombre.Text, categoriaPadre.Id);
                LlenarCatalogo(productos);
            }
            else
            {
                cbFiltroCategoria2.Items.Clear();
                List<ProductoTipo> categoriasHijo = new List<ProductoTipo>();
                categoriasHijo.Insert(0, new ProductoTipo() { Id = 0, Descripcion = "Todos" });

                cbFiltroCategoria2.DisplayMember = "Descripcion";
                cbFiltroCategoria2.DataSource = categoriasHijo;
                cbFiltroCategoria2.SelectedIndex = 0;

                List<Producto> productos = productoController.GetProductos(tbFiltroNombre.Text, null);
                LlenarCatalogo(productos);
            }
        }

        private void cbFiltroCategoria2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoTipo categoriaHijo = (ProductoTipo)cbFiltroCategoria2.SelectedItem;
            if (categoriaHijo.Id != 0)
            {
                List<Producto> productos = productoController.GetProductos(tbFiltroNombre.Text, categoriaHijo.Id);
                LlenarCatalogo(productos);
            }
            else
            {
                ProductoTipo categoriaPadre = (ProductoTipo)cbFiltroCategoria.SelectedItem;
                List<Producto> productos;
                if (categoriaPadre.Id != 0)
                {
                    productos = productoController.GetProductos(tbFiltroNombre.Text, categoriaPadre.Id);
                }
                else
                {
                    productos = productoController.GetProductos(tbFiltroNombre.Text, null);
                }

                LlenarCatalogo(productos);
            }
        }

        private void LlenarCatalogo(List<Producto> productos)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Producto producto in productos)
            {
                flowLayoutPanel1.Controls.Add(new CatalogProduct()
                {
                    IdProducto = producto.Id,
                    NombreProducto = producto.Nombre,
                    PrecioProducto = producto.Precio
                });
            }
        }

        private void LlenarTablaOrdenes(List<Orden> ordenes)
        {
            dgvCompras.Rows.Clear();

            // TODO: Llenar grilla de ordenes y luego de detalle de orden
        }

        private List<Orden> FiltrarOrdenes()
        {
            DateTime? desde = dtpDesde.Checked ? dtpDesde.Value : (DateTime?) null;
            DateTime? hasta = dtpHasta.Checked ? dtpHasta.Value : (DateTime?) null;
            OrdenCodigoEstado estado = (OrdenCodigoEstado)cbMPEstado.SelectedItem;

            return ordenController.GetOrdenes(clienteController.GetCliente(Session.UsuarioActual), desde, hasta, estado.Id != 0 ? estado : null)
        }
    }
}
