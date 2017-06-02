using System.Drawing;
using System.Windows.Forms;

namespace SuperCesarBoy.Controls
{
    public partial class TransparentPictureBox : UserControl
    {
        public TransparentPictureBox()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
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

        public override Image BackgroundImage
        {
            get
            {
                return pictureBox.BackgroundImage;
            }
            set
            {
                pictureBox.BackgroundImage = value;
            }
        }

        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return pictureBox.BackgroundImageLayout;
            }
            set
            {
                pictureBox.BackgroundImageLayout = value;
            }
        }

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                pictureBox.BackColor = value;
                base.BackColor = value;
            }
        }
    }
}
