using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_SQA_SEQUENCE_ACTION: clg_ControleurBase
{
	public clg_CTL_SQA_SEQUENCE_ACTION()
	{
		clg_ChargementBase.Modele.ListeSQA_SEQUENCE_ACTION = new clg_ListeSQA_SEQUENCE_ACTION();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT SQA_CN, SQA_A_LIBELLE, SQA_A_COMMENTAIRE FROM SQA_SEQUENCE_ACTION";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_SQA_SEQUENCE_ACTION l_Objet;
			l_Objet = new clg_SQA_SEQUENCE_ACTION(clg_ChargementBase.Cnn.RetourneCompteurFormate("SQA_CN", clg_SQA_SEQUENCE_ACTION.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString(),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_SQA_SEQUENCE_ACTION l_Objet = (clg_SQA_SEQUENCE_ACTION) pObjet;
		string l_ordreSQL = "UPDATE SQA_SEQUENCE_ACTION SET " +
		"SQA_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.SQA_CN) + "," +
		"SQA_A_LIBELLE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.SQA_A_LIBELLE) + "," +
		"SQA_A_COMMENTAIRE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.SQA_A_COMMENTAIRE)  +
		" WHERE SQA_CN=" + l_Objet.SQA_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_SQA_SEQUENCE_ACTION l_Objet = (clg_SQA_SEQUENCE_ACTION) pObjet;
		string l_ordreSQL = "INSERT INTO SQA_SEQUENCE_ACTION(SQA_CN,SQA_A_LIBELLE,SQA_A_COMMENTAIRE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.SQA_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.SQA_A_LIBELLE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.SQA_A_COMMENTAIRE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_SQA_SEQUENCE_ACTION l_Objet = (clg_SQA_SEQUENCE_ACTION) pObjet;
		string l_ordreSQL = "DELETE FROM SQA_SEQUENCE_ACTION WHERE SQA_CN="  + l_Objet.SQA_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
