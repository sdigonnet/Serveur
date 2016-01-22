using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_COULER: clg_ControleurBase
{
	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT COU_CN, CLS_CN FROM COULER";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_COU_COULIS l_COU_COULIS = clg_ChargementBase.Modele.ListeCOU_COULIS.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_COU_COULIS.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()))];
			clg_PAN_PANIER l_PAN_PANIER = clg_ChargementBase.Modele.ListePAN_PANIER.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_PAN_PANIER.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))];
			l_COU_COULIS.ListePAN_PANIER.Add(l_PAN_PANIER);
			l_PAN_PANIER.ListeCOU_COULIS.Add(l_COU_COULIS);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
	}
	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
	}
}
