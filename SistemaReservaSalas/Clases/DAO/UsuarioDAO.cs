using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaSalas.Clases.DAO
{
    public class UsuarioDAO : BaseDAO
    {
        #region Clase UsuarioDAO - Hereda de BaseDAO (HERENCIA 3)
        /// <summary>
        /// Clase DAO para operaciones con Usuarios
        /// Hereda de BaseDAO
        /// Autentica un usuario en el sistema
        /// </summary>
            public Usuario Autenticar(string nombreUsuario, string password)
            {
                try
                {
                    string query = @"SELECT IdUsuario, Nombre, Email, Telefono, Usuario, Password, Rol, Activo 
                                FROM Usuarios 
                                WHERE Usuario = @usuario AND Password = @password AND Activo = 1";

                    MySqlParameter[] parametros = {
                    new MySqlParameter("@usuario", nombreUsuario),
                    new MySqlParameter("@password", password)
                };

                    DataTable dt = EjecutarConsulta(query, parametros);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        return new Usuario(
                            Convert.ToInt32(row["IdUsuario"]),
                            row["Nombre"].ToString(),
                            row["Email"].ToString(),
                            row["Telefono"].ToString(),
                            row["Usuario"].ToString(),
                            row["Password"].ToString(),
                            row["Rol"].ToString(),
                            Convert.ToBoolean(row["Activo"])
                        );
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al autenticar usuario: " + ex.Message);
                }
            }

            /// <summary>
            /// Implementación del método abstracto Listar
            /// </summary>
            public override DataTable Listar()
            {
                string query = @"SELECT IdUsuario, Nombre, Email, Telefono, Usuario, Rol, 
                            CASE WHEN Activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado
                            FROM Usuarios ORDER BY Nombre";
                return EjecutarConsulta(query);
            }

            /// <summary>
            /// Implementación del método abstracto BuscarPorId
            /// </summary>
            public override object BuscarPorId(int id)
            {
                try
                {
                    string query = @"SELECT IdUsuario, Nombre, Email, Telefono, Usuario, Password, Rol, Activo 
                                FROM Usuarios WHERE IdUsuario = @id";

                    MySqlParameter[] parametros = { new MySqlParameter("@id", id) };
                    DataTable dt = EjecutarConsulta(query, parametros);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        return new Usuario(
                            Convert.ToInt32(row["IdUsuario"]),
                            row["Nombre"].ToString(),
                            row["Email"].ToString(),
                            row["Telefono"].ToString(),
                            row["Usuario"].ToString(),
                            row["Password"].ToString(),
                            row["Rol"].ToString(),
                            Convert.ToBoolean(row["Activo"])
                        );
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar usuario: " + ex.Message);
                }
            }

            /// <summary>
            /// Inserta un nuevo usuario
            /// </summary>
            public bool Insertar(Usuario usuario)
            {
                try
                {
                    string query = @"INSERT INTO Usuarios (Nombre, Email, Telefono, Usuario, Password, Rol, Activo)
                                VALUES (@nombre, @email, @telefono, @usuario, @password, @rol, @activo)";

                    MySqlParameter[] parametros = {
                    new MySqlParameter("@nombre", usuario.Nombre),
                    new MySqlParameter("@email", usuario.Email),
                    new MySqlParameter("@telefono", usuario.Telefono ?? ""),
                    new MySqlParameter("@usuario", usuario.NombreUsuario),
                    new MySqlParameter("@password", usuario.Password),
                    new MySqlParameter("@rol", usuario.Rol),
                    new MySqlParameter("@activo", usuario.Activo)
                };

                    return EjecutarComando(query, parametros);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar usuario: " + ex.Message);
                }
            }

            /// <summary>
            /// Actualiza un usuario existente
            /// </summary>
            public bool Actualizar(Usuario usuario)
            {
                try
                {
                    string query = @"UPDATE Usuarios SET 
                                Nombre = @nombre, Email = @email, Telefono = @telefono,
                                Usuario = @usuario, Password = @password, Rol = @rol, Activo = @activo
                                WHERE IdUsuario = @id";

                    MySqlParameter[] parametros = {
                    new MySqlParameter("@id", usuario.IdUsuario),
                    new MySqlParameter("@nombre", usuario.Nombre),
                    new MySqlParameter("@email", usuario.Email),
                    new MySqlParameter("@telefono", usuario.Telefono ?? ""),
                    new MySqlParameter("@usuario", usuario.NombreUsuario),
                    new MySqlParameter("@password", usuario.Password),
                    new MySqlParameter("@rol", usuario.Rol),
                    new MySqlParameter("@activo", usuario.Activo)
                };

                    return EjecutarComando(query, parametros);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar usuario: " + ex.Message);
                }
            }

            /// <summary>
            /// Elimina un usuario (eliminación lógica - marca como inactivo)
            /// </summary>
            public bool Eliminar(int idUsuario)
            {
                try
                {
                    string query = "UPDATE Usuarios SET Activo = 0 WHERE IdUsuario = @id";
                    MySqlParameter[] parametros = { new MySqlParameter("@id", idUsuario) };
                    return EjecutarComando(query, parametros);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar usuario: " + ex.Message);
                }
            }

            /// <summary>
            /// Busca usuarios por criterio
            /// </summary>
            public DataTable Buscar(string criterio)
            {
                try
                {
                    string query = @"SELECT IdUsuario, Nombre, Email, Telefono, Usuario, Rol,
                                CASE WHEN Activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado
                                FROM Usuarios 
                                WHERE Nombre LIKE @criterio OR Usuario LIKE @criterio OR Email LIKE @criterio
                                ORDER BY Nombre";

                    MySqlParameter[] parametros = {
                    new MySqlParameter("@criterio", "%" + criterio + "%")
                };

                    return EjecutarConsulta(query, parametros);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar usuarios: " + ex.Message);
                }
            }
    }
}
#endregion
