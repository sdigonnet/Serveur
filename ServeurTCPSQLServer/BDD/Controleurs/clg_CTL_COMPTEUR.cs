using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_COMPTEUR: clg_ControleurBase
{
	public clg_CTL_COMPTEUR()
	{
		clg_ChargementBase.Modele.ListeCOMPTEUR = new clg_ListeCOMPTEUR();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT CPT_CN, CPT_N_VALEUR FROM COMPTEUR";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_COMPTEUR l_Objet;
			l_Objet = new clg_COMPTEUR(clg_ChargementBase.Cnn.RetourneCompteurFormate("CPT_CN", clg_COMPTEUR.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()));
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_COMPTEUR l_Objet = (clg_COMPTEUR) pObjet;
		string l_ordreSQL = "UPDATE COMPTEUR SET " +
		"CPT_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.CPT_CN) + "," +
		"CPT_N_VALEUR=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.CPT_N_VALEUR)  +
		" WHERE CPT_CN=" + l_Objet.CPT_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_COMPTEUR l_Objet = (clg_COMPTEUR) pObjet;
		string l_ordreSQL = "INSERT INTO COMPTEUR(CPT_CN,CPT_N_VALEUR) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.CPT_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.CPT_N_VALEUR) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_COMPTEUR l_Objet = (clg_COMPTEUR) pObjet;
		string l_ordreSQL = "DELETE FROM COMPTEUR WHERE CPT_CN="  + l_Objet.CPT_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
