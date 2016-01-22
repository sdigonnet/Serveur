using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_PROFIL: clg_ControleurBase
{
	public clg_CTL_PROFIL()
	{
		clg_ChargementBase.Modele.ListePROFIL = new clg_ListePROFIL();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT PRO_CN, PRO_A_LIBELLE, PRO_A_COMMENTAIRE FROM PROFIL";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_PROFIL l_Objet;
			l_Objet = new clg_PROFIL(clg_ChargementBase.Cnn.RetourneCompteurFormate("PRO_CN", clg_PROFIL.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString(),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_PROFIL l_Objet = (clg_PROFIL) pObjet;
		string l_ordreSQL = "UPDATE PROFIL SET " +
		"PRO_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.PRO_CN) + "," +
		"PRO_A_LIBELLE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.PRO_A_LIBELLE) + "," +
		"PRO_A_COMMENTAIRE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.PRO_A_COMMENTAIRE)  +
		" WHERE PRO_CN=" + l_Objet.PRO_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_PROFIL l_Objet = (clg_PROFIL) pObjet;
		string l_ordreSQL = "INSERT INTO PROFIL(PRO_CN,PRO_A_LIBELLE,PRO_A_COMMENTAIRE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.PRO_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.PRO_A_LIBELLE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.PRO_A_COMMENTAIRE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_PROFIL l_Objet = (clg_PROFIL) pObjet;
		string l_ordreSQL = "DELETE FROM PROFIL WHERE PRO_CN="  + l_Objet.PRO_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
