namespace BlokAI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblUtakmica = new Label();
            txtUtakmica = new TextBox();
            btnPredict = new Button();
            lblRez = new Label();
            lblRezultat = new Label();
            SuspendLayout();
            // 
            // lblUtakmica
            // 
            lblUtakmica.AutoSize = true;
            lblUtakmica.Font = new Font("Segoe UI", 18F);
            lblUtakmica.Location = new Point(83, 56);
            lblUtakmica.Name = "lblUtakmica";
            lblUtakmica.Size = new Size(112, 32);
            lblUtakmica.TabIndex = 0;
            lblUtakmica.Text = "Utakmica";
            // 
            // txtUtakmica
            // 
            txtUtakmica.Font = new Font("Segoe UI", 18F);
            txtUtakmica.Location = new Point(88, 99);
            txtUtakmica.Name = "txtUtakmica";
            txtUtakmica.Size = new Size(612, 39);
            txtUtakmica.TabIndex = 1;
            txtUtakmica.TextChanged += textBox1_TextChanged;
            // 
            // btnPredict
            // 
            btnPredict.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPredict.Location = new Point(302, 158);
            btnPredict.Name = "btnPredict";
            btnPredict.Size = new Size(123, 46);
            btnPredict.TabIndex = 2;
            btnPredict.Text = "predict:";
            btnPredict.UseVisualStyleBackColor = true;
            btnPredict.Click += btnPredict_Click;
            // 
            // lblRez
            // 
            lblRez.AutoSize = true;
            lblRez.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRez.Location = new Point(83, 276);
            lblRez.Name = "lblRez";
            lblRez.Size = new Size(83, 32);
            lblRez.TabIndex = 3;
            lblRez.Text = "Result:";
            // 
            // lblRezultat
            // 
            lblRezultat.AutoSize = true;
            lblRezultat.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRezultat.Location = new Point(88, 340);
            lblRezultat.Name = "lblRezultat";
            lblRezultat.Size = new Size(24, 32);
            lblRezultat.TabIndex = 4;
            lblRezultat.Text = "-";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblRezultat);
            Controls.Add(lblRez);
            Controls.Add(btnPredict);
            Controls.Add(txtUtakmica);
            Controls.Add(lblUtakmica);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUtakmica;
        private TextBox txtUtakmica;
        private Button btnPredict;
        private Label lblRez;
        private Label lblRezultat;
    }
}
