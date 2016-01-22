using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dll_ServeurTCPSQLServer;

namespace TestClientSQLServer
{
    public partial class frmClientSQLServer : Form
    {
        clg_ClientTCPSQLServer c_ClientTCP;

        public frmClientSQLServer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c_ClientTCP = new clg_ClientTCPSQLServer(false);
            if (c_ClientTCP.Connecter("127.0.0.1", 30150))
            {
                string l_test = "";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            clg_TransfertObjetsCSV l_Resultat = (clg_TransfertObjetsCSV)c_ClientTCP.DemandeMAJObjets();
        }
    }
}
