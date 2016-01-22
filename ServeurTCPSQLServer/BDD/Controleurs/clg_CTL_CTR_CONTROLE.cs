using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_CTR_CONTROLE: clg_ControleurBase
{
	public clg_CTL_CTR_CONTROLE()
	{
		clg_ChargementBase.Modele.ListeCTR_CONTROLE = new clg_ListeCTR_CONTROLE();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT CTR_D_DATE, CTR_CN, VER_CN, TYC_CN, CTR_A_VALEUR, CTR_A_COMMENTAIRE FROM CTR_CONTROLE";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_CTR_CONTROLE l_Objet;
			l_Objet = new clg_CTR_CONTROLE(clg_ChargementBase.Cnn.RetourneCompteurFormate("CTR_CN", clg_CTR_CONTROLE.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString())));
			l_Objet.Initialise(
			DateTime.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()),
			clg_ChargementBase.Modele.ListeVER_VERIFICATION_CONTROLE.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_VER_VERIFICATION_CONTROLE.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString()))],
			clg_ChargementBase.Modele.ListeTYC_TYPE_CONTROLE.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_TYC_TYPE_CONTROLE.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 3)).ToString()))],
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 4)).ToString(),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 5)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_CTR_CONTROLE l_Objet = (clg_CTR_CONTROLE) pObjet;
		string l_ordreSQL = "UPDATE CTR_CONTROLE SET " +
		"CTR_D_DATE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.CTR_D_DATE) + "," +
		"CTR_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.CTR_CN) + "," +
		"VER_CN=" + l_Objet.VER_CN.VER_CN+ "," +
		"TYC_CN=" + l_Objet.TYC_CN.TYC_CN+ "," +
		"CTR_A_VALEUR=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.CTR_A_VALEUR) + "," +
		"CTR_A_COMMENTAIRE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.CTR_A_COMMENTAIRE)  +
		" WHERE CTR_CN=" + l_Objet.CTR_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_CTR_CONTROLE l_Objet = (clg_CTR_CONTROLE) pObjet;
		string l_ordreSQL = "INSERT INTO CTR_CONTROLE(CTR_D_DATE,CTR_CN,VER_CN,TYC_CN,CTR_A_VALEUR,CTR_A_COMMENTAIRE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.CTR_D_DATE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.CTR_CN) + "," +
		l_Objet.VER_CN.VER_CN + "," +
		l_Objet.TYC_CN.TYC_CN + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.CTR_A_VALEUR) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.CTR_A_COMMENTAIRE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_CTR_CONTROLE l_Objet = (clg_CTR_CONTROLE) pObjet;
		string l_ordreSQL = "DELETE FROM CTR_CONTROLE WHERE CTR_CN="  + l_Objet.CTR_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
