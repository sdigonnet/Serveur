using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_RAD_RADIO_ELEMENT: clg_ControleurBase
{
	public clg_CTL_RAD_RADIO_ELEMENT()
	{
		clg_ChargementBase.Modele.ListeRAD_RADIO_ELEMENT = new clg_ListeRAD_RADIO_ELEMENT();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT RAD_CN, RAD_A_LIBELLE, RAD_A_FONCTIONDECROISSANCE FROM RAD_RADIO_ELEMENT";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_RAD_RADIO_ELEMENT l_Objet;
			l_Objet = new clg_RAD_RADIO_ELEMENT(clg_ChargementBase.Cnn.RetourneCompteurFormate("RAD_CN", clg_RAD_RADIO_ELEMENT.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString(),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_RAD_RADIO_ELEMENT l_Objet = (clg_RAD_RADIO_ELEMENT) pObjet;
		string l_ordreSQL = "UPDATE RAD_RADIO_ELEMENT SET " +
		"RAD_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.RAD_CN) + "," +
		"RAD_A_LIBELLE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.RAD_A_LIBELLE) + "," +
		"RAD_A_FONCTIONDECROISSANCE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.RAD_A_FONCTIONDECROISSANCE)  +
		" WHERE RAD_CN=" + l_Objet.RAD_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_RAD_RADIO_ELEMENT l_Objet = (clg_RAD_RADIO_ELEMENT) pObjet;
		string l_ordreSQL = "INSERT INTO RAD_RADIO_ELEMENT(RAD_CN,RAD_A_LIBELLE,RAD_A_FONCTIONDECROISSANCE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.RAD_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.RAD_A_LIBELLE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.RAD_A_FONCTIONDECROISSANCE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_RAD_RADIO_ELEMENT l_Objet = (clg_RAD_RADIO_ELEMENT) pObjet;
		string l_ordreSQL = "DELETE FROM RAD_RADIO_ELEMENT WHERE RAD_CN="  + l_Objet.RAD_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
