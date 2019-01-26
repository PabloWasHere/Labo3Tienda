using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Controladores
{
    class PermisoController
    {
        private DataBaseController dataBaseController = null;

        public PermisoController()
        {
            dataBaseController = new DataBaseController(
                //"Data Source=pablolabo3.database.windows.net;Initial Catalog=ProjectManager;Persist Security Info=True;User ID=pablo;Password=253501PabBarc",
                "Server=tcp:pablolabo3.database.windows.net,1433;Initial Catalog=tienda;Persist Security Info=False;User ID=pablo;Password=253501PabBarc;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            );
        }

        private List<Permiso> FillObjects(List<Dictionary<string, dynamic>> data)
        {
            List<Permiso> permisos = new List<Permiso>();

            foreach (Dictionary<string, dynamic> row in data)
            {
                Permiso permiso = new Permiso();
                permiso.Id = row["id"];
                permiso.Codigo = row["codigo"];
                permiso.Descripcion = row["descripcion"];

                permisos.Add(permiso);
            }

            return permisos;
        }

        public List<Permiso> GetAll()
        {
            List<Dictionary<string, dynamic>> data = new List<Dictionary<string, dynamic>>();
            List<Permiso> permisos = new List<Permiso>();

            data = dataBaseController.ExecuteQuery("SELECT * FROM permiso", new List<SqlParameter>());

            permisos = FillObjects(data);

            return permisos;
        }

        public List<Permiso> GetAllByRol(Rol rol)
        {
            List<Dictionary<string, dynamic>> data = new List<Dictionary<string, dynamic>>();
            List<Permiso> permisos = new List<Permiso>();

            string query =
                "SELECT p.* FROM permiso p JOIN rol_permiso rp ON rp.permiso_id = p.id JOIN rol r ON r.id = rp.rol_id WHERE r.id = " + rol.Id;

            data = dataBaseController.ExecuteQuery(query, new List<SqlParameter>());

            permisos = FillObjects(data);

            return permisos;
        }

        public Permiso GetPermiso(int id)
        {
            List<Dictionary<string, dynamic>> data;
            List<Permiso> permisos;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter() { ParameterName = "@Id", Value = id });

            data = dataBaseController.ExecuteQuery("SELECT * FROM permiso WHERE id = @Id", param);

            permisos = FillObjects(data);

            return permisos[0];
        }
    }
}
