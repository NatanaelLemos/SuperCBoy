namespace SuperCesarBoy.Controls
{
    partial class charCesar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ptbHead = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbHead)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbHead
            // 
            this.ptbHead.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbHead.BackgroundImage = global::SuperCesarBoy.Properties.Resources.face;
            this.ptbHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbHead.Location = new System.Drawing.Point(6, 8);
            this.ptbHead.Name = "ptbHead";
            this.ptbHead.Size = new System.Drawing.Size(48, 42);
            this.ptbHead.TabIndex = 4;
            this.ptbHead.TabStop = false;
            // 
            // charCesar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::SuperCesarBoy.Properties.Resources.body001;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.ptbHead);
            this.DoubleBuffered = true;
            this.Name = "charCesar";
            this.Size = new System.Drawing.Size(60, 101);
            ((System.ComponentModel.ISupportInitialize)(this.ptbHead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbHead;
    }
}
