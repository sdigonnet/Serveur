using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_DCT_DOCUMENT: clg_ControleurBase
{
	public clg_CTL_DCT_DOCUMENT()
	{
		clg_ChargementBase.Modele.ListeDCT_DOCUMENT = new clg_ListeDCT_DOCUMENT();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT DCT_D_DATE, DCT_CN, DCT_A_CHEMIN, DCT_A_TYPE FROM DCT_DOCUMENT";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_DCT_DOCUMENT l_Objet;
			l_Objet = new clg_DCT_DOCUMENT(clg_ChargementBase.Cnn.RetourneCompteurFormate("DCT_CN", clg_DCT_DOCUMENT.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString())));
			l_Objet.Initialise(
			DateTime.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString(),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 3)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_DCT_DOCUMENT l_Objet = (clg_DCT_DOCUMENT) pObjet;
		string l_ordreSQL = "UPDATE DCT_DOCUMENT SET " +
		"DCT_D_DATE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.DCT_D_DATE) + "," +
		"DCT_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.DCT_CN) + "," +
		"DCT_A_CHEMIN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.DCT_A_CHEMIN) + "," +
		"DCT_A_TYPE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.DCT_A_TYPE)  +
		" WHERE DCT_CN=" + l_Objet.DCT_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_DCT_DOCUMENT l_Objet = (clg_DCT_DOCUMENT) pObjet;
		string l_ordreSQL = "INSERT INTO DCT_DOCUMENT(DCT_D_DATE,DCT_CN,DCT_A_CHEMIN,DCT_A_TYPE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.DCT_D_DATE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.DCT_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.DCT_A_CHEMIN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.DCT_A_TYPE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_DCT_DOCUMENT l_Objet = (clg_DCT_DOCUMENT) pObjet;
		string l_ordreSQL = "DELETE FROM DCT_DOCUMENT WHERE DCT_CN="  + l_Objet.DCT_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
