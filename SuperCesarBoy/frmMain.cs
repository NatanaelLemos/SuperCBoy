using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCesarBoy
{
    public partial class frmMain : Form
    {
        private Thread _MusicThread;

        private stageBase _FaseAtual;

        private int _LifeQtd;
        public int LifeQtd
        {
            get
            {
                return _LifeQtd;
            }
            set
            {
                _LifeQtd = value;

                switch (value)
                {
                    case 0:
                        this.Invoke(new Action(() => GameOver()));
                        break;
                    case 1:
                        ptbLife1.Visible = true;
                        ptbLife2.Visible = ptbLife3.Visible = ptbLife4.Visible = ptbLife5.Visible = ptbLife6.Visible = ptbLife7.Visible = ptbLife8.Visible = ptbLife9.Visible = ptbLife10.Visible = false;
                        break;
                    case 2:
                        ptbLife1.Visible = ptbLife2.Visible = true;
                        ptbLife3.Visible = ptbLife4.Visible = ptbLife5.Visible = ptbLife6.Visible = ptbLife7.Visible = ptbLife8.Visible = ptbLife9.Visible = ptbLife10.Visible = false;
                        break;
                    case 3:
                        ptbLife1.Visible = ptbLife2.Visible = ptbLife3.Visible = true;
                        ptbLife4.Visible = ptbLife5.Visible = ptbLife6.Visible = ptbLife7.Visible = ptbLife8.Visible = ptbLife9.Visible = ptbLife10.Visible = false;
                        break;
                    case 4:
                        ptbLife1.Visible = ptbLife2.Visible = ptbLife3.Visible = ptbLife4.Visible = true;
                        ptbLife5.Visible = ptbLife6.Visible = ptbLife7.Visible = ptbLife8.Visible = ptbLife9.Visible = ptbLife10.Visible = false;
                        break;
                    case 5:
                        ptbLife1.Visible = ptbLife2.Visible = ptbLife3.Visible = ptbLife4.Visible = ptbLife5.Visible = true;
                        ptbLife6.Visible = ptbLife7.Visible = ptbLife8.Visible = ptbLife9.Visible = ptbLife10.Visible = false;
                        break;
                    case 6:
                        ptbLife1.Visible = ptbLife2.Visible = ptbLife3.Visible = ptbLife4.Visible = ptbLife5.Visible = ptbLife6.Visible = true;
                        ptbLife7.Visible = ptbLife8.Visible = ptbLife9.Visible = ptbLife10.Visible = false;
                        break;
                    case 7:
                        ptbLife1.Visible = ptbLife2.Visible = ptbLife3.Visible = ptbLife4.Visible = ptbLife5.Visible = ptbLife6.Visible = ptbLife7.Visible = true;
                        ptbLife8.Visible = ptbLife9.Visible = ptbLife10.Visible = false;
                        break;
                    case 8:
                        ptbLife1.Visible = ptbLife2.Visible = ptbLife3.Visible = ptbLife4.Visible = ptbLife5.Visible = ptbLife6.Visible = ptbLife7.Visible = ptbLife8.Visible = true;
                        ptbLife9.Visible = ptbLife10.Visible = false;
                        break;
                    case 9:
                        ptbLife10.Visible = false;
                        ptbLife1.Visible = ptbLife2.Visible = ptbLife3.Visible = ptbLife4.Visible = ptbLife5.Visible = ptbLife6.Visible = ptbLife7.Visible = ptbLife8.Visible = ptbLife9.Visible = true;
                        break;
                    case 10:
                        ptbLife1.Visible = ptbLife2.Visible = ptbLife3.Visible = ptbLife4.Visible = ptbLife5.Visible = ptbLife6.Visible = ptbLife7.Visible = ptbLife8.Visible = ptbLife9.Visible = ptbLife10.Visible = true;
                        break;
                }
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //"Esquentar" as threads
            Parallel.For(0, 1000000, i => { Application.DoEvents(); });

            StartMusic();

            Stage01.stage0101 fase = new Stage01.stage0101(this);
            ShowStage(fase);
            LifeQtd = 4;
        }

        private void PlayMusic()
        {
            while (true)
            {
                Musics.MarioTheme.PlayMusic();
            }
        }

        public void StartMusic()
        {
            if (_MusicThread == null) _MusicThread = new Thread(PlayMusic);

            _MusicThread.Start();
        }

        public void StopMusic()
        {
            if (_MusicThread != null && _MusicThread.IsAlive)
            {
                _MusicThread.Abort();
                _MusicThread = null;
            }
        }

        private void GameOver()
        {
            MessageBox.Show("Game Over!");
            Environment.Exit(0);
        }

        public void ShowStage(stageBase frm)
        {
            if (_FaseAtual != null) _FaseAtual.Hide();

            _FaseAtual = frm;
            _FaseAtual.MdiParent = this;
            _FaseAtual.Show();
            _FaseAtual.WindowState = FormWindowState.Maximized;
        }

        public void NextStage()
        {
            stageBase faseAtual = null;
            switch (_FaseAtual.Name)
            {
                case "stage0101":
                    {
                        faseAtual = new Stage01.stage0102(this);
                        break;
                    }
                case "stage0102":
                    {
                        faseAtual = new Stage01.stage0103(this);
                        break;
                    }
                case "stage0103":
                    {
                        faseAtual = new Stage01.stage0104(this);
                        break;
                    }
                case "stage0104":
                    {
                        faseAtual = new Stage01.stage0105(this);
                        break;
                    }
            }

            if (_FaseAtual.Name == "stage0105")
            {
                MessageBox.Show("Parabéns, você terminou a demo de Super César Boy!" + Environment.NewLine + "Fique atento para novidades.");
                Environment.Exit(0);
            }
            _FaseAtual.Close();
            ShowStage(faseAtual);
        }

        public void RestartStage()
        {
            stageBase faseAtual = null;
            switch (_FaseAtual.Name)
            {
                case "stage0101":
                    {
                        faseAtual = new Stage01.stage0101(this);
                        break;
                    }
                case "stage0102":
                    {
                        faseAtual = new Stage01.stage0102(this);
                        break;
                    }
                case "stage0103":
                    {
                        faseAtual = new Stage01.stage0103(this);
                        break;
                    }
                case "stage0104":
                    {
                        faseAtual = new Stage01.stage0104(this);
                        break;
                    }
            }

            _FaseAtual.Close();
            ShowStage(faseAtual);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _MusicThread.Abort();
            }
            catch { }
        }

        private void btnMusic_Click(object sender, EventArgs e)
        {
            try
            {
                if (_MusicThread == null) StartMusic();
                else StopMusic();
            }
            catch { }
        }
    }
}
