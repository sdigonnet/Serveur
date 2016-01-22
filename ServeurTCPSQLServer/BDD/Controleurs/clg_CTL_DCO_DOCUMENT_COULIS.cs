using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_DCO_DOCUMENT_COULIS: clg_ControleurBase
{
	public clg_CTL_DCO_DOCUMENT_COULIS()
	{
		clg_ChargementBase.Modele.ListeDCO_DOCUMENT_COULIS = new clg_ListeDCO_DOCUMENT_COULIS();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT DCT_CN, DCO_A_LIBELLE FROM DCO_DOCUMENT_COULIS";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_DCO_DOCUMENT_COULIS l_Objet;
			l_Objet = new clg_DCO_DOCUMENT_COULIS(clg_ChargementBase.Cnn.RetourneCompteurFormate("DCT_CN", clg_DCO_DOCUMENT_COULIS.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			clg_ChargementBase.Modele.ListeDCT_DOCUMENT.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_DCT_DOCUMENT.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()))],
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_DCO_DOCUMENT_COULIS l_Objet = (clg_DCO_DOCUMENT_COULIS) pObjet;
		string l_ordreSQL = "UPDATE DCO_DOCUMENT_COULIS SET " +
		"DCT_CN=" + l_Objet.DCT_CN.DCT_CN+ "," +
		"DCO_A_LIBELLE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.DCO_A_LIBELLE)  +
		" WHERE DCT_CN=" + l_Objet.DCT_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_DCO_DOCUMENT_COULIS l_Objet = (clg_DCO_DOCUMENT_COULIS) pObjet;
		string l_ordreSQL = "INSERT INTO DCO_DOCUMENT_COULIS(DCT_CN,DCO_A_LIBELLE) VALUES (" +
		l_Objet.DCT_CN.DCT_CN + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.DCO_A_LIBELLE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_DCO_DOCUMENT_COULIS l_Objet = (clg_DCO_DOCUMENT_COULIS) pObjet;
		string l_ordreSQL = "DELETE FROM DCO_DOCUMENT_COULIS WHERE DCT_CN="  + l_Objet.DCT_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
