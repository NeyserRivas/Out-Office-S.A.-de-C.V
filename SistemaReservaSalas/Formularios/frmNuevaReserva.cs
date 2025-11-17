using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SistemaReservaSalas.Clases;
using SistemaReservaSalas.Clases.DAO;

namespace SistemaReservaSalas.Formularios
{
    /// <summary>
    /// Formulario para registrar nuevas reservas de salas
    /// Incluye validación de disponibilidad y cálculo de precios combinados
    /// </summary>
    public partial class frmNuevaReserva : Form
    {
        private Usuario usuarioActual;
        private SalaDAO salaDAO;
        private ReservaDAO reservaDAO;
        private Sala salaSeleccionada;
        private List<Asistente> listaAsistentes;

        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public frmNuevaReserva(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            salaDAO = new SalaDAO();
            reservaDAO = new ReservaDAO();
            listaAsistentes = new List<Asistente>();
            ConfigurarFormulario();
        }

        /// <summary>
        /// Configura las propiedades iniciales del formulario
        /// </summary>
        private void ConfigurarFormulario()
        {
            this.Text = "Nueva Reserva de Sala";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Configurar DateTimePickers
            dtpFecha.MinDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today;
            dtpFecha.Format = DateTimePickerFormat.Long;

            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Value = DateTime.Today.AddHours(8); // 8:00 AM por defecto

            // Configurar NumericUpDown
            numDuracion.Minimum = 0.5m;
            numDuracion.Maximum = 12;
            numDuracion.DecimalPlaces = 1;
            numDuracion.Increment = 0.5m;
            numDuracion.Value = 1;

            // Configurar ComboBox de combos
            cmbComboAsistente.Items.AddRange(new object[] {
                "Combo 1 - $10.00/hora",
                "Combo 2 - $20.00/hora",
                "Combo 3 - $25.00/hora"
            });
            cmbComboAsistente.SelectedIndex = 0;

            // Configurar DataGridView de asistentes
            ConfigurarDataGridAsistentes();

            // Cargar salas
            CargarSalas();

            // Configurar eventos
            numDuracion.ValueChanged += NumDuracion_ValueChanged;
            dtpHoraInicio.ValueChanged += DtpHoraInicio_ValueChanged;
            cmbSala.SelectedIndexChanged += CmbSala_SelectedIndexChanged;

            // Calcular hora fin inicial
            CalcularHoraFin();
        }

        /// <summary>
        /// Configura las columnas del DataGridView de asistentes
        /// </summary>
        private void ConfigurarDataGridAsistentes()
        {
            dgvAsistentes.Columns.Clear();
            dgvAsistentes.Columns.Add("Nombre", "Nombre del Asistente");
            dgvAsistentes.Columns.Add("Combo", "Combo");
            dgvAsistentes.Columns.Add("Precio", "Precio/Hora");
            dgvAsistentes.Columns.Add("Subtotal", "Subtotal");

            dgvAsistentes.Columns["Nombre"].Width = 200;
            dgvAsistentes.Columns["Combo"].Width = 80;
            dgvAsistentes.Columns["Precio"].Width = 100;
            dgvAsistentes.Columns["Subtotal"].Width = 100;

            dgvAsistentes.AllowUserToAddRows = false;
            dgvAsistentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAsistentes.MultiSelect = false;
        }

        /// <summary>
        /// Carga las salas disponibles en el ComboBox
        /// </summary>
        private void CargarSalas()
        {
            try
            {
                DataTable dt = salaDAO.ObtenerSalasDisponibles();

                cmbSala.DataSource = dt;
                cmbSala.DisplayMember = "NombreSala";
                cmbSala.ValueMember = "IdSala";
                cmbSala.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar salas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento al cambiar la sala seleccionada
        /// </summary>
        private void CmbSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSala.SelectedIndex != -1)
            {
                int idSala = Convert.ToInt32(cmbSala.SelectedValue);
                salaSeleccionada = (Sala)salaDAO.BuscarPorId(idSala);

                if (salaSeleccionada != null)
                {
                    lblCapacidadSala.Text = $"Capacidad: {salaSeleccionada.Capacidad} personas";
                }
            }
        }

        /// <summary>
        /// Muestra los detalles de la sala seleccionada
        /// </summary>
        private void btnVerDetallesSala_Click_1(object sender, EventArgs e)
        {
            if (salaSeleccionada == null)
            {
                MessageBox.Show("Por favor seleccione una sala primero.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string detalles = $"DETALLES DE LA SALA\n\n" +
                            $"Nombre: {salaSeleccionada.NombreSala}\n" +
                            $"Ubicación: {salaSeleccionada.Ubicacion}\n" +
                            $"Capacidad: {salaSeleccionada.Capacidad} personas\n" +
                            $"Distribución: {salaSeleccionada.Distribucion}\n\n" +
                            $"EQUIPAMIENTO:\n" +
                            $"{salaSeleccionada.ObtenerEquipamiento()}";

            MessageBox.Show(detalles, "Detalles de la Sala",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Evento al cambiar la duración
        /// </summary>
        private void NumDuracion_ValueChanged(object sender, EventArgs e)
        {
            CalcularHoraFin();
            ActualizarTotales();
        }

        /// <summary>
        /// Evento al cambiar la hora de inicio
        /// </summary>
        private void DtpHoraInicio_ValueChanged(object sender, EventArgs e)
        {
            CalcularHoraFin();
        }

        /// <summary>
        /// Calcula y muestra la hora de finalización
        /// </summary>
        private void CalcularHoraFin()
        {
            double horas = (double)numDuracion.Value;
            DateTime horaFin = dtpHoraInicio.Value.AddHours(horas);
            lblHoraFin.Text = $"Hora de Finalización: {horaFin:hh:mm tt}";
        }

        /// <summary>
        /// Verifica la disponibilidad de la sala en la fecha y hora seleccionadas
        /// </summary>
        private void btnVerificarDisponibilidad_Click_1(object sender, EventArgs e)
        {
            /*if (!ValidarSeleccionSala())
                return;*/

            try
            {
                TimeSpan horaInicio = dtpHoraInicio.Value.TimeOfDay;
                double horas = (double)numDuracion.Value;
                TimeSpan horaFin = horaInicio.Add(TimeSpan.FromHours(horas));

                bool disponible = salaDAO.VerificarDisponibilidad(
                    Convert.ToInt32(cmbSala.SelectedValue),
                    dtpFecha.Value.Date,
                    horaInicio,
                    horaFin
                );

                if (disponible)
                {
                    MessageBox.Show(
                        "¡La sala ESTÁ DISPONIBLE en el horario seleccionado!\n\n" +
                        $"Sala: {salaSeleccionada.NombreSala}\n" +
                        $"Fecha: {dtpFecha.Value:dd/MM/yyyy}\n" +
                        $"Horario: {horaInicio:hh\\:mm} - {horaFin:hh\\:mm}",
                        "Sala Disponible",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "La sala NO está disponible en el horario seleccionado.\n" +
                        "Por favor seleccione otra fecha u horario.",
                        "Sala Ocupada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar disponibilidad: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Agrega un asistente a la lista
        /// </summary>
        private void btnAgregarAsistente_Click(object sender, EventArgs e)
        {
            /*if (!ValidarDatosAsistente())
                return;
            */
            try
            {
                // Crear asistente
                Asistente asistente = new Asistente(
                    txtNombreAsistente.Text.Trim(),
                    cmbComboAsistente.SelectedIndex + 1
                );

                // Calcular subtotal para este asistente
                decimal subtotal = asistente.CalcularCosto(numDuracion.Value);

                // Agregar a DataGridView
                dgvAsistentes.Rows.Add(
                    asistente.NombreAsistente,//TODO: NombreAsistente da un error 
                    $"Combo {asistente.ComboSeleccionado}",
                    $"${asistente.ObtenerPrecioCombo():F2}",
                    $"${subtotal:F2}"
                );

                // Agregar a lista
                listaAsistentes.Add(asistente);

                // Actualizar totales
                ActualizarTotales();
                ActualizarContadorAsistentes();

                // Limpiar campos
               // LimpiarCamposAsistente();

                MessageBox.Show("Asistente agregado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar asistente: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Quita un asistente de la lista
        /// </summary>
        private void btnQuitarAsistente_Click_1(object sender, EventArgs e)
        {
            if (dgvAsistentes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un asistente para quitar.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de quitar al asistente seleccionado?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                int indice = dgvAsistentes.SelectedRows[0].Index;
                dgvAsistentes.Rows.RemoveAt(indice);
                listaAsistentes.RemoveAt(indice);

                ActualizarTotales();
                ActualizarContadorAsistentes();
            }
        }

        /// <summary>
        /// Actualiza los totales (Subtotal, IVA, Total)
        /// </summary>
        private void ActualizarTotales()
        {
            if (listaAsistentes.Count == 0)
            {
                lblSubtotal.Text = "Subtotal: $0.00";
                lblIVA.Text = "IVA (13%): $0.00";
                lblTotalPagar.Text = "TOTAL A PAGAR: $0.00";
                return;
            }

            // Calcular subtotal sumando todos los asistentes
            decimal subtotal = 0;
            foreach (var asistente in listaAsistentes)
            {
                subtotal += asistente.CalcularCosto(numDuracion.Value);
            }

            // Calcular IVA (13%)
            decimal iva = subtotal * 0.13m;
            decimal total = subtotal + iva;

            // Mostrar
            lblSubtotal.Text = $"Subtotal: ${subtotal:F2}";
            lblIVA.Text = $"IVA (13%): ${iva:F2}";
            lblTotalPagar.Text = $"TOTAL A PAGAR: ${total:F2}";

            // Actualizar subtotales en el DataGridView
            for (int i = 0; i < dgvAsistentes.Rows.Count; i++)
            {
                decimal subtotalAsistente = listaAsistentes[i].CalcularCosto(numDuracion.Value);
                dgvAsistentes.Rows[i].Cells["Subtotal"].Value = $"${subtotalAsistente:F2}";
            }

            // Mostrar desglose de combos
            MostrarDesgloseCombos();
        }

        /// <summary>
        /// Muestra el desglose de precios por combo
        /// </summary>
        private void MostrarDesgloseCombos()
        {
            var agrupadoPorCombo = listaAsistentes.GroupBy(a => a.ComboSeleccionado);

            string desglose = "";
            foreach (var grupo in agrupadoPorCombo.OrderBy(g => g.Key))
            {
                int cantidad = grupo.Count();
                decimal precioUnitario = grupo.First().ObtenerPrecioCombo();
                decimal subtotal = cantidad * precioUnitario * numDuracion.Value;

                desglose += $"Combo {grupo.Key}: {cantidad} persona(s) × ${precioUnitario} × {numDuracion.Value}h = ${subtotal:F2}\n";
            }

            lblCombo1.Text = desglose.TrimEnd('\n');
        }

        /// <summary>
        /// Actualiza el contador de asistentes
        /// </summary>
        private void ActualizarContadorAsistentes()
        {
            lblTotalAsistentes.Text = $"Total de Asistentes: {listaAsistentes.Count}";

            // Validar capacidad
            if (salaSeleccionada != null && listaAsistentes.Count > salaSeleccionada.Capacidad)
            {
                lblTotalAsistentes.ForeColor = Color.Red;
                lblTotalAsistentes.Text += $" (¡EXCEDE CAPACIDAD DE {salaSeleccionada.Capacidad}!)";
            }
            else
            {
                lblTotalAsistentes.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Guarda la reserva en la base de datos
        /// </summary>
        private void btnGuardarReserva_Click(object sender, EventArgs e)
        {
            //if (!ValidarReserva())
                //return;

            try
            {
                // Verificar disponibilidad una vez más antes de guardar
                TimeSpan horaInicio = dtpHoraInicio.Value.TimeOfDay;
                double horas = (double)numDuracion.Value;
                TimeSpan horaFin = horaInicio.Add(TimeSpan.FromHours(horas));

                bool disponible = salaDAO.VerificarDisponibilidad(
                    Convert.ToInt32(cmbSala.SelectedValue),
                    dtpFecha.Value.Date,
                    horaInicio,
                    horaFin
                );

                if (!disponible)
                {
                    MessageBox.Show(
                        "La sala ya NO está disponible en el horario seleccionado.\n" +
                        "Otra reserva fue registrada mientras ingresaba los datos.",
                        "Sala Ocupada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Confirmar guardado
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro de guardar esta reserva?\n\n" +
                    $"Sala: {salaSeleccionada.NombreSala}\n" +
                    $"Fecha: {dtpFecha.Value:dd/MM/yyyy}\n" +
                    $"Horario: {horaInicio:hh\\:mm} - {horaFin:hh\\:mm}\n" +
                    $"Asistentes: {listaAsistentes.Count}\n" +
                    $"Total: ${(lblTotalPagar.Text.Replace("TOTAL A PAGAR: $", ""))}",
                    "Confirmar Reserva",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                    return;

                // Crear objeto Reserva
                Reserva reserva = new Reserva
                {
                    IdSala = Convert.ToInt32(cmbSala.SelectedValue),
                    IdUsuario = usuarioActual.IdUsuario,
                    FechaReserva = dtpFecha.Value.Date,
                    HoraInicio = horaInicio,
                    Duracion = numDuracion.Value,
                    NombreResponsable = txtNombreResponsable.Text.Trim(),
                    EmailResponsable = txtEmailResponsable.Text.Trim(),
                    TelefonoResponsable = txtTelefonoResponsable.Text.Trim(),
                    PropositoEvento = rtbPropositoEvento.Text.Trim(),
                    Asistentes = listaAsistentes,
                    Estado = "Activa"
                };

                // Calcular totales y hora fin
                reserva.CalcularHoraFin();
                reserva.CalcularTotales();

                // Guardar en base de datos
                this.Cursor = Cursors.WaitCursor;
                bool guardado = reservaDAO.Insertar(reserva);

                if (guardado)
                {
                    MessageBox.Show(
                        $"¡Reserva guardada exitosamente!\n\n" +
                        $"Número de Reserva: {reserva.IdReserva}\n" +
                        $"Total: ${reserva.Total:F2}",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    //LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la reserva.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar reserva: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Evento del botón Cancelar
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (listaAsistentes.Count > 0 || !string.IsNullOrWhiteSpace(txtNombreResponsable.Text))
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro de cancelar? Se perderán los datos ingresados.",
                    "Confirmar Cancelación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    //TODO: Esto dice que no existe en el contexto actual
                    //LimpiarFormulario();
                }
            }
        }

        /// <summary>
        /// Evento del botón Cerrar
        /// </summary>
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento al cargar el formulario
        /// </summary>
        private void frmNuevaReserva_Load(object sender, EventArgs e)
        {
            cmbSala.Focus();
        }

    }
}