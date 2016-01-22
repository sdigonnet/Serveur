using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_CONTROLE: clg_ControleurBase
{
	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT CTA_CN, EMP_CN FROM CONTROLE";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_CTA_CONTROLE_ATTENDU l_CTA_CONTROLE_ATTENDU = clg_ChargementBase.Modele.ListeCTA_CONTROLE_ATTENDU.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_CTA_CONTROLE_ATTENDU.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()))];
			clg_EMP_EMPLACEMENT l_EMP_EMPLACEMENT = clg_ChargementBase.Modele.ListeEMP_EMPLACEMENT.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_EMP_EMPLACEMENT.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))];
			l_CTA_CONTROLE_ATTENDU.ListeEMP_EMPLACEMENT.Add(l_EMP_EMPLACEMENT);
			l_EMP_EMPLACEMENT.ListeCTA_CONTROLE_ATTENDU.Add(l_CTA_CONTROLE_ATTENDU);
		}
	}

	public override void Update(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
	}
	public override void Insert(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
	}

	public override void Delete(ref clg_ReflexionV3.clg_TableBase pObjet)
	{
	}
}
