
namespace SistemaReservaSalas.Formularios
{
    partial class frmNuevaReserva
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnGuardarReserva = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnVerDetallesSala = new System.Windows.Forms.Button();
            this.cmbSala = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCapacidadSala = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.numDuracion = new System.Windows.Forms.NumericUpDown();
            this.btnVerificarDisponibilidad = new System.Windows.Forms.Button();
            this.lblHoraFin = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtbPropositoEvento = new System.Windows.Forms.RichTextBox();
            this.txtTelefonoResponsable = new System.Windows.Forms.TextBox();
            this.txtEmailResponsable = new System.Windows.Forms.TextBox();
            this.txtNombreResponsable = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblTotalAsistentes = new System.Windows.Forms.Label();
            this.dgvAsistentes = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComboSeleccionado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuitarAsistente = new System.Windows.Forms.Button();
            this.btnAgregarAsistente = new System.Windows.Forms.Button();
            this.cmbComboAsistente = new System.Windows.Forms.ComboBox();
            this.txtNombreAsistente = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblCombo3Detalle = new System.Windows.Forms.Label();
            this.lblCombo2Detalle = new System.Windows.Forms.Label();
            this.lblCombo1Detalle = new System.Windows.Forms.Label();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblIVA = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCombo1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDuracion)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistentes)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardarReserva
            // 
            this.btnGuardarReserva.Location = new System.Drawing.Point(125, 688);
            this.btnGuardarReserva.Name = "btnGuardarReserva";
            this.btnGuardarReserva.Size = new System.Drawing.Size(115, 40);
            this.btnGuardarReserva.TabIndex = 0;
            this.btnGuardarReserva.Text = "Guardar Reserva";
            this.btnGuardarReserva.UseVisualStyleBackColor = true;
            this.btnGuardarReserva.Click += new System.EventHandler(this.btnGuardarReserva_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(263, 688);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 40);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(365, 688);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 40);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha: ";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(64, 26);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(99, 20);
            this.dtpFecha.TabIndex = 8;
            // 
            // btnVerDetallesSala
            // 
            this.btnVerDetallesSala.Location = new System.Drawing.Point(224, 23);
            this.btnVerDetallesSala.Name = "btnVerDetallesSala";
            this.btnVerDetallesSala.Size = new System.Drawing.Size(84, 28);
            this.btnVerDetallesSala.TabIndex = 3;
            this.btnVerDetallesSala.Text = "Ver detalle";
            this.btnVerDetallesSala.UseVisualStyleBackColor = true;
            this.btnVerDetallesSala.Click += new System.EventHandler(this.btnVerDetallesSala_Click_1);
            // 
            // cmbSala
            // 
            this.cmbSala.FormattingEnabled = true;
            this.cmbSala.Location = new System.Drawing.Point(67, 29);
            this.cmbSala.Name = "cmbSala";
            this.cmbSala.Size = new System.Drawing.Size(121, 20);
            this.cmbSala.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sala:";
            // 
            // lblCapacidadSala
            // 
            this.lblCapacidadSala.AutoSize = true;
            this.lblCapacidadSala.Location = new System.Drawing.Point(355, 29);
            this.lblCapacidadSala.Name = "lblCapacidadSala";
            this.lblCapacidadSala.Size = new System.Drawing.Size(52, 12);
            this.lblCapacidadSala.TabIndex = 6;
            this.lblCapacidadSala.Text = "Capacidad";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCapacidadSala);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbSala);
            this.groupBox1.Controls.Add(this.btnVerDetallesSala);
            this.groupBox1.Location = new System.Drawing.Point(52, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 73);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccion de sala:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpHoraInicio);
            this.groupBox2.Controls.Add(this.numDuracion);
            this.groupBox2.Controls.Add(this.btnVerificarDisponibilidad);
            this.groupBox2.Controls.Add(this.lblHoraFin);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtpFecha);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(52, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(487, 110);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fecha y Hora de Reserva:";
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraInicio.Location = new System.Drawing.Point(63, 63);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.Size = new System.Drawing.Size(100, 20);
            this.dtpHoraInicio.TabIndex = 13;
            // 
            // numDuracion
            // 
            this.numDuracion.Location = new System.Drawing.Point(268, 42);
            this.numDuracion.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numDuracion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDuracion.Name = "numDuracion";
            this.numDuracion.Size = new System.Drawing.Size(49, 20);
            this.numDuracion.TabIndex = 12;
            this.numDuracion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnVerificarDisponibilidad
            // 
            this.btnVerificarDisponibilidad.Location = new System.Drawing.Point(332, 19);
            this.btnVerificarDisponibilidad.Name = "btnVerificarDisponibilidad";
            this.btnVerificarDisponibilidad.Size = new System.Drawing.Size(146, 28);
            this.btnVerificarDisponibilidad.TabIndex = 7;
            this.btnVerificarDisponibilidad.Text = "Verificar Disponivilidad:";
            this.btnVerificarDisponibilidad.UseVisualStyleBackColor = true;
            this.btnVerificarDisponibilidad.Click += new System.EventHandler(this.btnVerificarDisponibilidad_Click_1);
            // 
            // lblHoraFin
            // 
            this.lblHoraFin.AutoSize = true;
            this.lblHoraFin.Location = new System.Drawing.Point(330, 69);
            this.lblHoraFin.Name = "lblHoraFin";
            this.lblHoraFin.Size = new System.Drawing.Size(49, 12);
            this.lblHoraFin.TabIndex = 11;
            this.lblHoraFin.Text = "Hora Fin:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 31);
            this.label6.TabIndex = 10;
            this.label6.Text = "Hora de Inicio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Duracion (hrs):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtbPropositoEvento);
            this.groupBox3.Controls.Add(this.txtTelefonoResponsable);
            this.groupBox3.Controls.Add(this.txtEmailResponsable);
            this.groupBox3.Controls.Add(this.txtNombreResponsable);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(52, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(487, 138);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos del Responsable";
            // 
            // rtbPropositoEvento
            // 
            this.rtbPropositoEvento.Location = new System.Drawing.Point(268, 25);
            this.rtbPropositoEvento.Name = "rtbPropositoEvento";
            this.rtbPropositoEvento.Size = new System.Drawing.Size(200, 100);
            this.rtbPropositoEvento.TabIndex = 15;
            this.rtbPropositoEvento.Text = "";
            // 
            // txtTelefonoResponsable
            // 
            this.txtTelefonoResponsable.Location = new System.Drawing.Point(64, 78);
            this.txtTelefonoResponsable.Name = "txtTelefonoResponsable";
            this.txtTelefonoResponsable.Size = new System.Drawing.Size(138, 20);
            this.txtTelefonoResponsable.TabIndex = 14;
            // 
            // txtEmailResponsable
            // 
            this.txtEmailResponsable.Location = new System.Drawing.Point(63, 51);
            this.txtEmailResponsable.Name = "txtEmailResponsable";
            this.txtEmailResponsable.Size = new System.Drawing.Size(139, 20);
            this.txtEmailResponsable.TabIndex = 13;
            // 
            // txtNombreResponsable
            // 
            this.txtNombreResponsable.Location = new System.Drawing.Point(64, 25);
            this.txtNombreResponsable.Name = "txtNombreResponsable";
            this.txtNombreResponsable.Size = new System.Drawing.Size(138, 20);
            this.txtNombreResponsable.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(208, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "Proposito:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "Email:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "Telefono:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "Nombre:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblTotalAsistentes);
            this.groupBox4.Controls.Add(this.dgvAsistentes);
            this.groupBox4.Controls.Add(this.btnQuitarAsistente);
            this.groupBox4.Controls.Add(this.btnAgregarAsistente);
            this.groupBox4.Controls.Add(this.cmbComboAsistente);
            this.groupBox4.Controls.Add(this.txtNombreAsistente);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(52, 360);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(487, 182);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Seleccion de sala:";
            // 
            // lblTotalAsistentes
            // 
            this.lblTotalAsistentes.AutoSize = true;
            this.lblTotalAsistentes.Location = new System.Drawing.Point(330, 100);
            this.lblTotalAsistentes.Name = "lblTotalAsistentes";
            this.lblTotalAsistentes.Size = new System.Drawing.Size(80, 12);
            this.lblTotalAsistentes.TabIndex = 21;
            this.lblTotalAsistentes.Text = "Total Asistentes";
            // 
            // dgvAsistentes
            // 
            this.dgvAsistentes.AllowUserToOrderColumns = true;
            this.dgvAsistentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.ComboSeleccionado});
            this.dgvAsistentes.Location = new System.Drawing.Point(20, 55);
            this.dgvAsistentes.Name = "dgvAsistentes";
            this.dgvAsistentes.Size = new System.Drawing.Size(244, 104);
            this.dgvAsistentes.TabIndex = 20;
            // 
            // Nombre
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Nombre.DefaultCellStyle = dataGridViewCellStyle3;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // ComboSeleccionado
            // 
            this.ComboSeleccionado.HeaderText = "Combo Seleccionado";
            this.ComboSeleccionado.Name = "ComboSeleccionado";
            // 
            // btnQuitarAsistente
            // 
            this.btnQuitarAsistente.Location = new System.Drawing.Point(422, 21);
            this.btnQuitarAsistente.Name = "btnQuitarAsistente";
            this.btnQuitarAsistente.Size = new System.Drawing.Size(59, 21);
            this.btnQuitarAsistente.TabIndex = 19;
            this.btnQuitarAsistente.Text = "Quitar";
            this.btnQuitarAsistente.UseVisualStyleBackColor = true;
            this.btnQuitarAsistente.Click += new System.EventHandler(this.btnQuitarAsistente_Click_1);
            // 
            // btnAgregarAsistente
            // 
            this.btnAgregarAsistente.Location = new System.Drawing.Point(357, 20);
            this.btnAgregarAsistente.Name = "btnAgregarAsistente";
            this.btnAgregarAsistente.Size = new System.Drawing.Size(59, 21);
            this.btnAgregarAsistente.TabIndex = 18;
            this.btnAgregarAsistente.Text = "Agregar";
            this.btnAgregarAsistente.UseVisualStyleBackColor = true;
            this.btnAgregarAsistente.Click += new System.EventHandler(this.btnAgregarAsistente_Click);
            // 
            // cmbComboAsistente
            // 
            this.cmbComboAsistente.FormattingEnabled = true;
            this.cmbComboAsistente.Location = new System.Drawing.Point(257, 21);
            this.cmbComboAsistente.Name = "cmbComboAsistente";
            this.cmbComboAsistente.Size = new System.Drawing.Size(94, 20);
            this.cmbComboAsistente.TabIndex = 17;
            // 
            // txtNombreAsistente
            // 
            this.txtNombreAsistente.Location = new System.Drawing.Point(64, 26);
            this.txtNombreAsistente.Name = "txtNombreAsistente";
            this.txtNombreAsistente.Size = new System.Drawing.Size(133, 20);
            this.txtNombreAsistente.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 12);
            this.label13.TabIndex = 16;
            this.label13.Text = "Nombre:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(208, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 6;
            this.label12.Text = "Combo:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblCombo1);
            this.groupBox5.Controls.Add(this.lblCombo3Detalle);
            this.groupBox5.Controls.Add(this.lblCombo2Detalle);
            this.groupBox5.Controls.Add(this.lblCombo1Detalle);
            this.groupBox5.Controls.Add(this.lblTotalPagar);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.lblIVA);
            this.groupBox5.Controls.Add(this.lblSubtotal);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Location = new System.Drawing.Point(52, 547);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(487, 135);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Seleccion de sala:";
            // 
            // lblCombo3Detalle
            // 
            this.lblCombo3Detalle.AutoSize = true;
            this.lblCombo3Detalle.Location = new System.Drawing.Point(23, 62);
            this.lblCombo3Detalle.Name = "lblCombo3Detalle";
            this.lblCombo3Detalle.Size = new System.Drawing.Size(49, 12);
            this.lblCombo3Detalle.TabIndex = 22;
            this.lblCombo3Detalle.Text = "Combo 3:";
            // 
            // lblCombo2Detalle
            // 
            this.lblCombo2Detalle.AutoSize = true;
            this.lblCombo2Detalle.Location = new System.Drawing.Point(23, 37);
            this.lblCombo2Detalle.Name = "lblCombo2Detalle";
            this.lblCombo2Detalle.Size = new System.Drawing.Size(49, 12);
            this.lblCombo2Detalle.TabIndex = 21;
            this.lblCombo2Detalle.Text = "Combo 2:";
            // 
            // lblCombo1Detalle
            // 
            this.lblCombo1Detalle.AutoSize = true;
            this.lblCombo1Detalle.Location = new System.Drawing.Point(23, 16);
            this.lblCombo1Detalle.Name = "lblCombo1Detalle";
            this.lblCombo1Detalle.Size = new System.Drawing.Size(49, 12);
            this.lblCombo1Detalle.TabIndex = 20;
            this.lblCombo1Detalle.Text = "Combo 1:";
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.Location = new System.Drawing.Point(295, 96);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(67, 12);
            this.lblTotalPagar.TabIndex = 19;
            this.lblTotalPagar.Text = "Total a Pagar:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(295, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(145, 12);
            this.label16.TabIndex = 18;
            this.label16.Text = "-----------------------------------";
            // 
            // lblIVA
            // 
            this.lblIVA.AutoSize = true;
            this.lblIVA.Location = new System.Drawing.Point(296, 62);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(55, 12);
            this.lblIVA.TabIndex = 17;
            this.lblIVA.Text = "Iva (13%):";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(295, 37);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(49, 12);
            this.lblSubtotal.TabIndex = 16;
            this.lblSubtotal.Text = "SubTotal:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(295, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 12);
            this.label14.TabIndex = 6;
            this.label14.Text = "Combo Seleccionado:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.salasToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.reportesToolStripMenuItem1,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(622, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // salasToolStripMenuItem
            // 
            this.salasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.salasToolStripMenuItem.Name = "salasToolStripMenuItem";
            this.salasToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.salasToolStripMenuItem.Text = "Salas";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.reportesToolStripMenuItem.Text = "Reservas";
            // 
            // reportesToolStripMenuItem1
            // 
            this.reportesToolStripMenuItem1.Name = "reportesToolStripMenuItem1";
            this.reportesToolStripMenuItem1.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem1.Text = "Reportes";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // lblCombo1
            // 
            this.lblCombo1.AutoSize = true;
            this.lblCombo1.Location = new System.Drawing.Point(23, 96);
            this.lblCombo1.Name = "lblCombo1";
            this.lblCombo1.Size = new System.Drawing.Size(0, 12);
            this.lblCombo1.TabIndex = 23;
            // 
            // frmNuevaReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 749);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardarReserva);
            this.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "frmNuevaReserva";
            this.Text = "Sistema de Reserva de Salas";
            this.Load += new System.EventHandler(this.frmNuevaReserva_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDuracion)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistentes)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardarReserva;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnVerDetallesSala;
        private System.Windows.Forms.ComboBox cmbSala;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCapacidadSala;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numDuracion;
        private System.Windows.Forms.Button btnVerificarDisponibilidad;
        private System.Windows.Forms.Label lblHoraFin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTelefonoResponsable;
        private System.Windows.Forms.TextBox txtEmailResponsable;
        private System.Windows.Forms.TextBox txtNombreResponsable;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox rtbPropositoEvento;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnQuitarAsistente;
        private System.Windows.Forms.Button btnAgregarAsistente;
        private System.Windows.Forms.ComboBox cmbComboAsistente;
        private System.Windows.Forms.TextBox txtNombreAsistente;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dgvAsistentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComboSeleccionado;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.Label lblTotalAsistentes;
        private System.Windows.Forms.Label lblCombo3Detalle;
        private System.Windows.Forms.Label lblCombo2Detalle;
        private System.Windows.Forms.Label lblCombo1Detalle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.Label lblCombo1;
    }
}