using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_FNC_FICHE_NON_CONFORMITE: clg_ControleurBase
{
	public clg_CTL_FNC_FICHE_NON_CONFORMITE()
	{
		clg_ChargementBase.Modele.ListeFNC_FICHE_NON_CONFORMITE = new clg_ListeFNC_FICHE_NON_CONFORMITE();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT FNC_D_DATE, DCT_CN, FNC_A_IDENTIFIANT FROM FNC_FICHE_NON_CONFORMITE";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_FNC_FICHE_NON_CONFORMITE l_Objet;
			l_Objet = new clg_FNC_FICHE_NON_CONFORMITE(clg_ChargementBase.Cnn.RetourneCompteurFormate("DCT_CN", clg_FNC_FICHE_NON_CONFORMITE.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString())));
			l_Objet.Initialise(
			DateTime.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_ChargementBase.Modele.ListeDCT_DOCUMENT.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_DCT_DOCUMENT.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))],
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_FNC_FICHE_NON_CONFORMITE l_Objet = (clg_FNC_FICHE_NON_CONFORMITE) pObjet;
		string l_ordreSQL = "UPDATE FNC_FICHE_NON_CONFORMITE SET " +
		"FNC_D_DATE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.FNC_D_DATE) + "," +
		"DCT_CN=" + l_Objet.DCT_CN.DCT_CN+ "," +
		"FNC_A_IDENTIFIANT=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.FNC_A_IDENTIFIANT)  +
		" WHERE DCT_CN=" + l_Objet.DCT_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_FNC_FICHE_NON_CONFORMITE l_Objet = (clg_FNC_FICHE_NON_CONFORMITE) pObjet;
		string l_ordreSQL = "INSERT INTO FNC_FICHE_NON_CONFORMITE(FNC_D_DATE,DCT_CN,FNC_A_IDENTIFIANT) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.FNC_D_DATE) + "," +
		l_Objet.DCT_CN.DCT_CN + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.FNC_A_IDENTIFIANT) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_FNC_FICHE_NON_CONFORMITE l_Objet = (clg_FNC_FICHE_NON_CONFORMITE) pObjet;
		string l_ordreSQL = "DELETE FROM FNC_FICHE_NON_CONFORMITE WHERE DCT_CN="  + l_Objet.DCT_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
