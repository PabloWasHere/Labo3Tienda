using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controles
{
    public partial class CatalogProduct : UserControl
    {
        public event EventHandler UserClick;
        public event EventHandler ProductClick;

        private int idProducto;
        private string nombreProducto;
        private float precioProducto;
        private Image fotoProducto;

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public string NombreProducto
        {
            get { return nombreProducto; }
            set
            {
                nombreProducto = value;
                lblNombre.Text = value;
            }
        }

        public float PrecioProducto
        {
            get { return precioProducto; }
            set
            {
                precioProducto = value;
                lblPrecio.Text = "$ " + value;
            }
        }

        public Image FotoProducto
        {
            get { return fotoProducto; }
            set
            {
                fotoProducto = value;
                pbFoto.Image = value;
            }
        }

        public CatalogProduct()
        {
            InitializeComponent();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {
            ProductClick?.Invoke(this, e);
        }
    }
}
