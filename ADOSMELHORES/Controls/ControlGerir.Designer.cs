namespace ADOSMELHORES.Controls
{
    partial class ControlGestao
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFormadores = new System.Windows.Forms.Button();
            this.btnCoordenadores = new System.Windows.Forms.Button();
            this.btnSecretarias = new System.Windows.Forms.Button();
            this.btnDiretores = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDiretores);
            this.panel1.Controls.Add(this.btnSecretarias);
            this.panel1.Controls.Add(this.btnCoordenadores);
            this.panel1.Controls.Add(this.btnFormadores);
            this.panel1.Location = new System.Drawing.Point(0, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 100);
            this.panel1.TabIndex = 0;
            // 
            // btnFormadores
            // 
            this.btnFormadores.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFormadores.Location = new System.Drawing.Point(0, 0);
            this.btnFormadores.Name = "btnFormadores";
            this.btnFormadores.Size = new System.Drawing.Size(99, 100);
            this.btnFormadores.TabIndex = 0;
            this.btnFormadores.Text = "Formadores";
            this.btnFormadores.UseVisualStyleBackColor = true;
            this.btnFormadores.Click += new System.EventHandler(this.btnFormadores_Click);
            // 
            // btnCoordenadores
            // 
            this.btnCoordenadores.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCoordenadores.Location = new System.Drawing.Point(99, 0);
            this.btnCoordenadores.Name = "btnCoordenadores";
            this.btnCoordenadores.Size = new System.Drawing.Size(99, 100);
            this.btnCoordenadores.TabIndex = 1;
            this.btnCoordenadores.Text = "Coordenadores";
            this.btnCoordenadores.UseVisualStyleBackColor = true;
            this.btnCoordenadores.Click += new System.EventHandler(this.btnCoordenadores_Click);
            // 
            // btnSecretarias
            // 
            this.btnSecretarias.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSecretarias.Location = new System.Drawing.Point(198, 0);
            this.btnSecretarias.Name = "btnSecretarias";
            this.btnSecretarias.Size = new System.Drawing.Size(99, 100);
            this.btnSecretarias.TabIndex = 2;
            this.btnSecretarias.Text = "Secretárias";
            this.btnSecretarias.UseVisualStyleBackColor = true;
            this.btnSecretarias.Click += new System.EventHandler(this.btnSecretarias_Click);
            // 
            // btnDiretores
            // 
            this.btnDiretores.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDiretores.Location = new System.Drawing.Point(297, 0);
            this.btnDiretores.Name = "btnDiretores";
            this.btnDiretores.Size = new System.Drawing.Size(99, 100);
            this.btnDiretores.TabIndex = 3;
            this.btnDiretores.Text = "Diretores";
            this.btnDiretores.UseVisualStyleBackColor = true;
            this.btnDiretores.Click += new System.EventHandler(this.btnDiretores_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(154, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestão de:";
            // 
            // ControlGerir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "ControlGerir";
            this.Size = new System.Drawing.Size(395, 233);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDiretores;
        private System.Windows.Forms.Button btnSecretarias;
        private System.Windows.Forms.Button btnCoordenadores;
        private System.Windows.Forms.Button btnFormadores;
        private System.Windows.Forms.Label label1;
    }
}
