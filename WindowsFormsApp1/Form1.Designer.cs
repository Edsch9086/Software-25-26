namespace WindowsFormsApp1
{
    partial class Form1
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
            this.b1 = new System.Windows.Forms.Button();
            this.b9 = new System.Windows.Forms.Button();
            this.b8 = new System.Windows.Forms.Button();
            this.b7 = new System.Windows.Forms.Button();
            this.b4 = new System.Windows.Forms.Button();
            this.b5 = new System.Windows.Forms.Button();
            this.b6 = new System.Windows.Forms.Button();
            this.b3 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.lblTurn = new System.Windows.Forms.Label();
            this.btnMode = new System.Windows.Forms.Button();
            this.btnDifficulty = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b1
            // 
            this.b1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.b1.Location = new System.Drawing.Point(116, 64);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(120, 120);
            this.b1.TabIndex = 0;
            this.b1.UseVisualStyleBackColor = true;
            this.b1.Click += new System.EventHandler(this.b1_click);
            // 
            // b9
            // 
            this.b9.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.b9.Location = new System.Drawing.Point(368, 316);
            this.b9.Name = "b9";
            this.b9.Size = new System.Drawing.Size(120, 120);
            this.b9.TabIndex = 1;
            this.b9.UseVisualStyleBackColor = true;
            this.b9.Click += new System.EventHandler(this.b1_click);
            // 
            // b8
            // 
            this.b8.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.b8.Location = new System.Drawing.Point(242, 316);
            this.b8.Name = "b8";
            this.b8.Size = new System.Drawing.Size(120, 120);
            this.b8.TabIndex = 2;
            this.b8.UseVisualStyleBackColor = true;
            this.b8.Click += new System.EventHandler(this.b1_click);
            // 
            // b7
            // 
            this.b7.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.b7.Location = new System.Drawing.Point(116, 316);
            this.b7.Name = "b7";
            this.b7.Size = new System.Drawing.Size(120, 120);
            this.b7.TabIndex = 3;
            this.b7.UseVisualStyleBackColor = true;
            this.b7.Click += new System.EventHandler(this.b1_click);
            // 
            // b4
            // 
            this.b4.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.b4.Location = new System.Drawing.Point(116, 190);
            this.b4.Name = "b4";
            this.b4.Size = new System.Drawing.Size(120, 120);
            this.b4.TabIndex = 4;
            this.b4.UseVisualStyleBackColor = true;
            this.b4.Click += new System.EventHandler(this.b1_click);
            // 
            // b5
            // 
            this.b5.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.b5.Location = new System.Drawing.Point(242, 190);
            this.b5.Name = "b5";
            this.b5.Size = new System.Drawing.Size(120, 120);
            this.b5.TabIndex = 5;
            this.b5.UseVisualStyleBackColor = true;
            this.b5.Click += new System.EventHandler(this.b1_click);
            // 
            // b6
            // 
            this.b6.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.b6.Location = new System.Drawing.Point(368, 190);
            this.b6.Name = "b6";
            this.b6.Size = new System.Drawing.Size(120, 120);
            this.b6.TabIndex = 6;
            this.b6.UseVisualStyleBackColor = true;
            this.b6.Click += new System.EventHandler(this.b1_click);
            // 
            // b3
            // 
            this.b3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.b3.Location = new System.Drawing.Point(368, 64);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(120, 120);
            this.b3.TabIndex = 7;
            this.b3.UseVisualStyleBackColor = true;
            this.b3.Click += new System.EventHandler(this.b1_click);
            // 
            // b2
            // 
            this.b2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.b2.Location = new System.Drawing.Point(242, 64);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(120, 120);
            this.b2.TabIndex = 8;
            this.b2.UseVisualStyleBackColor = true;
            this.b2.Click += new System.EventHandler(this.b1_click);
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurn.Location = new System.Drawing.Point(12, 9);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(80, 20);
            this.lblTurn.TabIndex = 10;
            this.lblTurn.Text = "Turn: X";
            // 
            // btnMode
            // 
            this.btnMode.Location = new System.Drawing.Point(120, 9);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(100, 23);
            this.btnMode.TabIndex = 11;
            this.btnMode.Text = "Mode: PvP"; // Initial text, will be updated in Form1.cs
            this.btnMode.UseVisualStyleBackColor = true;
            this.btnMode.Click += new System.EventHandler(this.btnMode_Click);
            // 
            // btnDifficulty
            // 
            this.btnDifficulty.Location = new System.Drawing.Point(230, 9);
            this.btnDifficulty.Name = "btnDifficulty";
            this.btnDifficulty.Size = new System.Drawing.Size(120, 23);
            this.btnDifficulty.TabIndex = 12;
            this.btnDifficulty.Text = "Difficulty: Easy"; // Initial text, will be updated in Form1.cs
            this.btnDifficulty.UseVisualStyleBackColor = true;
            this.btnDifficulty.Click += new System.EventHandler(this.btnDifficulty_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(360, 9);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 23);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 664);
            this.Controls.Add(this.lblTurn);
            this.Controls.Add(this.btnMode);
            this.Controls.Add(this.btnDifficulty);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.b3);
            this.Controls.Add(this.b6);
            this.Controls.Add(this.b5);
            this.Controls.Add(this.b4);
            this.Controls.Add(this.b7);
            this.Controls.Add(this.b8);
            this.Controls.Add(this.b9);
            this.Controls.Add(this.b1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button b9;
        private System.Windows.Forms.Button b8;
        private System.Windows.Forms.Button b7;
        private System.Windows.Forms.Button b4;
        private System.Windows.Forms.Button b5;
        private System.Windows.Forms.Button b6;
        private System.Windows.Forms.Button b3;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Button btnMode;
        private System.Windows.Forms.Button btnDifficulty;
        private System.Windows.Forms.Button btnReset;
    }
}

