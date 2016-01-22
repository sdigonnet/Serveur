using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_CLS_COLIS: clg_ControleurBase
{
	public clg_CTL_CLS_COLIS()
	{
		clg_ChargementBase.Modele.ListeCLS_COLIS = new clg_ListeCLS_COLIS();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT CLS_CN, SPR_CN, SIE_CN, EMT_CN, CLS_A_COMMENTAIRE FROM CLS_COLIS";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_CLS_COLIS l_Objet;
			l_Objet = new clg_CLS_COLIS(clg_ChargementBase.Cnn.RetourneCompteurFormate("CLS_CN", clg_CLS_COLIS.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_ChargementBase.Modele.ListeSPR_SITE_PRODUCTEUR.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_SPR_SITE_PRODUCTEUR.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))],
			clg_ChargementBase.Modele.ListeSIE_SITE_EXUTOIRE.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_SIE_SITE_EXUTOIRE.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString()))],
			clg_ChargementBase.Modele.ListeEMT_EMBALLAGE_DE_TRANSPORT.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_EMT_EMBALLAGE_DE_TRANSPORT.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 3)).ToString()))],
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 4)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_CLS_COLIS l_Objet = (clg_CLS_COLIS) pObjet;
		string l_ordreSQL = "UPDATE CLS_COLIS SET " +
		"CLS_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.CLS_CN) + "," +
		"SPR_CN=" + l_Objet.SPR_CN.SPR_CN+ "," +
		"SIE_CN=" + l_Objet.SIE_CN.SIE_CN+ "," +
		"EMT_CN=" + l_Objet.EMT_CN.EMT_CN+ "," +
		"CLS_A_COMMENTAIRE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.CLS_A_COMMENTAIRE)  +
		" WHERE CLS_CN=" + l_Objet.CLS_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_CLS_COLIS l_Objet = (clg_CLS_COLIS) pObjet;
		string l_ordreSQL = "INSERT INTO CLS_COLIS(CLS_CN,SPR_CN,SIE_CN,EMT_CN,CLS_A_COMMENTAIRE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.CLS_CN) + "," +
		l_Objet.SPR_CN.SPR_CN + "," +
		l_Objet.SIE_CN.SIE_CN + "," +
		l_Objet.EMT_CN.EMT_CN + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.CLS_A_COMMENTAIRE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_CLS_COLIS l_Objet = (clg_CLS_COLIS) pObjet;
		string l_ordreSQL = "DELETE FROM CLS_COLIS WHERE CLS_CN="  + l_Objet.CLS_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
