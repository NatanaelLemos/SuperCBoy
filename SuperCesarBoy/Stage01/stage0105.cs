using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SuperCesarBoy.Stage01
{
    public partial class stage0105 : SuperCesarBoy.stageBase
    { 
        public stage0105()
        {
            InitializeComponent();
        }

        public stage0105(frmMain FrmMain)
            : base(FrmMain)
        {
            InitializeComponent();

            StartMovingChar();
            charCesar.Top = (ground1.Top - charCesar.Height);

        }
    }
}
