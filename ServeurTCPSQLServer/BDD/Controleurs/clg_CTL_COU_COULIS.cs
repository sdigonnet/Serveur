using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_COU_COULIS: clg_ControleurBase
{
	public clg_CTL_COU_COULIS()
	{
		clg_ChargementBase.Modele.ListeCOU_COULIS = new clg_ListeCOU_COULIS();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT COU_CN, COU_A_LIBELLE, COU_A_COMMENTAIRE FROM COU_COULIS";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_COU_COULIS l_Objet;
			l_Objet = new clg_COU_COULIS(clg_ChargementBase.Cnn.RetourneCompteurFormate("COU_CN", clg_COU_COULIS.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString(),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_COU_COULIS l_Objet = (clg_COU_COULIS) pObjet;
		string l_ordreSQL = "UPDATE COU_COULIS SET " +
		"COU_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.COU_CN) + "," +
		"COU_A_LIBELLE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.COU_A_LIBELLE) + "," +
		"COU_A_COMMENTAIRE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.COU_A_COMMENTAIRE)  +
		" WHERE COU_CN=" + l_Objet.COU_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_COU_COULIS l_Objet = (clg_COU_COULIS) pObjet;
		string l_ordreSQL = "INSERT INTO COU_COULIS(COU_CN,COU_A_LIBELLE,COU_A_COMMENTAIRE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.COU_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.COU_A_LIBELLE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.COU_A_COMMENTAIRE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_COU_COULIS l_Objet = (clg_COU_COULIS) pObjet;
		string l_ordreSQL = "DELETE FROM COU_COULIS WHERE COU_CN="  + l_Objet.COU_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
