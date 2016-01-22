using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_HIE_HISTORIQUE_EMPLACEMENT: clg_ControleurBase
{
	public clg_CTL_HIE_HISTORIQUE_EMPLACEMENT()
	{
		clg_ChargementBase.Modele.ListeHIE_HISTORIQUE_EMPLACEMENT = new clg_ListeHIE_HISTORIQUE_EMPLACEMENT();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT HIE_D_DATE, HIE_D_SUPPRESSION, EMP_CN FROM HIE_HISTORIQUE_EMPLACEMENT";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_HIE_HISTORIQUE_EMPLACEMENT l_Objet;
			l_Objet = new clg_HIE_HISTORIQUE_EMPLACEMENT(clg_ChargementBase.Cnn.RetourneCompteurFormate("HIE_D_DATE", clg_HIE_HISTORIQUE_EMPLACEMENT.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			DateTime.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			DateTime.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()),
			clg_ChargementBase.Modele.ListeEMP_EMPLACEMENT.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_EMP_EMPLACEMENT.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString()))]);
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_HIE_HISTORIQUE_EMPLACEMENT l_Objet = (clg_HIE_HISTORIQUE_EMPLACEMENT) pObjet;
		string l_ordreSQL = "UPDATE HIE_HISTORIQUE_EMPLACEMENT SET " +
		"HIE_D_DATE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIE_D_DATE) + "," +
		"HIE_D_SUPPRESSION=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIE_D_SUPPRESSION) + "," +
		"EMP_CN=" + l_Objet.EMP_CN.EMP_CN +
		" WHERE HIE_D_DATE=" + l_Objet.HIE_D_DATE;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_HIE_HISTORIQUE_EMPLACEMENT l_Objet = (clg_HIE_HISTORIQUE_EMPLACEMENT) pObjet;
		string l_ordreSQL = "INSERT INTO HIE_HISTORIQUE_EMPLACEMENT(HIE_D_DATE,HIE_D_SUPPRESSION,EMP_CN) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIE_D_DATE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIE_D_SUPPRESSION) + "," +
		l_Objet.EMP_CN.EMP_CN + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_HIE_HISTORIQUE_EMPLACEMENT l_Objet = (clg_HIE_HISTORIQUE_EMPLACEMENT) pObjet;
		string l_ordreSQL = "DELETE FROM HIE_HISTORIQUE_EMPLACEMENT WHERE HIE_D_DATE="  + l_Objet.HIE_D_DATE;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
