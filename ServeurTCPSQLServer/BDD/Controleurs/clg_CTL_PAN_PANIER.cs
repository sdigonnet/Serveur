using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_PAN_PANIER: clg_ControleurBase
{
	public clg_CTL_PAN_PANIER()
	{
		clg_ChargementBase.Modele.ListePAN_PANIER = new clg_ListePAN_PANIER();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT CLS_CN, PAN_A_LIBELLE FROM PAN_PANIER";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_PAN_PANIER l_Objet;
			l_Objet = new clg_PAN_PANIER(clg_ChargementBase.Cnn.RetourneCompteurFormate("CLS_CN", clg_PAN_PANIER.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			clg_ChargementBase.Modele.ListeCLS_COLIS.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_CLS_COLIS.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()))],
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_PAN_PANIER l_Objet = (clg_PAN_PANIER) pObjet;
		string l_ordreSQL = "UPDATE PAN_PANIER SET " +
		"CLS_CN=" + l_Objet.CLS_CN.CLS_CN+ "," +
		"PAN_A_LIBELLE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.PAN_A_LIBELLE)  +
		" WHERE CLS_CN=" + l_Objet.CLS_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_PAN_PANIER l_Objet = (clg_PAN_PANIER) pObjet;
		string l_ordreSQL = "INSERT INTO PAN_PANIER(CLS_CN,PAN_A_LIBELLE) VALUES (" +
		l_Objet.CLS_CN.CLS_CN + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.PAN_A_LIBELLE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_PAN_PANIER l_Objet = (clg_PAN_PANIER) pObjet;
		string l_ordreSQL = "DELETE FROM PAN_PANIER WHERE CLS_CN="  + l_Objet.CLS_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
