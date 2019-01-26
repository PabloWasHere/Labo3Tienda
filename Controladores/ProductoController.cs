using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Controladores
{
    public class ProductoController
    {
        DataBaseController dataBaseController;

        public ProductoController()
        {
            dataBaseController = new DataBaseController(
                //"Data Source=pablolabo3.database.windows.net;Initial Catalog=ProjectManager;Persist Security Info=True;User ID=pablo;Password=253501PabBarc",
                "Server=tcp:pablolabo3.database.windows.net,1433;Initial Catalog=tienda;Persist Security Info=False;User ID=pablo;Password=253501PabBarc;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            );
        }

        private List<Producto> FillObjects(List<Dictionary<string, dynamic>> data)
        {
            List<Producto> productos = new List<Producto>();

            foreach (Dictionary<string, dynamic> row in data)
            {
                productos.Add(FillObject(row));
            }

            return productos;
        }

        private Producto FillObject(Dictionary<string, dynamic> data)
        {
            UsuarioController usuarioController = new UsuarioController();
            Producto producto = new Producto();

            producto.Id = data["id"];
            producto.ProductoTipo = GetProductoTipo(data["producto_tipo_id"]);
            producto.Stock = data["stock"];
            producto.Nombre = data["nombre"];
            producto.Precio = data["precio"];
            producto.Descripcion = data["descripcion"];
            producto.OtrosDetalles = data["otros_detalles"];
            producto.Creado = data["creado"];
            producto.Modificado = data["modificado"];
            producto.Activo = data["activo"];
            producto.Usuario = usuarioController.GetUsuario(data["usuario_id"]);

            return producto;
        }

        public Producto GetProducto(int id)
        {
            List<Dictionary<string, dynamic>> data;
            Producto producto = null;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter() { ParameterName = "@Id", Value = id });

            data = dataBaseController.ExecuteQuery("SELECT * FROM producto WHERE id = @Id AND activo = 1", param);

            if (data.Count > 0)
            {
                producto = FillObject(data[0]);
            }

            return producto;
        }

        public List<Producto> GetProductos(string nombre, int? productoTipoId)
        {
            List<Dictionary<string, dynamic>> data;
            List<Producto> productos;

            string query =
                "SELECT * FROM producto p LEFT JOIN producto_tipo pt ON p.producto_tipo_id = pt.id WHERE p.activo = 1";
            if (nombre != null)
            {
                query += " AND p.nombre LIKE @Nombre";
            }
            if (productoTipoId != null)
            {
                query += " AND (pt.id = @ProductoTipo OR pt.producto_tipo_padre_id = @ProductoTipo)";
            }

            List<SqlParameter> param = new List<SqlParameter>();
            if (nombre != null)
            {
                param.Add(new SqlParameter() { ParameterName = "@Nombre", Value = "%" + nombre + "%" });
            }
            if (productoTipoId != null)
            {
                param.Add(new SqlParameter() { ParameterName = "@ProductoTipo", Value = productoTipoId });
            }

            data = dataBaseController.ExecuteQuery(query, param);

            productos = FillObjects(data);

            return productos;
        }

        public ProductoTipo GetProductoTipo(int id)
        {
            List<Dictionary<string, dynamic>> data;
            ProductoTipo productoTipo = null;

            List<SqlParameter> param = new List<SqlParameter> {new SqlParameter() {ParameterName = "@Id", Value = id}};

            data = dataBaseController.ExecuteQuery("SELECT * FROM producto_tipo WHERE id = @Id AND activo = 1", param);

            if (data.Count > 0)
            {
                UsuarioController usuarioController = new UsuarioController();

                productoTipo = new ProductoTipo
                {
                    Id = data[0]["id"],
                    ProductoTipoPadre = GetProductoTipo(data[0]["producto_tipo_padre_id"]),
                    Codigo = data[0]["codigo"],
                    Descripcion = data[0]["descripcion"],
                    Creado = data[0]["creado"],
                    Modificado = data[0]["modificado"],
                    Activo = data[0]["activo"],
                    Usuario = usuarioController.GetUsuario(data[0]["usuario_id"])
                };
            }

            return productoTipo;
        }

        public List<ProductoTipo> GetProductoTiposPadres()
        {
            List<Dictionary<string, dynamic>> data;
            List<ProductoTipo> productoTipos = new List<ProductoTipo>();

            List<SqlParameter> param = new List<SqlParameter>();

            data = dataBaseController.ExecuteQuery("SELECT * FROM producto_tipo WHERE producto_tipo_padre_id IS NULL AND activo = 1", param);

            foreach (Dictionary<string, dynamic> row in data)
            {
                UsuarioController usuarioController = new UsuarioController();

                ProductoTipo productoTipo = new ProductoTipo
                {
                    Id = row["id"],
                    ProductoTipoPadre = null,
                    Codigo = row["codigo"],
                    Descripcion = row["descripcion"],
                    Creado = row["creado"],
                    Modificado = row["modificado"],
                    Activo = row["activo"],
                    Usuario = usuarioController.GetUsuario(row["usuario_id"])
                };

                productoTipos.Add(productoTipo);
            }

            return productoTipos;
        }

        public List<ProductoTipo> GetProductoTiposHijos(int id)
        {
            List<Dictionary<string, dynamic>> data;
            List<ProductoTipo> productoTipos = new List<ProductoTipo>();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter() { ParameterName = "@Id", Value = id });

            data = dataBaseController.ExecuteQuery("SELECT * FROM producto_tipo WHERE producto_tipo_padre_id = @Id AND activo = 1", param);

            foreach (Dictionary<string, dynamic> row in data)
            {
                UsuarioController usuarioController = new UsuarioController();

                ProductoTipo productoTipo = new ProductoTipo
                {
                    Id = row["id"],
                    ProductoTipoPadre = GetProductoTipo(data[0]["producto_tipo_padre_id"]),
                    Codigo = row["codigo"],
                    Descripcion = row["descripcion"],
                    Creado = row["creado"],
                    Modificado = row["modificado"],
                    Activo = row["activo"],
                    Usuario = usuarioController.GetUsuario(row["usuario_id"])
                };

                productoTipos.Add(productoTipo);
            }

            return productoTipos;
        }
    }
}
