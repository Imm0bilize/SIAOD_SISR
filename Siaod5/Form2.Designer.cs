namespace Siaod5
{
    partial class Form2
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_vsego = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_g = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_O = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_R = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(810, 400);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Узлов всего:";
            // 
            // label_vsego
            // 
            this.label_vsego.AutoSize = true;
            this.label_vsego.BackColor = System.Drawing.Color.Transparent;
            this.label_vsego.Location = new System.Drawing.Point(92, 419);
            this.label_vsego.Name = "label_vsego";
            this.label_vsego.Size = new System.Drawing.Size(13, 13);
            this.label_vsego.TabIndex = 2;
            this.label_vsego.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(122, 419);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Здоровых:";
            // 
            // label_g
            // 
            this.label_g.AutoSize = true;
            this.label_g.BackColor = System.Drawing.Color.Transparent;
            this.label_g.Location = new System.Drawing.Point(188, 419);
            this.label_g.Name = "label_g";
            this.label_g.Size = new System.Drawing.Size(13, 13);
            this.label_g.TabIndex = 4;
            this.label_g.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(207, 419);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Восприимчивых:";
            // 
            // label_O
            // 
            this.label_O.AutoSize = true;
            this.label_O.BackColor = System.Drawing.Color.Transparent;
            this.label_O.Location = new System.Drawing.Point(304, 419);
            this.label_O.Name = "label_O";
            this.label_O.Size = new System.Drawing.Size(13, 13);
            this.label_O.TabIndex = 6;
            this.label_O.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(323, 419);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Зараженных:";
            // 
            // label_R
            // 
            this.label_R.AutoSize = true;
            this.label_R.BackColor = System.Drawing.Color.Transparent;
            this.label_R.Location = new System.Drawing.Point(403, 419);
            this.label_R.Name = "label_R";
            this.label_R.Size = new System.Drawing.Size(13, 13);
            this.label_R.TabIndex = 8;
            this.label_R.Text = "0";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Siaod5.Resource1.background1;
            this.ClientSize = new System.Drawing.Size(838, 441);
            this.Controls.Add(this.label_R);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_O);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_g);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_vsego);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "График";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Label label_vsego;
        public System.Windows.Forms.Label label_g;
        public System.Windows.Forms.Label label_O;
        public System.Windows.Forms.Label label_R;
    }
}