using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_LCL_LOCAL: clg_ControleurBase
{
	public clg_CTL_LCL_LOCAL()
	{
		clg_ChargementBase.Modele.ListeLCL_LOCAL = new clg_ListeLCL_LOCAL();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT LCL_CN, LCL_A_LIBELLE FROM LCL_LOCAL";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_LCL_LOCAL l_Objet;
			l_Objet = new clg_LCL_LOCAL(clg_ChargementBase.Cnn.RetourneCompteurFormate("LCL_CN", clg_LCL_LOCAL.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_LCL_LOCAL l_Objet = (clg_LCL_LOCAL) pObjet;
		string l_ordreSQL = "UPDATE LCL_LOCAL SET " +
		"LCL_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.LCL_CN) + "," +
		"LCL_A_LIBELLE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.LCL_A_LIBELLE)  +
		" WHERE LCL_CN=" + l_Objet.LCL_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_LCL_LOCAL l_Objet = (clg_LCL_LOCAL) pObjet;
		string l_ordreSQL = "INSERT INTO LCL_LOCAL(LCL_CN,LCL_A_LIBELLE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.LCL_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.LCL_A_LIBELLE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_LCL_LOCAL l_Objet = (clg_LCL_LOCAL) pObjet;
		string l_ordreSQL = "DELETE FROM LCL_LOCAL WHERE LCL_CN="  + l_Objet.LCL_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
