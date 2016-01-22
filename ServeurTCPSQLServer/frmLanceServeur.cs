using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using dll_ServeurTCPSQLServer;

namespace ServeurTCPSQLServer
{
    public partial class frmLanceServeur : Form
    {
        private clg_ServeurTCPSQLSever c_Serveur;
        private clg_ChargementBase c_BaseChargee;

        public frmLanceServeur()
        {
            InitializeComponent();
        }

        private void btn_Demarrer_Click(object sender, EventArgs e)
        {
            try
            {
                //Connexion a la base de donnees
                CLG_AccesBD.clg_Connecteur l_connecteur = new CLG_AccesBD.clg_ConnecteurADODB_SQLServer(TBServeur.Text, TBNomBase.Text, TBUtilisateur.Text, TBMotDePasse.Text);
                c_BaseChargee = new clg_ChargementBase(l_connecteur);
                dll_Log4Net.Log.ExceptionLogger.Info("Connexion a la base avec les parametres suivants : " + TBServeur.Text + "," + TBNomBase.Text + "," + TBUtilisateur.Text + "," + TBMotDePasse.Text);
                if ((c_Serveur != null))
                {
                    ArreterSynchroTCP();
                }
                else
                {
                    //Instanciation du service d'ecoute TCP/IP
                    c_Serveur = new clg_ServeurTCPSQLSever(tbx_NomHost.Text, int.Parse(tbx_NumPort.Text), l_connecteur, dll_Log4Net.Log.ExceptionLogger);
                }
                GC.Collect();
                //Demarrage de l'ecoute
                c_Serveur.Demarrer();
                MessageBox.Show("Demarrage du serveur reussi");
            }
            catch (Exception ex)
            {
                dll_Log4Net.Log.ExceptionLogger.Error("Echec du demarrage du service d'ecoute : " + ex.Message);
                ArreterSynchroTCP();
            }
        }

        //Arret du service d'ecoute
        private void ArreterSynchroTCP()
        {
            try
            {
                if (c_Serveur != null)
                {
                    dll_Log4Net.Log.ExceptionLogger.Info("Demande d'arret du service d'ecoute");
                    c_Serveur.Arrêter();
                    c_Serveur = null;
                }
            }
            catch (Exception ex)
            {
                dll_Log4Net.Log.ExceptionLogger.Error("Echec de l'arret du service d'ecoute : " + ex.Message);
            }
        }

        private void btn_Arrêter_Click(object sender, EventArgs e)
        {
            ArreterSynchroTCP();
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            List<clg_ReflexionV3.clg_TableBase> l_liste = new List<clg_ReflexionV3.clg_TableBase>();
            foreach (clg_PUS_PUITS_STOCKAGE puits in clg_ChargementBase.Modele.ListePUS_PUITS_STOCKAGE.Dictionnaire.Values.ToList())
            {
                l_liste.Add(puits);
            }
            foreach (clg_ETU_ETUI etui in clg_ChargementBase.Modele.ListeETU_ETUI.Dictionnaire.Values.ToList())
            {
                l_liste.Add(etui);
            }

            clg_TransfertObjetsCSV l_TransfertObjetsCSV = new clg_TransfertObjetsCSV(clg_ExporteObjetsCSV.GenereLigne(l_liste));
            c_Serveur.Connexions.Values.First().c_QueueTransfertObjetsCSV.Enqueue(l_TransfertObjetsCSV);
        }
    }
}
