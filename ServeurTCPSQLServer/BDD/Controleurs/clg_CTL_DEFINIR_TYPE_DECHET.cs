using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_DEFINIR_TYPE_DECHET: clg_ControleurBase
{
	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT TYD_CN, CLS_CN FROM DEFINIR_TYPE_DECHET";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_TYD_TYPE__DECHET l_TYD_TYPE__DECHET = clg_ChargementBase.Modele.ListeTYD_TYPE__DECHET.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_TYD_TYPE__DECHET.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()))];
			clg_CLS_COLIS l_CLS_COLIS = clg_ChargementBase.Modele.ListeCLS_COLIS.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_CLS_COLIS.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))];
			l_TYD_TYPE__DECHET.ListeCLS_COLIS.Add(l_CLS_COLIS);
			l_CLS_COLIS.ListeTYD_TYPE__DECHET.Add(l_TYD_TYPE__DECHET);
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
