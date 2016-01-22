using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clg_dll_TypeTCPBase;

namespace dll_ServeurTCPSQLServer
{
    public class clg_ClientTCPSQLServer : clg_ClientTCP
    {
        public clg_ClientTCPSQLServer(bool pSansSigneDeVie)
            : base(pSansSigneDeVie)
        {
            
        }

        public clg_TransfertObjetsCSV DemandeMAJObjets()
        {
            try
            {
                ArreteTimerSDV();
                int l_tps = Environment.TickCount;

                object l_objRequete = default(clg_DemandeObjetsAMAJ);
                l_objRequete = new clg_DemandeObjetsAMAJ(new DateTime());

                c_TransertIp.EnvoieMessage(ref c_FluxReseau, ref  l_objRequete, "clg_DemandeObjetsAMAJ");
                clg_MessageIP_Serialise l_Reponse = default(clg_MessageIP_Serialise);
                l_Reponse = c_TransertIp.RecupMessage(ref c_FluxReseau);
                clg_TransfertObjetsCSV l_ResultatRequete = null;
                l_ResultatRequete = (clg_TransfertObjetsCSV) l_Reponse.Contenu;
                DemarreTimerSDV();
                return l_ResultatRequete;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}