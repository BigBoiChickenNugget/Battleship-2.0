namespace Battleship_2._0
{
    partial class SelectDifficulty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectDifficulty));
            this.Easy = new System.Windows.Forms.Label();
            this.Normal = new System.Windows.Forms.Label();
            this.Hard = new System.Windows.Forms.Label();
            this.EasyDesc = new System.Windows.Forms.Label();
            this.NormalDesc = new System.Windows.Forms.Label();
            this.HardDesc = new System.Windows.Forms.Label();
            this.Confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Easy
            // 
            this.Easy.AutoSize = true;
            this.Easy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Easy.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Easy.ForeColor = System.Drawing.Color.Green;
            this.Easy.Location = new System.Drawing.Point(128, 169);
            this.Easy.Name = "Easy";
            this.Easy.Size = new System.Drawing.Size(208, 73);
            this.Easy.TabIndex = 0;
            this.Easy.Text = "EASY";
            this.Easy.Click += new System.EventHandler(this.EasySelect);
            // 
            // Normal
            // 
            this.Normal.AutoSize = true;
            this.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Normal.ForeColor = System.Drawing.Color.Goldenrod;
            this.Normal.Location = new System.Drawing.Point(567, 169);
            this.Normal.Name = "Normal";
            this.Normal.Size = new System.Drawing.Size(312, 73);
            this.Normal.TabIndex = 1;
            this.Normal.Text = "NORMAL";
            this.Normal.Click += new System.EventHandler(this.NormalSelect);
            // 
            // Hard
            // 
            this.Hard.AutoSize = true;
            this.Hard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Hard.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hard.ForeColor = System.Drawing.Color.DarkRed;
            this.Hard.Location = new System.Drawing.Point(1096, 169);
            this.Hard.Name = "Hard";
            this.Hard.Size = new System.Drawing.Size(217, 73);
            this.Hard.TabIndex = 2;
            this.Hard.Text = "HARD";
            this.Hard.Click += new System.EventHandler(this.HardSelect);
            // 
            // EasyDesc
            // 
            this.EasyDesc.AutoSize = true;
            this.EasyDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.EasyDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EasyDesc.ForeColor = System.Drawing.Color.Green;
            this.EasyDesc.Location = new System.Drawing.Point(29, 272);
            this.EasyDesc.Name = "EasyDesc";
            this.EasyDesc.Size = new System.Drawing.Size(419, 140);
            this.EasyDesc.TabIndex = 3;
            this.EasyDesc.Text = resources.GetString("EasyDesc.Text");
            this.EasyDesc.Visible = false;
            // 
            // NormalDesc
            // 
            this.NormalDesc.AutoSize = true;
            this.NormalDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.NormalDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NormalDesc.ForeColor = System.Drawing.Color.Goldenrod;
            this.NormalDesc.Location = new System.Drawing.Point(507, 272);
            this.NormalDesc.Name = "NormalDesc";
            this.NormalDesc.Size = new System.Drawing.Size(419, 140);
            this.NormalDesc.TabIndex = 4;
            this.NormalDesc.Text = resources.GetString("NormalDesc.Text");
            this.NormalDesc.Visible = false;
            // 
            // HardDesc
            // 
            this.HardDesc.AutoSize = true;
            this.HardDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.HardDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HardDesc.ForeColor = System.Drawing.Color.DarkRed;
            this.HardDesc.Location = new System.Drawing.Point(982, 272);
            this.HardDesc.Name = "HardDesc";
            this.HardDesc.Size = new System.Drawing.Size(408, 140);
            this.HardDesc.TabIndex = 5;
            this.HardDesc.Text = resources.GetString("HardDesc.Text");
            this.HardDesc.Visible = false;
            // 
            // Confirm
            // 
            this.Confirm.BackColor = System.Drawing.Color.SkyBlue;
            this.Confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Confirm.Location = new System.Drawing.Point(511, 519);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(415, 93);
            this.Confirm.TabIndex = 6;
            this.Confirm.Text = "Click here to confirm!";
            this.Confirm.UseVisualStyleBackColor = false;
            this.Confirm.Visible = false;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // SelectDifficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Battleship_2._0.Properties.Resources._106033;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1424, 861);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.HardDesc);
            this.Controls.Add(this.NormalDesc);
            this.Controls.Add(this.EasyDesc);
            this.Controls.Add(this.Hard);
            this.Controls.Add(this.Normal);
            this.Controls.Add(this.Easy);
            this.Name = "SelectDifficulty";
            this.Text = "SelectDifficulty";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Easy;
        private System.Windows.Forms.Label Normal;
        private System.Windows.Forms.Label Hard;
        private System.Windows.Forms.Label EasyDesc;
        private System.Windows.Forms.Label NormalDesc;
        private System.Windows.Forms.Label HardDesc;
        private System.Windows.Forms.Button Confirm;
    }
}