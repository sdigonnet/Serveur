using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLG_AccesBD;

class clg_ChargementBase
{
    public static clg_Modele Modele;
    public static clg_Controleur Controleur;
    public static clg_Connection Cnn;

    public clg_ChargementBase(clg_Connecteur pConnecteur)
    {
        Cnn = new clg_Connection(ref pConnecteur);
        Cnn.Ouvre();

        Modele = new clg_Modele();
        Controleur = new clg_Controleur(Cnn);

        Modele.ChargeStructure();
    }
}