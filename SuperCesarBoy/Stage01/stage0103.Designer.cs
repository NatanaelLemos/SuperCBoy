namespace SuperCesarBoy.Stage01
{
    partial class stage0103
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stage0103));
            this.ground1 = new SuperCesarBoy.Controls.ground();
            this.endPoint1 = new SuperCesarBoy.Controls.EndPoint();
            this.ground2 = new SuperCesarBoy.Controls.ground();
            this.ground3 = new SuperCesarBoy.Controls.ground();
            this.ground4 = new SuperCesarBoy.Controls.ground();
            this.ground5 = new SuperCesarBoy.Controls.ground();
            this.ptbBird = new System.Windows.Forms.PictureBox();
            this.ground7 = new SuperCesarBoy.Controls.ground();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBird)).BeginInit();
            this.SuspendLayout();
            // 
            // charCesar
            // 
            this.charCesar.Location = new System.Drawing.Point(9, 419);
            // 
            // ground1
            // 
            this.ground1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ground1.BackgroundImage")));
            this.ground1.Location = new System.Drawing.Point(-6, 520);
            this.ground1.Name = "ground1";
            this.ground1.Size = new System.Drawing.Size(1130, 136);
            this.ground1.TabIndex = 1;
            // 
            // endPoint1
            // 
            this.endPoint1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endPoint1.BackColor = System.Drawing.Color.Transparent;
            this.endPoint1.Location = new System.Drawing.Point(929, -30);
            this.endPoint1.Name = "endPoint1";
            this.endPoint1.Size = new System.Drawing.Size(55, 632);
            this.endPoint1.TabIndex = 2;
            // 
            // ground2
            // 
            this.ground2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ground2.BackgroundImage")));
            this.ground2.Location = new System.Drawing.Point(354, 458);
            this.ground2.Name = "ground2";
            this.ground2.Size = new System.Drawing.Size(939, 77);
            this.ground2.TabIndex = 3;
            // 
            // ground3
            // 
            this.ground3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ground3.BackgroundImage")));
            this.ground3.Location = new System.Drawing.Point(504, 398);
            this.ground3.Name = "ground3";
            this.ground3.Size = new System.Drawing.Size(860, 77);
            this.ground3.TabIndex = 4;
            // 
            // ground4
            // 
            this.ground4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ground4.BackgroundImage")));
            this.ground4.Location = new System.Drawing.Point(624, 335);
            this.ground4.Name = "ground4";
            this.ground4.Size = new System.Drawing.Size(769, 77);
            this.ground4.TabIndex = 5;
            // 
            // ground5
            // 
            this.ground5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ground5.BackgroundImage")));
            this.ground5.Location = new System.Drawing.Point(775, 275);
            this.ground5.Name = "ground5";
            this.ground5.Size = new System.Drawing.Size(565, 77);
            this.ground5.TabIndex = 6;
            // 
            // ptbBird
            // 
            this.ptbBird.BackColor = System.Drawing.Color.Transparent;
            this.ptbBird.BackgroundImage = global::SuperCesarBoy.Properties.Resources.bird02;
            this.ptbBird.Location = new System.Drawing.Point(962, 12);
            this.ptbBird.Name = "ptbBird";
            this.ptbBird.Size = new System.Drawing.Size(79, 81);
            this.ptbBird.TabIndex = 8;
            this.ptbBird.TabStop = false;
            // 
            // ground7
            // 
            this.ground7.BackgroundImage = global::SuperCesarBoy.Properties.Resources.blocoInquebravel;
            this.ground7.Location = new System.Drawing.Point(115, 381);
            this.ground7.Name = "ground7";
            this.ground7.Size = new System.Drawing.Size(112, 28);
            this.ground7.TabIndex = 9;
            // 
            // stage0103
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(971, 606);
            this.Controls.Add(this.ground7);
            this.Controls.Add(this.ptbBird);
            this.Controls.Add(this.ground5);
            this.Controls.Add(this.ground4);
            this.Controls.Add(this.ground3);
            this.Controls.Add(this.ground2);
            this.Controls.Add(this.ground1);
            this.Controls.Add(this.endPoint1);
            this.Name = "stage0103";
            this.Started = true;
            this.Text = "";
            this.Shown += new System.EventHandler(this.stage0103_Shown);
            this.Controls.SetChildIndex(this.charCesar, 0);
            this.Controls.SetChildIndex(this.endPoint1, 0);
            this.Controls.SetChildIndex(this.ground1, 0);
            this.Controls.SetChildIndex(this.ground2, 0);
            this.Controls.SetChildIndex(this.ground3, 0);
            this.Controls.SetChildIndex(this.ground4, 0);
            this.Controls.SetChildIndex(this.ground5, 0);
            this.Controls.SetChildIndex(this.ptbBird, 0);
            this.Controls.SetChildIndex(this.ground7, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ptbBird)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ground ground1;
        private Controls.EndPoint endPoint1;
        private Controls.ground ground2;
        private Controls.ground ground3;
        private Controls.ground ground4;
        private Controls.ground ground5;
        private System.Windows.Forms.PictureBox ptbBird;
        private Controls.ground ground7;
    }
}
