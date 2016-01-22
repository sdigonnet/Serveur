using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_HIL_HISTORIQUE_LOCAL: clg_ControleurBase
{
	public clg_CTL_HIL_HISTORIQUE_LOCAL()
	{
		clg_ChargementBase.Modele.ListeHIL_HISTORIQUE_LOCAL = new clg_ListeHIL_HISTORIQUE_LOCAL();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT HIL_D_DATE, LCL_CN, HIL_A_VALEUR FROM HIL_HISTORIQUE_LOCAL";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_HIL_HISTORIQUE_LOCAL l_Objet;
			l_Objet = new clg_HIL_HISTORIQUE_LOCAL(clg_ChargementBase.Cnn.RetourneCompteurFormate("HIL_D_DATE", clg_HIL_HISTORIQUE_LOCAL.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			DateTime.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_ChargementBase.Modele.ListeLCL_LOCAL.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_LCL_LOCAL.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))],
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_HIL_HISTORIQUE_LOCAL l_Objet = (clg_HIL_HISTORIQUE_LOCAL) pObjet;
		string l_ordreSQL = "UPDATE HIL_HISTORIQUE_LOCAL SET " +
		"HIL_D_DATE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIL_D_DATE) + "," +
		"LCL_CN=" + l_Objet.LCL_CN.LCL_CN+ "," +
		"HIL_A_VALEUR=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIL_A_VALEUR)  +
		" WHERE HIL_D_DATE=" + l_Objet.HIL_D_DATE;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_HIL_HISTORIQUE_LOCAL l_Objet = (clg_HIL_HISTORIQUE_LOCAL) pObjet;
		string l_ordreSQL = "INSERT INTO HIL_HISTORIQUE_LOCAL(HIL_D_DATE,LCL_CN,HIL_A_VALEUR) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIL_D_DATE) + "," +
		l_Objet.LCL_CN.LCL_CN + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIL_A_VALEUR) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_HIL_HISTORIQUE_LOCAL l_Objet = (clg_HIL_HISTORIQUE_LOCAL) pObjet;
		string l_ordreSQL = "DELETE FROM HIL_HISTORIQUE_LOCAL WHERE HIL_D_DATE="  + l_Objet.HIL_D_DATE;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
