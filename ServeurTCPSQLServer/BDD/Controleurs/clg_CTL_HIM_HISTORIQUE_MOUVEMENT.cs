using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_HIM_HISTORIQUE_MOUVEMENT: clg_ControleurBase
{
	public clg_CTL_HIM_HISTORIQUE_MOUVEMENT()
	{
		clg_ChargementBase.Modele.ListeHIM_HISTORIQUE_MOUVEMENT = new clg_ListeHIM_HISTORIQUE_MOUVEMENT();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT HIM_B_ANNULE, HIM_D_DEBUT, HIM_D_FIN, EMP_CN, _NCHILD__EMP_CN FROM HIM_HISTORIQUE_MOUVEMENT";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_HIM_HISTORIQUE_MOUVEMENT l_Objet;
			l_Objet = new clg_HIM_HISTORIQUE_MOUVEMENT(clg_ChargementBase.Cnn.RetourneCompteurFormate("HIM_D_DEBUT", clg_HIM_HISTORIQUE_MOUVEMENT.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString())));
			l_Objet.Initialise(
			Int16.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			DateTime.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()),
			DateTime.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString()),
			clg_ChargementBase.Modele.ListeEMP_EMPLACEMENT.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_EMP_EMPLACEMENT.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 3)).ToString()))],
			clg_ChargementBase.Modele.ListeEMP_EMPLACEMENT.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_EMP_EMPLACEMENT.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 4)).ToString()))]);
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_HIM_HISTORIQUE_MOUVEMENT l_Objet = (clg_HIM_HISTORIQUE_MOUVEMENT) pObjet;
		string l_ordreSQL = "UPDATE HIM_HISTORIQUE_MOUVEMENT SET " +
		"HIM_B_ANNULE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIM_B_ANNULE) + "," +
		"HIM_D_DEBUT=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIM_D_DEBUT) + "," +
		"HIM_D_FIN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIM_D_FIN) + "," +
		"EMP_CN=" + l_Objet.EMP_CN.EMP_CN+ "," +
		"_NCHILD__EMP_CN=" + l_Objet._NCHILD__EMP_CN.EMP_CN +
		" WHERE HIM_D_DEBUT=" + l_Objet.HIM_D_DEBUT;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_HIM_HISTORIQUE_MOUVEMENT l_Objet = (clg_HIM_HISTORIQUE_MOUVEMENT) pObjet;
		string l_ordreSQL = "INSERT INTO HIM_HISTORIQUE_MOUVEMENT(HIM_B_ANNULE,HIM_D_DEBUT,HIM_D_FIN,EMP_CN,_NCHILD__EMP_CN) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIM_B_ANNULE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIM_D_DEBUT) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIM_D_FIN) + "," +
		l_Objet.EMP_CN.EMP_CN + "," +
		l_Objet._NCHILD__EMP_CN.EMP_CN + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_HIM_HISTORIQUE_MOUVEMENT l_Objet = (clg_HIM_HISTORIQUE_MOUVEMENT) pObjet;
		string l_ordreSQL = "DELETE FROM HIM_HISTORIQUE_MOUVEMENT WHERE HIM_D_DEBUT="  + l_Objet.HIM_D_DEBUT;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
