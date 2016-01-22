using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_EMP_EMPLACEMENT: clg_ControleurBase
{
	public clg_CTL_EMP_EMPLACEMENT()
	{
		clg_ChargementBase.Modele.ListeEMP_EMPLACEMENT = new clg_ListeEMP_EMPLACEMENT();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT EMP_N_POSX, EMP_N_POSY, EMP_B_HISTORISE, EMP_CN, LCL_CN FROM EMP_EMPLACEMENT";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_EMP_EMPLACEMENT l_Objet;
			l_Objet = new clg_EMP_EMPLACEMENT(clg_ChargementBase.Cnn.RetourneCompteurFormate("EMP_CN", clg_EMP_EMPLACEMENT.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 3)).ToString())));
			l_Objet.Initialise(
			Int16.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			Int16.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()),
			Int16.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString()),
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 3)).ToString()),
			clg_ChargementBase.Modele.ListeLCL_LOCAL.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_LCL_LOCAL.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 4)).ToString()))]);
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_EMP_EMPLACEMENT l_Objet = (clg_EMP_EMPLACEMENT) pObjet;
		string l_ordreSQL = "UPDATE EMP_EMPLACEMENT SET " +
		"EMP_N_POSX=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.EMP_N_POSX) + "," +
		"EMP_N_POSY=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.EMP_N_POSY) + "," +
		"EMP_B_HISTORISE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.EMP_B_HISTORISE) + "," +
		"EMP_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.EMP_CN) + "," +
		"LCL_CN=" + l_Objet.LCL_CN.LCL_CN +
		" WHERE EMP_CN=" + l_Objet.EMP_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_EMP_EMPLACEMENT l_Objet = (clg_EMP_EMPLACEMENT) pObjet;
		string l_ordreSQL = "INSERT INTO EMP_EMPLACEMENT(EMP_N_POSX,EMP_N_POSY,EMP_B_HISTORISE,EMP_CN,LCL_CN) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.EMP_N_POSX) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.EMP_N_POSY) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.EMP_B_HISTORISE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.EMP_CN) + "," +
		l_Objet.LCL_CN.LCL_CN + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_EMP_EMPLACEMENT l_Objet = (clg_EMP_EMPLACEMENT) pObjet;
		string l_ordreSQL = "DELETE FROM EMP_EMPLACEMENT WHERE EMP_CN="  + l_Objet.EMP_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
