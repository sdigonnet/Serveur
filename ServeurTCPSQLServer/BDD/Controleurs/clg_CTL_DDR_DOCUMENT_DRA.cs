using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_DDR_DOCUMENT_DRA: clg_ControleurBase
{
	public clg_CTL_DDR_DOCUMENT_DRA()
	{
		clg_ChargementBase.Modele.ListeDDR_DOCUMENT_DRA = new clg_ListeDDR_DOCUMENT_DRA();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT DCT_CN, DDR_A_LIBELLE FROM DDR_DOCUMENT_DRA";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_DDR_DOCUMENT_DRA l_Objet;
			l_Objet = new clg_DDR_DOCUMENT_DRA(clg_ChargementBase.Cnn.RetourneCompteurFormate("DCT_CN", clg_DDR_DOCUMENT_DRA.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			clg_ChargementBase.Modele.ListeDCT_DOCUMENT.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_DCT_DOCUMENT.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()))],
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_DDR_DOCUMENT_DRA l_Objet = (clg_DDR_DOCUMENT_DRA) pObjet;
		string l_ordreSQL = "UPDATE DDR_DOCUMENT_DRA SET " +
		"DCT_CN=" + l_Objet.DCT_CN.DCT_CN+ "," +
		"DDR_A_LIBELLE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.DDR_A_LIBELLE)  +
		" WHERE DCT_CN=" + l_Objet.DCT_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_DDR_DOCUMENT_DRA l_Objet = (clg_DDR_DOCUMENT_DRA) pObjet;
		string l_ordreSQL = "INSERT INTO DDR_DOCUMENT_DRA(DCT_CN,DDR_A_LIBELLE) VALUES (" +
		l_Objet.DCT_CN.DCT_CN + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.DDR_A_LIBELLE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_DDR_DOCUMENT_DRA l_Objet = (clg_DDR_DOCUMENT_DRA) pObjet;
		string l_ordreSQL = "DELETE FROM DDR_DOCUMENT_DRA WHERE DCT_CN="  + l_Objet.DCT_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
