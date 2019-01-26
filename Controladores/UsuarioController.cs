using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Controladores
{
    public class UsuarioController
    {
        DataBaseController dataBaseController;
        RolController rolController;

        public UsuarioController()
        {
            dataBaseController = new DataBaseController(
                //"Data Source=pablolabo3.database.windows.net;Initial Catalog=ProjectManager;Persist Security Info=True;User ID=pablo;Password=253501PabBarc",
                "Server=tcp:pablolabo3.database.windows.net,1433;Initial Catalog=tienda;Persist Security Info=False;User ID=pablo;Password=253501PabBarc;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            );
        }

        private List<Usuario> FillObjects(List<Dictionary<string, dynamic>> data)
        {
            rolController = new RolController();
            List<Usuario> usuarios = new List<Usuario>();

            foreach (Dictionary<string, dynamic> row in data)
            {
                usuarios.Add(FillObject(row));
            }

            return usuarios;
        }

        private Usuario FillObject(Dictionary<string, dynamic> data)
        {
            rolController = new RolController();
            Usuario usuario = new Usuario();

            usuario.Id = data["id"];
            usuario.Nick = data["nick"];
            usuario.Password = data["password"];
            usuario.Nombre = data["nombre"];
            usuario.Apellido = data["apellido"];
            usuario.Creado = data["creado"];
            usuario.Modificado = data["modificado"];
            usuario.Activo = data["activo"];

            usuario.Roles = rolController.GetAllByUsuario(usuario);

            return usuario;
        }

        public Usuario GetUsuario(int id)
        {
            List<Dictionary<string, dynamic>> data;
            Usuario usuario = null;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter() { ParameterName = "@Id", Value = id });

            data = dataBaseController.ExecuteQuery("SELECT * FROM usuario WHERE id = @Id", param);

            if (data.Count > 0)
            {
                usuario = FillObject(data[0]);
            }

            return usuario;
        }

        public List<Usuario> GetAll()
        {
            List<Dictionary<string, dynamic>> data;
            List<Usuario> usuarios;

            data = dataBaseController.ExecuteQuery("SELECT * FROM usuario", new List<SqlParameter>());

            usuarios = FillObjects(data);

            return usuarios;
        }

        public List<Usuario> GetAllActivos()
        {
            List<Dictionary<string, dynamic>> data;
            List<Usuario> usuarios;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter() { ParameterName = "@Activo", Value = 1 });

            data = dataBaseController.ExecuteQuery("SELECT * FROM usuario WHERE activo = @Activo", param);

            usuarios = FillObjects(data);

            return usuarios;
        }

        public Usuario GetUsuarioByLogin(string username, string password)
        {
            List<Dictionary<string, dynamic>> data;
            Usuario usuario = null;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter() { ParameterName = "@Username", Value = username });
            param.Add(new SqlParameter() { ParameterName = "@Password", Value = password });

            data = dataBaseController.ExecuteQuery("SELECT * FROM usuario WHERE nick = @Username AND password = @Password AND activo = 1", param);

            if (data.Count == 1)
            {
                usuario = FillObject(data[0]);
            }

            return usuario;
        }

        private bool UsuarioExists(string username, int id)
        {
            List<Dictionary<string, dynamic>> data;

            List<SqlParameter> param = new List<SqlParameter>();

            if (id >= 0)
            {
                param.Add(new SqlParameter() { ParameterName = "@Username", Value = username });
                param.Add(new SqlParameter() { ParameterName = "@Id", Value = id });

                data = dataBaseController.ExecuteQuery("SELECT * FROM usuario WHERE nick = @Username AND id != @id AND activo = 1", param);
            }
            else
            {
                param.Add(new SqlParameter() { ParameterName = "@Username", Value = username });

                data = dataBaseController.ExecuteQuery("SELECT * FROM usuario WHERE nick = @Username AND activo = 1", param);
            }

            return data.Count > 0;
        }

        public Usuario Update(Usuario usuario)
        {
            if (!UsuarioExists(usuario.Nick, usuario.Id))
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter() { ParameterName = "@Nick", Value = usuario.Nick });
                param.Add(new SqlParameter() { ParameterName = "@Password", Value = usuario.Password });
                param.Add(new SqlParameter() { ParameterName = "@Nombre", Value = usuario.Nombre });
                param.Add(new SqlParameter() { ParameterName = "@Apellido", Value = usuario.Apellido });
                param.Add(new SqlParameter() { ParameterName = "@Id", Value = usuario.Id });
                param.Add(new SqlParameter() { ParameterName = "@Modificado", Value = DateTime.Now });

                string query =
                    "UPDATE usuario SET nick = @Nick, password = @Password, nombre = @Nombre, apellido = @Apellido, modificado = @Modificado WHERE id = @Id";

                dataBaseController.ExecuteNonQuery(query, param);

                param = new List<SqlParameter>();
                param.Add(new SqlParameter() { ParameterName = "@Id", Value = usuario.Id });

                query =
                    "DELETE FROM usuario_rol WHERE usuario_id = @Id";

                dataBaseController.ExecuteNonQuery(query, param);

                foreach (Rol rol in usuario.Roles)
                {
                    param = new List<SqlParameter>();
                    param.Add(new SqlParameter() { ParameterName = "@IdUsuario", Value = usuario.Id });
                    param.Add(new SqlParameter() { ParameterName = "@IdRol", Value = rol.Id });

                    query =
                        "INSERT INTO usuario_rol(usuario_id, rol_id) VALUES (@IdUsuario, @IdRol)";

                    dataBaseController.ExecuteNonQuery(query, param);
                }

                Usuario usuarioNuevo = GetUsuario(usuario.Id);

                return usuarioNuevo;
            }

            throw new Exception("El nombre de usuario ingresado ya pertenece a un usuario activo");
        }

        public Usuario Save(Usuario usuario)
        {
            if (!UsuarioExists(usuario.Nick, 0))
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter() { ParameterName = "@Nick", Value = usuario.Nick });
                param.Add(new SqlParameter() { ParameterName = "@Password", Value = usuario.Password });
                param.Add(new SqlParameter() { ParameterName = "@Nombre", Value = usuario.Nombre });
                param.Add(new SqlParameter() { ParameterName = "@Apellido", Value = usuario.Apellido });
                param.Add(new SqlParameter() { ParameterName = "@Activo", Value = 1 });
                param.Add(new SqlParameter() { ParameterName = "@Creado", Value = DateTime.Now });

                string query =
                    "INSERT INTO usuario(nick, password, nombre, apellido, activo, creado) VALUES (@Nick, @Password, @Nombre, @Apellido, @Activo, @Creado)";

                int identity = dataBaseController.ExecuteNonQuery(query, param);

                foreach (Rol rol in usuario.Roles)
                {
                    param = new List<SqlParameter>();
                    param.Add(new SqlParameter() { ParameterName = "@IdUsuario", Value = identity });
                    param.Add(new SqlParameter() { ParameterName = "@IdRol", Value = rol.Id });

                    query =
                        "INSERT INTO usuario_rol(usuario_id, rol_id) VALUES (@IdUsuario, @IdRol)";

                    dataBaseController.ExecuteNonQuery(query, param);
                }

                Usuario usuarioNuevo = GetUsuario(identity);

                return usuarioNuevo;
            }

            throw new Exception("El nombre de usuario ingresado ya pertenece a un usuario activo");
        }

        public void Delete(int idUsuario)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter() { ParameterName = "@Activo", Value = 0 });
            param.Add(new SqlParameter() { ParameterName = "@Modificado", Value = DateTime.Now });
            param.Add(new SqlParameter() { ParameterName = "@Id", Value = idUsuario });

            string query =
                "UPDATE usuario SET activo = @Activo, modificado = @Modificado WHERE id = @Id";

            dataBaseController.ExecuteNonQuery(query, param);
        }
    }
}
