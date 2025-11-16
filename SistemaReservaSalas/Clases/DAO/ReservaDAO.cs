using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaSalas.Clases.DAO
{
    class ReservaDAO
    {
        /// <summary>
        /// Clase DAO para operaciones con Reservas
        /// Hereda de BaseDAO
        /// </summary>
        public class ReservaDAO : BaseDAO
        {
            private AsistenteDAO asistenteDAO;

            public ReservaDAO()
            {
                asistenteDAO = new AsistenteDAO();
            }

            /// <summary>
            /// Implementación del método abstracto Listar
            /// </summary>
            public override DataTable Listar()
            {
                string query = @"SELECT r.IdReserva, s.NombreSala AS Sala, r.FechaReserva AS Fecha,
                            r.HoraInicio AS Inicio, r.HoraFin AS Fin, r.NombreResponsable AS Responsable,
                            r.Total, r.Estado
                            FROM Reservas r
                            INNER JOIN Salas s ON r.IdSala = s.IdSala
                            ORDER BY r.FechaReserva DESC, r.HoraInicio DESC";
                return EjecutarConsulta(query);
            }

            /// <summary>
            /// Implementación del método abstracto BuscarPorId
            /// </summary>
            public override object BuscarPorId(int id)
            {
                try
                {
                    string query = @"SELECT r.*, s.NombreSala, s.Ubicacion AS UbicacionSala
                                FROM Reservas r
                                INNER JOIN Salas s ON r.IdSala = s.IdSala
                                WHERE r.IdReserva = @id";

                    MySqlParameter[] parametros = { new MySqlParameter("@id", id) };
                    DataTable dt = EjecutarConsulta(query, parametros);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        Reserva reserva = new Reserva
                        {
                            IdReserva = Convert.ToInt32(row["IdReserva"]),
                            IdSala = Convert.ToInt32(row["IdSala"]),
                            IdUsuario = Convert.ToInt32(row["IdUsuario"]),
                            FechaReserva = Convert.ToDateTime(row["FechaReserva"]),
                            HoraInicio = (TimeSpan)row["HoraInicio"],
                            Duracion = Convert.ToDecimal(row["Duracion"]),
                            HoraFin = (TimeSpan)row["HoraFin"],
                            NombreResponsable = row["NombreResponsable"].ToString(),
                            EmailResponsable = row["EmailResponsable"].ToString(),
                            TelefonoResponsable = row["TelefonoResponsable"].ToString(),
                            PropositoEvento = row["PropositoEvento"].ToString(),
                            Subtotal = Convert.ToDecimal(row["Subtotal"]),
                            IVA = Convert.ToDecimal(row["IVA"]),
                            Total = Convert.ToDecimal(row["Total"]),
                            Estado = row["Estado"].ToString(),
                            NombreSala = row["NombreSala"].ToString(),
                            UbicacionSala = row["UbicacionSala"].ToString()
                        };

                        // Cargar asistentes
                        reserva.Asistentes = asistenteDAO.ObtenerPorReserva(reserva.IdReserva);

                        return reserva;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar reserva: " + ex.Message);
                }
            }

            /// <summary>
            /// Inserta una nueva reserva con sus asistentes
            /// </summary>
            public bool Insertar(Reserva reserva)
            {
                try
                {
                    conexionBD.Conectar();

                    // Iniciar transacción
                    MySqlTransaction transaccion = conexionBD.ObtenerConexion().BeginTransaction();

                    try
                    {
                        // Insertar reserva
                        string query = @"INSERT INTO Reservas 
                                    (IdSala, IdUsuario, FechaReserva, HoraInicio, Duracion, HoraFin,
                                    NombreResponsable, EmailResponsable, TelefonoResponsable, PropositoEvento,
                                    Subtotal, IVA, Total, Estado)
                                    VALUES 
                                    (@idSala, @idUsuario, @fecha, @horaInicio, @duracion, @horaFin,
                                    @nombreResp, @emailResp, @telefonoResp, @proposito,
                                    @subtotal, @iva, @total, @estado)";

                        using (MySqlCommand cmd = new MySqlCommand(query, conexionBD.ObtenerConexion(), transaccion))
                        {
                            cmd.Parameters.AddWithValue("@idSala", reserva.IdSala);
                            cmd.Parameters.AddWithValue("@idUsuario", reserva.IdUsuario);
                            cmd.Parameters.AddWithValue("@fecha", reserva.FechaReserva.Date);
                            cmd.Parameters.AddWithValue("@horaInicio", reserva.HoraInicio);
                            cmd.Parameters.AddWithValue("@duracion", reserva.Duracion);
                            cmd.Parameters.AddWithValue("@horaFin", reserva.HoraFin);
                            cmd.Parameters.AddWithValue("@nombreResp", reserva.NombreResponsable);
                            cmd.Parameters.AddWithValue("@emailResp", reserva.EmailResponsable);
                            cmd.Parameters.AddWithValue("@telefonoResp", reserva.TelefonoResponsable ?? "");
                            cmd.Parameters.AddWithValue("@proposito", reserva.PropositoEvento ?? "");
                            cmd.Parameters.AddWithValue("@subtotal", reserva.Subtotal);
                            cmd.Parameters.AddWithValue("@iva", reserva.IVA);
                            cmd.Parameters.AddWithValue("@total", reserva.Total);
                            cmd.Parameters.AddWithValue("@estado", reserva.Estado);

                            cmd.ExecuteNonQuery();
                        }

                        // Obtener el ID de la reserva insertada
                        int idReserva = ObtenerUltimoId();
                        reserva.IdReserva = idReserva;

                        // Insertar asistentes
                        foreach (var asistente in reserva.Asistentes)
                        {
                            asistente.IdReserva = idReserva;
                            asistenteDAO.InsertarConTransaccion(asistente, transaccion);
                        }

                        // Confirmar transacción
                        transaccion.Commit();
                        return true;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar reserva: " + ex.Message);
                }
                finally
                {
                    conexionBD.Desconectar();
                }
            }

            /// <summary>
            /// Actualiza una reserva existente
            /// </summary>
            public bool Actualizar(Reserva reserva)
            {
                try
                {
                    conexionBD.Conectar();
                    MySqlTransaction transaccion = conexionBD.ObtenerConexion().BeginTransaction();

                    try
                    {
                        // Actualizar reserva
                        string query = @"UPDATE Reservas SET 
                                    IdSala = @idSala, FechaReserva = @fecha, HoraInicio = @horaInicio,
                                    Duracion = @duracion, HoraFin = @horaFin, NombreResponsable = @nombreResp,
                                    EmailResponsable = @emailResp, TelefonoResponsable = @telefonoResp,
                                    PropositoEvento = @proposito, Subtotal = @subtotal, IVA = @iva,
                                    Total = @total, Estado = @estado
                                    WHERE IdReserva = @id";

                        using (MySqlCommand cmd = new MySqlCommand(query, conexionBD.ObtenerConexion(), transaccion))
                        {
                            cmd.Parameters.AddWithValue("@id", reserva.IdReserva);
                            cmd.Parameters.AddWithValue("@idSala", reserva.IdSala);
                            cmd.Parameters.AddWithValue("@fecha", reserva.FechaReserva.Date);
                            cmd.Parameters.AddWithValue("@horaInicio", reserva.HoraInicio);
                            cmd.Parameters.AddWithValue("@duracion", reserva.Duracion);
                            cmd.Parameters.AddWithValue("@horaFin", reserva.HoraFin);
                            cmd.Parameters.AddWithValue("@nombreResp", reserva.NombreResponsable);
                            cmd.Parameters.AddWithValue("@emailResp", reserva.EmailResponsable);
                            cmd.Parameters.AddWithValue("@telefonoResp", reserva.TelefonoResponsable ?? "");
                            cmd.Parameters.AddWithValue("@proposito", reserva.PropositoEvento ?? "");
                            cmd.Parameters.AddWithValue("@subtotal", reserva.Subtotal);
                            cmd.Parameters.AddWithValue("@iva", reserva.IVA);
                            cmd.Parameters.AddWithValue("@total", reserva.Total);
                            cmd.Parameters.AddWithValue("@estado", reserva.Estado);

                            cmd.ExecuteNonQuery();
                        }

                        // Eliminar asistentes anteriores
                        asistenteDAO.EliminarPorReservaConTransaccion(reserva.IdReserva, transaccion);

                        // Insertar nuevos asistentes
                        foreach (var asistente in reserva.Asistentes)
                        {
                            asistente.IdReserva = reserva.IdReserva;
                            asistenteDAO.InsertarConTransaccion(asistente, transaccion);
                        }

                        transaccion.Commit();
                        return true;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar reserva: " + ex.Message);
                }
                finally
                {
                    conexionBD.Desconectar();
                }
            }

            /// <summary>
            /// Cancela una reserva (cambiar estado)
            /// </summary>
            public bool CancelarReserva(int idReserva)
            {
                try
                {
                    string query = "UPDATE Reservas SET Estado = 'Cancelada' WHERE IdReserva = @id";
                    MySqlParameter[] parametros = { new MySqlParameter("@id", idReserva) };
                    return EjecutarComando(query, parametros);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cancelar reserva: " + ex.Message);
                }
            }

            /// <summary>
            /// Busca reservas por múltiples criterios
            /// </summary>
            public DataTable BuscarConFiltros(DateTime? fechaDesde, DateTime? fechaHasta, int? idSala, string estado)
            {
                try
                {
                    string query = @"SELECT r.IdReserva, s.NombreSala AS Sala, r.FechaReserva AS Fecha,
                                r.HoraInicio AS Inicio, r.HoraFin AS Fin, r.NombreResponsable AS Responsable,
                                r.Total, r.Estado
                                FROM Reservas r
                                INNER JOIN Salas s ON r.IdSala = s.IdSala
                                WHERE 1=1";

                    List<MySqlParameter> parametros = new List<MySqlParameter>();

                    if (fechaDesde.HasValue)
                    {
                        query += " AND r.FechaReserva >= @fechaDesde";
                        parametros.Add(new MySqlParameter("@fechaDesde", fechaDesde.Value.Date));
                    }

                    if (fechaHasta.HasValue)
                    {
                        query += " AND r.FechaReserva <= @fechaHasta";
                        parametros.Add(new MySqlParameter("@fechaHasta", fechaHasta.Value.Date));
                    }

                    if (idSala.HasValue && idSala.Value > 0)
                    {
                        query += " AND r.IdSala = @idSala";
                        parametros.Add(new MySqlParameter("@idSala", idSala.Value));
                    }

                    if (!string.IsNullOrEmpty(estado) && estado != "Todos")
                    {
                        query += " AND r.Estado = @estado";
                        parametros.Add(new MySqlParameter("@estado", estado));
                    }

                    query += " ORDER BY r.FechaReserva DESC, r.HoraInicio DESC";

                    return EjecutarConsulta(query, parametros.ToArray());
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar reservas: " + ex.Message);
                }
            }

            /// <summary>
            /// Obtiene los horarios ocupados de una sala en una fecha
            /// </summary>
            public DataTable ObtenerHorariosOcupados(int idSala, DateTime fecha)
            {
                try
                {
                    string query = @"SELECT HoraInicio, HoraFin, NombreResponsable, Estado
                                FROM Reservas
                                WHERE IdSala = @idSala AND FechaReserva = @fecha AND Estado = 'Activa'
                                ORDER BY HoraInicio";

                    MySqlParameter[] parametros = {
                    new MySqlParameter("@idSala", idSala),
                    new MySqlParameter("@fecha", fecha.Date)
                };

                    return EjecutarConsulta(query, parametros);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener horarios: " + ex.Message);
                }
            }

            /// <summary>
            /// Obtiene reservas para reportes por fecha
            /// </summary>
            public DataTable ObtenerReportePorFecha(DateTime fechaDesde, DateTime fechaHasta)
            {
                try
                {
                    string query = @"SELECT r.FechaReserva AS Fecha, s.NombreSala AS Sala,
                                COUNT(*) AS CantidadReservas, SUM(r.Total) AS TotalIngresos
                                FROM Reservas r
                                INNER JOIN Salas s ON r.IdSala = s.IdSala
                                WHERE r.FechaReserva BETWEEN @desde AND @hasta
                                AND r.Estado != 'Cancelada'
                                GROUP BY r.FechaReserva, s.NombreSala
                                ORDER BY r.FechaReserva DESC";

                    MySqlParameter[] parametros = {
                    new MySqlParameter("@desde", fechaDesde.Date),
                    new MySqlParameter("@hasta", fechaHasta.Date)
                };

                    return EjecutarConsulta(query, parametros);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al generar reporte: " + ex.Message);
                }
            }

            /// <summary>
            /// Obtiene ingresos por sala
            /// </summary>
            public DataTable ObtenerIngresosPorSala(DateTime fechaDesde, DateTime fechaHasta)
            {
                try
                {
                    string query = @"SELECT s.NombreSala AS Sala, COUNT(r.IdReserva) AS TotalReservas,
                                SUM(r.Total) AS TotalIngresos
                                FROM Salas s
                                LEFT JOIN Reservas r ON s.IdSala = r.IdSala 
                                AND r.FechaReserva BETWEEN @desde AND @hasta
                                AND r.Estado != 'Cancelada'
                                GROUP BY s.IdSala, s.NombreSala
                                ORDER BY TotalIngresos DESC";

                    MySqlParameter[] parametros = {
                    new MySqlParameter("@desde", fechaDesde.Date),
                    new MySqlParameter("@hasta", fechaHasta.Date)
                };

                    return EjecutarConsulta(query, parametros);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener ingresos: " + ex.Message);
                }
            }

            /// <summary>
            /// Obtiene ocupación de salas
            /// </summary>
            public DataTable ObtenerOcupacionSalas(DateTime fechaDesde, DateTime fechaHasta)
            {
                try
                {
                    string query = @"SELECT s.NombreSala AS Sala, 
                                COUNT(r.IdReserva) AS ReservasActivas,
                                SUM(r.Duracion) AS HorasTotales
                                FROM Salas s
                                LEFT JOIN Reservas r ON s.IdSala = r.IdSala 
                                AND r.FechaReserva BETWEEN @desde AND @hasta
                                AND r.Estado = 'Activa'
                                GROUP BY s.IdSala, s.NombreSala
                                ORDER BY HorasTotales DESC";

                    MySqlParameter[] parametros = {
                    new MySqlParameter("@desde", fechaDesde.Date),
                    new MySqlParameter("@hasta", fechaHasta.Date)
                };

                    return EjecutarConsulta(query, parametros);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener ocupación: " + ex.Message);
                }
            }
        }
    }
}
