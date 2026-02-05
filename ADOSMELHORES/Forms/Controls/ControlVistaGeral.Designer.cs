namespace ADOSMELHORES.Forms.Controls
{
    partial class ControlVistaGeral
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
            this.lstFuncionarios = new System.Windows.Forms.ListView();
            this.lblLista = new System.Windows.Forms.Label();
            this.btnCSV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstFuncionarios
            // 
            this.lstFuncionarios.HideSelection = false;
            this.lstFuncionarios.Location = new System.Drawing.Point(15, 86);
            this.lstFuncionarios.Name = "lstFuncionarios";
            this.lstFuncionarios.Size = new System.Drawing.Size(497, 261);
            this.lstFuncionarios.TabIndex = 0;
            this.lstFuncionarios.UseCompatibleStateImageBehavior = false;
            // 
            // lblLista
            // 
            this.lblLista.AutoSize = true;
            this.lblLista.Location = new System.Drawing.Point(12, 70);
            this.lblLista.Name = "lblLista";
            this.lblLista.Size = new System.Drawing.Size(35, 13);
            this.lblLista.TabIndex = 1;
            this.lblLista.Text = "label1";
            // 
            // btnCSV
            // 
            this.btnCSV.Location = new System.Drawing.Point(407, 60);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(105, 23);
            this.btnCSV.TabIndex = 3;
            this.btnCSV.Text = "Exportar para CSV";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // ControlVistaGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.lblLista);
            this.Controls.Add(this.lstFuncionarios);
            this.Name = "ControlVistaGeral";
            this.Size = new System.Drawing.Size(531, 364);
            this.Click += new System.EventHandler(this.frm_onClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstFuncionarios;
        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.Button btnCSV;
    }
}
