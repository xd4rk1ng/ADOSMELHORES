namespace ADOSMELHORES.Forms
{
    partial class FormFiltrarCoordenadores
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
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblAreaFormacao = new System.Windows.Forms.Label();
            this.txtAreaFormacao = new System.Windows.Forms.TextBox();
            this.checkBoxSalarioMin = new System.Windows.Forms.CheckBox();
            this.numericSalarioMin = new System.Windows.Forms.NumericUpDown();
            this.checkBoxSalarioMax = new System.Windows.Forms.CheckBox();
            this.numericSalarioMax = new System.Windows.Forms.NumericUpDown();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericSalarioMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSalarioMax)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(20, 50);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(150, 47);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(250, 20);
            this.txtNome.TabIndex = 1;
            // 
            // lblAreaFormacao
            // 
            this.lblAreaFormacao.AutoSize = true;
            this.lblAreaFormacao.Location = new System.Drawing.Point(20, 80);
            this.lblAreaFormacao.Name = "lblAreaFormacao";
            this.lblAreaFormacao.Size = new System.Drawing.Size(93, 13);
            this.lblAreaFormacao.TabIndex = 2;
            this.lblAreaFormacao.Text = "Área de Formação:";
            // 
            // txtAreaFormacao
            // 
            this.txtAreaFormacao.Location = new System.Drawing.Point(150, 77);
            this.txtAreaFormacao.Name = "txtAreaFormacao";
            this.txtAreaFormacao.Size = new System.Drawing.Size(250, 20);
            this.txtAreaFormacao.TabIndex = 3;
            // 
            // checkBoxSalarioMin
            // 
            this.checkBoxSalarioMin.AutoSize = true;
            this.checkBoxSalarioMin.Location = new System.Drawing.Point(23, 110);
            this.checkBoxSalarioMin.Name = "checkBoxSalarioMin";
            this.checkBoxSalarioMin.Size = new System.Drawing.Size(100, 17);
            this.checkBoxSalarioMin.TabIndex = 4;
            this.checkBoxSalarioMin.Text = "Salário Mínimo:";
            this.checkBoxSalarioMin.UseVisualStyleBackColor = true;
            // 
            // numericSalarioMin
            // 
            this.numericSalarioMin.DecimalPlaces = 2;
            this.numericSalarioMin.Location = new System.Drawing.Point(150, 107);
            this.numericSalarioMin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericSalarioMin.Name = "numericSalarioMin";
            this.numericSalarioMin.Size = new System.Drawing.Size(250, 20);
            this.numericSalarioMin.TabIndex = 5;
            // 
            // checkBoxSalarioMax
            // 
            this.checkBoxSalarioMax.AutoSize = true;
            this.checkBoxSalarioMax.Location = new System.Drawing.Point(23, 140);
            this.checkBoxSalarioMax.Name = "checkBoxSalarioMax";
            this.checkBoxSalarioMax.Size = new System.Drawing.Size(103, 17);
            this.checkBoxSalarioMax.TabIndex = 6;
            this.checkBoxSalarioMax.Text = "Salário Máximo:";
            this.checkBoxSalarioMax.UseVisualStyleBackColor = true;
            // 
            // numericSalarioMax
            // 
            this.numericSalarioMax.DecimalPlaces = 2;
            this.numericSalarioMax.Location = new System.Drawing.Point(150, 137);
            this.numericSalarioMax.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericSalarioMax.Name = "numericSalarioMax";
            this.numericSalarioMax.Size = new System.Drawing.Size(250, 20);
            this.numericSalarioMax.TabIndex = 7;
            this.numericSalarioMax.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(200, 180);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(90, 30);
            this.btnFiltrar.TabIndex = 8;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(310, 180);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 9;
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
            this.lblTitulo.Size = new System.Drawing.Size(178, 18);
            this.lblTitulo.TabIndex = 10;
            this.lblTitulo.Text = "Filtrar Coordenadores";
            // 
            // FormFiltrarCoordenadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 231);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.numericSalarioMax);
            this.Controls.Add(this.checkBoxSalarioMax);
            this.Controls.Add(this.numericSalarioMin);
            this.Controls.Add(this.checkBoxSalarioMin);
            this.Controls.Add(this.txtAreaFormacao);
            this.Controls.Add(this.lblAreaFormacao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFiltrarCoordenadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filtrar Coordenadores";
            ((System.ComponentModel.ISupportInitialize)(this.numericSalarioMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSalarioMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblAreaFormacao;
        private System.Windows.Forms.TextBox txtAreaFormacao;
        private System.Windows.Forms.CheckBox checkBoxSalarioMin;
        private System.Windows.Forms.NumericUpDown numericSalarioMin;
        private System.Windows.Forms.CheckBox checkBoxSalarioMax;
        private System.Windows.Forms.NumericUpDown numericSalarioMax;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblTitulo;
    }
}
