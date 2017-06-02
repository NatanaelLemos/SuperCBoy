using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SuperCesarBoy.Controls;
using System.Threading;
using System.Media;
using System.IO;

namespace SuperCesarBoy
{
    public partial class stageBase : Form
    {
        #region Properties/Variables
        [DllImport("user32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern short GetAsyncKeyState(Keys vKey);

        private bool _IsMovingFront;
        private bool _FallRisk;
        private bool _IsFalling;
        private bool _IsLastLeft;

        private SoundPlayer _JumpSound = new SoundPlayer(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\sndJump.dllx"));
        private SoundPlayer _LoseSound = new SoundPlayer(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\sndLoseLife.dllx"));

        private frmMain _FrmMain;
        private Thread _JumpThread;
    
        public bool Started { get; set; }
        #endregion

        #region Constructor
        public stageBase()
        {
            InitializeComponent();
        }
        public stageBase(frmMain FrmMain)
        {
            _FrmMain = FrmMain;
            InitializeComponent();
        }

        private void stageBase_Load(object sender, EventArgs e)
        {
            _IsMovingFront = true;
            Started = true;
            charCesar.BringToFront();
           // _FrmMain.RefreshLifeImage();
        }
        #endregion

        #region Methods
        protected void StartMovingChar()
        {
            tmrMoveChar.Enabled = true;
        }

        private bool Impact()
        {
            if (_FallRisk) return false;

            int CharCesarLeftPlusWidth = charCesar.Left + charCesar.Width;

            if (charCesar.Left <= 0)
            {
                charCesar.Left++;
                return true;
            }
            else if ((CharCesarLeftPlusWidth) >= (this.Width))
            {
                charCesar.Left--;
                return true;
            }

            foreach (Control ctr in this.Controls)
            {
                if (!Started) return false;
                if (ctr is EndPoint)
                {
                    if ((CharCesarLeftPlusWidth) >= (ctr.Left)) NextStage();
                    return false;
                }

                if (!(ctr is ground)) continue;
                if ((charCesar.Top + charCesar.Height) == ctr.Top) continue;
                if (charCesar.Left > (ctr.Left + ctr.Width)) continue;
                if ((CharCesarLeftPlusWidth) < ctr.Left) continue;
                if (charCesar.IsJumping) continue;
                if ((charCesar.Left >= (ctr.Left - 10)) && ((CharCesarLeftPlusWidth) <= (ctr.Left + ctr.Width + 10))) continue;
                if (charCesar.Top > (ctr.Top + ctr.Height)) continue;

                if (_IsMovingFront)
                {
                    charCesar.Left--;
                    return true;
                }
                else
                {
                    charCesar.Left++;
                    return true;
                }
            }
            return false;
        }

        private bool Fall()
        {
            if (charCesar.IsJumping) return false;
            int CharCesarLeftPlusWidth = charCesar.Left + charCesar.Width;
            foreach (Control ctr in this.Controls)
            {
                if (!(ctr is role)) continue;

                if ((CharCesarLeftPlusWidth) > ctr.Left && charCesar.Left < (ctr.Left + ctr.Width))
                {
                    _FallRisk = true;

                    if (charCesar.Left > ctr.Left && (CharCesarLeftPlusWidth) < (ctr.Left + ctr.Width))
                    {
                        int charCesarHeightDivTwo = charCesar.Height / 2;
                        while (charCesar.Top < (this.Height - (charCesarHeightDivTwo)))
                        {
                            if (!Started) return false;
                            charCesar.Top += 2;
                            this.Refresh();
                        }
                        return true;
                    }
                    return false;
                }
                _FallRisk = false;

            }
            return false;
        }

        private void NextStage()
        {
            Started = false;
            tmrMoveChar.Enabled = false;

            _FrmMain.NextStage();
        }

        protected void LoseGame()
        {
            _FrmMain.StopMusic();
            _LoseSound.Play();
            Started = false;
            tmrMoveChar.Enabled = false;

            this.Invoke(new Action(() => DyingScene()));

            _FrmMain.LifeQtd = _FrmMain.LifeQtd - 1;
            DialogResult restartGame = MessageBox.Show("Perdeu!" + Environment.NewLine + "Deseja recomeçar ?", "Perdeu", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            Thread.Sleep(10);
            if (restartGame == System.Windows.Forms.DialogResult.Yes)
            {
                _FrmMain.StartMusic();
                _FrmMain.RestartStage();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void DyingScene()
        {
            charCesar.Die();

            int charOldTop = charCesar.Top;
            while (charCesar.Top > charOldTop - 40)
            {
                charCesar.Top--;
                Thread.Sleep(2);
                Application.DoEvents();
            }
            while (charCesar.Top < this.Height)
            {
                charCesar.Top+=2;
                Thread.Sleep(2);
                Application.DoEvents();
            }
        }

        private void Gravity()
        {
            _IsFalling = true;
            ground upperGround = null;

            int CharCesarLeftPlusWidth = charCesar.Left + charCesar.Width;
            foreach (Control ctr in this.Controls)
            {
                if (!(ctr is ground)) continue;

                if ((charCesar.Left >= (ctr.Left - charCesar.Width)) && ((CharCesarLeftPlusWidth) <= (ctr.Left + ctr.Width + charCesar.Width)))
                {
                    if (upperGround == null) upperGround = (ctr as ground);
                    if (ctr.Top < upperGround.Top) upperGround = (ctr as ground);
                }
            }

            if (upperGround != null)
            {
                try
                {
                    this.Invoke
                    (
                        new Action(() =>
                        {
                            try
                            {
                                while ((charCesar.Top + charCesar.Height) < upperGround.Top)
                                {
                                    charCesar.Top += 4;
                                    Thread.Sleep(2);
                                    Application.DoEvents();
                                }

                                _IsFalling = false;
                            }
                            catch { }
                        })
                    );
                }
                catch { }
            }
        }
        #endregion

        #region Jump
        private void Jump()
        {
            if (!charCesar.IsJumping)
            {
                charCesar.IsJumping = true;
                _JumpThread = new Thread(JumpInvoker);
                _JumpThread.Start();
            }
        }

        private void JumpInvoker()
        {
            try
            {
                _JumpSound.Play();
                this.Invoke(new Action(() => CharJump()));
            }
            catch
            {
                Application.ExitThread();
            }
        }

        private void CharJump()
        {
            int charOldTop = charCesar.Top;
            int CharCesarLeftPlusWidth = charCesar.Left + charCesar.Width;
            if (charCesar.IsJumping)
            {
                bool haveGroundAbove = false;
                while (charCesar.Top > charOldTop - (charCesar.Height * 1.3))
                {
                    if (!Started) return;

                    foreach (Control ctr in this.Controls)
                    {
                        if ((ctr is ground)
                            && (charCesar.Top < (ctr.Top + ctr.Height)) && (charCesar.Top > ctr.Top)
                            && (charCesar.Left > ctr.Left) && ((CharCesarLeftPlusWidth) < (ctr.Left + ctr.Width)))
                        {
                            haveGroundAbove = true;
                            charCesar.Top = (ctr.Top + ctr.Height + 1);
                            break;
                        }
                    }
                    if (haveGroundAbove) break;

                    charCesar.Top -= 4;

                    Thread.Sleep(5);
                    Application.DoEvents();
                }

                bool isInGround = false;
                while (charCesar.Top < charOldTop)
                {
                    if (!Started) return;

                    foreach (Control ctr in this.Controls)
                    {
                        if (!(ctr is ground)) continue;

                        if (!haveGroundAbove && (charCesar.Top + charCesar.Height) >= ctr.Top)
                        {
                            if ((charCesar.Left >= (ctr.Left - charCesar.Width)) &&
                                ((charCesar.Left + charCesar.Height) <= (ctr.Left + ctr.Width + charCesar.Width)))
                            {
                                isInGround = true;
                                charCesar.Top = (ctr.Top - charCesar.Height);
                                break;
                            }
                        }
                    }
                    if (isInGround) break;

                    charCesar.Top += 4;
                    Thread.Sleep(5);
                    Application.DoEvents();
                }
                charCesar.IsJumping = false;
            }
        }
        #endregion

        #region Handlers
        private void tmrMoveChar_Tick(object sender, EventArgs e)
        {
            if (!Started) return;
            if (_IsFalling) return;

            if (!charCesar.IsJumping)
            {
                Gravity();

                if (stageBase.GetAsyncKeyState(Keys.Up) != 0) Jump();
            }

            if (Impact()) return;

            if (stageBase.GetAsyncKeyState(Keys.Right) != 0)
            {
                charCesar.MoveFront();
                if (charCesar.IsJumping) charCesar.Left += 3;
                else charCesar.Left += 5;
                _IsMovingFront = true;
                _IsLastLeft = false;
            }
            else if (stageBase.GetAsyncKeyState(Keys.Left) != 0)
            {
                charCesar.MoveBack();
                if (charCesar.IsJumping) charCesar.Left -= 3;
                else charCesar.Left -= 5;
                _IsMovingFront = false;
                _IsLastLeft = true;
            }
            else 
            {
                if (_IsLastLeft)
                {
                    charCesar.MoveBack(false);
                }
                else
                {
                    charCesar.MoveFront(false);
                }
                return;
            }
            
            Application.DoEvents();
            if (Fall()) LoseGame();
        }

        private void stageBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
            Started = false;
        }
        #endregion

        /*protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Right)
            {
                charCesar.MoveFront();
                if (charCesar.IsJumping) charCesar.Left += 3;
                else charCesar.Left += 5;
                _IsMovingFront = true;
                LastLeft = false;
                return true;
            }
            else if (keyData == Keys.Left)
            {
                charCesar.MoveBack();
                if (charCesar.IsJumping) charCesar.Left -= 3;
                else charCesar.Left -= 5;
                _IsMovingFront = false;
                LastLeft = true;
                return true;
            }
            else if (keyData == Keys.Up)
            {
                Jump();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }*/
    }
}
