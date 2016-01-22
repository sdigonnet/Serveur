using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_PAR_CARACTERISTIQUE: clg_ControleurBase
{
	public clg_CTL_PAR_CARACTERISTIQUE()
	{
		clg_ChargementBase.Modele.ListePAR_CARACTERISTIQUE = new clg_ListePAR_CARACTERISTIQUE();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT CAR_B_OBLIGATOIRE, CAR_N_ORDRE, CAR_CN, TYV_CN, CAR_A_COMMENTAIRE FROM PAR_CARACTERISTIQUE";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_PAR_CARACTERISTIQUE l_Objet;
			l_Objet = new clg_PAR_CARACTERISTIQUE(clg_ChargementBase.Cnn.RetourneCompteurFormate("CAR_CN", clg_PAR_CARACTERISTIQUE.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString())));
			l_Objet.Initialise(
			Int16.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			Int16.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()),
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 2)).ToString()),
			clg_ChargementBase.Modele.ListeTYV_TYPE_VARIABLE.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_TYV_TYPE_VARIABLE.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 3)).ToString()))],
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 4)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_PAR_CARACTERISTIQUE l_Objet = (clg_PAR_CARACTERISTIQUE) pObjet;
		string l_ordreSQL = "UPDATE PAR_CARACTERISTIQUE SET " +
		"CAR_B_OBLIGATOIRE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.CAR_B_OBLIGATOIRE) + "," +
		"CAR_N_ORDRE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.CAR_N_ORDRE) + "," +
		"CAR_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.CAR_CN) + "," +
		"TYV_CN=" + l_Objet.TYV_CN.TYV_CN+ "," +
		"CAR_A_COMMENTAIRE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.CAR_A_COMMENTAIRE)  +
		" WHERE CAR_CN=" + l_Objet.CAR_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_PAR_CARACTERISTIQUE l_Objet = (clg_PAR_CARACTERISTIQUE) pObjet;
		string l_ordreSQL = "INSERT INTO PAR_CARACTERISTIQUE(CAR_B_OBLIGATOIRE,CAR_N_ORDRE,CAR_CN,TYV_CN,CAR_A_COMMENTAIRE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.CAR_B_OBLIGATOIRE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.CAR_N_ORDRE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.CAR_CN) + "," +
		l_Objet.TYV_CN.TYV_CN + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.CAR_A_COMMENTAIRE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_PAR_CARACTERISTIQUE l_Objet = (clg_PAR_CARACTERISTIQUE) pObjet;
		string l_ordreSQL = "DELETE FROM PAR_CARACTERISTIQUE WHERE CAR_CN="  + l_Objet.CAR_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
