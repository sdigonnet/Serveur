using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_TYC_TYPE_CONTROLE: clg_ControleurBase
{
	public clg_CTL_TYC_TYPE_CONTROLE()
	{
		clg_ChargementBase.Modele.ListeTYC_TYPE_CONTROLE = new clg_ListeTYC_TYPE_CONTROLE();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT TYC_CN, TYC_A_LIBELLE, TYC_A_COMMENTAIRE FROM TYC_TYPE_CONTROLE";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_TYC_TYPE_CONTROLE l_Objet;
			l_Objet = new clg_TYC_TYPE_CONTROLE(clg_ChargementBase.Cnn.RetourneCompteurFormate("TYC_CN", clg_TYC_TYPE_CONTROLE.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString(),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_TYC_TYPE_CONTROLE l_Objet = (clg_TYC_TYPE_CONTROLE) pObjet;
		string l_ordreSQL = "UPDATE TYC_TYPE_CONTROLE SET " +
		"TYC_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYC_CN) + "," +
		"TYC_A_LIBELLE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYC_A_LIBELLE) + "," +
		"TYC_A_COMMENTAIRE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYC_A_COMMENTAIRE)  +
		" WHERE TYC_CN=" + l_Objet.TYC_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_TYC_TYPE_CONTROLE l_Objet = (clg_TYC_TYPE_CONTROLE) pObjet;
		string l_ordreSQL = "INSERT INTO TYC_TYPE_CONTROLE(TYC_CN,TYC_A_LIBELLE,TYC_A_COMMENTAIRE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYC_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYC_A_LIBELLE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.TYC_A_COMMENTAIRE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_TYC_TYPE_CONTROLE l_Objet = (clg_TYC_TYPE_CONTROLE) pObjet;
		string l_ordreSQL = "DELETE FROM TYC_TYPE_CONTROLE WHERE TYC_CN="  + l_Objet.TYC_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
