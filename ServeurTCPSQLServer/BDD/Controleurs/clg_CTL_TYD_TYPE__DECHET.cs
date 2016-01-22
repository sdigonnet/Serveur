using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_TYD_TYPE__DECHET: clg_ControleurBase
{
	public clg_CTL_TYD_TYPE__DECHET()
	{
		clg_ChargementBase.Modele.ListeTYD_TYPE__DECHET = new clg_ListeTYD_TYPE__DECHET();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT TYD_CN, TYD_A_LIBELLE, TYD_A_COMMENTAIRE FROM TYD_TYPE__DECHET";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_TYD_TYPE__DECHET l_Objet;
			l_Objet = new clg_TYD_TYPE__DECHET(clg_ChargementBase.Cnn.RetourneCompteurFormate("TYD_CN", clg_TYD_TYPE__DECHET.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString(),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_TYD_TYPE__DECHET l_Objet = (clg_TYD_TYPE__DECHET) pObjet;
		string l_ordreSQL = "UPDATE TYD_TYPE__DECHET SET " +
		"TYD_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYD_CN) + "," +
		"TYD_A_LIBELLE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYD_A_LIBELLE) + "," +
		"TYD_A_COMMENTAIRE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYD_A_COMMENTAIRE)  +
		" WHERE TYD_CN=" + l_Objet.TYD_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_TYD_TYPE__DECHET l_Objet = (clg_TYD_TYPE__DECHET) pObjet;
		string l_ordreSQL = "INSERT INTO TYD_TYPE__DECHET(TYD_CN,TYD_A_LIBELLE,TYD_A_COMMENTAIRE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYD_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYD_A_LIBELLE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYD_A_COMMENTAIRE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_TYD_TYPE__DECHET l_Objet = (clg_TYD_TYPE__DECHET) pObjet;
		string l_ordreSQL = "DELETE FROM TYD_TYPE__DECHET WHERE TYD_CN="  + l_Objet.TYD_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
