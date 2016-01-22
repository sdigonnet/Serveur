using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_PUT_PUISSANCE_THERMIQUE: clg_ControleurBase
{
	public clg_CTL_PUT_PUISSANCE_THERMIQUE()
	{
		clg_ChargementBase.Modele.ListePUT_PUISSANCE_THERMIQUE = new clg_ListePUT_PUISSANCE_THERMIQUE();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT PUT_N_VALEUR, PUT_CN, CLS_CN FROM PUT_PUISSANCE_THERMIQUE";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_PUT_PUISSANCE_THERMIQUE l_Objet;
			l_Objet = new clg_PUT_PUISSANCE_THERMIQUE(clg_ChargementBase.Cnn.RetourneCompteurFormate("PUT_CN", clg_PUT_PUISSANCE_THERMIQUE.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString())));
			l_Objet.Initialise(
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString(),
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()),
			clg_ChargementBase.Modele.ListeCLS_COLIS.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_CLS_COLIS.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString()))]);
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_PUT_PUISSANCE_THERMIQUE l_Objet = (clg_PUT_PUISSANCE_THERMIQUE) pObjet;
		string l_ordreSQL = "UPDATE PUT_PUISSANCE_THERMIQUE SET " +
		"PUT_N_VALEUR=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.PUT_N_VALEUR) + "," +
		"PUT_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.PUT_CN) + "," +
		"CLS_CN=" + l_Objet.CLS_CN.CLS_CN +
		" WHERE PUT_CN=" + l_Objet.PUT_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_PUT_PUISSANCE_THERMIQUE l_Objet = (clg_PUT_PUISSANCE_THERMIQUE) pObjet;
		string l_ordreSQL = "INSERT INTO PUT_PUISSANCE_THERMIQUE(PUT_N_VALEUR,PUT_CN,CLS_CN) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.PUT_N_VALEUR) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.PUT_CN) + "," +
		l_Objet.CLS_CN.CLS_CN + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_PUT_PUISSANCE_THERMIQUE l_Objet = (clg_PUT_PUISSANCE_THERMIQUE) pObjet;
		string l_ordreSQL = "DELETE FROM PUT_PUISSANCE_THERMIQUE WHERE PUT_CN="  + l_Objet.PUT_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
