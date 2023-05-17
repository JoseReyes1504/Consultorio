namespace CML
{
    partial class FrmMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.PictureBox();
            this.lblHora = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnControlDiario = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnEntregaMeds = new System.Windows.Forms.Button();
            this.btnExpediente = new System.Windows.Forms.Button();
            this.btnIncapacidad = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnBitacora = new System.Windows.Forms.Button();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Tiempo = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(142)))), ((int)(((byte)(118)))));
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.lblHora);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1228, 47);
            this.panel1.TabIndex = 89;
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(1675, 14);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(33, 33);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSalir.TabIndex = 81;
            this.btnSalir.TabStop = false;
            // 
            // lblHora
            // 
            this.lblHora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(142)))), ((int)(((byte)(118)))));
            this.lblHora.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblHora.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHora.ForeColor = System.Drawing.Color.White;
            this.lblHora.Location = new System.Drawing.Point(989, -2);
            this.lblHora.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblHora.Name = "lblHora";
            this.lblHora.ReadOnly = true;
            this.lblHora.ShortcutsEnabled = false;
            this.lblHora.Size = new System.Drawing.Size(239, 46);
            this.lblHora.TabIndex = 108;
            this.lblHora.Text = "00/00/00";
            this.lblHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(354, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(521, 39);
            this.label1.TabIndex = 109;
            this.label1.Text = "CONSULTORIO MEDICO LITORAL";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(477, 317);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(277, 254);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 111;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnControlDiario);
            this.groupBox1.Controls.Add(this.btnReportes);
            this.groupBox1.Controls.Add(this.btnEntregaMeds);
            this.groupBox1.Controls.Add(this.btnExpediente);
            this.groupBox1.Controls.Add(this.btnIncapacidad);
            this.groupBox1.Controls.Add(this.btnInventario);
            this.groupBox1.Controls.Add(this.btnBitacora);
            this.groupBox1.Controls.Add(this.btnConsulta);
            this.groupBox1.Controls.Add(this.btnUsuarios);
            this.groupBox1.Location = new System.Drawing.Point(28, 55);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1168, 258);
            this.groupBox1.TabIndex = 106;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnControlDiario
            // 
            this.btnControlDiario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControlDiario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnControlDiario.ForeColor = System.Drawing.Color.White;
            this.btnControlDiario.Image = ((System.Drawing.Image)(resources.GetObject("btnControlDiario.Image")));
            this.btnControlDiario.Location = new System.Drawing.Point(605, 145);
            this.btnControlDiario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnControlDiario.Name = "btnControlDiario";
            this.btnControlDiario.Size = new System.Drawing.Size(195, 97);
            this.btnControlDiario.TabIndex = 113;
            this.btnControlDiario.Text = "Control Diario";
            this.btnControlDiario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnControlDiario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnControlDiario.UseVisualStyleBackColor = false;
            this.btnControlDiario.Click += new System.EventHandler(this.btnControlDiario_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Image = ((System.Drawing.Image)(resources.GetObject("btnReportes.Image")));
            this.btnReportes.Location = new System.Drawing.Point(720, 21);
            this.btnReportes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(195, 97);
            this.btnReportes.TabIndex = 112;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnEntregaMeds
            // 
            this.btnEntregaMeds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntregaMeds.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntregaMeds.ForeColor = System.Drawing.Color.White;
            this.btnEntregaMeds.Image = ((System.Drawing.Image)(resources.GetObject("btnEntregaMeds.Image")));
            this.btnEntregaMeds.Location = new System.Drawing.Point(147, 145);
            this.btnEntregaMeds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEntregaMeds.Name = "btnEntregaMeds";
            this.btnEntregaMeds.Size = new System.Drawing.Size(195, 97);
            this.btnEntregaMeds.TabIndex = 111;
            this.btnEntregaMeds.Text = "Entrega Meds";
            this.btnEntregaMeds.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEntregaMeds.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEntregaMeds.UseVisualStyleBackColor = false;
            this.btnEntregaMeds.Click += new System.EventHandler(this.btnEntregaMeds_Click);
            // 
            // btnExpediente
            // 
            this.btnExpediente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpediente.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpediente.ForeColor = System.Drawing.Color.White;
            this.btnExpediente.Image = ((System.Drawing.Image)(resources.GetObject("btnExpediente.Image")));
            this.btnExpediente.Location = new System.Drawing.Point(30, 21);
            this.btnExpediente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExpediente.Name = "btnExpediente";
            this.btnExpediente.Size = new System.Drawing.Size(195, 97);
            this.btnExpediente.TabIndex = 110;
            this.btnExpediente.Text = "Expediente";
            this.btnExpediente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExpediente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExpediente.UseVisualStyleBackColor = false;
            this.btnExpediente.Click += new System.EventHandler(this.btnExpediente_Click);
            // 
            // btnIncapacidad
            // 
            this.btnIncapacidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncapacidad.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncapacidad.ForeColor = System.Drawing.Color.White;
            this.btnIncapacidad.Image = ((System.Drawing.Image)(resources.GetObject("btnIncapacidad.Image")));
            this.btnIncapacidad.Location = new System.Drawing.Point(376, 145);
            this.btnIncapacidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIncapacidad.Name = "btnIncapacidad";
            this.btnIncapacidad.Size = new System.Drawing.Size(195, 97);
            this.btnIncapacidad.TabIndex = 109;
            this.btnIncapacidad.Text = "Incapacidad";
            this.btnIncapacidad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIncapacidad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIncapacidad.UseVisualStyleBackColor = false;
            this.btnIncapacidad.Click += new System.EventHandler(this.btnIncapacidad_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.ForeColor = System.Drawing.Color.White;
            this.btnInventario.Image = ((System.Drawing.Image)(resources.GetObject("btnInventario.Image")));
            this.btnInventario.Location = new System.Drawing.Point(944, 21);
            this.btnInventario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(195, 97);
            this.btnInventario.TabIndex = 108;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnBitacora
            // 
            this.btnBitacora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBitacora.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBitacora.ForeColor = System.Drawing.Color.White;
            this.btnBitacora.Image = ((System.Drawing.Image)(resources.GetObject("btnBitacora.Image")));
            this.btnBitacora.Location = new System.Drawing.Point(830, 145);
            this.btnBitacora.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBitacora.Name = "btnBitacora";
            this.btnBitacora.Size = new System.Drawing.Size(195, 97);
            this.btnBitacora.TabIndex = 107;
            this.btnBitacora.Text = "Bitácora";
            this.btnBitacora.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBitacora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBitacora.UseVisualStyleBackColor = false;
            this.btnBitacora.Click += new System.EventHandler(this.btnBitacora_Click);
            // 
            // btnConsulta
            // 
            this.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsulta.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsulta.ForeColor = System.Drawing.Color.White;
            this.btnConsulta.Image = ((System.Drawing.Image)(resources.GetObject("btnConsulta.Image")));
            this.btnConsulta.Location = new System.Drawing.Point(260, 21);
            this.btnConsulta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(195, 97);
            this.btnConsulta.TabIndex = 106;
            this.btnConsulta.Text = "Consulta";
            this.btnConsulta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsulta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConsulta.UseVisualStyleBackColor = false;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
            this.btnUsuarios.Location = new System.Drawing.Point(490, 21);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(195, 97);
            this.btnUsuarios.TabIndex = 101;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(161)))), ((int)(((byte)(142)))));
            this.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblFecha.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(28, 588);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.ReadOnly = true;
            this.lblFecha.ShortcutsEnabled = false;
            this.lblFecha.Size = new System.Drawing.Size(1168, 74);
            this.lblFecha.TabIndex = 107;
            this.lblFecha.Text = "00/00/00";
            this.lblFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Tiempo
            // 
            this.Tiempo.Enabled = true;
            this.Tiempo.Tick += new System.EventHandler(this.Tiempo_Tick);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(161)))), ((int)(((byte)(142)))));
            this.ClientSize = new System.Drawing.Size(1228, 687);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenu_FormClosing);
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnSalir;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox lblHora;
        private System.Windows.Forms.TextBox lblFecha;
        private System.Windows.Forms.Button btnExpediente;
        private System.Windows.Forms.Button btnIncapacidad;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnBitacora;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEntregaMeds;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnControlDiario;
        private System.Windows.Forms.Timer Tiempo;
    }
}