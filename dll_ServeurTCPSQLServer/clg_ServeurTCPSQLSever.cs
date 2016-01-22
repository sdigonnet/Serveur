using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clg_dll_TypeTCPBase;
using System.Net.Sockets;

namespace dll_ServeurTCPSQLServer
{
    public class clg_ServeurTCPSQLSever : clg_ServeurTCP
    {
        private string c_AdresseServSynchro;
	    private int c_PortServSynchro;
	    private E_EtatServeur c_ServDemarOK;
        private Dictionary<string, clg_CnnServeurTCPSQLServer> c_ConnexionsTCP;
        private CLG_AccesBD.clg_Connecteur c_Connecteur;
        private CLG_AccesBD.clg_Connection c_Cnn;
        private log4net.ILog c_Loggeur;

        public clg_ServeurTCPSQLSever(string pServeur, int pPortEcouteServBD, CLG_AccesBD.clg_Connecteur pCnn, log4net.ILog pLoggeur)
            : base(pServeur, pPortEcouteServBD)
	    {
		    try {
                c_Loggeur = pLoggeur;
                c_Connecteur = pCnn;
                c_AdresseServSynchro = pServeur;
                c_PortServSynchro = pPortEcouteServBD;
                c_ConnexionsTCP = new Dictionary<string, clg_CnnServeurTCPSQLServer>();

                c_Cnn = new CLG_AccesBD.clg_Connection(ref c_Connecteur);
                c_Cnn.Ouvre();
		    } catch (Exception ex) {
                c_Loggeur.Error("Erreur a l'instanciation de la classe ServeurTCPSQLServer : " + ex.Message);
		    }
	    }

	    public override void ChangeEtat(clg_dll_TypeTCPBase.clg_ServeurTCP.E_EtatServeur pEtat)
	    {
		    base.ChangeEtat(pEtat);
	    }

	    public override clg_ConnexionServeurTCP CreObjConnexionServeur(ref TcpClient pClient)
	    {
		    try {
                //Tentative de connexion d'un client
                string l_key = pClient.Client.RemoteEndPoint.ToString();
                c_Loggeur.Info("Tentative de connexion du client : " + l_key);
                clg_CnnServeurTCPSQLServer l_Cnn;

                if (c_ConnexionsTCP.ContainsKey(l_key))
                {
                    c_Loggeur.Info("Le client existait déjà à cette adresse, remplacement du client");
                    l_Cnn = c_ConnexionsTCP[l_key];
                    base.EnleveConnexionServeur(l_Cnn);
                    c_ConnexionsTCP.Remove(l_Cnn.GetIDReseau);
                    l_Cnn.Arrete();
                    l_Cnn = null;
                }

                l_Cnn = new clg_CnnServeurTCPSQLServer(pClient, this);
                c_ConnexionsTCP.Add(l_Cnn.GetIDReseau, l_Cnn);
                return l_Cnn;
		    } catch (Exception ex) {
                c_Loggeur.Error("Erreur lors de la tentative de connexion du client : " + ex.Message);
                return null;
		    }
	    }

	    public override void Arrêter()
	    {
		    try {
                c_Loggeur.Info("Arret du serveur de transfert de synchronisation");
			    c_ServDemarOK = E_EtatServeur.Arrete;
			    base.Arrêter();
		    } catch (Exception ex) {
                c_Loggeur.Error("Erreur lors de l'arret du serveur de transfert de synchronisation : " + ex.Message);
		    }
	    }

	    ~clg_ServeurTCPSQLSever() 
	    {
		    Arrêter();
	    }

        public string AdresseServSynchro
        {
            get { return c_AdresseServSynchro; }
        }

        public int PortServSynchro
        {
            get { return c_PortServSynchro; }
        }

        public log4net.ILog Loggeur
        {
            get { return c_Loggeur; }
        }

        public CLG_AccesBD.clg_Connecteur Connecteur
        {
            get { return c_Connecteur; }
        }

        public Dictionary<string, clg_CnnServeurTCPSQLServer> Connexions
        {
            get
            {
                return c_ConnexionsTCP;
            }
        }
    }
}