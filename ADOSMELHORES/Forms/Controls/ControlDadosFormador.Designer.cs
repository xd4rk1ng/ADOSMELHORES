namespace ADOSMELHORES.Controls
{
    partial class ControlDadosFormador
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbDisponibilidade = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAreaLeciona = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbDisponibilidade
            // 
            this.cmbDisponibilidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisponibilidade.FormattingEnabled = true;
            this.cmbDisponibilidade.Location = new System.Drawing.Point(137, 33);
            this.cmbDisponibilidade.Name = "cmbDisponibilidade";
            this.cmbDisponibilidade.Size = new System.Drawing.Size(200, 21);
            this.cmbDisponibilidade.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Disponibilidade:";
            // 
            // txtAreaLeciona
            // 
            this.txtAreaLeciona.Location = new System.Drawing.Point(137, 3);
            this.txtAreaLeciona.Name = "txtAreaLeciona";
            this.txtAreaLeciona.Size = new System.Drawing.Size(320, 20);
            this.txtAreaLeciona.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Área Leciona:";
            // 
            // ControlDadosFormador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbDisponibilidade);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAreaLeciona);
            this.Controls.Add(this.label5);
            this.Name = "ControlDadosFormador";
            this.Size = new System.Drawing.Size(480, 68);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDisponibilidade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAreaLeciona;
        private System.Windows.Forms.Label label5;
    }
}
