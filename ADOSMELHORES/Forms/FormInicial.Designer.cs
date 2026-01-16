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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnExemplo = new System.Windows.Forms.Button();
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
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(39, 139);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1011, 372);
            this.listBox1.TabIndex = 4;
            // 
            // btnExemplo
            // 
            this.btnExemplo.Location = new System.Drawing.Point(39, 103);
            this.btnExemplo.Margin = new System.Windows.Forms.Padding(4);
            this.btnExemplo.Name = "btnExemplo";
            this.btnExemplo.Size = new System.Drawing.Size(493, 28);
            this.btnExemplo.TabIndex = 5;
            this.btnExemplo.Text = "Inserir Exemplo";
            this.btnExemplo.UseVisualStyleBackColor = true;
            this.btnExemplo.Click += new System.EventHandler(this.btnExemplo_Click_1);
            // 
            // FormInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnExemplo);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnDiretor);
            this.Controls.Add(this.btnSecretaria);
            this.Controls.Add(this.btnCoordenador);
            this.Controls.Add(this.btnFormador);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormInicial";
            this.Text = "Form Inicial";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFormador;
        private System.Windows.Forms.Button btnCoordenador;
        private System.Windows.Forms.Button btnSecretaria;
        private System.Windows.Forms.Button btnDiretor;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnExemplo;
    }
}

