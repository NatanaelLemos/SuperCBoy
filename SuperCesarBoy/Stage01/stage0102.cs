using System;
using System.Threading;

namespace SuperCesarBoy.Stage01
{
    public partial class stage0102 : stageBase
    {
        private Thread _PlantsThread;
        public stage0102()
        {
            InitializeComponent();
        }
        public stage0102(frmMain FrmMain)
            : base(FrmMain)
        {
            InitializeComponent();

            StartMovingChar();
            charCesar.Top = (ground1.Top - charCesar.Height);
        }

        private void stage0102_Shown(object sender, EventArgs e)
        {
            _PlantsThread = new Thread(MovePlantsInvoker);
            _PlantsThread.Start();
        }

        private void MovePlantsInvoker()
        {
            Boolean isTopPlant1 = false;
            Boolean isTopPlant2 = false;
            Boolean isTopPlant3 = false;
            Boolean isTopPlant4 = false;

            while (true)
            {
                if (!Started) break;
                try
                {
                    this.Invoke(new Action(() => MovePlants(isTopPlant1, isTopPlant2, isTopPlant3, isTopPlant4)));
                }
                catch { }
                Thread.Sleep(10);

                if (
                        (((ptbPlant1.Top - 10) < ground2.Top) && (charCesar.Left > ground2.Left) && ((charCesar.Left + charCesar.Width) < (ground2.Left + ground2.Width))) ||
                        (((ptbPlant2.Top - 10) < ground3.Top) && (charCesar.Left > ground3.Left) && ((charCesar.Left + charCesar.Width) < (ground3.Left + ground3.Width))) ||
                        (((ptbPlant3.Top - 10) < ground4.Top) && (charCesar.Left > ground4.Left) && ((charCesar.Left + charCesar.Width) < (ground4.Left + ground4.Width))) ||
                        (((ptbPlant4.Top - 10) < ground5.Top) && (charCesar.Left > ground5.Left) && ((charCesar.Left + charCesar.Width) < (ground5.Left + ground5.Width)))
                    )
                {
                    if (!charCesar.IsJumping)
                    {
                        this.Invoke(new Action(() => LoseGame()));
                        break;
                    }
                }


                if ((ptbPlant1.Top + ptbPlant1.Height) < ground2.Top) isTopPlant1 = true;
                else if (ptbPlant1.Top > (ground2.Top + ptbPlant1.Height + ptbPlant1.Height)) isTopPlant1 = false;

                if ((ptbPlant2.Top + ptbPlant2.Height) < ground3.Top) isTopPlant2 = true;
                else if (ptbPlant2.Top > (ground3.Top + ptbPlant2.Height + ptbPlant2.Height)) isTopPlant2 = false;

                if ((ptbPlant3.Top + ptbPlant3.Height) < ground4.Top) isTopPlant3 = true;
                else if (ptbPlant3.Top > (ground4.Top + ptbPlant3.Height + ptbPlant3.Height)) isTopPlant3 = false;

                if ((ptbPlant4.Top + ptbPlant4.Height) < ground5.Top) isTopPlant4 = true;
                else if (ptbPlant4.Top > (ground5.Top + ptbPlant4.Height + ptbPlant4.Height)) isTopPlant4 = false;
            }

        }

        private void MovePlants(Boolean isTopPlant1, Boolean isTopPlant2, Boolean isTopPlant3, Boolean isTopPlant4)
        {
            if (isTopPlant1) ptbPlant1.Top++;
            else ptbPlant1.Top--;

            if (isTopPlant2) ptbPlant2.Top++;
            else ptbPlant2.Top--;

            if (isTopPlant3) ptbPlant3.Top++;
            else ptbPlant3.Top--;

            if (isTopPlant4) ptbPlant4.Top++;
            else ptbPlant4.Top--;
        }

    }
}
