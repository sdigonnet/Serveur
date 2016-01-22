using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_HID_HISTORIQUE_DOCUMENT: clg_ControleurBase
{
	public clg_CTL_HID_HISTORIQUE_DOCUMENT()
	{
		clg_ChargementBase.Modele.ListeHID_HISTORIQUE_DOCUMENT = new clg_ListeHID_HISTORIQUE_DOCUMENT();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT HID_CN, DCT_CN FROM HID_HISTORIQUE_DOCUMENT";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_HID_HISTORIQUE_DOCUMENT l_Objet;
			l_Objet = new clg_HID_HISTORIQUE_DOCUMENT(clg_ChargementBase.Cnn.RetourneCompteurFormate("HID_CN", clg_HID_HISTORIQUE_DOCUMENT.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_ChargementBase.Modele.ListeDCT_DOCUMENT.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_DCT_DOCUMENT.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))]);
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_HID_HISTORIQUE_DOCUMENT l_Objet = (clg_HID_HISTORIQUE_DOCUMENT) pObjet;
		string l_ordreSQL = "UPDATE HID_HISTORIQUE_DOCUMENT SET " +
		"HID_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.HID_CN) + "," +
		"DCT_CN=" + l_Objet.DCT_CN.DCT_CN +
		" WHERE HID_CN=" + l_Objet.HID_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_HID_HISTORIQUE_DOCUMENT l_Objet = (clg_HID_HISTORIQUE_DOCUMENT) pObjet;
		string l_ordreSQL = "INSERT INTO HID_HISTORIQUE_DOCUMENT(HID_CN,DCT_CN) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.HID_CN) + "," +
		l_Objet.DCT_CN.DCT_CN + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_HID_HISTORIQUE_DOCUMENT l_Objet = (clg_HID_HISTORIQUE_DOCUMENT) pObjet;
		string l_ordreSQL = "DELETE FROM HID_HISTORIQUE_DOCUMENT WHERE HID_CN="  + l_Objet.HID_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
