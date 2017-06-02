
namespace SuperCesarBoy.Stage01
{
    public partial class stage0104 : SuperCesarBoy.stageBase
    {
        public stage0104()
        {
            InitializeComponent();
        }

        public stage0104(frmMain FrmMain)
            : base(FrmMain)
        {
            InitializeComponent();

            StartMovingChar();
            charCesar.Top = (ground1.Top - charCesar.Height);
        }
    }
}
