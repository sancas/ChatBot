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
        string botName,
            username;
        int control;
        List<string> Saludos = new List<string>(new string[]
        { "Hola", "Hola!", "hola",
        "Que ondas", "Que ondas!", "que ondas", "que ondas!",
        "Buenos dias", "Buenos dias!", "buenos dias", "buenos dias!",
        "Buenas tardes", "Buenas tardes!", "buenas tardes", "buenas tardes!",
        "Buenas noches", "Buenas noches!", "buenas noches", "buenas noches!"
        });
        string[] operaciones =
        {
            "Suma", "suma", "sumar", "Sumar",
            "Resta", "resta", "restar", "Restar",
            "Multiplicacion", "multiplicacion", "Multiplicar", "multiplicar",
            "Division", "division", "Dividir", "dividir"
        };
        List<string> ListaOperaciones = new List<string>();
        List<string> Afirmaciones = new List<string>(new string[]
        { "Si", "si", "Si!", "si!", "Simon", "simon", "Simon!"
        });
        public frmPrincipal()
        {
            InitializeComponent();
            botName = "ChatBot";
            username = "Tu";
            ListaOperaciones.AddRange(operaciones);
            control = 0;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            txtChat.Text += username + ": " + txtMessage.Text + "\r\n";
            if (control == 3)
            {
                if (ListaOperaciones.Contains(txtMessage.Text))
                {
                    for (int x = 0; x <= ListaOperaciones.Count; x++)
                    {
                        if (ListaOperaciones[x] == txtMessage.Text)
                        {
                            if (x < 4)
                                control = 4;
                            else if (x < 8)
                                control = 5;
                            else if (x < 12)
                                control = 6;
                            else if (x < 16)
                                control = 7;
                            break;
                        }
                    }
                }
                else
                {
                    txtChat.Text += botName + ": Esa operación no la puedo realizar, intenta con otra! :D \r\n";
                }
            }
            if (control == 2)
            {
                if (Afirmaciones.Contains(txtMessage.Text))
                {
                    txtChat.Text += botName + ": Que operación deseas realizar? \r\n";
                    control = 3;
                }
            }
            if (control == 1)
            {
                username = txtMessage.Text;
                txtChat.Text += botName + ": Un gustazo " + username + ", te gustaria realizar alguna operación?\r\n";
                control = 2;
            }
            if (control == 0)
            {
                if (Saludos.Contains(txtMessage.Text))
                {
                    txtChat.Text += "PC: " + txtMessage.Text + ", me llamo " + botName + " como te llamas tu?" + "\r\n";
                    control = 1;
                }

            }
            txtMessage.Clear();
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSend.PerformClick();
            }
        }
    }
}
