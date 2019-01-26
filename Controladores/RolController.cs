using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Controladores
{
    public class RolController
    {
        private DataBaseController dataBaseController = null;

        public RolController()
        {
            dataBaseController = new DataBaseController(
                //"Data Source=pablolabo3.database.windows.net;Initial Catalog=ProjectManager;Persist Security Info=True;User ID=pablo;Password=253501PabBarc",
                "Server=tcp:pablolabo3.database.windows.net,1433;Initial Catalog=tienda;Persist Security Info=False;User ID=pablo;Password=253501PabBarc;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            );
        }

        private List<Rol> FillObjects(List<Dictionary<string, dynamic>> data)
        {
            PermisoController permisoController = new PermisoController();
            List<Rol> roles = new List<Rol>();

            foreach (Dictionary<string, dynamic> row in data)
            {
                Rol rol = new Rol();
                rol.Id = row["id"];
                rol.Codigo = row["codigo"];
                rol.Descripcion = row["descripcion"];
                rol.Permisos = permisoController.GetAllByRol(rol);

                roles.Add(rol);
            }

            return roles;
        }

        public List<Rol> GetAll()
        {
            List<Dictionary<string, dynamic>> data = new List<Dictionary<string, dynamic>>();
            List<Rol> roles = new List<Rol>();

            data = dataBaseController.ExecuteQuery("SELECT * FROM rol", new List<SqlParameter>());

            roles = FillObjects(data);

            return roles;
        }

        public List<Rol> GetAllByUsuario(Usuario usuario)
        {
            List<Dictionary<string, dynamic>> data = new List<Dictionary<string, dynamic>>();
            List<Rol> roles = new List<Rol>();

            string query =
                "SELECT r.* FROM rol r JOIN usuario_rol ur ON ur.rol_id = r.id JOIN usuario u ON u.id = ur.usuario_id WHERE u.id = " + usuario.Id;

            data = dataBaseController.ExecuteQuery(query, new List<SqlParameter>());

            roles = FillObjects(data);

            return roles;
        }

        public Rol GetRol(int id)
        {
            List<Dictionary<string, dynamic>> data;
            List<Rol> roles;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter() { ParameterName = "@Id", Value = id });

            data = dataBaseController.ExecuteQuery("SELECT * FROM rol WHERE id = @Id", param);

            roles = FillObjects(data);

            return roles[0];
        }
    }
}
