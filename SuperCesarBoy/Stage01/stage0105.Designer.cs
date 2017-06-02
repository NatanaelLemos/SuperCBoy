namespace SuperCesarBoy.Stage01
{
    partial class stage0105
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stage0105));
            this.ground2 = new SuperCesarBoy.Controls.ground();
            this.ground3 = new SuperCesarBoy.Controls.ground();
            this.ground1 = new SuperCesarBoy.Controls.ground();
            this.ground4 = new SuperCesarBoy.Controls.ground();
            this.ground5 = new SuperCesarBoy.Controls.ground();
            this.pgbEnd = new System.Windows.Forms.ProgressBar();
            this.endPoint1 = new SuperCesarBoy.Controls.EndPoint();
            this.SuspendLayout();
            // 
            // charCesar
            // 
            this.charCesar.Location = new System.Drawing.Point(-5, 134);
            // 
            // ground2
            // 
            this.ground2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ground2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ground2.BackgroundImage")));
            this.ground2.Location = new System.Drawing.Point(-21, 501);
            this.ground2.Name = "ground2";
            this.ground2.Size = new System.Drawing.Size(1235, 133);
            this.ground2.TabIndex = 3;
            // 
            // ground3
            // 
            this.ground3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ground3.BackgroundImage = global::SuperCesarBoy.Properties.Resources.blocoInquebravel;
            this.ground3.Location = new System.Drawing.Point(186, 246);
            this.ground3.Name = "ground3";
            this.ground3.Size = new System.Drawing.Size(113, 28);
            this.ground3.TabIndex = 4;
            // 
            // ground1
            // 
            this.ground1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ground1.BackgroundImage = global::SuperCesarBoy.Properties.Resources.blocoInquebravel;
            this.ground1.Location = new System.Drawing.Point(-5, 246);
            this.ground1.Name = "ground1";
            this.ground1.Size = new System.Drawing.Size(113, 28);
            this.ground1.TabIndex = 5;
            // 
            // ground4
            // 
            this.ground4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ground4.BackgroundImage = global::SuperCesarBoy.Properties.Resources.blocoInquebravel;
            this.ground4.Location = new System.Drawing.Point(385, 246);
            this.ground4.Name = "ground4";
            this.ground4.Size = new System.Drawing.Size(113, 28);
            this.ground4.TabIndex = 6;
            // 
            // ground5
            // 
            this.ground5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ground5.BackgroundImage = global::SuperCesarBoy.Properties.Resources.blocoInquebravel;
            this.ground5.Location = new System.Drawing.Point(579, 246);
            this.ground5.Name = "ground5";
            this.ground5.Size = new System.Drawing.Size(113, 28);
            this.ground5.TabIndex = 7;
            // 
            // pgbEnd
            // 
            this.pgbEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbEnd.Location = new System.Drawing.Point(801, 108);
            this.pgbEnd.Name = "pgbEnd";
            this.pgbEnd.Size = new System.Drawing.Size(16, 480);
            this.pgbEnd.TabIndex = 8;
            // 
            // endPoint1
            // 
            this.endPoint1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endPoint1.BackColor = System.Drawing.Color.Transparent;
            this.endPoint1.Location = new System.Drawing.Point(801, -10);
            this.endPoint1.Name = "endPoint1";
            this.endPoint1.Size = new System.Drawing.Size(317, 592);
            this.endPoint1.TabIndex = 9;
            // 
            // stage0105
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.ground5);
            this.Controls.Add(this.ground4);
            this.Controls.Add(this.ground1);
            this.Controls.Add(this.ground3);
            this.Controls.Add(this.ground2);
            this.Controls.Add(this.pgbEnd);
            this.Controls.Add(this.endPoint1);
            this.Name = "stage0105";
            this.Started = true;
            this.Controls.SetChildIndex(this.endPoint1, 0);
            this.Controls.SetChildIndex(this.pgbEnd, 0);
            this.Controls.SetChildIndex(this.charCesar, 0);
            this.Controls.SetChildIndex(this.ground2, 0);
            this.Controls.SetChildIndex(this.ground3, 0);
            this.Controls.SetChildIndex(this.ground1, 0);
            this.Controls.SetChildIndex(this.ground4, 0);
            this.Controls.SetChildIndex(this.ground5, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ground ground2;
        private Controls.ground ground3;
        private Controls.ground ground1;
        private Controls.ground ground4;
        private Controls.ground ground5;
        private System.Windows.Forms.ProgressBar pgbEnd;
        private Controls.EndPoint endPoint1;
    }
}
