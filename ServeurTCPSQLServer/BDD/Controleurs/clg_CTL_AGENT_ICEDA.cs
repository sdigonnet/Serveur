using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_AGENT_ICEDA: clg_ControleurBase
{
	public clg_CTL_AGENT_ICEDA()
	{
		clg_ChargementBase.Modele.ListeAGENT_ICEDA = new clg_ListeAGENT_ICEDA();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT AGN_CN, PRO_CN, AGN_A_NOM, AGN_A_LOGIN, AGN_A_COMMENTAIRE FROM AGENT_ICEDA";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_AGENT_ICEDA l_Objet;
			l_Objet = new clg_AGENT_ICEDA(clg_ChargementBase.Cnn.RetourneCompteurFormate("AGN_CN", clg_AGENT_ICEDA.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_ChargementBase.Modele.ListePROFIL.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_PROFIL.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))],
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString(),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 3)).ToString(),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 4)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_AGENT_ICEDA l_Objet = (clg_AGENT_ICEDA) pObjet;
		string l_ordreSQL = "UPDATE AGENT_ICEDA SET " +
		"AGN_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.AGN_CN) + "," +
		"PRO_CN=" + l_Objet.PRO_CN.PRO_CN+ "," +
		"AGN_A_NOM=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.AGN_A_NOM) + "," +
		"AGN_A_LOGIN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.AGN_A_LOGIN) + "," +
		"AGN_A_COMMENTAIRE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.AGN_A_COMMENTAIRE)  +
		" WHERE AGN_CN=" + l_Objet.AGN_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_AGENT_ICEDA l_Objet = (clg_AGENT_ICEDA) pObjet;
		string l_ordreSQL = "INSERT INTO AGENT_ICEDA(AGN_CN,PRO_CN,AGN_A_NOM,AGN_A_LOGIN,AGN_A_COMMENTAIRE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.AGN_CN) + "," +
		l_Objet.PRO_CN.PRO_CN + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.AGN_A_NOM) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.AGN_A_LOGIN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.AGN_A_COMMENTAIRE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_AGENT_ICEDA l_Objet = (clg_AGENT_ICEDA) pObjet;
		string l_ordreSQL = "DELETE FROM AGENT_ICEDA WHERE AGN_CN="  + l_Objet.AGN_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
