using System;
using System.Windows.Forms;

namespace Tralala
{
    public partial class traFrmAbout : Form
    {
        public traFrmAbout()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
