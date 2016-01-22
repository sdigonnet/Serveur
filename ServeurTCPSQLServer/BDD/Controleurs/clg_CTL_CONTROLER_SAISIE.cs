using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_CONTROLER_SAISIE: clg_ControleurBase
{
	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT AGN_CN, VER_CN FROM CONTROLER_SAISIE";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_AGENT_ICEDA l_AGENT_ICEDA = clg_ChargementBase.Modele.ListeAGENT_ICEDA.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_AGENT_ICEDA.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()))];
			clg_VER_VERIFICATION_CONTROLE l_VER_VERIFICATION_CONTROLE = clg_ChargementBase.Modele.ListeVER_VERIFICATION_CONTROLE.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_VER_VERIFICATION_CONTROLE.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))];
			l_AGENT_ICEDA.ListeVER_VERIFICATION_CONTROLE.Add(l_VER_VERIFICATION_CONTROLE);
			l_VER_VERIFICATION_CONTROLE.ListeAGENT_ICEDA.Add(l_AGENT_ICEDA);
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
