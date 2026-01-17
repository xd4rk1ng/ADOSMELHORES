namespace ADOSMELHORES.Controls
{
    partial class Test
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
            this.botao1 = new ADOSMELHORES.Controls.Features.Botao();
            this.butaoToggle1 = new ADOSMELHORES.Controls.Features.ButaoToggle();
            this.customDatePicker1 = new ADOSMELHORES.Controls.RJControls.CustomDatePicker();
            this.SuspendLayout();
            // 
            // botao1
            // 
            this.botao1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.botao1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.botao1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.botao1.BorderRadius = 10;
            this.botao1.BorderSize = 1;
            this.botao1.FlatAppearance.BorderSize = 0;
            this.botao1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botao1.ForeColor = System.Drawing.Color.White;
            this.botao1.Location = new System.Drawing.Point(12, 12);
            this.botao1.Name = "botao1";
            this.botao1.Size = new System.Drawing.Size(150, 40);
            this.botao1.TabIndex = 1;
            this.botao1.Text = "botao1";
            this.botao1.TextColor = System.Drawing.Color.White;
            this.botao1.UseVisualStyleBackColor = false;
            // 
            // butaoToggle1
            // 
            this.butaoToggle1.AutoSize = true;
            this.butaoToggle1.Location = new System.Drawing.Point(12, 58);
            this.butaoToggle1.MinimumSize = new System.Drawing.Size(45, 22);
            this.butaoToggle1.Name = "butaoToggle1";
            this.butaoToggle1.OffBackColor = System.Drawing.Color.Gray;
            this.butaoToggle1.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.butaoToggle1.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.butaoToggle1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.butaoToggle1.Size = new System.Drawing.Size(45, 22);
            this.butaoToggle1.TabIndex = 0;
            this.butaoToggle1.UseVisualStyleBackColor = true;
            // 
            // customDatePicker1
            // 
            this.customDatePicker1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.customDatePicker1.BorderSize = 0;
            this.customDatePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.customDatePicker1.Location = new System.Drawing.Point(200, 17);
            this.customDatePicker1.MinimumSize = new System.Drawing.Size(0, 35);
            this.customDatePicker1.Name = "customDatePicker1";
            this.customDatePicker1.Size = new System.Drawing.Size(200, 35);
            this.customDatePicker1.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.customDatePicker1.TabIndex = 2;
            this.customDatePicker1.TextColor = System.Drawing.Color.White;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.customDatePicker1);
            this.Controls.Add(this.botao1);
            this.Controls.Add(this.butaoToggle1);
            this.Name = "Test";
            this.Text = "Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Features.ButaoToggle butaoToggle1;
        private Features.Botao botao1;
        private RJControls.CustomDatePicker customDatePicker1;
    }
}