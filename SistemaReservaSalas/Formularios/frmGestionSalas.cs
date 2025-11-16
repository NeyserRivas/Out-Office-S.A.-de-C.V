using System;
using System.Data;
using System.Windows.Forms;
using SistemaReservaSalas.Clases;
using SistemaReservaSalas.Clases.DAO;



namespace SistemaReservaSalas.Formularios
{
    /// <summary>
    /// Formulario para administrar las salas disponibles
    /// Incluye gestión completa de equipamiento y capacidad
    /// </summary>
    public partial class frmGestionSalas : Form
    {
        private Usuario usuarioActual;
        private SalaDAO salaDAO;
        private int idSalaSeleccionada;
        private bool esNueva;

        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public frmGestionSalas(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            salaDAO = new SalaDAO();
            ConfigurarFormulario();
        }

        /// <summary>
        /// Configura las propiedades iniciales del formulario
        /// </summary>
        private void ConfigurarFormulario()
        {
            this.Text = "Gestión de Salas";
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.Size = new System.Drawing.Size(1000, 700);

            // Configurar controles
            txtIdSala.ReadOnly = true;

            // Configurar NumericUpDown para capacidad
            numCapacidad.Minimum = 1;
            numCapacidad.Maximum = 500;
            numCapacidad.Value = 10;

            // Configurar DataGridView
            ConfigurarDataGridView();

            // Estado inicial
            EstadoInicial();
            CargarSalas();
        }

        /// <summary>
        /// Configura las columnas del DataGridView
        /// </summary>
        private void ConfigurarDataGridView()
        {
            dgvSalas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalas.MultiSelect = false;
            dgvSalas.AllowUserToAddRows = false;
            dgvSalas.ReadOnly = true;
            dgvSalas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Carga todas las salas en el DataGridView
        /// </summary>
        private void CargarSalas()
        {
            try
            {
                DataTable dt = salaDAO.Listar();
                dgvSalas.DataSource = dt;

                // Ocultar columna ID si es visible
                if (dgvSalas.Columns["IdSala"] != null)
                    dgvSalas.Columns["IdSala"].Visible = false;

                // Ajustar anchos de columnas
                if (dgvSalas.Columns["NombreSala"] != null)
                    dgvSalas.Columns["NombreSala"].Width = 200;
                if (dgvSalas.Columns["Ubicacion"] != null)
                    dgvSalas.Columns["Ubicacion"].Width = 250;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar salas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Busca salas por nombre o ubicación
        /// </summary>
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscarSala.Text))
                {
                    CargarSalas();
                }
                else
                {
                    DataTable dt = salaDAO.Buscar(txtBuscarSala.Text.Trim());
                    dgvSalas.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron salas con el criterio especificado.",
                            "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar salas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento al hacer clic en una fila del DataGridView
        /// </summary>
        private void dgvSalas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSalas.Rows[e.RowIndex];
                idSalaSeleccionada = Convert.ToInt32(row.Cells["IdSala"].Value);
                CargarDatosSala(idSalaSeleccionada);
                EstadoEdicion();
            }
        }

        /// <summary>
        /// Carga los datos de una sala en los controles
        /// </summary>
        private void CargarDatosSala(int idSala)
        {
            try
            {
                Sala sala = (Sala)salaDAO.BuscarPorId(idSala);

                if (sala != null)
                {
                    txtIdSala.Text = sala.IdSala.ToString();
                    txtNombreSala.Text = sala.NombreSala;
                    txtUbicacion.Text = sala.Ubicacion;
                    numCapacidad.Value = sala.Capacidad;
                    rtbDistribucion.Text = sala.Distribucion;

                    // Equipamiento
                    chkProyector.Checked = sala.TieneProyector;
                    chkOasis.Checked = sala.TieneOasis;
                    chkCafetera.Checked = sala.TieneCafetera;
                    chkPizarra.Checked = sala.TienePizarra;
                    chkAireAcondicionado.Checked = sala.TieneAireAcondicionado;
                    txtOtroEquipo.Text = sala.OtrosEquipos;

                    // Estado
                    chkDisponible.Checked = sala.Disponible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la sala: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Prepara el formulario para una nueva sala
        /// </summary>
        private void btnNuevaSala_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            EstadoNuevo();
            txtNombreSala.Focus();
        }

        /// <summary>
        /// Guarda una sala (nueva o actualizada)
        /// </summary>
        private void btnGuardarSala_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            try
            {
                Sala sala = new Sala
                {
                    NombreSala = txtNombreSala.Text.Trim(),
                    Ubicacion = txtUbicacion.Text.Trim(),
                    Capacidad = (int)numCapacidad.Value,
                    Distribucion = rtbDistribucion.Text.Trim(),
                    TieneProyector = chkProyector.Checked,
                    TieneOasis = chkOasis.Checked,
                    TieneCafetera = chkCafetera.Checked,
                    TienePizarra = chkPizarra.Checked,
                    TieneAireAcondicionado = chkAireAcondicionado.Checked,
                    OtrosEquipos = txtOtroEquipo.Text.Trim(),
                    Disponible = chkDisponible.Checked
                };

                bool resultado;

                if (esNueva)
                {
                    // Insertar nueva sala
                    resultado = salaDAO.Insertar(sala);

                    if (resultado)
                    {
                        MessageBox.Show("Sala guardada exitosamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Actualizar sala existente
                    sala.IdSala = idSalaSeleccionada;
                    resultado = salaDAO.Actualizar(sala);

                    if (resultado)
                    {
                        MessageBox.Show("Sala actualizada exitosamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (resultado)
                {
                    CargarSalas();
                    EstadoInicial();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar sala: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Elimina una sala
        /// </summary>
        private void btnEliminarSala_Click(object sender, EventArgs e)
        {
            if (idSalaSeleccionada == 0)
            {
                MessageBox.Show("Por favor seleccione una sala de la lista.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de eliminar esta sala?\n" +
                "Esta acción no se puede deshacer y se perderá toda la información de la sala.\n\n" +
                "ADVERTENCIA: Si la sala tiene reservas asociadas, no se podrá eliminar.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    bool eliminada = salaDAO.Eliminar(idSalaSeleccionada);

                    if (eliminada)
                    {
                        MessageBox.Show("Sala eliminada exitosamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarSalas();
                        EstadoInicial();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error al eliminar sala:\n" + ex.Message + "\n\n" +
                        "Posiblemente la sala tiene reservas asociadas.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Abre el formulario de disponibilidad para la sala seleccionada
        /// </summary>
        private void btnVerDisponibilidad_Click(object sender, EventArgs e)
        {
            if (idSalaSeleccionada == 0)
            {
                MessageBox.Show("Por favor seleccione una sala de la lista.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Sala sala = (Sala)salaDAO.BuscarPorId(idSalaSeleccionada);
                frmDisponibilidadSalas frmDisponibilidad = new frmDisponibilidadSalas(sala.IdSala);
                frmDisponibilidad.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir disponibilidad: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cancela la operación actual
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Validaciones

        /// <summary>
        /// Valida los datos de la sala antes de guardar
        /// </summary>
        private bool ValidarDatos()
        {
            // Validar nombre
            if (string.IsNullOrWhiteSpace(txtNombreSala.Text))
            {
                MessageBox.Show("Por favor ingrese el nombre de la sala.",
                    "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreSala.Focus();
                return false;
            }

            // Validar ubicación
            if (string.IsNullOrWhiteSpace(txtUbicacion.Text))
            {
                MessageBox.Show("Por favor ingrese la ubicación de la sala.",
                    "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUbicacion.Focus();
                return false;
            }

            // Validar capacidad
            if (numCapacidad.Value < 1)
            {
                MessageBox.Show("La capacidad debe ser al menos 1 persona.",
                    "Capacidad Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCapacidad.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Estados del Formulario

        /// <summary>
        /// Configura el estado inicial del formulario
        /// </summary>
        private void EstadoInicial()
        {
            LimpiarCampos();

            btnNuevaSala.Enabled = true;
            btnGuardarSala.Enabled = false;
            btnEliminarSala.Enabled = false;
            btnVerDisponibilidad.Enabled = false;
            btnCancelar.Enabled = false;

            HabilitarCampos(false);

            esNueva = false;
            idSalaSeleccionada = 0;
        }

        /// <summary>
        /// Configura el estado para nueva sala
        /// </summary>
        private void EstadoNuevo()
        {
            btnNuevaSala.Enabled = false;
            btnGuardarSala.Enabled = true;
            btnEliminarSala.Enabled = false;
            btnVerDisponibilidad.Enabled = false;
            btnCancelar.Enabled = true;

            HabilitarCampos(true);

            esNueva = true;
            chkDisponible.Checked = true;
        }

        /// <summary>
        /// Configura el estado para edición
        /// </summary>
        private void EstadoEdicion()
        {
            btnNuevaSala.Enabled = true;
            btnGuardarSala.Enabled = true;
            btnEliminarSala.Enabled = true;
            btnVerDisponibilidad.Enabled = true;
            btnCancelar.Enabled = true;

            HabilitarCampos(true);

            esNueva = false;
        }

        /// <summary>
        /// Habilita o deshabilita los campos de entrada
        /// </summary>
        private void HabilitarCampos(bool habilitar)
        {
            txtNombreSala.Enabled = habilitar;
            txtUbicacion.Enabled = habilitar;
            numCapacidad.Enabled = habilitar;
            rtbDistribucion.Enabled = habilitar;
            chkProyector.Enabled = habilitar;
            chkOasis.Enabled = habilitar;
            chkCafetera.Enabled = habilitar;
            chkPizarra.Enabled = habilitar;
            chkAireAcondicionado.Enabled = habilitar;
            txtOtroEquipo.Enabled = habilitar;
            chkDisponible.Enabled = habilitar;
        }

        /// <summary>
        /// Limpia todos los campos del formulario
        /// </summary>
        private void LimpiarCampos()
        {
            txtIdSala.Clear();
            txtNombreSala.Clear();
            txtUbicacion.Clear();
            numCapacidad.Value = 10;
            rtbDistribucion.Clear();
            chkProyector.Checked = false;
            chkOasis.Checked = false;
            chkCafetera.Checked = false;
            chkPizarra.Checked = false;
            chkAireAcondicionado.Checked = false;
            txtOtroEquipo.Clear();
            chkDisponible.Checked = true;
            txtBuscarSala.Clear();
        }



        /// <summary>
        /// Evento al presionar Enter en el campo de búsqueda
        /// </summary>
        private void txtBuscarSala_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar.PerformClick();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Evento al cargar el formulario
        /// </summary>
        private void frmGestionSalas_Load_1(object sender, EventArgs e)
        {
            txtBuscarSala.Focus();
        }

        /// <summary>
        /// Evento de doble clic en el DataGridView para editar rápidamente
        /// </summary>
        private void dgvSalas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvSalas_CellClick(sender, e);
                txtNombreSala.Focus();
            }
        }
    }   
    
}

//No se para que sirve esto pero el ide daba error si no lo ponia
#endregion