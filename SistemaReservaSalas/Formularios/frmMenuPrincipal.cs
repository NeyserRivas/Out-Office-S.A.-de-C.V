using System;
using System.Windows.Forms;
using SistemaReservaSalas.Clases;

namespace SistemaReservaSalas.Formularios
{
    /// <summary>
    /// Formulario del menú principal del sistema
    /// Hub central de navegación
    /// </summary>
    public partial class frmMenuPrincipal : Form
    {
        private Usuario usuarioActual;
        private Timer timer;

        /// <summary>
        /// Constructor que recibe el usuario autenticado
        /// </summary>
        public frmMenuPrincipal(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            ConfigurarFormulario();
            ConfigurarPermisos();
            IniciarReloj();
        }

        /// <summary>
        /// Configura las propiedades iniciales del formulario
        /// </summary>
        private void ConfigurarFormulario()
        {
            //this.WindowState = FormWindowState.Maximized;
            //this.IsMdiContainer = true;

            // Mostrar información de bienvenida
            lblBienvenida.Text = $"Bienvenido(a): {usuarioActual.Nombre}";

            // Configurar StatusStrip
            statusStrip1.Items.Add($"Usuario: {usuarioActual.NombreUsuario} | Rol: {usuarioActual.Rol}");
        }

        /// <summary>
        /// Configura los permisos según el rol del usuario
        /// </summary>
        private void ConfigurarPermisos()
        {
            // Solo los administradores pueden gestionar usuarios
            if (!usuarioActual.EsAdministrador())
            {
                usuariosToolStripMenuItem.Visible = false;
                btnGestionUsuarios.Visible = false;
            }
        }

        /// <summary>
        /// Inicia el reloj que muestra fecha y hora actual
        /// </summary>
        private void IniciarReloj()
        {
            timer = new Timer();
            timer.Interval = 1000; // 1 segundo
            timer.Tick += Timer_Tick;
            timer.Start();
            ActualizarFechaHora();
        }

        /// <summary>
        /// Evento del timer para actualizar fecha y hora
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            ActualizarFechaHora();
        }

        /// <summary>
        /// Actualiza el label con la fecha y hora actual
        /// </summary>
        private void ActualizarFechaHora()
        {
            lblFechaHora.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy - hh:mm:ss tt");
        }

        #region Eventos del Menú Strip

        /// <summary>
        /// Menú: Usuarios → Gestión de Usuarios
        /// </summary>
        private void gestionDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmGestionUsuarios(usuarioActual));
        }

        /// <summary>
        /// Menú: Salas → Gestión de Salas
        /// </summary>
        private void gestionDeSalasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmGestionSalas(usuarioActual));
        }

        /// <summary>
        /// Menú: Salas → Ver Disponibilidad
        /// </summary>
        private void verDisponibilidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmDisponibilidadSalas());
        }

        /// <summary>
        /// Menú: Reservas → Nueva Reserva
        /// </summary>
        private void nuevaReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmNuevaReserva(usuarioActual));
        }

        /// <summary>
        /// Menú: Reservas → Consultar Reservas
        /// </summary>
        private void consultarReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmConsultaReservas(usuarioActual));
        }

        /// <summary>
        /// Menú: Reportes → Generar Reportes
        /// </summary>
        private void generarReportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReportes(usuarioActual));
        }

        /// <summary>
        /// Menú: Ayuda → Acerca De
        /// </summary>
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Sistema de Reservación de Salas\n" +
                "Versión 1.0\n\n" +
                "Out Office S.A. de C.V.\n" +
                "© 2025 Todos los derechos reservados\n\n" +
                "Desarrollado con Windows Forms y MySQL",
                "Acerca del Sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Menú: Ayuda → Manual de Usuario
        /// </summary>
        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Manual de Usuario:\n\n" +
                "1. USUARIOS: Gestione los usuarios del sistema (solo administradores)\n" +
                "2. SALAS: Administre las salas disponibles\n" +
                "3. RESERVAS: Cree y consulte reservas\n" +
                "4. REPORTES: Genere reportes de ocupación e ingresos\n\n" +
                "Para más información, contacte al administrador del sistema.",
                "Manual de Usuario",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Menú: Archivo → Cerrar Sesión
        /// </summary>
        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        /// <summary>
        /// Menú: Archivo → Salir
        /// </summary>
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarAplicacion();
        }

        #endregion

        #region Eventos de Botones del Panel

        /// <summary>
        /// Botón: Nueva Reserva
        /// </summary>
        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmNuevaReserva(usuarioActual));
        }

        /// <summary>
        /// Botón: Ver Salas
        /// </summary>
        private void btnVerSalas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmGestionSalas(usuarioActual));
        }

        /// <summary>
        /// Botón: Gestión de Usuarios (solo admin)
        /// </summary>
        private void btnGestionUsuarios_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new frmGestionUsuarios(usuarioActual));
        }

        //#endregion

        //#region Métodos Auxiliares

        /// <summary>
        /// Abre un formulario como hijo MDI
        /// </summary>
        private void AbrirFormulario(Form formulario)
        {
            try
            {
                // Cerrar formularios hijos abiertos del mismo tipo
                foreach (Form form in this.MdiChildren)
                {
                    if (form.GetType() == formulario.GetType())
                    {
                        form.Activate();
                        return;
                    }
                }

                // Abrir nuevo formulario
                formulario.MdiParent = this;
                formulario.WindowState = FormWindowState.Maximized;
                formulario.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir formulario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cierra la sesión actual y vuelve al login
        /// </summary>
        private void CerrarSesion()
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea cerrar la sesión?",
                "Confirmar Cierre de Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                timer.Stop();
                timer.Dispose();
                this.Close();
            }
        }

        /// <summary>
        /// Cierra la aplicación completamente
        /// </summary>
        private void CerrarAplicacion()
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea salir de la aplicación?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                timer.Stop();
                timer.Dispose();
                Application.Exit();
            }
        }

        #endregion

        /// <summary>
        /// Evento al cerrar el formulario
        /// </summary>
        private void frmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Detener el timer
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }

            // Cerrar todos los formularios hijos
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
        }

        /// <summary>
        /// Evento al cargar el formulario
        /// </summary>
        private void frmMenuPrincipal_Load_1(object sender, EventArgs e)
        {
            // Centrar panel de bienvenida
            panelBienvenida.Dock = DockStyle.Fill;
        }

        //cerrar 
        private void btnCerrarApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}