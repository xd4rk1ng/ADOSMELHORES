namespace ADOSMELHORES.Forms
{
    partial class FormInicial
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
            this.btnFormador = new System.Windows.Forms.Button();
            this.btnCoordenador = new System.Windows.Forms.Button();
            this.btnSecretaria = new System.Windows.Forms.Button();
            this.btnDiretor = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFormador
            // 
            this.btnFormador.Location = new System.Drawing.Point(39, 32);
            this.btnFormador.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormador.Name = "btnFormador";
            this.btnFormador.Size = new System.Drawing.Size(493, 28);
            this.btnFormador.TabIndex = 0;
            this.btnFormador.Text = "Inserir Formador";
            this.btnFormador.UseVisualStyleBackColor = true;
            this.btnFormador.Click += new System.EventHandler(this.btnFormador_Click);
            // 
            // btnCoordenador
            // 
            this.btnCoordenador.Location = new System.Drawing.Point(39, 66);
            this.btnCoordenador.Margin = new System.Windows.Forms.Padding(4);
            this.btnCoordenador.Name = "btnCoordenador";
            this.btnCoordenador.Size = new System.Drawing.Size(493, 28);
            this.btnCoordenador.TabIndex = 1;
            this.btnCoordenador.Text = "Inserir Coordenador";
            this.btnCoordenador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCoordenador.UseVisualStyleBackColor = true;
            this.btnCoordenador.Click += new System.EventHandler(this.btnCoordenador_Click);
            // 
            // btnSecretaria
            // 
            this.btnSecretaria.Location = new System.Drawing.Point(540, 31);
            this.btnSecretaria.Margin = new System.Windows.Forms.Padding(4);
            this.btnSecretaria.Name = "btnSecretaria";
            this.btnSecretaria.Size = new System.Drawing.Size(511, 28);
            this.btnSecretaria.TabIndex = 2;
            this.btnSecretaria.Text = "Inserir Secretaria";
            this.btnSecretaria.UseVisualStyleBackColor = true;
            this.btnSecretaria.Click += new System.EventHandler(this.btnSecretaria_Click);
            // 
            // btnDiretor
            // 
            this.btnDiretor.Location = new System.Drawing.Point(540, 66);
            this.btnDiretor.Margin = new System.Windows.Forms.Padding(4);
            this.btnDiretor.Name = "btnDiretor";
            this.btnDiretor.Size = new System.Drawing.Size(511, 28);
            this.btnDiretor.TabIndex = 3;
            this.btnDiretor.Text = "Inserir Diretor";
            this.btnDiretor.UseVisualStyleBackColor = true;
            this.btnDiretor.Click += new System.EventHandler(this.btnDiretor_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(453, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 86);
            this.button1.TabIndex = 4;
            this.button1.Text = "Gerir Despesas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDiretor);
            this.Controls.Add(this.btnSecretaria);
            this.Controls.Add(this.btnCoordenador);
            this.Controls.Add(this.btnFormador);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormInicial";
            this.Text = "Form Inicial";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormInicialClose);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFormador;
        private System.Windows.Forms.Button btnCoordenador;
        private System.Windows.Forms.Button btnSecretaria;
        private System.Windows.Forms.Button btnDiretor;
        private System.Windows.Forms.Button button1;
    }
}

