using System;
using System.Drawing;

using System.Windows.Forms;

namespace SuperCesarBoy.Controls
{
    public partial class charCesar : UserControl
    {
        public Boolean IsJumping { get; set; }
        private Boolean _IsLookingFront;

        private int iPos;
        public charCesar()
        {
            InitializeComponent();

            iPos = 0;
            _IsLookingFront = true;
        }

        public void MoveFront(Boolean IsMoving = true)
        {
            if (!_IsLookingFront)
            {
                ptbHead.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                _IsLookingFront = true;
            }

            if (IsJumping)
            {
                this.BackgroundImage = Properties.Resources.body003;
                return;
            }

            if (!IsMoving)
            {
                iPos = 0;
                this.BackgroundImage = Properties.Resources.body001;
                return;
            }
            ChangeImage();
        }

        private void ChangeImage()
        {

            switch (iPos)
            {
                case 0:
                    iPos = 1;
                    this.BackgroundImage = Properties.Resources.body002;
                    break;
                case 1:
                    iPos = 2;
                    this.BackgroundImage = Properties.Resources.body003;
                    break;
                case 2:
                    iPos = 3;
                    this.BackgroundImage = Properties.Resources.body004;
                    break;
                case 3:
                    iPos = 4;
                    this.BackgroundImage = Properties.Resources.body005;
                    break;
                case 4:
                    iPos = 5;
                    this.BackgroundImage = Properties.Resources.body006;
                    break;
                case 5:
                    iPos = 6;
                    this.BackgroundImage = Properties.Resources.body007;
                    break;
                case 6:
                    iPos = 7;
                    this.BackgroundImage = Properties.Resources.body008;
                    break;
                case 7:
                    iPos = 8;
                    this.BackgroundImage = Properties.Resources.body009;
                    break;
                case 8:
                    iPos = 2;
                    this.BackgroundImage = Properties.Resources.body005;
                    break;
            }
        }


        public void MoveBack(Boolean IsMoving = true)
        {
            if (_IsLookingFront)
            {
                ptbHead.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                _IsLookingFront = false;
            }

            if (IsJumping)
            {
                this.BackgroundImage = Properties.Resources.body003;
                this.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                return;
            }
            if (!IsMoving)
            {
                iPos = 0;
                this.BackgroundImage = Properties.Resources.body001;
                this.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                return;
            }

            ChangeImage();

            this.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

        //Boolean isDying;
        public void Die()
        {
            this.BackgroundImage = Properties.Resources.bodydie;
            
            /*isDying = true;
            this.BackgroundImage = null;
            PictureBox ptbBody = new PictureBox();
            ptbBody.BackColor = System.Drawing.Color.Transparent;
            ptbBody.BackgroundImage = Properties.Resources.bodydie;
            ptbBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ptbBody.Name = "ptbBody";
            ptbBody.Size = new System.Drawing.Size(this.Width, this.Height);
            ptbBody.TabStop = false;
            ptbBody.Visible = true;
            ptbBody.TabIndex = 11;
            ptbBody.Location = new System.Drawing.Point(0, 0);

            this.Controls.Add(ptbBody);
            ptbBody.BringToFront();
            ptbHead.BringToFront();*/
        }

        /*protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (isDying)
            {
                Graphics g = e.Graphics;

                if (Parent != null)
                {
                    int index = Parent.Controls.GetChildIndex(this);
                    for (int i = Parent.Controls.Count - 1; i > index; i--)
                    {
                        Control c = Parent.Controls[i];

                        if (c.Bounds.IntersectsWith(Bounds) && c.Visible)
                        {
                            Bitmap bmp = new Bitmap(c.Width, c.Height, g);
                            c.DrawToBitmap(bmp, c.ClientRectangle);
                            g.TranslateTransform(c.Left - Left, c.Top - Top);
                            g.DrawImageUnscaled(bmp, Point.Empty);
                            g.TranslateTransform(Left - c.Left, Top - c.Top);
                            bmp.Dispose();
                        }
                    }
                }
            }
        }*/


    }
}
