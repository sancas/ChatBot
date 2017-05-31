using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ChatBot
{
    public partial class frmPrincipal : MetroForm
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            txtChat.Text += "Tu: " + txtMessage.Text + "\r\n";
            txtMessage.Clear();
        }
    }
}
