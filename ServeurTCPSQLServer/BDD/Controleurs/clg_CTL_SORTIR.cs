using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_SORTIR: clg_ControleurBase
{
	public clg_CTL_SORTIR()
	{
		clg_ChargementBase.Modele.ListeSORTIR = new clg_ListeSORTIR();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT EML_CN, CLS_CN, SRT_CN FROM SORTIR";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_SORTIR l_Objet;
			l_Objet = new clg_SORTIR(clg_ChargementBase.Cnn.RetourneCompteurFormate("EML_CN", clg_SORTIR.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			clg_ChargementBase.Modele.ListeEMI_EMBALLAGE_IP2.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_EMI_EMBALLAGE_IP2.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()))],
			clg_ChargementBase.Modele.ListeCLS_COLIS.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_CLS_COLIS.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))],
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString()));
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_SORTIR l_Objet = (clg_SORTIR) pObjet;
		string l_ordreSQL = "UPDATE SORTIR SET " +
		"EML_CN=" + l_Objet.EML_CN.EML_CN+ "," +
		"CLS_CN=" + l_Objet.CLS_CN.CLS_CN+ "," +
		"SRT_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.SRT_CN)  +
		" WHERE EML_CN=" + l_Objet.EML_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_SORTIR l_Objet = (clg_SORTIR) pObjet;
		string l_ordreSQL = "INSERT INTO SORTIR(EML_CN,CLS_CN,SRT_CN) VALUES (" +
		l_Objet.EML_CN.EML_CN + "," +
		l_Objet.CLS_CN.CLS_CN + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.SRT_CN) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_SORTIR l_Objet = (clg_SORTIR) pObjet;
		string l_ordreSQL = "DELETE FROM SORTIR WHERE EML_CN="  + l_Objet.EML_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
