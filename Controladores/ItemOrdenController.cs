using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Controladores
{
    public class ItemOrdenController
    {
        DataBaseController dataBaseController;

        public ItemOrdenController()
        {
            dataBaseController = new DataBaseController(
                //"Data Source=pablolabo3.database.windows.net;Initial Catalog=ProjectManager;Persist Security Info=True;User ID=pablo;Password=253501PabBarc",
                "Server=tcp:pablolabo3.database.windows.net,1433;Initial Catalog=tienda;Persist Security Info=False;User ID=pablo;Password=253501PabBarc;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            );
        }

        private List<ItemOrden> FillObjects(List<Dictionary<string, dynamic>> data)
        {
            List<ItemOrden> items = new List<ItemOrden>();

            foreach (Dictionary<string, dynamic> row in data)
            {
                items.Add(FillObject(row));
            }

            return items;
        }

        private ItemOrden FillObject(Dictionary<string, dynamic> data)
        {
            UsuarioController usuarioController = new UsuarioController();
            ProductoController productoController = new ProductoController();
            ItemOrden item = new ItemOrden();

            item.Id = data["id"];
            item.CodigoEstado = GetCodigoEstado(data["item_orden_codigo_estado_id"]);
            item.Producto = productoController.GetProducto(data["producto_id"]);
            item.Cantidad = data["cantidad"];
            item.Precio = data["precio"];
            item.Detalles = data["detalles"];
            item.Creado = data["creado"];
            item.Modificado = data["modificado"];
            item.Activo = data["activo"];
            item.Usuario = usuarioController.GetUsuario(data["usuario_id"]);

            return item;
        }

        public ItemOrden GetItemOrden(int id)
        {
            List<Dictionary<string, dynamic>> data;
            ItemOrden item = null;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter() { ParameterName = "@Id", Value = id });

            data = dataBaseController.ExecuteQuery("SELECT * FROM item_orden WHERE id = @Id AND activo = 1", param);

            if (data.Count > 0)
            {
                item = FillObject(data[0]);
            }

            return item;
        }

        public List<ItemOrden> GetItemsOrden(int id)
        {
            List<Dictionary<string, dynamic>> data;
            List<ItemOrden> items;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter() { ParameterName = "@Orden", Value = id });

            data = dataBaseController.ExecuteQuery("SELECT * FROM item_orden WHERE orden_id = @Orden AND activo = 1", param);
            
            items = FillObjects(data);

            return items;
        }

        public ItemOrdenCodigoEstado GetCodigoEstado(int id)
        {
            List<Dictionary<string, dynamic>> data;
            ItemOrdenCodigoEstado itemordenCodigoEstado = null;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter() { ParameterName = "@Id", Value = id });

            data = dataBaseController.ExecuteQuery("SELECT * FROM item_orden_codigo_estado WHERE id = @Id", param);

            if (data.Count > 0)
            {
                itemordenCodigoEstado = new ItemOrdenCodigoEstado
                {
                    Id = data[0]["id"],
                    Descripcion = data[0]["descripcion"]
                };
            }

            return itemordenCodigoEstado;
        }
    }
}
