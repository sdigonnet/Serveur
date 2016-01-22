using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_GROUPER: clg_ControleurBase
{
	public clg_CTL_GROUPER()
	{
		clg_ChargementBase.Modele.ListeGROUPER = new clg_ListeGROUPER();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT CAR_CN, INF_CN, GRP_CN FROM GROUPER";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_GROUPER l_Objet;
			l_Objet = new clg_GROUPER(clg_ChargementBase.Cnn.RetourneCompteurFormate("CAR_CN", clg_GROUPER.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			clg_ChargementBase.Modele.ListePAR_CARACTERISTIQUE.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_PAR_CARACTERISTIQUE.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()))],
			clg_ChargementBase.Modele.ListeINF_INFORMATION.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_INF_INFORMATION.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))],
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString()));
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_GROUPER l_Objet = (clg_GROUPER) pObjet;
		string l_ordreSQL = "UPDATE GROUPER SET " +
		"CAR_CN=" + l_Objet.CAR_CN.CAR_CN+ "," +
		"INF_CN=" + l_Objet.INF_CN.INF_CN+ "," +
		"GRP_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.GRP_CN)  +
		" WHERE CAR_CN=" + l_Objet.CAR_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_GROUPER l_Objet = (clg_GROUPER) pObjet;
		string l_ordreSQL = "INSERT INTO GROUPER(CAR_CN,INF_CN,GRP_CN) VALUES (" +
		l_Objet.CAR_CN.CAR_CN + "," +
		l_Objet.INF_CN.INF_CN + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.GRP_CN) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_GROUPER l_Objet = (clg_GROUPER) pObjet;
		string l_ordreSQL = "DELETE FROM GROUPER WHERE CAR_CN="  + l_Objet.CAR_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
