using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_PUS_PUITS_STOCKAGE: clg_ControleurBase
{
	public clg_CTL_PUS_PUITS_STOCKAGE()
	{
		clg_ChargementBase.Modele.ListePUS_PUITS_STOCKAGE = new clg_ListePUS_PUITS_STOCKAGE();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT PUS_CN, PUS_A_COMMENTAIRE, PUS_A_LIBELLE FROM PUS_PUITS_STOCKAGE";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_PUS_PUITS_STOCKAGE l_Objet;
			l_Objet = new clg_PUS_PUITS_STOCKAGE(clg_ChargementBase.Cnn.RetourneCompteurFormate("PUS_CN", clg_PUS_PUITS_STOCKAGE.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString(),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_PUS_PUITS_STOCKAGE l_Objet = (clg_PUS_PUITS_STOCKAGE) pObjet;
		string l_ordreSQL = "UPDATE PUS_PUITS_STOCKAGE SET " +
		"PUS_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.PUS_CN) + "," +
		"PUS_A_COMMENTAIRE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.PUS_A_COMMENTAIRE) + "," +
		"PUS_A_LIBELLE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.PUS_A_LIBELLE)  +
		" WHERE PUS_CN=" + l_Objet.PUS_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_PUS_PUITS_STOCKAGE l_Objet = (clg_PUS_PUITS_STOCKAGE) pObjet;
		string l_ordreSQL = "INSERT INTO PUS_PUITS_STOCKAGE(PUS_CN,PUS_A_COMMENTAIRE,PUS_A_LIBELLE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.PUS_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.PUS_A_COMMENTAIRE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.PUS_A_LIBELLE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_PUS_PUITS_STOCKAGE l_Objet = (clg_PUS_PUITS_STOCKAGE) pObjet;
		string l_ordreSQL = "DELETE FROM PUS_PUITS_STOCKAGE WHERE PUS_CN="  + l_Objet.PUS_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
