using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaSalas.Clases.DAO
{
    class SalaDAO
    {
        #region Clase SalaDAO - Hereda de BaseDAO (HERENCIA 3)
        /// <summary>
        /// Clase DAO para operaciones con Salas
        /// Hereda de BaseDAO
        /// </summary>
        public class SalaDAO : BaseDAO
        {
            /// <summary>
            /// Implementación del método abstracto Listar
            /// </summary>
            public override DataTable Listar()
            {
                string query = @"SELECT IdSala, NombreSala, Ubicacion, Capacidad,
                            CASE WHEN Disponible = 1 THEN 'Disponible' ELSE 'No Disponible' END AS Estado
                            FROM Salas ORDER BY NombreSala";
                return EjecutarConsulta(query);
            }

            /// <summary>
            /// Implementación del método abstracto BuscarPorId
            /// </summary>
            public override object BuscarPorId(int id)
            {
                try
                {
                    string query = "SELECT * FROM Salas WHERE IdSala = @id";
                    MySqlParameter[] parametros = { new MySqlParameter("@id", id) };
                    DataTable dt = EjecutarConsulta(query, parametros);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        return new Sala
                        {
                            IdSala = Convert.ToInt32(row["IdSala"]),
                            NombreSala = row["NombreSala"].ToString(),
                            Ubicacion = row["Ubicacion"].ToString(),
                            Capacidad = Convert.ToInt32(row["Capacidad"]),
                            Distribucion = row["Distribucion"].ToString(),
                            TieneProyector = Convert.ToBoolean(row["TieneProyector"]),
                            TieneOasis = Convert.ToBoolean(row["TieneOasis"]),
                            TieneCafetera = Convert.ToBoolean(row["TieneCafetera"]),
                            TienePizarra = Convert.ToBoolean(row["TienePizarra"]),
                            TieneAireAcondicionado = Convert.ToBoolean(row["TieneAireAcondicionado"]),
                            OtrosEquipos = row["OtrosEquipos"].ToString(),
                            Disponible = Convert.ToBoolean(row["Disponible"])
                        };
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar sala: " + ex.Message);
                }
            }

            /// <summary>
            /// Inserta una nueva sala
            /// </summary>
            public bool Insertar(Sala sala)
            {
                try
                {
                    string query = @"INSERT INTO Salas (NombreSala, Ubicacion, Capacidad, Distribucion,
                                TieneProyector, TieneOasis, TieneCafetera, TienePizarra, TieneAireAcondicionado,
                                OtrosEquipos, Disponible)
                                VALUES (@nombre, @ubicacion, @capacidad, @distribucion,
                                @proyector, @oasis, @cafetera, @pizarra, @aire, @otros, @disponible)";

                    MySqlParameter[] parametros = {
                    new MySqlParameter("@nombre", sala.NombreSala),
                    new MySqlParameter("@ubicacion", sala.Ubicacion),
                    new MySqlParameter("@capacidad", sala.Capacidad),
                    new MySqlParameter("@distribucion", sala.Distribucion ?? ""),
                    new MySqlParameter("@proyector", sala.TieneProyector),
                    new MySqlParameter("@oasis", sala.TieneOasis),
                    new MySqlParameter("@cafetera", sala.TieneCafetera),
                    new MySqlParameter("@pizarra", sala.TienePizarra),
                    new MySqlParameter("@aire", sala.TieneAireAcondicionado),
                    new MySqlParameter("@otros", sala.OtrosEquipos ?? ""),
                    new MySqlParameter("@disponible", sala.Disponible)
                };

                    return EjecutarComando(query, parametros);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar sala: " + ex.Message);
                }
            }

            /// <summary>
            /// Actualiza una sala existente
            /// </summary>
            public bool Actualizar(Sala sala)
            {
                try
                {
                    string query = @"UPDATE Salas SET 
                                NombreSala = @nombre, Ubicacion = @ubicacion, Capacidad = @capacidad,
                                Distribucion = @distribucion, TieneProyector = @proyector, TieneOasis = @oasis,
                                TieneCafetera = @cafetera, TienePizarra = @pizarra, 
                                TieneAireAcondicionado = @aire, OtrosEquipos = @otros, Disponible = @disponible
                                WHERE IdSala = @id";

                    MySqlParameter[] parametros = {
                    new MySqlParameter("@id", sala.IdSala),
                    new MySqlParameter("@nombre", sala.NombreSala),
                    new MySqlParameter("@ubicacion", sala.Ubicacion),
                    new MySqlParameter("@capacidad", sala.Capacidad),
                    new MySqlParameter("@distribucion", sala.Distribucion ?? ""),
                    new MySqlParameter("@proyector", sala.TieneProyector),
                    new MySqlParameter("@oasis", sala.TieneOasis),
                    new MySqlParameter("@cafetera", sala.TieneCafetera),
                    new MySqlParameter("@pizarra", sala.TienePizarra),
                    new MySqlParameter("@aire", sala.TieneAireAcondicionado),
                    new MySqlParameter("@otros", sala.OtrosEquipos ?? ""),
                    new MySqlParameter("@disponible", sala.Disponible)
                };

                    return EjecutarComando(query, parametros);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar sala: " + ex.Message);
                }
            }

            /// <summary>
            /// Elimina una sala
            /// </summary>
            public bool Eliminar(int idSala)
            {
                try
                {
                    string query = "DELETE FROM Salas WHERE IdSala = @id";
                    MySqlParameter[] parametros = { new MySqlParameter("@id", idSala) };
                    return EjecutarComando(query, parametros);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar sala: " + ex.Message);
                }
            }

            /// <summary>
            /// Busca salas por criterio
            /// </summary>
            public DataTable Buscar(string criterio)
            {
                try
                {
                    string query = @"SELECT IdSala, NombreSala, Ubicacion, Capacidad,
                                CASE WHEN Disponible = 1 THEN 'Disponible' ELSE 'No Disponible' END AS Estado
                                FROM Salas 
                                WHERE NombreSala LIKE @criterio OR Ubicacion LIKE @criterio
                                ORDER BY NombreSala";

                    MySqlParameter[] parametros = {
                    new MySqlParameter("@criterio", "%" + criterio + "%")
                };

                    return EjecutarConsulta(query, parametros);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar salas: " + ex.Message);
                }
            }

            /// <summary>
            /// Obtiene todas las salas disponibles
            /// </summary>
            public DataTable ObtenerSalasDisponibles()
            {
                string query = "SELECT IdSala, NombreSala, Capacidad FROM Salas WHERE Disponible = 1 ORDER BY NombreSala";
                return EjecutarConsulta(query);
            }

            /// <summary>
            /// Verifica disponibilidad de una sala en fecha y hora específica
            /// </summary>
            public bool VerificarDisponibilidad(int idSala, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin, int idReservaExcluir = 0)
            {
                try
                {
                    string query = @"SELECT COUNT(*) FROM Reservas 
                                WHERE IdSala = @idSala 
                                AND FechaReserva = @fecha 
                                AND Estado = 'Activa'
                                AND IdReserva != @idExcluir
                                AND (
                                    (@horaInicio >= HoraInicio AND @horaInicio < HoraFin) OR
                                    (@horaFin > HoraInicio AND @horaFin <= HoraFin) OR
                                    (@horaInicio <= HoraInicio AND @horaFin >= HoraFin)
                                )";

                    MySqlParameter[] parametros = {
                    new MySqlParameter("@idSala", idSala),
                    new MySqlParameter("@fecha", fecha.Date),
                    new MySqlParameter("@horaInicio", horaInicio),
                    new MySqlParameter("@horaFin", horaFin),
                    new MySqlParameter("@idExcluir", idReservaExcluir)
                };

                    conexionBD.Conectar();
                    using (MySqlCommand cmd = new MySqlCommand(query, conexionBD.ObtenerConexion()))
                    {
                        cmd.Parameters.AddRange(parametros);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count == 0; // Disponible si no hay conflictos
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al verificar disponibilidad: " + ex.Message);
                }
                finally
                {
                    conexionBD.Desconectar();
                }
            }
        }
    }
}
