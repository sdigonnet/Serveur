using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_HIP_HISTORIQUE_PUISSANCETHERMIQUE: clg_ControleurBase
{
	public clg_CTL_HIP_HISTORIQUE_PUISSANCETHERMIQUE()
	{
		clg_ChargementBase.Modele.ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE = new clg_ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT HIP_D_DATE, HIP_A_LIBELLE FROM HIP_HISTORIQUE_PUISSANCETHERMIQUE";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE l_Objet;
			l_Objet = new clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE(clg_ChargementBase.Cnn.RetourneCompteurFormate("HIP_D_DATE", clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			DateTime.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE l_Objet = (clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE) pObjet;
		string l_ordreSQL = "UPDATE HIP_HISTORIQUE_PUISSANCETHERMIQUE SET " +
		"HIP_D_DATE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIP_D_DATE) + "," +
		"HIP_A_LIBELLE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIP_A_LIBELLE)  +
		" WHERE HIP_D_DATE=" + l_Objet.HIP_D_DATE;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE l_Objet = (clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE) pObjet;
		string l_ordreSQL = "INSERT INTO HIP_HISTORIQUE_PUISSANCETHERMIQUE(HIP_D_DATE,HIP_A_LIBELLE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIP_D_DATE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.HIP_A_LIBELLE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE l_Objet = (clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE) pObjet;
		string l_ordreSQL = "DELETE FROM HIP_HISTORIQUE_PUISSANCETHERMIQUE WHERE HIP_D_DATE="  + l_Objet.HIP_D_DATE;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
