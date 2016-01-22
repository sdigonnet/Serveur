using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_SPR_SITE_PRODUCTEUR: clg_ControleurBase
{
	public clg_CTL_SPR_SITE_PRODUCTEUR()
	{
		clg_ChargementBase.Modele.ListeSPR_SITE_PRODUCTEUR = new clg_ListeSPR_SITE_PRODUCTEUR();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT SPR_CN, SPR_A_LIBELLE, SPR_A_COMMENAIRE FROM SPR_SITE_PRODUCTEUR";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_SPR_SITE_PRODUCTEUR l_Objet;
			l_Objet = new clg_SPR_SITE_PRODUCTEUR(clg_ChargementBase.Cnn.RetourneCompteurFormate("SPR_CN", clg_SPR_SITE_PRODUCTEUR.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString(),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_SPR_SITE_PRODUCTEUR l_Objet = (clg_SPR_SITE_PRODUCTEUR) pObjet;
		string l_ordreSQL = "UPDATE SPR_SITE_PRODUCTEUR SET " +
		"SPR_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.SPR_CN) + "," +
		"SPR_A_LIBELLE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.SPR_A_LIBELLE) + "," +
		"SPR_A_COMMENAIRE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.SPR_A_COMMENAIRE)  +
		" WHERE SPR_CN=" + l_Objet.SPR_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_SPR_SITE_PRODUCTEUR l_Objet = (clg_SPR_SITE_PRODUCTEUR) pObjet;
		string l_ordreSQL = "INSERT INTO SPR_SITE_PRODUCTEUR(SPR_CN,SPR_A_LIBELLE,SPR_A_COMMENAIRE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.SPR_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.SPR_A_LIBELLE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.SPR_A_COMMENAIRE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_SPR_SITE_PRODUCTEUR l_Objet = (clg_SPR_SITE_PRODUCTEUR) pObjet;
		string l_ordreSQL = "DELETE FROM SPR_SITE_PRODUCTEUR WHERE SPR_CN="  + l_Objet.SPR_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
