using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_EMT_EMBALLAGE_DE_TRANSPORT: clg_ControleurBase
{
	public clg_CTL_EMT_EMBALLAGE_DE_TRANSPORT()
	{
		clg_ChargementBase.Modele.ListeEMT_EMBALLAGE_DE_TRANSPORT = new clg_ListeEMT_EMBALLAGE_DE_TRANSPORT();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT EMT_CN, EMT_A_LIBELLE FROM EMT_EMBALLAGE_DE_TRANSPORT";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_EMT_EMBALLAGE_DE_TRANSPORT l_Objet;
			l_Objet = new clg_EMT_EMBALLAGE_DE_TRANSPORT(clg_ChargementBase.Cnn.RetourneCompteurFormate("EMT_CN", clg_EMT_EMBALLAGE_DE_TRANSPORT.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString())));
			l_Objet.Initialise(
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString());
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_EMT_EMBALLAGE_DE_TRANSPORT l_Objet = (clg_EMT_EMBALLAGE_DE_TRANSPORT) pObjet;
		string l_ordreSQL = "UPDATE EMT_EMBALLAGE_DE_TRANSPORT SET " +
		"EMT_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.EMT_CN) + "," +
		"EMT_A_LIBELLE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.EMT_A_LIBELLE)  +
		" WHERE EMT_CN=" + l_Objet.EMT_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_EMT_EMBALLAGE_DE_TRANSPORT l_Objet = (clg_EMT_EMBALLAGE_DE_TRANSPORT) pObjet;
		string l_ordreSQL = "INSERT INTO EMT_EMBALLAGE_DE_TRANSPORT(EMT_CN,EMT_A_LIBELLE) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.EMT_CN) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.EMT_A_LIBELLE) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_EMT_EMBALLAGE_DE_TRANSPORT l_Objet = (clg_EMT_EMBALLAGE_DE_TRANSPORT) pObjet;
		string l_ordreSQL = "DELETE FROM EMT_EMBALLAGE_DE_TRANSPORT WHERE EMT_CN="  + l_Objet.EMT_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
