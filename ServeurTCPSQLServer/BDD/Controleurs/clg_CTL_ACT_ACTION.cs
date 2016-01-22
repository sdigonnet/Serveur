using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_ACT_ACTION: clg_ControleurBase
{
	public clg_CTL_ACT_ACTION()
	{
		clg_ChargementBase.Modele.ListeACT_ACTION = new clg_ListeACT_ACTION();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT ACT_CN, ACT_A_LIBELLE, ACT_A_COMMENTAIRE FROM ACT_ACTION";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_ACT_ACTION l_Objet;
			l_Objet = new clg_ACT_ACTION(clg_ChargementBase.Cnn.RetourneCompteurFormate("ACT_CN", clg_ACT_ACTION.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString(),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_ACT_ACTION l_Objet = (clg_ACT_ACTION) pObjet;
		string l_ordreSQL = "UPDATE ACT_ACTION SET " +
		"ACT_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.ACT_CN) + "," +
		"ACT_A_LIBELLE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.ACT_A_LIBELLE) + "," +
		"ACT_A_COMMENTAIRE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.ACT_A_COMMENTAIRE)  +
		" WHERE ACT_CN=" + l_Objet.ACT_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_ACT_ACTION l_Objet = (clg_ACT_ACTION) pObjet;
		string l_ordreSQL = "INSERT INTO ACT_ACTION(ACT_CN,ACT_A_LIBELLE,ACT_A_COMMENTAIRE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.ACT_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.ACT_A_LIBELLE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.ACT_A_COMMENTAIRE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_ACT_ACTION l_Objet = (clg_ACT_ACTION) pObjet;
		string l_ordreSQL = "DELETE FROM ACT_ACTION WHERE ACT_CN="  + l_Objet.ACT_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
