using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_CRA_CRAYON: clg_ControleurBase
{
	public clg_CTL_CRA_CRAYON()
	{
		clg_ChargementBase.Modele.ListeCRA_CRAYON = new clg_ListeCRA_CRAYON();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT CRA_CN, ETU_CN, CLS_CN FROM CRA_CRAYON";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_CRA_CRAYON l_Objet;
			l_Objet = new clg_CRA_CRAYON(clg_ChargementBase.Cnn.RetourneCompteurFormate("CRA_CN", clg_CRA_CRAYON.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_ChargementBase.Modele.ListeETU_ETUI.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_ETU_ETUI.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))],
			clg_ChargementBase.Modele.ListeTN_TN.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_TN_TN.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString()))]);
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_CRA_CRAYON l_Objet = (clg_CRA_CRAYON) pObjet;
		string l_ordreSQL = "UPDATE CRA_CRAYON SET " +
		"CRA_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.CRA_CN) + "," +
		"ETU_CN=" + l_Objet.ETU_CN.ETU_CN+ "," +
		"CLS_CN=" + l_Objet.CLS_CN.CLS_CN +
		" WHERE CRA_CN=" + l_Objet.CRA_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_CRA_CRAYON l_Objet = (clg_CRA_CRAYON) pObjet;
		string l_ordreSQL = "INSERT INTO CRA_CRAYON(CRA_CN,ETU_CN,CLS_CN) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.CRA_CN) + "," +
		l_Objet.ETU_CN.ETU_CN + "," +
		l_Objet.CLS_CN.CLS_CN + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_CRA_CRAYON l_Objet = (clg_CRA_CRAYON) pObjet;
		string l_ordreSQL = "DELETE FROM CRA_CRAYON WHERE CRA_CN="  + l_Objet.CRA_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
