using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_GROUPER_ACTION: clg_ControleurBase
{
	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT SQA_CN, ACT_CN FROM GROUPER_ACTION";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_SQA_SEQUENCE_ACTION l_SQA_SEQUENCE_ACTION = clg_ChargementBase.Modele.ListeSQA_SEQUENCE_ACTION.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_SQA_SEQUENCE_ACTION.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()))];
			clg_ACT_ACTION l_ACT_ACTION = clg_ChargementBase.Modele.ListeACT_ACTION.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_ACT_ACTION.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))];
			l_SQA_SEQUENCE_ACTION.ListeACT_ACTION.Add(l_ACT_ACTION);
			l_ACT_ACTION.ListeSQA_SEQUENCE_ACTION.Add(l_SQA_SEQUENCE_ACTION);
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
