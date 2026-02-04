namespace ADOSMELHORES.Forms
{
    partial class FormAlocarFormador
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblFormador = new System.Windows.Forms.Label();
            this.lblCoordenador = new System.Windows.Forms.Label();
            this.cmbCoordenadores = new System.Windows.Forms.ComboBox();
            this.btnAlocar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblAviso = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFormador
            // 
            this.lblFormador.AutoSize = true;
            this.lblFormador.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormador.Location = new System.Drawing.Point(18, 26);
            this.lblFormador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormador.Name = "lblFormador";
            this.lblFormador.Size = new System.Drawing.Size(95, 23);
            this.lblFormador.TabIndex = 0;
            this.lblFormador.Text = "Formador:";
            // 
            // lblCoordenador
            // 
            this.lblCoordenador.AutoSize = true;
            this.lblCoordenador.Location = new System.Drawing.Point(18, 59);
            this.lblCoordenador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCoordenador.Name = "lblCoordenador";
            this.lblCoordenador.Size = new System.Drawing.Size(207, 23);
            this.lblCoordenador.TabIndex = 1;
            this.lblCoordenador.Text = "Selecione o Coordenador:";
            // 
            // cmbCoordenadores
            // 
            this.cmbCoordenadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoordenadores.FormattingEnabled = true;
            this.cmbCoordenadores.Location = new System.Drawing.Point(22, 88);
            this.cmbCoordenadores.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmbCoordenadores.Name = "cmbCoordenadores";
            this.cmbCoordenadores.Size = new System.Drawing.Size(523, 31);
            this.cmbCoordenadores.TabIndex = 2;
            // 
            // btnAlocar
            // 
            this.btnAlocar.BackColor = System.Drawing.Color.Green;
            this.btnAlocar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlocar.ForeColor = System.Drawing.Color.White;
            this.btnAlocar.Location = new System.Drawing.Point(103, 142);
            this.btnAlocar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAlocar.Name = "btnAlocar";
            this.btnAlocar.Size = new System.Drawing.Size(156, 36);
            this.btnAlocar.TabIndex = 3;
            this.btnAlocar.Text = "✓ Alocar";
            this.btnAlocar.UseVisualStyleBackColor = false;
            this.btnAlocar.Click += new System.EventHandler(this.btnAlocar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(284, 142);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(156, 36);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "✖ Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Location = new System.Drawing.Point(18, 194);
            this.lblAviso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(0, 23);
            this.lblAviso.TabIndex = 5;
            // 
            // FormAlocarFormador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(252)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(567, 202);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAlocar);
            this.Controls.Add(this.cmbCoordenadores);
            this.Controls.Add(this.lblCoordenador);
            this.Controls.Add(this.lblFormador);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAlocarFormador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alocar Formador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblFormador;
        private System.Windows.Forms.Label lblCoordenador;
        private System.Windows.Forms.ComboBox cmbCoordenadores;
        private System.Windows.Forms.Button btnAlocar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblAviso;
    }
}
