using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_CALER: clg_ControleurBase
{
	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT COU_CN, CLS_CN FROM CALER";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_COU_COULIS l_COU_COULIS = clg_ChargementBase.Modele.ListeCOU_COULIS.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_COU_COULIS.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()))];
			clg_CLS_COLIS l_CLS_COLIS = clg_ChargementBase.Modele.ListeCLS_COLIS.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_CLS_COLIS.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))];
			l_COU_COULIS.ListeCLS_COLIS.Add(l_CLS_COLIS);
			l_CLS_COLIS.ListeCOU_COULIS.Add(l_COU_COULIS);
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
