using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_INF_INFORMATION: clg_ControleurBase
{
	public clg_CTL_INF_INFORMATION()
	{
		clg_ChargementBase.Modele.ListeINF_INFORMATION = new clg_ListeINF_INFORMATION();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT INF_CN, INF_A_COMMENTAIRE FROM INF_INFORMATION";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_INF_INFORMATION l_Objet;
			l_Objet = new clg_INF_INFORMATION(clg_ChargementBase.Cnn.RetourneCompteurFormate("INF_CN", clg_INF_INFORMATION.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_INF_INFORMATION l_Objet = (clg_INF_INFORMATION) pObjet;
		string l_ordreSQL = "UPDATE INF_INFORMATION SET " +
		"INF_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.INF_CN) + "," +
		"INF_A_COMMENTAIRE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.INF_A_COMMENTAIRE)  +
		" WHERE INF_CN=" + l_Objet.INF_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_INF_INFORMATION l_Objet = (clg_INF_INFORMATION) pObjet;
		string l_ordreSQL = "INSERT INTO INF_INFORMATION(INF_CN,INF_A_COMMENTAIRE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.INF_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.INF_A_COMMENTAIRE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_INF_INFORMATION l_Objet = (clg_INF_INFORMATION) pObjet;
		string l_ordreSQL = "DELETE FROM INF_INFORMATION WHERE INF_CN="  + l_Objet.INF_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
