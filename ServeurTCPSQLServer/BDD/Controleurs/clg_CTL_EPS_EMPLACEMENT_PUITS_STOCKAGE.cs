using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_EPS_EMPLACEMENT_PUITS_STOCKAGE: clg_ControleurBase
{
	public clg_CTL_EPS_EMPLACEMENT_PUITS_STOCKAGE()
	{
		clg_ChargementBase.Modele.ListeEPS_EMPLACEMENT_PUITS_STOCKAGE = new clg_ListeEPS_EMPLACEMENT_PUITS_STOCKAGE();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT EPS_N_NUMERO, EMP_CN FROM EPS_EMPLACEMENT_PUITS_STOCKAGE";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_EPS_EMPLACEMENT_PUITS_STOCKAGE l_Objet;
			l_Objet = new clg_EPS_EMPLACEMENT_PUITS_STOCKAGE(clg_ChargementBase.Cnn.RetourneCompteurFormate("EMP_CN", clg_EPS_EMPLACEMENT_PUITS_STOCKAGE.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString())));
			l_Objet.Initialise(
			Int16.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_ChargementBase.Modele.ListeEMP_EMPLACEMENT.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_EMP_EMPLACEMENT.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))]);
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_EPS_EMPLACEMENT_PUITS_STOCKAGE l_Objet = (clg_EPS_EMPLACEMENT_PUITS_STOCKAGE) pObjet;
		string l_ordreSQL = "UPDATE EPS_EMPLACEMENT_PUITS_STOCKAGE SET " +
		"EPS_N_NUMERO=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.EPS_N_NUMERO) + "," +
		"EMP_CN=" + l_Objet.EMP_CN.EMP_CN +
		" WHERE EMP_CN=" + l_Objet.EMP_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_EPS_EMPLACEMENT_PUITS_STOCKAGE l_Objet = (clg_EPS_EMPLACEMENT_PUITS_STOCKAGE) pObjet;
		string l_ordreSQL = "INSERT INTO EPS_EMPLACEMENT_PUITS_STOCKAGE(EPS_N_NUMERO,EMP_CN) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.EPS_N_NUMERO) + "," +
		l_Objet.EMP_CN.EMP_CN + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_EPS_EMPLACEMENT_PUITS_STOCKAGE l_Objet = (clg_EPS_EMPLACEMENT_PUITS_STOCKAGE) pObjet;
		string l_ordreSQL = "DELETE FROM EPS_EMPLACEMENT_PUITS_STOCKAGE WHERE EMP_CN="  + l_Objet.EMP_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
