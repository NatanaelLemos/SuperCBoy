using SuperCesarBoy.Controls;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SuperCesarBoy.Stage01
{
    public partial class stage0103 : SuperCesarBoy.stageBase
    {
        private Thread _BirdThread;

        public stage0103()
        {
            InitializeComponent();
        }
        public stage0103(frmMain FrmMain)
            : base(FrmMain)
        {
            InitializeComponent();

            StartMovingChar();
            charCesar.Top = (ground1.Top - charCesar.Height);
        }

        private void stage0103_Shown(object sender, EventArgs e)
        {
            _BirdThread = new Thread(BirdInvoker);
            _BirdThread.Start();
        }

        private void BirdInvoker()
        {
            Boolean isLeft = false;
            int imgIndex = 0;
            int shotIndex = 0;

            while (true)
            {
                if (!Started) break;

                if (ptbBird.Left <= 0)
                {
                    isLeft = true;
                }
                else if (ptbBird.Left >= (this.Width - ptbBird.Width))
                {
                    isLeft = false;
                }
                try
                {
                    this.Invoke(new Action(() => MoveBird(isLeft, imgIndex)));
                    Thread.Sleep(10);
                    Application.DoEvents();
                }
                catch { }

                try
                {
                    this.Invoke(new Action(() => Shot(shotIndex)));
                    Thread.Sleep(10);
                    Application.DoEvents();
                }
                catch { }

                imgIndex++;
                if (imgIndex > 2) imgIndex = 0;

                shotIndex++;
                if (shotIndex > 50) shotIndex = 0;
            }
        }

        private void Shot(int ShotIndex)
        {
            int shotCount = 0;

            foreach (Control shotCtr in this.Controls)
            {
                if (!(shotCtr is Shot)) continue;

                shotCount++;
                shotCtr.Top += 3;

                if (shotCtr.Left > charCesar.Left && (shotCtr.Left + shotCtr.Width) < (charCesar.Left + charCesar.Width) && 
                    (shotCtr.Top + shotCtr.Height) > charCesar.Top && (shotCtr.Top + shotCtr.Height) < (charCesar.Top + charCesar.Height))
                {
                    LoseGame();
                    return;
                }

                ground groundUnderShot = null;
                foreach (Control grdCtr in this.Controls)
                {
                    if (grdCtr == shotCtr) continue;
                    if (!(grdCtr is ground)) continue;

                    if (shotCtr.Left >= grdCtr.Left && (shotCtr.Left + shotCtr.Width) <= (grdCtr.Left + grdCtr.Width))
                    {
                        groundUnderShot = (grdCtr as ground);
                        break;
                    }
                }

                if ((shotCtr.Top + shotCtr.Height) >= groundUnderShot.Top) shotCtr.Dispose();
            }
            if (shotCount > 3) return;
            if (ShotIndex < 50) return;

            Shot shot = new Shot();
            shot.BackColor = System.Drawing.Color.Transparent;
            shot.BackgroundImage = Properties.Resources.torpedo_icon;
            shot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            shot.Name = "ptbShot";
            shot.Size = new System.Drawing.Size(26, 39);
            shot.TabStop = false;
            shot.Visible = true;
            shot.TabIndex = 11;
            shot.Location = new System.Drawing.Point((ptbBird.Left + (ptbBird.Width / 2)), (ptbBird.Top + ptbBird.Height));

            this.Controls.Add(shot);
            shot.BringToFront();
        }

        private void MoveBird(Boolean IsLeft, int ImgIndex)
        {
            if (IsLeft)
            {
                ptbBird.Left += 4;
            }
            else
            {
                ptbBird.Left -= 4;
            }

            switch (ImgIndex)
            {
                case 0:
                    ptbBird.BackgroundImage = Properties.Resources.bird01;
                    break;
                case 1:
                    ptbBird.BackgroundImage = Properties.Resources.bird02;
                    break;
                case 2:
                    ptbBird.BackgroundImage = Properties.Resources.bird00;
                    break;
            }

            if (IsLeft) ptbBird.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }
    }
}
