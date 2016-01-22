using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using clg_dll_TypeTCPBase;

namespace dll_ServeurTCPSQLServer
{
    public class clg_CnnServeurTCPSQLServer : clg_ConnexionServeurTCP
    {
	    clg_ServeurTCPSQLSever c_ServeurBDSynchro;
	    clg_ClientTCP c_ClientSynchro = null;
        public Queue<clg_TransfertObjetsCSV> c_QueueTransfertObjetsCSV;

        public clg_CnnServeurTCPSQLServer(TcpClient pTcpClient, clg_ServeurTCPSQLSever pServeurBD)
            : base(pTcpClient)
	    {
		    c_ServeurBDSynchro = pServeurBD;
            c_QueueTransfertObjetsCSV = new Queue<clg_TransfertObjetsCSV>();
	    }

	    public override void AvantConnecte()
	    {
		    try {
                c_ServeurBDSynchro.Loggeur.Info("Tentative de demarrage d'une connexion vers un client : " + c_TcpClient.Client.RemoteEndPoint.ToString());
			    c_ClientSynchro = new clg_ClientTCPSQLServer(false);
			    c_ClientSynchro.Connecter(c_ServeurBDSynchro.AdresseServSynchro, c_ServeurBDSynchro.PortServSynchro);
		    } catch (Exception ex) {
                c_ServeurBDSynchro.Loggeur.Error("Echec de demarrage d'une connexion vers un client : " + ex.Message);
		    }
	    }

	    public override void GereMessageRecu(clg_MessageIP_Serialise pObjet, ref object pObjetReponse, ref string pTypeContenuReponse)
	    {
		    try {
                c_ServeurBDSynchro.Loggeur.Info("Reception d'un message de " + c_TcpClient.Client.RemoteEndPoint.ToString());

			    if ((pObjet != null)) {
                    c_ServeurBDSynchro.Loggeur.Info("Nature du message : " + pObjet.TypeContenu);
                    if (pObjet.TypeContenu == "clg_DemandeRequeteSQL")
                    {
                        clg_DemandeRequeteSQL l_Message = (clg_DemandeRequeteSQL) pObjet.Contenu;

                        c_ServeurBDSynchro.Loggeur.Info("Demande d'execution de la requete : " + l_Message.OrdreSQL);
                        clg_dll_TypeTCPBase.clg_ResultatRequete l_ResultReq = c_ServeurBDSynchro.Connecteur.ResultatSELECT(l_Message.OrdreSQL);

					    //Initialise les éléments de réponse qui seront renvoyés
                        pObjetReponse = l_ResultReq;
                        pTypeContenuReponse = "clg_dll_TypeTCPBase.clg_ResultatRequete";

                    }
                    else if (pObjet.TypeContenu == "clg_SigneDeVie")
                    {
                        c_ServeurBDSynchro.Loggeur.Info("Renvoi d'un signe de vie");
                        clg_SigneDeVie l_SDVClient = (clg_SigneDeVie)pObjet.Contenu;
                        pObjetReponse = null;
                        pTypeContenuReponse = "ReponseSigneDeVie";
                    }
                    else if (pObjet.TypeContenu == "clg_DemandeObjetsAMAJ")
                    {
                        c_ServeurBDSynchro.Loggeur.Info("Renvoi des objets a MAJ");
                        clg_DemandeObjetsAMAJ l_Demande = (clg_DemandeObjetsAMAJ)pObjet.Contenu;
                        if (c_QueueTransfertObjetsCSV.Count > 0)
                        {
                            pObjetReponse = c_QueueTransfertObjetsCSV.First();
                        }
                        else
                        {
                            pObjetReponse = null;
                        }
                        pTypeContenuReponse = "clg_TransfertObjetsCSV";
				    }
				    pObjet = null;
			    }
		    } catch (Exception ex) {
                c_ServeurBDSynchro.Loggeur.Error("Erreur dans le traitement d'un message : " + ex.Message);
		    }
	    }
    }
}