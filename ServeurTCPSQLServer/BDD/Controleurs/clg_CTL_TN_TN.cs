using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_TN_TN: clg_ControleurBase
{
	public clg_CTL_TN_TN()
	{
		clg_ChargementBase.Modele.ListeTN_TN = new clg_ListeTN_TN();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT CLS_CN, TN_A_LIBELLE FROM TN_TN";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_TN_TN l_Objet;
			l_Objet = new clg_TN_TN(clg_ChargementBase.Cnn.RetourneCompteurFormate("CLS_CN", clg_TN_TN.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			clg_ChargementBase.Modele.ListeCLS_COLIS.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_CLS_COLIS.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()))],
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_TN_TN l_Objet = (clg_TN_TN) pObjet;
		string l_ordreSQL = "UPDATE TN_TN SET " +
		"CLS_CN=" + l_Objet.CLS_CN.CLS_CN+ "," +
		"TN_A_LIBELLE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.TN_A_LIBELLE)  +
		" WHERE CLS_CN=" + l_Objet.CLS_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_TN_TN l_Objet = (clg_TN_TN) pObjet;
		string l_ordreSQL = "INSERT INTO TN_TN(CLS_CN,TN_A_LIBELLE) VALUES (" +
		l_Objet.CLS_CN.CLS_CN + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.TN_A_LIBELLE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_TN_TN l_Objet = (clg_TN_TN) pObjet;
		string l_ordreSQL = "DELETE FROM TN_TN WHERE CLS_CN="  + l_Objet.CLS_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
