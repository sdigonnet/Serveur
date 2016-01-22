using System;
using CLG_AccesBD;
using clg_ReflexionV3;

public class clg_CTL_HISTORISER_PUISSANCETHERMIQUE: clg_ControleurBase
{
	public void Initialise()
	{
		clg_JeuEnregistrement l_rds;
		string l_MsgErr = "";
		string l_ordreSQL = "SELECT HIP_D_DATE, PUT_CN FROM HISTORISER_PUISSANCETHERMIQUE";
		l_rds = clg_Controleur.c_cnx.GetObjConnexion.ExecuteSELECT(l_ordreSQL, ref l_MsgErr);
		for (int i = 0; i <= l_rds.NombreLignes - 1; i++)
		{
			clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE l_HIP_HISTORIQUE_PUISSANCETHERMIQUE = clg_ChargementBase.Modele.ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 0)).ToString()))];
			clg_PUT_PUISSANCE_THERMIQUE l_PUT_PUISSANCE_THERMIQUE = clg_ChargementBase.Modele.ListePUT_PUISSANCE_THERMIQUE.Dictionnaire[clg_ChargementBase.Cnn.RetourneCompteurFormate("", clg_PUT_PUISSANCE_THERMIQUE.ID_Table,long.Parse(clg_Modele.ValeurDonnee(l_rds.get_Donnee(i, 1)).ToString()))];
			l_HIP_HISTORIQUE_PUISSANCETHERMIQUE.ListePUT_PUISSANCE_THERMIQUE.Add(l_PUT_PUISSANCE_THERMIQUE);
			l_PUT_PUISSANCE_THERMIQUE.ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE.Add(l_HIP_HISTORIQUE_PUISSANCETHERMIQUE);
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
