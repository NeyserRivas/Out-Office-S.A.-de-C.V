using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaSalas.Clases.DAO
{
    public class AsistenteDAO : BaseDAO
    {
        /// <summary>
        /// Clase DAO para operaciones con Asistentes
        /// Hereda de BaseDAO
        /// Implementación del método abstracto Listar
        /// </summary>
            public override DataTable Listar()
            {
                string query = "SELECT * FROM AsistentesReserva ORDER BY IdAsistente";
                return EjecutarConsulta(query);
            }

            /// <summary>
            /// Implementación del método abstracto BuscarPorId
            /// </summary>
            public override object BuscarPorId(int id)
            {
                try
                {
                    string query = "SELECT * FROM AsistentesReserva WHERE IdAsistente = @id";
                    MySqlParameter[] parametros = { new MySqlParameter("@id", id) };
                    DataTable dt = EjecutarConsulta(query, parametros);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        return new Asistente(
                            Convert.ToInt32(row["IdAsistente"]),
                            Convert.ToInt32(row["IdReserva"]),
                            row["NombreAsistente"].ToString(),
                            Convert.ToInt32(row["ComboSeleccionado"])
                        );
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar asistente: " + ex.Message);
                }
            }

            /// <summary>
            /// Obtiene todos los asistentes de una reserva
            /// </summary>
            public List<Asistente> ObtenerPorReserva(int idReserva)
            {
                List<Asistente> asistentes = new List<Asistente>();
                try
                {
                    string query = "SELECT * FROM AsistentesReserva WHERE IdReserva = @idReserva";
                    MySqlParameter[] parametros = { new MySqlParameter("@idReserva", idReserva) };
                    DataTable dt = EjecutarConsulta(query, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        asistentes.Add(new Asistente(
                            Convert.ToInt32(row["IdAsistente"]),
                            Convert.ToInt32(row["IdReserva"]),
                            row["NombreAsistente"].ToString(),
                            Convert.ToInt32(row["ComboSeleccionado"])
                        ));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener asistentes: " + ex.Message);
                }
                return asistentes;
            }

            /// <summary>
            /// Inserta un asistente con transacción
            /// </summary>
            public void InsertarConTransaccion(Asistente asistente, MySqlTransaction transaccion)
            {
                try
                {
                    string query = @"INSERT INTO AsistentesReserva (IdReserva, NombreAsistente, ComboSeleccionado)
                                VALUES (@idReserva, @nombre, @combo)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexionBD.ObtenerConexion(), transaccion))
                    {
                        cmd.Parameters.AddWithValue("@idReserva", asistente.IdReserva);
                        cmd.Parameters.AddWithValue("@nombre", asistente.NombreAsistente);
                        cmd.Parameters.AddWithValue("@combo", asistente.ComboSeleccionado);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar asistente: " + ex.Message);
                }
            }

            /// <summary>
            /// Elimina asistentes por reserva con transacción
            /// </summary>
            public void EliminarPorReservaConTransaccion(int idReserva, MySqlTransaction transaccion)
            {
                try
                {
                    string query = "DELETE FROM AsistentesReserva WHERE IdReserva = @idReserva";
                    using (MySqlCommand cmd = new MySqlCommand(query, conexionBD.ObtenerConexion(), transaccion))
                    {
                        cmd.Parameters.AddWithValue("@idReserva", idReserva);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar asistentes: " + ex.Message);
                }
            }
    }
}
