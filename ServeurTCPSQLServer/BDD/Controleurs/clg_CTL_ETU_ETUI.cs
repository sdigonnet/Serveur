using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_ETU_ETUI: clg_ControleurBase
{
	public clg_CTL_ETU_ETUI()
	{
		clg_ChargementBase.Modele.ListeETU_ETUI = new clg_ListeETU_ETUI();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT ETU_CN, PUS_CN FROM ETU_ETUI";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_ETU_ETUI l_Objet;
			l_Objet = new clg_ETU_ETUI(clg_ChargementBase.Cnn.RetourneCompteurFormate("ETU_CN", clg_ETU_ETUI.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_ChargementBase.Modele.ListePUS_PUITS_STOCKAGE.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_PUS_PUITS_STOCKAGE.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))]);
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_ETU_ETUI l_Objet = (clg_ETU_ETUI) pObjet;
		string l_ordreSQL = "UPDATE ETU_ETUI SET " +
		"ETU_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.ETU_CN) + "," +
		"PUS_CN=" + l_Objet.PUS_CN.PUS_CN +
		" WHERE ETU_CN=" + l_Objet.ETU_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_ETU_ETUI l_Objet = (clg_ETU_ETUI) pObjet;
		string l_ordreSQL = "INSERT INTO ETU_ETUI(ETU_CN,PUS_CN) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.ETU_CN) + "," +
		l_Objet.PUS_CN.PUS_CN + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_ETU_ETUI l_Objet = (clg_ETU_ETUI) pObjet;
		string l_ordreSQL = "DELETE FROM ETU_ETUI WHERE ETU_CN="  + l_Objet.ETU_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
