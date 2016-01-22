using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_CTA_CONTROLE_ATTENDU: clg_ControleurBase
{
	public clg_CTL_CTA_CONTROLE_ATTENDU()
	{
		clg_ChargementBase.Modele.ListeCTA_CONTROLE_ATTENDU = new clg_ListeCTA_CONTROLE_ATTENDU();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT CTA_CN, CTA_TYP_CN FROM CTA_CONTROLE_ATTENDU";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_CTA_CONTROLE_ATTENDU l_Objet;
			l_Objet = new clg_CTA_CONTROLE_ATTENDU(clg_ChargementBase.Cnn.RetourneCompteurFormate("CTA_CN", clg_CTA_CONTROLE_ATTENDU.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()));
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_CTA_CONTROLE_ATTENDU l_Objet = (clg_CTA_CONTROLE_ATTENDU) pObjet;
		string l_ordreSQL = "UPDATE CTA_CONTROLE_ATTENDU SET " +
		"CTA_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.CTA_CN) + "," +
		"CTA_TYP_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.CTA_TYP_CN)  +
		" WHERE CTA_CN=" + l_Objet.CTA_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_CTA_CONTROLE_ATTENDU l_Objet = (clg_CTA_CONTROLE_ATTENDU) pObjet;
		string l_ordreSQL = "INSERT INTO CTA_CONTROLE_ATTENDU(CTA_CN,CTA_TYP_CN) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.CTA_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.CTA_TYP_CN) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_CTA_CONTROLE_ATTENDU l_Objet = (clg_CTA_CONTROLE_ATTENDU) pObjet;
		string l_ordreSQL = "DELETE FROM CTA_CONTROLE_ATTENDU WHERE CTA_CN="  + l_Objet.CTA_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
