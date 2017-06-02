namespace SuperCesarBoy
{
    partial class stageBase
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stageBase));
            this.tmrMoveChar = new System.Windows.Forms.Timer(this.components);
            this.charCesar = new SuperCesarBoy.Controls.charCesar();
            this.SuspendLayout();
            // 
            // tmrMoveChar
            // 
            this.tmrMoveChar.Interval = 11;
            this.tmrMoveChar.Tick += new System.EventHandler(this.tmrMoveChar_Tick);
            // 
            // charCesar
            // 
            this.charCesar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.charCesar.BackColor = System.Drawing.Color.Transparent;
            this.charCesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("charCesar.BackgroundImage")));
            this.charCesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.charCesar.IsJumping = false;
            this.charCesar.Location = new System.Drawing.Point(109, 325);
            this.charCesar.Name = "charCesar";
            this.charCesar.Size = new System.Drawing.Size(59, 106);
            this.charCesar.TabIndex = 0;
            // 
            // stageBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.charCesar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "stageBase";
            this.Text = "faseBase";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.stageBase_FormClosing);
            this.Load += new System.EventHandler(this.stageBase_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrMoveChar;
        public Controls.charCesar charCesar;


    }
}