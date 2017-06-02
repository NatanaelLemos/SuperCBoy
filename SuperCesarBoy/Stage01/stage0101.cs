using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.IO;

namespace SuperCesarBoy.Stage01
{
    public partial class stage0101 : SuperCesarBoy.stageBase
    {
        private Thread _EnemyThread;
        private Thread _CloudThread;

        private Boolean _IsMovingEnemyLeft;
        private Boolean _IsKillingEnemy;

        private SoundPlayer _KillingEnemySound = new SoundPlayer(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\sndKillEnemy1.dllx"));

        public stage0101() : base() { }

        public stage0101(frmMain FrmMain)
            : base(FrmMain)
        {
            InitializeComponent();

            StartMovingChar();
            charCesar.Top = (ground1.Top - charCesar.Height);

            ptbEnemy.Top = (ground2.Top - ptbEnemy.Height);
        }

        private void stage0101_Shown(object sender, EventArgs e)
        {
            _EnemyThread = new Thread(MoveEnemy);
            _EnemyThread.Start();

            _CloudThread = new Thread(MoveCloudInvoker);
            _CloudThread.Start();
        }

        private void MoveCloudInvoker()
        {
            Boolean leftSide = false;
            while (true)
            {
                if (!Started) return;

                if (cloud1.Left < 10) leftSide = false;
                else if ((cloud2.Left + cloud2.Width) >= (this.Width - 10)) leftSide = true;
                try
                {
                    this.Invoke(new Action(() => MoveCloud(leftSide)));
                }
                catch
                {
                    break;
                }
                Thread.Sleep(10);
                Application.DoEvents();
            }
        }

        private void MoveCloud(Boolean leftSide)
        {
            if (leftSide)
            {
                cloud1.Left -= 2;
                cloud2.Left -= 2;

                cloud3.Left += 2;
                cloud4.Left += 2;
            }
            else
            {
                cloud1.Left += 2;
                cloud2.Left += 2;

                cloud3.Left -= 2;
                cloud4.Left -= 2;
            }
        }

        private void MoveEnemy()
        {
            _IsMovingEnemyLeft = true;
            _IsKillingEnemy = false;
            while (true)
            {
                if (!Started) return;
                try
                {
                    if ((charCesar.Left >= (ptbEnemy.Left - charCesar.Width)) && ((charCesar.Left + charCesar.Width) <= (ptbEnemy.Left + ptbEnemy.Width + charCesar.Width)))
                    {
                        if (((charCesar.Top + charCesar.Height) == (ptbEnemy.Top + ptbEnemy.Height)) && ((charCesar.Left + charCesar.Width) >= (ptbEnemy.Left)) && (ptbEnemy.Visible))
                        {
                            if (!_IsKillingEnemy)
                                this.Invoke(new Action(() => LoseGame()));

                        }
                        else if (((charCesar.Top + charCesar.Height) <= (ptbEnemy.Top + ptbEnemy.Height)) && ((charCesar.Top + charCesar.Height) >= ptbEnemy.Top))
                        {
                            _IsKillingEnemy = true;

                            _KillingEnemySound.Play();
                            while (_IsKillingEnemy)
                            {
                                this.Invoke(new Action(() => DestroyEnemy()));
                                Thread.Sleep(5);
                            }
                            _KillingEnemySound.SoundLocation = "";
                            _KillingEnemySound.Dispose();
                        }
                    }
                    else
                    {
                        this.Invoke(new Action(() => MovingEnemy()));
                    }

                    Thread.Sleep(10);
                }
                catch
                {
                    break;
                }

            }
        }

        private void DestroyEnemy()
        {
            ptbEnemy.Height--;
            ptbEnemy.Top++;

            if (ptbEnemy.Height <= 5)
            {
                _IsKillingEnemy = false;
                ptbEnemy.Visible = false;
                ptbEnemy.Dispose();
                _EnemyThread.Join(1);
            }
        }

        private void MovingEnemy()
        {
            if (_IsMovingEnemyLeft)
                ptbEnemy.Left -= 1;
            else
                ptbEnemy.Left += 1;

            if (ptbEnemy.Left < (ground2.Left))
            {
                ptbEnemy.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                _IsMovingEnemyLeft = false;
            }
            else if (ptbEnemy.Left > (ground2.Left + ground2.Width) - ptbEnemy.Width)
            {
                ptbEnemy.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                _IsMovingEnemyLeft = true;
            }
        }

    }
}
