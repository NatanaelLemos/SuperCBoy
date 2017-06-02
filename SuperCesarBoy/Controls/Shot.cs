using System.ComponentModel;
using System.Windows.Forms;

namespace SuperCesarBoy.Controls
{
    public partial class Shot : PictureBox
    {
        public Shot()
        {
            InitializeComponent();
        }

        public Shot(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
