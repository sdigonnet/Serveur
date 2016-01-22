using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_COMPOSITION_RADIOELEMENTS: clg_ControleurBase
{
	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT DCT_CN, CLS_CN FROM COMPOSITION_RADIOELEMENTS";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_DSP_DOCUMENT_SPECTRO l_DSP_DOCUMENT_SPECTRO = clg_ChargementBase.Modele.ListeDSP_DOCUMENT_SPECTRO.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_DSP_DOCUMENT_SPECTRO.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()))];
			clg_CLS_COLIS l_CLS_COLIS = clg_ChargementBase.Modele.ListeCLS_COLIS.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_CLS_COLIS.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))];
			l_DSP_DOCUMENT_SPECTRO.ListeCLS_COLIS.Add(l_CLS_COLIS);
			l_CLS_COLIS.ListeDSP_DOCUMENT_SPECTRO.Add(l_DSP_DOCUMENT_SPECTRO);
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
