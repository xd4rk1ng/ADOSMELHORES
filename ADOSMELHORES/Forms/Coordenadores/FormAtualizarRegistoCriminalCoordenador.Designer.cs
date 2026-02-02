namespace ADOSMELHORES.Forms
{
    partial class FormAtualizarRegistoCriminalCoordenador
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
            this.lblNome = new System.Windows.Forms.Label();
            this.lblValidade = new System.Windows.Forms.Label();
            this.dateTimePickerValidade = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNome.Location = new System.Drawing.Point(20, 50);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(83, 15);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Coordenador:";
            // 
            // lblValidade
            // 
            this.lblValidade.AutoSize = true;
            this.lblValidade.Location = new System.Drawing.Point(20, 80);
            this.lblValidade.Name = "lblValidade";
            this.lblValidade.Size = new System.Drawing.Size(108, 13);
            this.lblValidade.TabIndex = 1;
            this.lblValidade.Text = "Data de Validade:";
            // 
            // dateTimePickerValidade
            // 
            this.dateTimePickerValidade.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerValidade.Location = new System.Drawing.Point(150, 77);
            this.dateTimePickerValidade.Name = "dateTimePickerValidade";
            this.dateTimePickerValidade.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerValidade.TabIndex = 2;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(150, 120);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 30);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(260, 120);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(237, 18);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Atualizar Registo Criminal";
            // 
            // FormAtualizarRegistoCriminalCoordenador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 171);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dateTimePickerValidade);
            this.Controls.Add(this.lblValidade);
            this.Controls.Add(this.lblNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAtualizarRegistoCriminalCoordenador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Atualizar Registo Criminal";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblValidade;
        private System.Windows.Forms.DateTimePicker dateTimePickerValidade;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblTitulo;
    }
}
