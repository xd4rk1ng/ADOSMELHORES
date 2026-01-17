namespace ADOSMELHORES.Forms
{
    partial class FormAtualizarRegistoCriminal
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
            this.lblDataAtual = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblNovaData = new System.Windows.Forms.Label();
            this.dtpNovaData = new System.Windows.Forms.DateTimePicker();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
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
            // lblDataAtual
            // 
            this.lblDataAtual.AutoSize = true;
            this.lblDataAtual.Location = new System.Drawing.Point(12, 50);
            this.lblDataAtual.Name = "lblDataAtual";
            this.lblDataAtual.Size = new System.Drawing.Size(120, 13);
            this.lblDataAtual.TabIndex = 1;
            this.lblDataAtual.Text = "Data Atual do Registo:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(12, 75);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(51, 15);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            // 
            // lblNovaData
            // 
            this.lblNovaData.AutoSize = true;
            this.lblNovaData.Location = new System.Drawing.Point(12, 110);
            this.lblNovaData.Name = "lblNovaData";
            this.lblNovaData.Size = new System.Drawing.Size(144, 13);
            this.lblNovaData.TabIndex = 3;
            this.lblNovaData.Text = "Nova Data de Validade:";
            // 
            // dtpNovaData
            // 
            this.dtpNovaData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNovaData.Location = new System.Drawing.Point(165, 107);
            this.dtpNovaData.Name = "dtpNovaData";
            this.dtpNovaData.Size = new System.Drawing.Size(200, 20);
            this.dtpNovaData.TabIndex = 4;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(165, 145);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(95, 30);
            this.btnAtualizar.TabIndex = 5;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(270, 145);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 30);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormAtualizarRegistoCriminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 191);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.dtpNovaData);
            this.Controls.Add(this.lblNovaData);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblDataAtual);
            this.Controls.Add(this.lblFormador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAtualizarRegistoCriminal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Atualizar Registo Criminal";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblFormador;
        private System.Windows.Forms.Label lblDataAtual;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblNovaData;
        private System.Windows.Forms.DateTimePicker dtpNovaData;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
