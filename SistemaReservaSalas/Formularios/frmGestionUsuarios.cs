using System;
using System.Data;
using System.Windows.Forms;
using SistemaReservaSalas.Clases;
using SistemaReservaSalas.Clases.DAO;

namespace SistemaReservaSalas.Formularios
{
    /// <summary>
    /// Formulario para administrar usuarios del sistema
    /// Solo accesible para administradores
    /// </summary>
    public partial class frmGestionUsuarios : Form
    {
        private Usuario usuarioActual;
        private UsuarioDAO usuarioDAO;
        private int idUsuarioSeleccionado;
        private bool esNuevo;

        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public frmGestionUsuarios(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            usuarioDAO = new UsuarioDAO();
            ConfigurarFormulario();
        }

        /// <summary>
        /// Configura las propiedades iniciales del formulario
        /// </summary>
        private void ConfigurarFormulario()
        {
            this.Text = "Gestión de Usuarios";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Verificar permisos
            if (!usuarioActual.EsAdministrador())
            {
                MessageBox.Show("No tiene permisos para acceder a este módulo.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Configurar controles
            txtIdUsuario.ReadOnly = true;
            txtPassword.PasswordChar = '*';

            // Configurar ComboBox de Rol
            cmbRol.Items.Clear();
            cmbRol.Items.Add("Administrador");
            cmbRol.Items.Add("Usuario");
            cmbRol.SelectedIndex = 1; // Usuario por defecto

            // Configurar DataGridView
            ConfigurarDataGridView();

            // Estado inicial
            EstadoInicial();
            CargarUsuarios();
        }

        /// <summary>
        /// Configura las columnas del DataGridView
        /// </summary>
        private void ConfigurarDataGridView()
        {
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Carga todos los usuarios en el DataGridView
        /// </summary>
        private void CargarUsuarios()
        {
            try
            {
                DataTable dt = usuarioDAO.Listar();
                dgvUsuarios.DataSource = dt;

                // Ocultar columna ID si es visible
                if (dgvUsuarios.Columns["IdUsuario"] != null)
                    dgvUsuarios.Columns["IdUsuario"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Busca usuarios por criterio
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    CargarUsuarios();
                }
                else
                {
                    DataTable dt = usuarioDAO.Buscar(txtBuscar.Text.Trim());
                    dgvUsuarios.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron usuarios con el criterio especificado.",
                            "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar usuarios: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento al hacer clic en una fila del DataGridView
        /// </summary>
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];
                idUsuarioSeleccionado = Convert.ToInt32(row.Cells["IdUsuario"].Value);
                CargarDatosUsuario(idUsuarioSeleccionado);
                EstadoEdicion();
            }
        }

        /// <summary>
        /// Carga los datos de un usuario en los controles
        /// </summary>
        private void CargarDatosUsuario(int idUsuario)
        {
            try
            {
                Usuario usuario = (Usuario)usuarioDAO.BuscarPorId(idUsuario);

                if (usuario != null)
                {
                    txtIdUsuario.Text = usuario.IdUsuario.ToString();
                    txtNombre.Text = usuario.Nombre;
                    txtEmail.Text = usuario.Email;
                    txtTelefono.Text = usuario.Telefono;
                    txtUsuario.Text = usuario.NombreUsuario;
                    txtPassword.Text = usuario.Password;
                    cmbRol.SelectedItem = usuario.Rol;
                    chkActivo.Checked = usuario.Activo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del usuario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Prepara el formulario para un nuevo usuario
        /// </summary>
        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            LimpiarCampos();
            EstadoNuevo();
            txtNombre.Focus();
        }

        /// <summary>
        /// Guarda un usuario (nuevo o actualizado)
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            try
            {
                Usuario usuario = new Usuario(
                    txtNombre.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtUsuario.Text.Trim(),
                    txtPassword.Text,
                    cmbRol.SelectedItem.ToString()
                );
                usuario.Activo = chkActivo.Checked;

                bool resultado;

                if (esNuevo)
                {
                    // Insertar nuevo usuario
                    resultado = usuarioDAO.Insertar(usuario);

                    if (resultado)
                    {
                        MessageBox.Show("Usuario guardado exitosamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Actualizar usuario existente
                    usuario.IdUsuario = idUsuarioSeleccionado;
                    resultado = usuarioDAO.Actualizar(usuario);

                    if (resultado)
                    {
                        MessageBox.Show("Usuario actualizado exitosamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (resultado)
                {
                    CargarUsuarios();
                    EstadoInicial();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Elimina (desactiva) un usuario
        /// </summary>
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Por favor seleccione un usuario de la lista.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // No permitir eliminar al usuario actual
            if (idUsuarioSeleccionado == usuarioActual.IdUsuario)
            {
                MessageBox.Show("No puede eliminar su propio usuario.",
                    "Operación No Permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de desactivar este usuario?\n" +
                "El usuario no podrá iniciar sesión en el sistema.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    bool eliminado = usuarioDAO.Eliminar(idUsuarioSeleccionado);

                    if (eliminado)
                    {
                        MessageBox.Show("Usuario desactivado exitosamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
                        EstadoInicial();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar usuario: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        /// Valida los datos del usuario antes de guardar
        /// </summary>
        private bool ValidarDatos()
        {
            // Validar nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor ingrese el nombre completo.",
                    "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            // Validar email
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Por favor ingrese un email válido.",
                    "Email Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Validar usuario
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Por favor ingrese el nombre de usuario.",
                    "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }

            if (txtUsuario.Text.Length < 4)
            {
                MessageBox.Show("El nombre de usuario debe tener al menos 4 caracteres.",
                    "Usuario Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }

            // Validar contraseña
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Por favor ingrese la contraseña.",
                    "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.",
                    "Contraseña Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            // Validar rol
            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione un rol.",
                    "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
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

            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;

            HabilitarCampos(false);

            esNuevo = false;
            idUsuarioSeleccionado = 0;
        }

        /// <summary>
        /// Configura el estado para nuevo usuario
        /// </summary>
        private void EstadoNuevo()
        {
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = true;

            HabilitarCampos(true);

            esNuevo = true;
            chkActivo.Checked = true;
        }

        /// <summary>
        /// Configura el estado para edición
        /// </summary>
        private void EstadoEdicion()
        {
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = true;
            btnEliminar.Enabled = true;
            btnCancelar.Enabled = true;

            HabilitarCampos(true);

            esNuevo = false;
        }

        /// <summary>
        /// Habilita o deshabilita los campos de entrada
        /// </summary>
        private void HabilitarCampos(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtEmail.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            txtUsuario.Enabled = habilitar;
            txtPassword.Enabled = habilitar;
            cmbRol.Enabled = habilitar;
            chkActivo.Enabled = habilitar;
        }

        /// <summary>
        /// Limpia todos los campos del formulario
        /// </summary>
        private void LimpiarCampos()
        {
            txtIdUsuario.Clear();
            txtNombre.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtUsuario.Clear();
            txtPassword.Clear();
            cmbRol.SelectedIndex = 1; // Usuario por defecto
            chkActivo.Checked = true;
            txtBuscar.Clear();
        }

        #endregion

        /// <summary>
        /// Evento al presionar Enter en el campo de búsqueda
        /// </summary>
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmGestionUsuarios_Load_1(object sender, EventArgs e)
        {
            txtBuscar.Focus();
        }
    }
}