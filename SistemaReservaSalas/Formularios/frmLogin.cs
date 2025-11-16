using System;
using System.Windows.Forms;
using SistemaReservaSalas.Clases;
using SistemaReservaSalas.Clases.DAO;

namespace SistemaReservaSalas.Formularios
{
    /// <summary>
    /// Formulario de inicio de sesión
    /// Primer punto de acceso al sistema
    /// </summary>
    public partial class frmLogin : Form
    {
        private UsuarioDAO usuarioDAO;

        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public frmLogin()
        {
            InitializeComponent();
            usuarioDAO = new UsuarioDAO();
            ConfigurarFormulario();
        }

        /// <summary>
        /// Configura las propiedades iniciales del formulario
        /// </summary>
        private void ConfigurarFormulario()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Configurar TextBox de contraseña
            txtPassword.PasswordChar = '*';

            // Evento Enter para facilitar navegación
            txtUsuario.KeyPress += TxtUsuario_KeyPress;
            txtPassword.KeyPress += TxtPassword_KeyPress;
        }

        /// <summary>
        /// Permite presionar Enter en el campo usuario para pasar al siguiente
        /// </summary>
        private void TxtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Permite presionar Enter en el campo contraseña para iniciar sesión
        /// </summary>
        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnIngresar.PerformClick();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Evento click del botón Ingresar
        /// Valida credenciales y abre el menú principal
        /// </summary>
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos vacíos
                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MessageBox.Show("Por favor ingrese el nombre de usuario.",
                        "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Por favor ingrese la contraseña.",
                        "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }

                // Mostrar cursor de espera
                this.Cursor = Cursors.WaitCursor;

                // Intentar autenticar
                Usuario usuario = usuarioDAO.Autenticar(txtUsuario.Text.Trim(), txtPassword.Text);

                if (usuario != null)
                {
                    // Usuario autenticado correctamente
                    MessageBox.Show($"Bienvenido {usuario.Nombre}",
                        "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ocultar formulario de login
                    this.Hide();

                    // Abrir menú principal pasando el usuario autenticado
                    frmMenuPrincipal menuPrincipal = new frmMenuPrincipal(usuario);
                    menuPrincipal.ShowDialog();

                    // Al cerrar el menú principal, limpiar campos y mostrar login nuevamente
                    LimpiarCampos();
                    this.Show();
                }
                else
                {
                    // Credenciales incorrectas
                    MessageBox.Show("Usuario o contraseña incorrectos.\nPor favor verifique sus credenciales.",
                        "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar iniciar sesión:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Evento click del botón Salir
        /// Cierra la aplicación
        /// </summary>
        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea salir de la aplicación?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Limpia los campos del formulario
        /// </summary>
        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtPassword.Clear();
            txtUsuario.Focus();
        }

        /// <summary>
        /// Evento al cargar el formulario
        /// </summary>
        private void frmLogin_Load_1(object sender, EventArgs e)
        {
            // Establecer foco en el campo usuario
            txtUsuario.Focus();

            // Mostrar información de usuario por defecto (solo para desarrollo)
            // COMENTAR ESTAS LÍNEAS EN PRODUCCIÓN
            //txtUsuario.Text = "admin";
            //txtPassword.Text = "admin123";
        }

        /// <summary>
        /// Evento al cerrar el formulario
        /// </summary>
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea cerrar la aplicación?",
                    "Confirmar Cierre",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

    
    }
}