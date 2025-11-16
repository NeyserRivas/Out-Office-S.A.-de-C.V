using System;
using System.Data;
using MySql.Data.MySqlClient;
using SistemaReservaSalas.Clases;

namespace SistemaReservaSalas.Clases.DAO
{
    public abstract class BaseDAO
    {
        protected ConexionBD conexionBD = new ConexionBD();

        public abstract DataTable Listar();
        public abstract object BuscarPorId(int id);

        protected bool EjecutarComando(string query, MySqlParameter[] parametros = null)
        {
            try
            {
                conexionBD.Conectar();
                using (MySqlCommand cmd = new MySqlCommand(query, conexionBD.ObtenerConexion()))
                {
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);
                    int afectadas = cmd.ExecuteNonQuery();
                    return afectadas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar comando: " + ex.Message, ex);
            }
            finally
            {
                conexionBD.Desconectar();
            }
        }

        protected DataTable EjecutarConsulta(string query, MySqlParameter[] parametros = null)
        {
            try
            {
                conexionBD.Conectar();
                using (MySqlCommand cmd = new MySqlCommand(query, conexionBD.ObtenerConexion()))
                {
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar consulta: " + ex.Message, ex);
            }
            finally
            {
                conexionBD.Desconectar();
            }
        }

        protected int ObtenerUltimoId()
        {
            try
            {
                conexionBD.Conectar();
                string query = "SELECT LAST_INSERT_ID();";
                using (MySqlCommand cmd = new MySqlCommand(query, conexionBD.ObtenerConexion()))
                {
                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener último ID: " + ex.Message, ex);
            }
            finally
            {
                conexionBD.Desconectar();
            }
        }
    }
}
