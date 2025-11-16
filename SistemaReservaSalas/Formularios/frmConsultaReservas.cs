using System;
using System.Data;
using System.Windows.Forms;
using SistemaReservaSalas.Clases;
using SistemaReservaSalas.Clases.DAO;

namespace SistemaReservaSalas.Formularios
{
    /// <summary>
    /// Formulario para consultar y gestionar reservas existentes
    /// Permite ver detalles, modificar, cancelar e imprimir reservas
    /// </summary>
    public partial class frmConsultaReservas : Form
    {
        private Usuario usuarioActual;
        private ReservaDAO reservaDAO;
        private SalaDAO salaDAO;
        private int idReservaSeleccionada;
        private Reserva reservaActual;

        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public frmConsultaReservas(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            reservaDAO = new ReservaDAO();
            salaDAO = new SalaDAO();
            ConfigurarFormulario();
        }


        /// <summary>
        /// Configura las propiedades iniciales del formulario
        /// </summary>
        private void ConfigurarFormulario()
        {
            this.Text = "Consulta de Reservas";
            this.StartPosition = FormStartPosition.CenterScreen;
            

            // Configurar DateTimePickers
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today.AddMonths(1);
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpHasta.Format = DateTimePickerFormat.Short;

            // Configurar ComboBox de Estado
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Todos");
            cmbEstado.Items.Add("Activa");
            cmbEstado.Items.Add("Cancelada");
            cmbEstado.Items.Add("Completada");
            cmbEstado.SelectedIndex = 0;

            // Cargar salas en el ComboBox de filtro
            CargarSalasFiltro();

            // Configurar DataGridViews
            ConfigurarDataGridReservas();
            ConfigurarDataGridAsistentes();

            // Limpiar panel de detalles
            LimpiarDetalles();

            // Deshabilitar botones de acción
            btnVerDetalle.Enabled = false;
            btnModificar.Enabled = false;
            btnCancelarReserva.Enabled = false;
            btnImprimir.Enabled = false;

            // Buscar reservas automáticamente
            BuscarReservas();
        }

        /// <summary>
        /// Carga las salas en el ComboBox de filtro
        /// </summary>
        private void CargarSalasFiltro()
        {
            try
            {
                DataTable dt = salaDAO.ObtenerSalasDisponibles();

                // Agregar opción "Todas"
                DataRow row = dt.NewRow();
                row["IdSala"] = 0;
                row["NombreSala"] = "Todas las salas";
                dt.Rows.InsertAt(row, 0);

                cmbSalaFiltro.DataSource = dt;
                cmbSalaFiltro.DisplayMember = "NombreSala";
                cmbSalaFiltro.ValueMember = "IdSala";
                cmbSalaFiltro.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar salas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Configura el DataGridView de reservas
        /// </summary>
        private void ConfigurarDataGridReservas()
        {
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.MultiSelect = false;
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.ReadOnly = true;
            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Configura el DataGridView de asistentes
        /// </summary>
        private void ConfigurarDataGridAsistentes()
        {
            dgvDetalleAsistentes.Columns.Clear();
            dgvDetalleAsistentes.Columns.Add("Nombre", "Nombre del Asistente");
            dgvDetalleAsistentes.Columns.Add("Combo", "Combo");
            dgvDetalleAsistentes.Columns.Add("Precio", "Precio/Hora");

            //modificale el tamaño a esas madres xq yo no se como hacerlo en propiedades
            dgvDetalleAsistentes.Columns["Nombre"].Width = 200;
            dgvDetalleAsistentes.Columns["Combo"].Width = 100;
            dgvDetalleAsistentes.Columns["Precio"].Width = 100;

            dgvDetalleAsistentes.AllowUserToAddRows = false;
            dgvDetalleAsistentes.ReadOnly = true;
        }

        /// <summary>
        /// Busca reservas según los filtros aplicados
        /// </summary>
        private void btnBuscarReservas_Click(object sender, EventArgs e)
        {
            BuscarReservas();
        }

        /// <summary>
        /// Ejecuta la búsqueda de reservas
        /// </summary>
        private void BuscarReservas()
        {
            try
            {
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date;
                int? idSala = null;

                if (cmbSalaFiltro.SelectedValue != null &&
                    Convert.ToInt32(cmbSalaFiltro.SelectedValue) > 0)
                {
                    idSala = Convert.ToInt32(cmbSalaFiltro.SelectedValue);
                }

                string estado = cmbEstado.SelectedItem.ToString();

                DataTable dt = reservaDAO.BuscarConFiltros(desde, hasta, idSala, estado);
                dgvReservas.DataSource = dt;

                // Ocultar columna ID
                if (dgvReservas.Columns["IdReserva"] != null)
                    dgvReservas.Columns["IdReserva"].Visible = false;

                // Formato de columnas
                if (dgvReservas.Columns["Fecha"] != null)
                    dgvReservas.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                if (dgvReservas.Columns["Inicio"] != null)
                    dgvReservas.Columns["Inicio"].DefaultCellStyle.Format = "hh\\:mm";

                if (dgvReservas.Columns["Fin"] != null)
                    dgvReservas.Columns["Fin"].DefaultCellStyle.Format = "hh\\:mm";

                if (dgvReservas.Columns["Total"] != null)
                    dgvReservas.Columns["Total"].DefaultCellStyle.Format = "C2";

                // Limpiar detalles
                LimpiarDetalles();
                idReservaSeleccionada = 0;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron reservas con los criterios especificados.",
                        "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar reservas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento al seleccionar una reserva del DataGridView
        /// </summary>
        private void dgvReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvReservas.Rows[e.RowIndex];
                idReservaSeleccionada = Convert.ToInt32(row.Cells["IdReserva"].Value);

                // Habilitar botones
                btnVerDetalle.Enabled = true;
                btnModificar.Enabled = true;
                btnCancelarReserva.Enabled = true;
                btnImprimir.Enabled = true;

                // Cargar detalles automáticamente
                CargarDetallesReserva();
            }
        }

        /// <summary>
        /// Muestra los detalles de la reserva seleccionada
        /// </summary>
        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (idReservaSeleccionada == 0)
            {
                MessageBox.Show("Por favor seleccione una reserva de la lista.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CargarDetallesReserva();
        }

        /// <summary>
        /// Carga los detalles completos de una reserva
        /// </summary>
        private void CargarDetallesReserva()
        {
            try
            {
                reservaActual = (Reserva)reservaDAO.BuscarPorId(idReservaSeleccionada);

                if (reservaActual != null)
                {
                    // Información de la sala
                    lblInfoSala.Text = $"{reservaActual.NombreSala}\n{reservaActual.UbicacionSala}";

                    // Fecha y horario
                    lblFechaHora.Text = $"Fecha: {reservaActual.FechaReserva:dddd, dd 'de' MMMM 'de' yyyy}\n" +
                                       $"Horario: {reservaActual.HoraInicio:hh\\:mm tt} - {reservaActual.HoraFin:hh\\:mm tt}\n" +
                                       $"Duración: {reservaActual.Duracion} horas";

                    // Responsable
                    lblResponsable.Text = $"Responsable: {reservaActual.NombreResponsable}\n" +
                                         $"Email: {reservaActual.EmailResponsable}\n" +
                                         $"Teléfono: {reservaActual.TelefonoResponsable}\n" +
                                         $"Propósito: {reservaActual.PropositoEvento}";

                    // Total
                    lblTotalDetalle.Text = $"Subtotal: ${reservaActual.Subtotal:F2}\n" +
                                          $"IVA (13%): ${reservaActual.IVA:F2}\n" +
                                          $"TOTAL: ${reservaActual.Total:F2}\n" +
                                          $"Estado: {reservaActual.Estado}";

                    // Cargar asistentes
                    dgvDetalleAsistentes.Rows.Clear();
                    foreach (var asistente in reservaActual.Asistentes)
                    {
                        dgvDetalleAsistentes.Rows.Add(
                            //TODO: Otra vez este nombre asistente que no se de donde depende
                            asistente.NombreAsistente,
                            $"Combo {asistente.ComboSeleccionado}",
                            $"${asistente.ObtenerPrecioCombo():F2}"
                        );
                    }

                    // Ajustar habilitación de botones según estado
                    if (reservaActual.Estado == "Cancelada" || reservaActual.Estado == "Completada")
                    {
                        btnModificar.Enabled = false;
                        btnCancelarReserva.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalles de la reserva: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Abre el formulario para modificar la reserva
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idReservaSeleccionada == 0)
            {
                MessageBox.Show("Por favor seleccione una reserva de la lista.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (reservaActual == null)
            {
                MessageBox.Show("Por favor cargue los detalles de la reserva primero.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (reservaActual.Estado != "Activa")
            {
                MessageBox.Show("Solo se pueden modificar reservas con estado 'Activa'.",
                    "Operación No Permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si la reserva ya pasó
            DateTime fechaHoraReserva = reservaActual.FechaReserva.Date.Add(reservaActual.HoraInicio);
            if (fechaHoraReserva < DateTime.Now)
            {
                MessageBox.Show("No se puede modificar una reserva que ya pasó.",
                    "Operación No Permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Abrir formulario de edición (puedes crear un constructor especial en frmNuevaReserva)
                MessageBox.Show(
                    "Para modificar la reserva, deberá:\n\n" +
                    "1. Cancelar esta reserva\n" +
                    "2. Crear una nueva reserva con los datos modificados\n\n" +
                    "Esta funcionalidad se implementará en una versión futura.",
                    "Modificar Reserva",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Alternativa: Abrir frmNuevaReserva con los datos cargados
                // frmNuevaReserva frm = new frmNuevaReserva(usuarioActual, reservaActual);
                // frm.ShowDialog();
                // BuscarReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar reserva: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cancela una reserva
        /// </summary>
        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            if (idReservaSeleccionada == 0)
            {
                MessageBox.Show("Por favor seleccione una reserva de la lista.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (reservaActual == null)
            {
                MessageBox.Show("Por favor cargue los detalles de la reserva primero.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (reservaActual.Estado != "Activa")
            {
                MessageBox.Show("Solo se pueden cancelar reservas con estado 'Activa'.",
                    "Operación No Permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de cancelar esta reserva?\n\n" +
                $"Sala: {reservaActual.NombreSala}\n" +
                $"Fecha: {reservaActual.FechaReserva:dd/MM/yyyy}\n" +
                $"Horario: {reservaActual.HoraInicio:hh\\:mm} - {reservaActual.HoraFin:hh\\:mm}\n" +
                $"Responsable: {reservaActual.NombreResponsable}\n\n" +
                "Esta acción no se puede deshacer.",
                "Confirmar Cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    bool cancelada = reservaDAO.CancelarReserva(idReservaSeleccionada);

                    if (cancelada)
                    {
                        MessageBox.Show("Reserva cancelada exitosamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refrescar búsqueda
                        BuscarReservas();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cancelar reserva: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Imprime o genera un documento de la reserva
        /// </summary>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (idReservaSeleccionada == 0)
            {
                MessageBox.Show("Por favor seleccione una reserva de la lista.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (reservaActual == null)
            {
                MessageBox.Show("Por favor cargue los detalles de la reserva primero.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Generar texto para imprimir
                string documento = GenerarDocumentoReserva();

                // Mostrar en un cuadro de diálogo o guardar como archivo
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Archivo de Texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
                sfd.FileName = $"Reserva_{idReservaSeleccionada}_{DateTime.Now:yyyyMMdd}.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(sfd.FileName, documento);
                    MessageBox.Show("Documento generado exitosamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abrir el archivo
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar documento: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Genera el documento de texto de la reserva
        /// </summary>
        private string GenerarDocumentoReserva()
        {
            string doc = "═══════════════════════════════════════════════════════════\n";
            doc += "            OUT OFFICE S.A. DE C.V.\n";
            doc += "        COMPROBANTE DE RESERVA DE SALA\n";
            doc += "═══════════════════════════════════════════════════════════\n\n";
            doc += $"Número de Reserva: {reservaActual.IdReserva}\n";
            doc += $"Fecha de Emisión: {DateTime.Now:dd/MM/yyyy hh:mm tt}\n";
            doc += $"Estado: {reservaActual.Estado}\n\n";

            doc += "───────────────────────────────────────────────────────────\n";
            doc += "INFORMACIÓN DE LA SALA\n";
            doc += "───────────────────────────────────────────────────────────\n";
            doc += $"Sala: {reservaActual.NombreSala}\n";
            doc += $"Ubicación: {reservaActual.UbicacionSala}\n\n";

            doc += "───────────────────────────────────────────────────────────\n";
            doc += "FECHA Y HORARIO\n";
            doc += "───────────────────────────────────────────────────────────\n";
            doc += $"Fecha: {reservaActual.FechaReserva:dddd, dd 'de' MMMM 'de' yyyy}\n";
            doc += $"Hora de Inicio: {reservaActual.HoraInicio:hh\\:mm tt}\n";
            doc += $"Hora de Finalización: {reservaActual.HoraFin:hh\\:mm tt}\n";
            doc += $"Duración: {reservaActual.Duracion} hora(s)\n\n";

            doc += "───────────────────────────────────────────────────────────\n";
            doc += "RESPONSABLE DEL EVENTO\n";
            doc += "───────────────────────────────────────────────────────────\n";
            doc += $"Nombre: {reservaActual.NombreResponsable}\n";
            doc += $"Email: {reservaActual.EmailResponsable}\n";
            doc += $"Teléfono: {reservaActual.TelefonoResponsable}\n";
            doc += $"Propósito: {reservaActual.PropositoEvento}\n\n";

            doc += "───────────────────────────────────────────────────────────\n";
            doc += "ASISTENTES Y SERVICIOS\n";
            doc += "───────────────────────────────────────────────────────────\n";

            //TODO: este GroupBy da error tambien y no se de que depense
            var agrupadoPorCombo = reservaActual.Asistentes.GroupBy(a => a.ComboSeleccionado);
            foreach (var grupo in agrupadoPorCombo.OrderBy(g => g.Key))
            {
                int cantidad = grupo.Count();
                decimal precioUnitario = grupo.First().ObtenerPrecioCombo();
                decimal subtotal = cantidad * precioUnitario * reservaActual.Duracion;

                doc += $"Combo {grupo.Key}: {cantidad} persona(s) × ${precioUnitario:F2} × {reservaActual.Duracion}h = ${subtotal:F2}\n";
            }

            doc += $"\nTotal de Asistentes: {reservaActual.Asistentes.Count}\n\n";

            doc += "───────────────────────────────────────────────────────────\n";
            doc += "DETALLE DE COSTOS\n";
            doc += "───────────────────────────────────────────────────────────\n";
            doc += $"Subtotal:           ${reservaActual.Subtotal,10:F2}\n";
            doc += $"IVA (13%):          ${reservaActual.IVA,10:F2}\n";
            doc += $"                    ──────────────\n";
            doc += $"TOTAL:              ${reservaActual.Total,10:F2}\n\n";

            doc += "═══════════════════════════════════════════════════════════\n";
            doc += "Gracias por su preferencia\n";
            doc += "Out Office S.A. de C.V.\n";
            doc += "www.outoffice.com | info@outoffice.com\n";
            doc += "═══════════════════════════════════════════════════════════\n";

            return doc;
        }

        /// <summary>
        /// Limpia el panel de detalles
        /// </summary>
        private void LimpiarDetalles()
        {
            lblInfoSala.Text = "Seleccione una reserva para ver los detalles";
            lblFechaHora.Text = "";
            lblResponsable.Text = "";
            lblTotalDetalle.Text = "";
            dgvDetalleAsistentes.Rows.Clear();

            btnVerDetalle.Enabled = false;
            btnModificar.Enabled = false;
            btnCancelarReserva.Enabled = false;
            btnImprimir.Enabled = false;
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
        private void frmConsultaReservas_Load_1(object sender, EventArgs e)
        {
            dgvReservas.Focus();
        }

        /// <summary>
        /// Evento de doble clic para ver detalles rápidamente
        /// </summary>
        private void dgvReservas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvReservas_CellClick(sender, e);
                btnVerDetalle.PerformClick();
            }
        }

    }
}