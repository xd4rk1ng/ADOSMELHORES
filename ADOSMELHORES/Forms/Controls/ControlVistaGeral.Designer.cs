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
            this.cmbFiltros = new System.Windows.Forms.ComboBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.lblLista.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLista.Location = new System.Drawing.Point(12, 46);
            this.lblLista.Name = "lblLista";
            this.lblLista.Size = new System.Drawing.Size(111, 13);
            this.lblLista.TabIndex = 1;
            this.lblLista.Text = "Lista de funcionários";
            // 
            // btnCSV
            // 
            this.btnCSV.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCSV.Location = new System.Drawing.Point(370, 46);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(142, 37);
            this.btnCSV.TabIndex = 3;
            this.btnCSV.Text = "Exportar para CSV";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // cmbFiltros
            // 
            this.cmbFiltros.FormattingEnabled = true;
            this.cmbFiltros.Location = new System.Drawing.Point(53, 62);
            this.cmbFiltros.Name = "cmbFiltros";
            this.cmbFiltros.Size = new System.Drawing.Size(121, 21);
            this.cmbFiltros.TabIndex = 4;
            this.cmbFiltros.SelectedIndexChanged += new System.EventHandler(this.cmbFiltros_SelectedIndexChanged);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(12, 65);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(40, 13);
            this.lblFiltro.TabIndex = 5;
            this.lblFiltro.Text = "Filtrar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(207, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "Vista Geral";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ControlVistaGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.cmbFiltros);
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
        private System.Windows.Forms.ComboBox cmbFiltros;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Label label2;
    }
}
