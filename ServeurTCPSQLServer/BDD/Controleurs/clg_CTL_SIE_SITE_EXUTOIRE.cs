using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_SIE_SITE_EXUTOIRE: clg_ControleurBase
{
	public clg_CTL_SIE_SITE_EXUTOIRE()
	{
		clg_ChargementBase.Modele.ListeSIE_SITE_EXUTOIRE = new clg_ListeSIE_SITE_EXUTOIRE();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT SIE_CN, SIE_A_NOM, SIE_A_COMMENTAIRE FROM SIE_SITE_EXUTOIRE";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_SIE_SITE_EXUTOIRE l_Objet;
			l_Objet = new clg_SIE_SITE_EXUTOIRE(clg_ChargementBase.Cnn.RetourneCompteurFormate("SIE_CN", clg_SIE_SITE_EXUTOIRE.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString(),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_SIE_SITE_EXUTOIRE l_Objet = (clg_SIE_SITE_EXUTOIRE) pObjet;
		string l_ordreSQL = "UPDATE SIE_SITE_EXUTOIRE SET " +
		"SIE_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.SIE_CN) + "," +
		"SIE_A_NOM=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.SIE_A_NOM) + "," +
		"SIE_A_COMMENTAIRE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.SIE_A_COMMENTAIRE)  +
		" WHERE SIE_CN=" + l_Objet.SIE_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_SIE_SITE_EXUTOIRE l_Objet = (clg_SIE_SITE_EXUTOIRE) pObjet;
		string l_ordreSQL = "INSERT INTO SIE_SITE_EXUTOIRE(SIE_CN,SIE_A_NOM,SIE_A_COMMENTAIRE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.SIE_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.SIE_A_NOM) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.SIE_A_COMMENTAIRE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_SIE_SITE_EXUTOIRE l_Objet = (clg_SIE_SITE_EXUTOIRE) pObjet;
		string l_ordreSQL = "DELETE FROM SIE_SITE_EXUTOIRE WHERE SIE_CN="  + l_Objet.SIE_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
