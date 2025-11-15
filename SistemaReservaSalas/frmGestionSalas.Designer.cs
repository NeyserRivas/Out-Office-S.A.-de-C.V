
namespace SistemaReservaSalas
{
    partial class frmGestionSalas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuscarSala = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvSalas = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rtbDistribucion = new System.Windows.Forms.RichTextBox();
            this.numCapacidad = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.txtNombreSala = new System.Windows.Forms.TextBox();
            this.l = new System.Windows.Forms.Label();
            this.txtIdSala = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkProyector = new System.Windows.Forms.CheckBox();
            this.chkPizarra = new System.Windows.Forms.CheckBox();
            this.chkOasis = new System.Windows.Forms.CheckBox();
            this.chkAireAcondicionado = new System.Windows.Forms.CheckBox();
            this.chkCafetera = new System.Windows.Forms.CheckBox();
            this.chkOtro = new System.Windows.Forms.CheckBox();
            this.chkDisponible = new System.Windows.Forms.CheckBox();
            this.txtOtroEquipo = new System.Windows.Forms.TextBox();
            this.btnNuevaSala = new System.Windows.Forms.Button();
            this.btnGuardarSala = new System.Windows.Forms.Button();
            this.btnVerCalendario = new System.Windows.Forms.Button();
            this.btnEliminarSala = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacidad)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(881, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión de Salas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(256, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Buscar Sala:";
            // 
            // txtBuscarSala
            // 
            this.txtBuscarSala.Location = new System.Drawing.Point(331, 50);
            this.txtBuscarSala.Name = "txtBuscarSala";
            this.txtBuscarSala.Size = new System.Drawing.Size(194, 20);
            this.txtBuscarSala.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(547, 47);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dgvSalas
            // 
            this.dgvSalas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalas.Location = new System.Drawing.Point(128, 108);
            this.dgvSalas.Name = "dgvSalas";
            this.dgvSalas.Size = new System.Drawing.Size(627, 150);
            this.dgvSalas.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(205, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lista de salas:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDisponible);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.rtbDistribucion);
            this.groupBox1.Controls.Add(this.numCapacidad);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtUbicacion);
            this.groupBox1.Controls.Add(this.txtNombreSala);
            this.groupBox1.Controls.Add(this.l);
            this.groupBox1.Controls.Add(this.txtIdSala);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(27, 296);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(823, 274);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "Distribución Física:";
            // 
            // rtbDistribucion
            // 
            this.rtbDistribucion.Location = new System.Drawing.Point(206, 90);
            this.rtbDistribucion.Name = "rtbDistribucion";
            this.rtbDistribucion.Size = new System.Drawing.Size(144, 96);
            this.rtbDistribucion.TabIndex = 8;
            this.rtbDistribucion.Text = "";
            // 
            // numCapacidad
            // 
            this.numCapacidad.Location = new System.Drawing.Point(21, 217);
            this.numCapacidad.Name = "numCapacidad";
            this.numCapacidad.Size = new System.Drawing.Size(136, 20);
            this.numCapacidad.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "Capacidad: (Personas)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ubicación/Dirección";
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(21, 149);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(136, 20);
            this.txtUbicacion.TabIndex = 4;
            // 
            // txtNombreSala
            // 
            this.txtNombreSala.Location = new System.Drawing.Point(19, 90);
            this.txtNombreSala.Name = "txtNombreSala";
            this.txtNombreSala.Size = new System.Drawing.Size(138, 20);
            this.txtNombreSala.TabIndex = 3;
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.Location = new System.Drawing.Point(19, 63);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(79, 12);
            this.l.TabIndex = 2;
            this.l.Text = "Nombre de sala:";
            // 
            // txtIdSala
            // 
            this.txtIdSala.Location = new System.Drawing.Point(57, 20);
            this.txtIdSala.Name = "txtIdSala";
            this.txtIdSala.Size = new System.Drawing.Size(100, 20);
            this.txtIdSala.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "ID:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOtroEquipo);
            this.groupBox2.Controls.Add(this.chkOtro);
            this.groupBox2.Controls.Add(this.chkCafetera);
            this.groupBox2.Controls.Add(this.chkAireAcondicionado);
            this.groupBox2.Controls.Add(this.chkOasis);
            this.groupBox2.Controls.Add(this.chkPizarra);
            this.groupBox2.Controls.Add(this.chkProyector);
            this.groupBox2.Location = new System.Drawing.Point(436, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 173);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Equipamiento Disponible";
            // 
            // chkProyector
            // 
            this.chkProyector.AutoSize = true;
            this.chkProyector.Location = new System.Drawing.Point(19, 33);
            this.chkProyector.Name = "chkProyector";
            this.chkProyector.Size = new System.Drawing.Size(72, 16);
            this.chkProyector.TabIndex = 11;
            this.chkProyector.Text = "Proyector";
            this.chkProyector.UseVisualStyleBackColor = true;
            // 
            // chkPizarra
            // 
            this.chkPizarra.AutoSize = true;
            this.chkPizarra.Location = new System.Drawing.Point(19, 65);
            this.chkPizarra.Name = "chkPizarra";
            this.chkPizarra.Size = new System.Drawing.Size(58, 16);
            this.chkPizarra.TabIndex = 12;
            this.chkPizarra.Text = "Pizarra";
            this.chkPizarra.UseVisualStyleBackColor = true;
            // 
            // chkOasis
            // 
            this.chkOasis.AutoSize = true;
            this.chkOasis.Location = new System.Drawing.Point(19, 95);
            this.chkOasis.Name = "chkOasis";
            this.chkOasis.Size = new System.Drawing.Size(49, 16);
            this.chkOasis.TabIndex = 13;
            this.chkOasis.Text = "Oasis";
            this.chkOasis.UseVisualStyleBackColor = true;
            // 
            // chkAireAcondicionado
            // 
            this.chkAireAcondicionado.AutoSize = true;
            this.chkAireAcondicionado.Location = new System.Drawing.Point(161, 30);
            this.chkAireAcondicionado.Name = "chkAireAcondicionado";
            this.chkAireAcondicionado.Size = new System.Drawing.Size(116, 16);
            this.chkAireAcondicionado.TabIndex = 14;
            this.chkAireAcondicionado.Text = "Aire Acondicionado";
            this.chkAireAcondicionado.UseVisualStyleBackColor = true;
            // 
            // chkCafetera
            // 
            this.chkCafetera.AutoSize = true;
            this.chkCafetera.Location = new System.Drawing.Point(161, 65);
            this.chkCafetera.Name = "chkCafetera";
            this.chkCafetera.Size = new System.Drawing.Size(62, 16);
            this.chkCafetera.TabIndex = 15;
            this.chkCafetera.Text = "Cafétera";
            this.chkCafetera.UseVisualStyleBackColor = true;
            // 
            // chkOtro
            // 
            this.chkOtro.AutoSize = true;
            this.chkOtro.Location = new System.Drawing.Point(161, 95);
            this.chkOtro.Name = "chkOtro";
            this.chkOtro.Size = new System.Drawing.Size(46, 16);
            this.chkOtro.TabIndex = 16;
            this.chkOtro.Text = "Otro";
            this.chkOtro.UseVisualStyleBackColor = true;
            // 
            // chkDisponible
            // 
            this.chkDisponible.AutoSize = true;
            this.chkDisponible.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisponible.Location = new System.Drawing.Point(314, 230);
            this.chkDisponible.Name = "chkDisponible";
            this.chkDisponible.Size = new System.Drawing.Size(215, 21);
            this.chkDisponible.TabIndex = 11;
            this.chkDisponible.Text = "Sala Disponible para Reservas ";
            this.chkDisponible.UseVisualStyleBackColor = true;
            // 
            // txtOtroEquipo
            // 
            this.txtOtroEquipo.Location = new System.Drawing.Point(213, 91);
            this.txtOtroEquipo.Name = "txtOtroEquipo";
            this.txtOtroEquipo.Size = new System.Drawing.Size(100, 20);
            this.txtOtroEquipo.TabIndex = 17;
            // 
            // btnNuevaSala
            // 
            this.btnNuevaSala.Location = new System.Drawing.Point(46, 607);
            this.btnNuevaSala.Name = "btnNuevaSala";
            this.btnNuevaSala.Size = new System.Drawing.Size(101, 43);
            this.btnNuevaSala.TabIndex = 7;
            this.btnNuevaSala.Text = "Nueva Sala";
            this.btnNuevaSala.UseVisualStyleBackColor = true;
            // 
            // btnGuardarSala
            // 
            this.btnGuardarSala.Location = new System.Drawing.Point(207, 607);
            this.btnGuardarSala.Name = "btnGuardarSala";
            this.btnGuardarSala.Size = new System.Drawing.Size(101, 43);
            this.btnGuardarSala.TabIndex = 8;
            this.btnGuardarSala.Text = "Guardar";
            this.btnGuardarSala.UseVisualStyleBackColor = true;
            // 
            // btnVerCalendario
            // 
            this.btnVerCalendario.Location = new System.Drawing.Point(547, 607);
            this.btnVerCalendario.Name = "btnVerCalendario";
            this.btnVerCalendario.Size = new System.Drawing.Size(101, 43);
            this.btnVerCalendario.TabIndex = 9;
            this.btnVerCalendario.Text = "Ver  Calendario";
            this.btnVerCalendario.UseVisualStyleBackColor = true;
            // 
            // btnEliminarSala
            // 
            this.btnEliminarSala.Location = new System.Drawing.Point(378, 607);
            this.btnEliminarSala.Name = "btnEliminarSala";
            this.btnEliminarSala.Size = new System.Drawing.Size(101, 43);
            this.btnEliminarSala.TabIndex = 10;
            this.btnEliminarSala.Text = "Eliminar";
            this.btnEliminarSala.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(705, 607);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(101, 43);
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // frmGestionSalas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 677);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnEliminarSala);
            this.Controls.Add(this.btnVerCalendario);
            this.Controls.Add(this.btnGuardarSala);
            this.Controls.Add(this.btnNuevaSala);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvSalas);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscarSala);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmGestionSalas";
            this.Text = "Gestión de Salas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacidad)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuscarSala;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvSalas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.TextBox txtNombreSala;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.TextBox txtIdSala;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtbDistribucion;
        private System.Windows.Forms.NumericUpDown numCapacidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkDisponible;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtOtroEquipo;
        private System.Windows.Forms.CheckBox chkOtro;
        private System.Windows.Forms.CheckBox chkCafetera;
        private System.Windows.Forms.CheckBox chkAireAcondicionado;
        private System.Windows.Forms.CheckBox chkOasis;
        private System.Windows.Forms.CheckBox chkPizarra;
        private System.Windows.Forms.CheckBox chkProyector;
        private System.Windows.Forms.Button btnNuevaSala;
        private System.Windows.Forms.Button btnGuardarSala;
        private System.Windows.Forms.Button btnVerCalendario;
        private System.Windows.Forms.Button btnEliminarSala;
        private System.Windows.Forms.Button btnCerrar;
    }
}