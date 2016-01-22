using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_VER_VERIFICATION_CONTROLE: clg_ControleurBase
{
	public clg_CTL_VER_VERIFICATION_CONTROLE()
	{
		clg_ChargementBase.Modele.ListeVER_VERIFICATION_CONTROLE = new clg_ListeVER_VERIFICATION_CONTROLE();
	}

	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT VER_B_ACCEPTE, VER_CN FROM VER_VERIFICATION_CONTROLE";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_VER_VERIFICATION_CONTROLE l_Objet;
			l_Objet = new clg_VER_VERIFICATION_CONTROLE(clg_ChargementBase.Cnn.RetourneCompteurFormate("VER_CN", clg_VER_VERIFICATION_CONTROLE.ID_Table, long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString())));
			l_Objet.Initialise(
			Int16.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()),
			Int32.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()));
			clg_Controleur.c_ColObjet.Add(l_Objet.ID, l_Objet);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_VER_VERIFICATION_CONTROLE l_Objet = (clg_VER_VERIFICATION_CONTROLE) pObjet;
		string l_ordreSQL = "UPDATE VER_VERIFICATION_CONTROLE SET " +
		"VER_B_ACCEPTE=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.VER_B_ACCEPTE) + "," +
		"VER_CN=" + clg_ConvertDonneesSQL.ValeurBase(l_Objet.VER_CN)  +
		" WHERE VER_CN=" + l_Objet.VER_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_VER_VERIFICATION_CONTROLE l_Objet = (clg_VER_VERIFICATION_CONTROLE) pObjet;
		string l_ordreSQL = "INSERT INTO VER_VERIFICATION_CONTROLE(VER_B_ACCEPTE,VER_CN) VALUES (" +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.VER_B_ACCEPTE) + "," +
		clg_ConvertDonneesSQL.ValeurBase(l_Objet.VER_CN) + ")";
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
		clg_VER_VERIFICATION_CONTROLE l_Objet = (clg_VER_VERIFICATION_CONTROLE) pObjet;
		string l_ordreSQL = "DELETE FROM VER_VERIFICATION_CONTROLE WHERE VER_CN="  + l_Objet.VER_CN;
		clg_Controleur.c_cnx.GetObjConnexion.ExecCmdSansSync(l_ordreSQL);
	}
}
