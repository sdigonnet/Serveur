using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeurTCPSQLServer
{
    class clg_GereCompteurs
    {
        CLG_AccesBD.clg_ConnexionBD c_Cnn;

        public clg_GereCompteurs(CLG_AccesBD.clg_ConnexionBD pCnn)
        {
            c_Cnn = pCnn;
        }

        public void ChargeCompteursExistants()
        {
            string l_Requete = "SELECT cpt_cn, cpt_n_valeur FROM compteur";
            c_Cnn.ExecuteSELECT(l_Requete);
        }

        public void CreeNouvelUtilisateur()
        {

        }
    }
}
