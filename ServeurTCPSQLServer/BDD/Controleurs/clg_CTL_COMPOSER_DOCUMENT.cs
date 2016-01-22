using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_COMPOSER_DOCUMENT: clg_ControleurBase
{
	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT RAD_CN, DCT_CN FROM COMPOSER_DOCUMENT";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_RAD_RADIO_ELEMENT l_RAD_RADIO_ELEMENT = clg_ChargementBase.Modele.ListeRAD_RADIO_ELEMENT.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_RAD_RADIO_ELEMENT.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()))];
			clg_DSP_DOCUMENT_SPECTRO l_DSP_DOCUMENT_SPECTRO = clg_ChargementBase.Modele.ListeDSP_DOCUMENT_SPECTRO.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_DSP_DOCUMENT_SPECTRO.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))];
			l_RAD_RADIO_ELEMENT.ListeDSP_DOCUMENT_SPECTRO.Add(l_DSP_DOCUMENT_SPECTRO);
			l_DSP_DOCUMENT_SPECTRO.ListeRAD_RADIO_ELEMENT.Add(l_RAD_RADIO_ELEMENT);
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
