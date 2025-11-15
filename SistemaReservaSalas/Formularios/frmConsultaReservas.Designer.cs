
namespace SistemaReservaSalas
{
    partial class frmConsultaReservas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.cmbSalaFiltro = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnBuscarReservas = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalDetalle = new System.Windows.Forms.Label();
            this.dgvDetalleAsistentes = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.lblEstadoDetalle = new System.Windows.Forms.Label();
            this.lblFechaDetalle = new System.Windows.Forms.Label();
            this.lblSalaDetalle = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBuscarResponsable = new System.Windows.Forms.TextBox();
            this.lblReservaId = new System.Windows.Forms.Label();
            this.lblSubtotalDetalle = new System.Windows.Forms.Label();
            this.lblIVADetalle = new System.Windows.Forms.Label();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCancelarReserva = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblHorarioDetalle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblResponsableNombre = new System.Windows.Forms.Label();
            this.lblResponsableEmail = new System.Windows.Forms.Label();
            this.lblResponsableTelefono = new System.Windows.Forms.Label();
            this.lblProposito = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleAsistentes)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBuscarResponsable);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.dtpDesde);
            this.groupBox1.Controls.Add(this.cmbSalaFiltro);
            this.groupBox1.Controls.Add(this.cmbEstado);
            this.groupBox1.Controls.Add(this.btnBuscarReservas);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(661, 114);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Panel de Filtros:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(327, 30);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 13;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(70, 31);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 12;
            // 
            // cmbSalaFiltro
            // 
            this.cmbSalaFiltro.FormattingEnabled = true;
            this.cmbSalaFiltro.Location = new System.Drawing.Point(70, 78);
            this.cmbSalaFiltro.Name = "cmbSalaFiltro";
            this.cmbSalaFiltro.Size = new System.Drawing.Size(90, 21);
            this.cmbSalaFiltro.TabIndex = 11;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Activas",
            "Canceladas",
            "Completadas"});
            this.cmbEstado.Location = new System.Drawing.Point(246, 78);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(85, 21);
            this.cmbEstado.TabIndex = 9;
            // 
            // btnBuscarReservas
            // 
            this.btnBuscarReservas.Location = new System.Drawing.Point(580, 31);
            this.btnBuscarReservas.Name = "btnBuscarReservas";
            this.btnBuscarReservas.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarReservas.TabIndex = 8;
            this.btnBuscarReservas.Text = "Buscar";
            this.btnBuscarReservas.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Sala:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hasta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Estado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Desde:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblProposito);
            this.groupBox2.Controls.Add(this.lblResponsableTelefono);
            this.groupBox2.Controls.Add(this.lblResponsableEmail);
            this.groupBox2.Controls.Add(this.lblResponsableNombre);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblHorarioDetalle);
            this.groupBox2.Controls.Add(this.lblIVADetalle);
            this.groupBox2.Controls.Add(this.lblSubtotalDetalle);
            this.groupBox2.Controls.Add(this.lblReservaId);
            this.groupBox2.Controls.Add(this.lblTotalDetalle);
            this.groupBox2.Controls.Add(this.dgvDetalleAsistentes);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblEstadoDetalle);
            this.groupBox2.Controls.Add(this.lblFechaDetalle);
            this.groupBox2.Controls.Add(this.lblSalaDetalle);
            this.groupBox2.Location = new System.Drawing.Point(49, 375);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(576, 265);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Panel de Detalle de la Reserva:";
            // 
            // lblTotalDetalle
            // 
            this.lblTotalDetalle.AutoSize = true;
            this.lblTotalDetalle.Location = new System.Drawing.Point(409, 234);
            this.lblTotalDetalle.Name = "lblTotalDetalle";
            this.lblTotalDetalle.Size = new System.Drawing.Size(37, 13);
            this.lblTotalDetalle.TabIndex = 8;
            this.lblTotalDetalle.Text = "Total: ";
            // 
            // dgvDetalleAsistentes
            // 
            this.dgvDetalleAsistentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleAsistentes.Location = new System.Drawing.Point(6, 148);
            this.dgvDetalleAsistentes.Name = "dgvDetalleAsistentes";
            this.dgvDetalleAsistentes.Size = new System.Drawing.Size(382, 111);
            this.dgvDetalleAsistentes.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Lista de asistentes:";
            // 
            // lblEstadoDetalle
            // 
            this.lblEstadoDetalle.AutoSize = true;
            this.lblEstadoDetalle.Location = new System.Drawing.Point(23, 100);
            this.lblEstadoDetalle.Name = "lblEstadoDetalle";
            this.lblEstadoDetalle.Size = new System.Drawing.Size(43, 13);
            this.lblEstadoDetalle.TabIndex = 6;
            this.lblEstadoDetalle.Text = "Estado:";
            // 
            // lblFechaDetalle
            // 
            this.lblFechaDetalle.AutoSize = true;
            this.lblFechaDetalle.Location = new System.Drawing.Point(23, 64);
            this.lblFechaDetalle.Name = "lblFechaDetalle";
            this.lblFechaDetalle.Size = new System.Drawing.Size(40, 13);
            this.lblFechaDetalle.TabIndex = 5;
            this.lblFechaDetalle.Text = "Fecha:";
            // 
            // lblSalaDetalle
            // 
            this.lblSalaDetalle.AutoSize = true;
            this.lblSalaDetalle.Location = new System.Drawing.Point(23, 51);
            this.lblSalaDetalle.Name = "lblSalaDetalle";
            this.lblSalaDetalle.Size = new System.Drawing.Size(31, 13);
            this.lblSalaDetalle.TabIndex = 4;
            this.lblSalaDetalle.Text = "Sala:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvReservas);
            this.groupBox3.Location = new System.Drawing.Point(49, 176);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(576, 174);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lista de Reserva:";
            // 
            // dgvReservas
            // 
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Location = new System.Drawing.Point(6, 19);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.Size = new System.Drawing.Size(564, 130);
            this.dgvReservas.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label10.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(-2, -1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(691, 35);
            this.label10.TabIndex = 11;
            this.label10.Text = "CONSULTA DE RESERVAS";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(353, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Responsable:";
            // 
            // txtBuscarResponsable
            // 
            this.txtBuscarResponsable.Location = new System.Drawing.Point(433, 78);
            this.txtBuscarResponsable.Name = "txtBuscarResponsable";
            this.txtBuscarResponsable.Size = new System.Drawing.Size(135, 20);
            this.txtBuscarResponsable.TabIndex = 15;
            // 
            // lblReservaId
            // 
            this.lblReservaId.AutoSize = true;
            this.lblReservaId.Location = new System.Drawing.Point(23, 26);
            this.lblReservaId.Name = "lblReservaId";
            this.lblReservaId.Size = new System.Drawing.Size(64, 13);
            this.lblReservaId.TabIndex = 9;
            this.lblReservaId.Text = "Reserva ID:";
            // 
            // lblSubtotalDetalle
            // 
            this.lblSubtotalDetalle.AutoSize = true;
            this.lblSubtotalDetalle.Location = new System.Drawing.Point(409, 176);
            this.lblSubtotalDetalle.Name = "lblSubtotalDetalle";
            this.lblSubtotalDetalle.Size = new System.Drawing.Size(56, 13);
            this.lblSubtotalDetalle.TabIndex = 10;
            this.lblSubtotalDetalle.Text = "Sub Total:";
            // 
            // lblIVADetalle
            // 
            this.lblIVADetalle.AutoSize = true;
            this.lblIVADetalle.Location = new System.Drawing.Point(409, 204);
            this.lblIVADetalle.Name = "lblIVADetalle";
            this.lblIVADetalle.Size = new System.Drawing.Size(53, 13);
            this.lblIVADetalle.TabIndex = 11;
            this.lblIVADetalle.Text = "IVA (13%)";
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.Location = new System.Drawing.Point(12, 665);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(108, 33);
            this.btnVerDetalle.TabIndex = 12;
            this.btnVerDetalle.Text = "Ver Detalle";
            this.btnVerDetalle.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(144, 665);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(108, 33);
            this.btnModificar.TabIndex = 13;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnCancelarReserva
            // 
            this.btnCancelarReserva.Location = new System.Drawing.Point(283, 665);
            this.btnCancelarReserva.Name = "btnCancelarReserva";
            this.btnCancelarReserva.Size = new System.Drawing.Size(108, 33);
            this.btnCancelarReserva.TabIndex = 14;
            this.btnCancelarReserva.Text = "Cancelar Reserva";
            this.btnCancelarReserva.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(415, 665);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(108, 33);
            this.btnImprimir.TabIndex = 15;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(550, 665);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(108, 33);
            this.btnCerrar.TabIndex = 16;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // lblHorarioDetalle
            // 
            this.lblHorarioDetalle.AutoSize = true;
            this.lblHorarioDetalle.Location = new System.Drawing.Point(23, 77);
            this.lblHorarioDetalle.Name = "lblHorarioDetalle";
            this.lblHorarioDetalle.Size = new System.Drawing.Size(44, 13);
            this.lblHorarioDetalle.TabIndex = 12;
            this.lblHorarioDetalle.Text = "Horario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Responsable:";
            // 
            // lblResponsableNombre
            // 
            this.lblResponsableNombre.AutoSize = true;
            this.lblResponsableNombre.Location = new System.Drawing.Point(222, 51);
            this.lblResponsableNombre.Name = "lblResponsableNombre";
            this.lblResponsableNombre.Size = new System.Drawing.Size(50, 13);
            this.lblResponsableNombre.TabIndex = 14;
            this.lblResponsableNombre.Text = "Nombre: ";
            // 
            // lblResponsableEmail
            // 
            this.lblResponsableEmail.AutoSize = true;
            this.lblResponsableEmail.Location = new System.Drawing.Point(222, 77);
            this.lblResponsableEmail.Name = "lblResponsableEmail";
            this.lblResponsableEmail.Size = new System.Drawing.Size(32, 13);
            this.lblResponsableEmail.TabIndex = 15;
            this.lblResponsableEmail.Text = "Email";
            // 
            // lblResponsableTelefono
            // 
            this.lblResponsableTelefono.AutoSize = true;
            this.lblResponsableTelefono.Location = new System.Drawing.Point(222, 100);
            this.lblResponsableTelefono.Name = "lblResponsableTelefono";
            this.lblResponsableTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblResponsableTelefono.TabIndex = 16;
            this.lblResponsableTelefono.Text = "Teléfono";
            // 
            // lblProposito
            // 
            this.lblProposito.AutoSize = true;
            this.lblProposito.Location = new System.Drawing.Point(222, 122);
            this.lblProposito.Name = "lblProposito";
            this.lblProposito.Size = new System.Drawing.Size(54, 13);
            this.lblProposito.TabIndex = 17;
            this.lblProposito.Text = "Proposito:";
            // 
            // frmConsultaReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 724);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCancelarReserva);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnVerDetalle);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConsultaReservas";
            this.Text = "Nueva Reserva - Gestion de Reservas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleAsistentes)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSalaDetalle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbSalaFiltro;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnBuscarReservas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalDetalle;
        private System.Windows.Forms.DataGridView dgvDetalleAsistentes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblEstadoDetalle;
        private System.Windows.Forms.Label lblFechaDetalle;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBuscarResponsable;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblIVADetalle;
        private System.Windows.Forms.Label lblSubtotalDetalle;
        private System.Windows.Forms.Label lblReservaId;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCancelarReserva;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHorarioDetalle;
        private System.Windows.Forms.Label lblProposito;
        private System.Windows.Forms.Label lblResponsableTelefono;
        private System.Windows.Forms.Label lblResponsableEmail;
        private System.Windows.Forms.Label lblResponsableNombre;
    }
}