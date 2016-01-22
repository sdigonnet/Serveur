using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_TYV_TYPE_VARIABLE: clg_ControleurBase
{
	public clg_CTL_TYV_TYPE_VARIABLE()
	{
		clg_ChargementBase.Modele.ListeTYV_TYPE_VARIABLE = new clg_ListeTYV_TYPE_VARIABLE();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT TYV_CN, TYV_A_REGEX, TYV_A_TYPECDIEZE, TYV_A_COMMENTAIRE FROM TYV_TYPE_VARIABLE";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_TYV_TYPE_VARIABLE l_Objet;
			l_Objet = new clg_TYV_TYPE_VARIABLE(clg_ChargementBase.Cnn.RetourneCompteurFormate("TYV_CN", clg_TYV_TYPE_VARIABLE.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString(),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString(),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 3)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_TYV_TYPE_VARIABLE l_Objet = (clg_TYV_TYPE_VARIABLE) pObjet;
		string l_ordreSQL = "UPDATE TYV_TYPE_VARIABLE SET " +
		"TYV_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYV_CN) + "," +
		"TYV_A_REGEX=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYV_A_REGEX) + "," +
		"TYV_A_TYPECDIEZE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYV_A_TYPECDIEZE) + "," +
		"TYV_A_COMMENTAIRE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYV_A_COMMENTAIRE)  +
		" WHERE TYV_CN=" + l_Objet.TYV_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_TYV_TYPE_VARIABLE l_Objet = (clg_TYV_TYPE_VARIABLE) pObjet;
		string l_ordreSQL = "INSERT INTO TYV_TYPE_VARIABLE(TYV_CN,TYV_A_REGEX,TYV_A_TYPECDIEZE,TYV_A_COMMENTAIRE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYV_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYV_A_REGEX) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYV_A_TYPECDIEZE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYV_A_COMMENTAIRE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_TYV_TYPE_VARIABLE l_Objet = (clg_TYV_TYPE_VARIABLE) pObjet;
		string l_ordreSQL = "DELETE FROM TYV_TYPE_VARIABLE WHERE TYV_CN="  + l_Objet.TYV_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
