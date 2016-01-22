using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_EMI_EMBALLAGE_IP2: clg_ControleurBase
{
	public clg_CTL_EMI_EMBALLAGE_IP2()
	{
		clg_ChargementBase.Modele.ListeEMI_EMBALLAGE_IP2 = new clg_ListeEMI_EMBALLAGE_IP2();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT EML_CN, EML_A_LIBELLE FROM EMI_EMBALLAGE_IP2";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_EMI_EMBALLAGE_IP2 l_Objet;
			l_Objet = new clg_EMI_EMBALLAGE_IP2(clg_ChargementBase.Cnn.RetourneCompteurFormate("EML_CN", clg_EMI_EMBALLAGE_IP2.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_EMI_EMBALLAGE_IP2 l_Objet = (clg_EMI_EMBALLAGE_IP2) pObjet;
		string l_ordreSQL = "UPDATE EMI_EMBALLAGE_IP2 SET " +
		"EML_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.EML_CN) + "," +
		"EML_A_LIBELLE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.EML_A_LIBELLE)  +
		" WHERE EML_CN=" + l_Objet.EML_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_EMI_EMBALLAGE_IP2 l_Objet = (clg_EMI_EMBALLAGE_IP2) pObjet;
		string l_ordreSQL = "INSERT INTO EMI_EMBALLAGE_IP2(EML_CN,EML_A_LIBELLE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.EML_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.EML_A_LIBELLE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_EMI_EMBALLAGE_IP2 l_Objet = (clg_EMI_EMBALLAGE_IP2) pObjet;
		string l_ordreSQL = "DELETE FROM EMI_EMBALLAGE_IP2 WHERE EML_CN="  + l_Objet.EML_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
