using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_DEPLACER: clg_ControleurBase
{
	public clg_CTL_DEPLACER()
	{
		clg_ChargementBase.Modele.ListeDEPLACER = new clg_ListeDEPLACER();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT HIM_D_DEBUT, CLS_CN, DPL_CN FROM DEPLACER";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_DEPLACER l_Objet;
			l_Objet = new clg_DEPLACER(clg_ChargementBase.Cnn.RetourneCompteurFormate("HIM_D_DEBUT", clg_DEPLACER.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			clg_ChargementBase.Modele.ListeHIM_HISTORIQUE_MOUVEMENT.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_HIM_HISTORIQUE_MOUVEMENT.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()))],
			clg_ChargementBase.Modele.ListeCLS_COLIS.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_CLS_COLIS.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))],
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString()));
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_DEPLACER l_Objet = (clg_DEPLACER) pObjet;
		string l_ordreSQL = "UPDATE DEPLACER SET " +
		"HIM_D_DEBUT=" + l_Objet.HIM_D_DEBUT.HIM_D_DEBUT+ "," +
		"CLS_CN=" + l_Objet.CLS_CN.CLS_CN+ "," +
		"DPL_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.DPL_CN)  +
		" WHERE HIM_D_DEBUT=" + l_Objet.HIM_D_DEBUT;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_DEPLACER l_Objet = (clg_DEPLACER) pObjet;
		string l_ordreSQL = "INSERT INTO DEPLACER(HIM_D_DEBUT,CLS_CN,DPL_CN) VALUES (" +
		l_Objet.HIM_D_DEBUT.HIM_D_DEBUT + "," +
		l_Objet.CLS_CN.CLS_CN + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.DPL_CN) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_DEPLACER l_Objet = (clg_DEPLACER) pObjet;
		string l_ordreSQL = "DELETE FROM DEPLACER WHERE HIM_D_DEBUT="  + l_Objet.HIM_D_DEBUT;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
