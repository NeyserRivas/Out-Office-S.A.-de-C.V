using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaReservaSalas.Clases;
using SistemaReservaSalas.Clases.DAO;

namespace SistemaReservaSalas.Formularios
{
    /// <summary>
    /// Formulario para ver la disponibilidad de salas en formato calendario
    /// Muestra los horarios ocupados y disponibles por día
    /// </summary>
    public partial class frmDisponibilidadSalas : Form
    {
        private SalaDAO salaDAO;
        private ReservaDAO reservaDAO;
        private int idSalaPreseleccionada;

        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public frmDisponibilidadSalas()
        {
            InitializeComponent();
            salaDAO = new SalaDAO();
            reservaDAO = new ReservaDAO();
            idSalaPreseleccionada = 0;
            ConfigurarFormulario();
        }

        /// <summary>
        /// Constructor con sala preseleccionada
        /// </summary>
        public frmDisponibilidadSalas(int idSala)
        {
            InitializeComponent();
            salaDAO = new SalaDAO();
            reservaDAO = new ReservaDAO();
            idSalaPreseleccionada = idSala;
            ConfigurarFormulario();
        }

        /// <summary>
        /// Configura las propiedades iniciales del formulario
        /// </summary>
        private void ConfigurarFormulario()
        {
            this.Text = "Disponibilidad de Salas";
            this.StartPosition = FormStartPosition.CenterScreen;
            

            // Configurar MonthCalendar
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar1.ShowToday = true;
            monthCalendar1.ShowTodayCircle = true;
            monthCalendar1.TodayDate = DateTime.Today;

            // Cargar salas en el ComboBox
            CargarSalas();

            // Configurar DataGridView de horarios
            ConfigurarDataGridHorarios();

            // Actualizar información del día seleccionado
            ActualizarInformacionDia();

            // Si hay sala preseleccionada, seleccionarla
            if (idSalaPreseleccionada > 0)
            {
                for (int i = 0; i < cmbSalaCalendario.Items.Count; i++)
                {
                    DataRowView row = (DataRowView)cmbSalaCalendario.Items[i];
                    if (Convert.ToInt32(row["IdSala"]) == idSalaPreseleccionada)
                    {
                        cmbSalaCalendario.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Carga las salas en el ComboBox
        /// </summary>
        private void CargarSalas()
        {
            try
            {
                DataTable dt = salaDAO.Listar();

                // Agregar columna combinada para mostrar
                dt.Columns.Add("SalaCompleta", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    row["SalaCompleta"] = $"{row["NombreSala"]} - Cap: {row["Capacidad"]}";
                }

                cmbSalaCalendario.DataSource = dt;
                cmbSalaCalendario.DisplayMember = "SalaCompleta";
                cmbSalaCalendario.ValueMember = "IdSala";
                cmbSalaCalendario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar salas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Configura el DataGridView de horarios
        /// </summary>
        private void ConfigurarDataGridHorarios()
        {
            dgvHorarios.Columns.Clear();
            dgvHorarios.Columns.Add("HoraInicio", "Hora Inicio");
            dgvHorarios.Columns.Add("HoraFin", "Hora Fin");
            dgvHorarios.Columns.Add("Responsable", "Responsable");
            dgvHorarios.Columns.Add("Estado", "Estado");

            dgvHorarios.Columns["HoraInicio"].Width = 100;
            dgvHorarios.Columns["HoraFin"].Width = 100;
            dgvHorarios.Columns["Responsable"].Width = 200;
            dgvHorarios.Columns["Estado"].Width = 100;

            dgvHorarios.AllowUserToAddRows = false;
            dgvHorarios.ReadOnly = true;
            dgvHorarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// Evento al cambiar la fecha seleccionada en el calendario
        /// </summary>
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            ActualizarInformacionDia();
        }

        /// <summary>
        /// Evento al cambiar la sala seleccionada
        /// </summary>
        private void cmbSalaCalendario_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarInformacionDia();
        }

        /// <summary>
        /// Actualiza la información del día y sala seleccionados
        /// </summary>
        private void ActualizarInformacionDia()
        {
            DateTime fecha = monthCalendar1.SelectionStart;

            // Actualizar label de información
            string infoFecha = $"Fecha: {fecha:dddd, dd 'de' MMMM 'de' yyyy}";

            if (cmbSalaCalendario.SelectedIndex == -1)
            {
                //lblInfoDia.Text = infoFecha + "\n\nSeleccione una sala para ver su disponibilidad.";
                dgvHorarios.Rows.Clear();
                return;
            }

            try
            {
                int idSala = Convert.ToInt32(cmbSalaCalendario.SelectedValue);
                DataRowView salaRow = (DataRowView)cmbSalaCalendario.SelectedItem;
                string nombreSala = salaRow["NombreSala"].ToString();

                // Obtener horarios ocupados
                DataTable horarios = reservaDAO.ObtenerHorariosOcupados(idSala, fecha);

                // Limpiar DataGridView
                dgvHorarios.Rows.Clear();

                if (horarios.Rows.Count == 0)
                {
                    //TODO: estos lblInfoDia no se donde colocarlos porque
                    //ya no tengo espacio en un forms porque ademas no se de donde salio
                    lblInfoDia.Text = infoFecha + $"\nSala: {nombreSala}\n\n" +
                                     "✓ ¡SALA DISPONIBLE TODO EL DÍA!";
                    lblInfoDia.ForeColor = Color.Green;
                }
                else
                {
                    lblInfoDia.Text = infoFecha + $"\nSala: {nombreSala}\n\n" +
                                     $"⚠ {horarios.Rows.Count} reserva(s) registrada(s)";
                    lblInfoDia.ForeColor = Color.Orange;

                    // Cargar horarios ocupados
                    foreach (DataRow row in horarios.Rows)
                    {
                        TimeSpan horaInicio = (TimeSpan)row["HoraInicio"];
                        TimeSpan horaFin = (TimeSpan)row["HoraFin"];
                        string responsable = row["NombreResponsable"].ToString();
                        string estado = row["Estado"].ToString();

                        dgvHorarios.Rows.Add(
                            horaInicio.ToString(@"hh\:mm"),
                            horaFin.ToString(@"hh\:mm"),
                            responsable,
                            estado
                        );
                    }

                    // Colorear filas según estado
                    foreach (DataGridViewRow row in dgvHorarios.Rows)
                    {
                        string estado = row.Cells["Estado"].Value.ToString();
                        if (estado == "Activa")
                        {
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                        }
                        else if (estado == "Cancelada")
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                            row.DefaultCellStyle.ForeColor = Color.DarkGray;
                        }
                        else if (estado == "Completada")
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                    }
                }

                // Mostrar horarios disponibles sugeridos
                MostrarHorariosDisponibles(horarios);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar información: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Muestra los horarios disponibles del día
        /// </summary>
        private void MostrarHorariosDisponibles(DataTable horariosOcupados)
        {
            if (horariosOcupados.Rows.Count == 0)
            {
                return;
            }

            // Calcular horarios disponibles (lógica simple)
            string disponibles = "\n\nHorarios sugeridos disponibles:\n";

            // Horarios estándar de oficina
            TimeSpan[] horariosEstandar = {
                new TimeSpan(8, 0, 0),   // 8:00 AM
                new TimeSpan(10, 0, 0),  // 10:00 AM
                new TimeSpan(12, 0, 0),  // 12:00 PM
                new TimeSpan(14, 0, 0),  // 2:00 PM
                new TimeSpan(16, 0, 0),  // 4:00 PM
                new TimeSpan(18, 0, 0)   // 6:00 PM
            };

            bool hayDisponibles = false;
            foreach (TimeSpan hora in horariosEstandar)
            {
                bool estaOcupado = false;

                foreach (DataRow row in horariosOcupados.Rows)
                {
                    if (row["Estado"].ToString() != "Activa") continue;

                    TimeSpan horaInicio = (TimeSpan)row["HoraInicio"];
                    TimeSpan horaFin = (TimeSpan)row["HoraFin"];

                    if (hora >= horaInicio && hora < horaFin)
                    {
                        estaOcupado = true;
                        break;
                    }
                }

                if (!estaOcupado)
                {
                    disponibles += $"• {hora:hh\\:mm tt}\n";
                    hayDisponibles = true;
                }
            }

            if (hayDisponibles)
            {
                lblInfoDia.Text += disponibles;
            }
        }

        /// <summary>
        /// Actualiza la visualización
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarInformacionDia();
            MessageBox.Show("Información actualizada.",
                "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento al cargar el formulario
        /// </summary>
        private void frmDisponibilidadSalas_Load(object sender, EventArgs e)
        {
            // Seleccionar la primera sala si no hay preselección
            if (cmbSalaCalendario.SelectedIndex == -1 && cmbSalaCalendario.Items.Count > 0)
            {
                cmbSalaCalendario.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Muestra una leyenda de colores
        /// </summary>
        //TODO: Tampoco tiene referencias
        private void MostrarLeyenda()
        {
            string leyenda = "LEYENDA DE ESTADOS:\n\n" +
                           "🟡 Amarillo: Reserva Activa\n" +
                           "🟢 Verde: Reserva Completada\n" +
                           "⚫ Gris: Reserva Cancelada";

            MessageBox.Show(leyenda, "Leyenda de Colores",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Evento de doble clic en el calendario para seleccionar fecha rápidamente
        /// </summary>
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            ActualizarInformacionDia();
        }

        /// <summary>
        /// Genera un resumen semanal de disponibilidad
        /// </summary>
        //TODO: No tiene ninguna referencia y se supone que es el metodo de algo 
        private void GenerarResumenSemanal()
        {
            if (cmbSalaCalendario.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione una sala primero.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int idSala = Convert.ToInt32(cmbSalaCalendario.SelectedValue);
                DateTime fechaInicio = monthCalendar1.SelectionStart;
                DateTime fechaFin = fechaInicio.AddDays(6);

                string resumen = $"RESUMEN SEMANAL DE DISPONIBILIDAD\n";
                resumen += $"Sala: {cmbSalaCalendario.Text}\n";
                resumen += $"Semana del {fechaInicio:dd/MM/yyyy} al {fechaFin:dd/MM/yyyy}\n";
                resumen += "═══════════════════════════════════════════\n\n";

                for (DateTime fecha = fechaInicio; fecha <= fechaFin; fecha = fecha.AddDays(1))
                {
                    DataTable horarios = reservaDAO.ObtenerHorariosOcupados(idSala, fecha);

                    resumen += $"{fecha:dddd dd/MM}: ";
                    if (horarios.Rows.Count == 0)
                    {
                        resumen += "✓ Disponible\n";
                    }
                    else
                    {
                        resumen += $"{horarios.Rows.Count} reserva(s)\n";
                    }
                }

                MessageBox.Show(resumen, "Resumen Semanal",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar resumen: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //TODO: No tene funcionalidad alguna
        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {

        }
    }
}