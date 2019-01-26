using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Controladores
{
    public class OrdenController
    {
        DataBaseController dataBaseController;

        public OrdenController()
        {
            dataBaseController = new DataBaseController(
                //"Data Source=pablolabo3.database.windows.net;Initial Catalog=ProjectManager;Persist Security Info=True;User ID=pablo;Password=253501PabBarc",
                "Server=tcp:pablolabo3.database.windows.net,1433;Initial Catalog=tienda;Persist Security Info=False;User ID=pablo;Password=253501PabBarc;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            );
        }

        private List<Orden> FillObjects(List<Dictionary<string, dynamic>> data)
        {
            List<Orden> ordenes = new List<Orden>();

            foreach (Dictionary<string, dynamic> row in data)
            {
                ordenes.Add(FillObject(row));
            }

            return ordenes;
        }

        private Orden FillObject(Dictionary<string, dynamic> data)
        {
            UsuarioController usuarioController = new UsuarioController();
            ItemOrdenController itemOrdenController = new ItemOrdenController();
            Orden orden = new Orden();

            orden.Id = data["id"];
            orden.CodigoEstado = GetCodigoEstado(data["orden_codigo_estado_id"]);
            orden.FechaPedido = data["fecha_pedido"];
            orden.Detalles = data["detalles"];
            orden.Items = itemOrdenController.GetItemsOrden(orden.Id);
            orden.Creado = data["creado"];
            orden.Modificado = data["modificado"];
            orden.Activo = data["activo"];
            orden.Usuario = usuarioController.GetUsuario(data["usuario_id"]);

            return orden;
        }

        public Orden GetOrden(int id)
        {
            List<Dictionary<string, dynamic>> data;
            Orden orden = null;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter() { ParameterName = "@Id", Value = id });

            data = dataBaseController.ExecuteQuery("SELECT * FROM orden WHERE id = @Id AND activo = 1", param);

            if (data.Count > 0)
            {
                orden = FillObject(data[0]);
            }

            return orden;
        }

        public List<Orden> GetOrdenes(Cliente cliente, DateTime? fechaDesde, DateTime? fechaHasta, OrdenCodigoEstado estado)
        {
            List<Dictionary<string, dynamic>> data;
            List<Orden> ordenes;

            List<SqlParameter> param = new List<SqlParameter>();

            string query =
                "SELECT * FROM orden WHERE activo = 1";
            if (cliente != null)
            {
                param.Add(new SqlParameter() { ParameterName = "@Cliente", Value = cliente.Id });
                query += " AND cliente_id = @Cliente";
            }
            if (fechaDesde != null)
            {
                param.Add(new SqlParameter() { ParameterName = "@FechaDesde", Value = fechaDesde });
                query += " AND fecha_pedido >= @FechaDesde";
            }
            if (fechaHasta != null)
            {
                param.Add(new SqlParameter() { ParameterName = "@FechaHasta", Value = fechaHasta });
                query += " AND fecha_pedido <= @FechaHasta";
            }
            if (estado != null)
            {
                param.Add(new SqlParameter() { ParameterName = "@Estado", Value = estado.Id });
                query += " AND orden_codigo_estado_id = @Estado";
            }

            data = dataBaseController.ExecuteQuery(query, param);

            ordenes = FillObjects(data);

            return ordenes;
        }

        public OrdenCodigoEstado GetCodigoEstado(int id)
        {
            List<Dictionary<string, dynamic>> data;
            OrdenCodigoEstado ordenCodigoEstado = null;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter() { ParameterName = "@Id", Value = id });

            data = dataBaseController.ExecuteQuery("SELECT * FROM orden_codigo_estado WHERE id = @Id", param);

            if (data.Count > 0)
            {
                ordenCodigoEstado = new OrdenCodigoEstado
                {
                    Id = data[0]["id"],
                    Codigo = data[0]["codigo"],
                    Descripcion = data[0]["descripcion"]
                };
            }

            return ordenCodigoEstado;
        }

        public List<OrdenCodigoEstado> GetAllOrdenCodigoEstado()
        {
            List<Dictionary<string, dynamic>> data;
            List<OrdenCodigoEstado> estados = new List<OrdenCodigoEstado>();

            List<SqlParameter> param = new List<SqlParameter>();

            data = dataBaseController.ExecuteQuery("SELECT * FROM orden_codigo_estado", param);

            foreach (Dictionary<string, dynamic> row in data)
            {
                estados.Add(new OrdenCodigoEstado(row["id"], row["codigo"], row["descripcion"]));
            }

            return estados;
        }
    }
}
