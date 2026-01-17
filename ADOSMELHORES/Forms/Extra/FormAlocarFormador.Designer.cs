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
            this.lblFormador.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblFormador.Location = new System.Drawing.Point(12, 15);
            this.lblFormador.Name = "lblFormador";
            this.lblFormador.Size = new System.Drawing.Size(80, 17);
            this.lblFormador.TabIndex = 0;
            this.lblFormador.Text = "Formador:";
            // 
            // lblCoordenador
            // 
            this.lblCoordenador.AutoSize = true;
            this.lblCoordenador.Location = new System.Drawing.Point(12, 55);
            this.lblCoordenador.Name = "lblCoordenador";
            this.lblCoordenador.Size = new System.Drawing.Size(133, 13);
            this.lblCoordenador.TabIndex = 1;
            this.lblCoordenador.Text = "Selecione o Coordenador:";
            // 
            // cmbCoordenadores
            // 
            this.cmbCoordenadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoordenadores.FormattingEnabled = true;
            this.cmbCoordenadores.Location = new System.Drawing.Point(15, 75);
            this.cmbCoordenadores.Name = "cmbCoordenadores";
            this.cmbCoordenadores.Size = new System.Drawing.Size(350, 21);
            this.cmbCoordenadores.TabIndex = 2;
            // 
            // btnAlocar
            // 
            this.btnAlocar.Location = new System.Drawing.Point(165, 140);
            this.btnAlocar.Name = "btnAlocar";
            this.btnAlocar.Size = new System.Drawing.Size(95, 30);
            this.btnAlocar.TabIndex = 3;
            this.btnAlocar.Text = "Alocar";
            this.btnAlocar.UseVisualStyleBackColor = true;
            this.btnAlocar.Click += new System.EventHandler(this.btnAlocar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(270, 140);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Location = new System.Drawing.Point(12, 110);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(0, 13);
            this.lblAviso.TabIndex = 5;
            // 
            // FormAlocarFormador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 191);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAlocar);
            this.Controls.Add(this.cmbCoordenadores);
            this.Controls.Add(this.lblCoordenador);
            this.Controls.Add(this.lblFormador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
