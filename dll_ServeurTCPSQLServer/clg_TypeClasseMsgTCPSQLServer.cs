using System;

namespace dll_ServeurTCPSQLServer
{
    [Serializable()]
    public class clg_DemandeObjetsAMAJ
    {

        public DateTime DateHeure;
        public clg_DemandeObjetsAMAJ(DateTime pDateHeure)
        {
            DateHeure = pDateHeure;
        }
    }

    [Serializable()]
    public class clg_TransfertObjetsCSV
    {

        public string ChaineCSV;
        public clg_TransfertObjetsCSV(string pChaineCSV)
        {
            ChaineCSV = pChaineCSV;
        }
    }
}