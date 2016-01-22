using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE: clg_TableBase
{
	public const int ID_Table = 39;
	public static clg_CTL_HIP_HISTORIQUE_PUISSANCETHERMIQUE c_CTL_HIP_HISTORIQUE_PUISSANCETHERMIQUE;
	private DateTime c_HIP_D_DATE;
	private List<clg_PUT_PUISSANCE_THERMIQUE> c_ListePUT_PUISSANCE_THERMIQUE = new List<clg_PUT_PUISSANCE_THERMIQUE>();
	private string c_HIP_A_LIBELLE;

	public clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE(Int64 pID, bool pIsClone=false) : base(c_CTL_HIP_HISTORIQUE_PUISSANCETHERMIQUE)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (DateTime pHIP_D_DATE, string pHIP_A_LIBELLE)
	{
		c_HIP_D_DATE = pHIP_D_DATE;
		c_HIP_A_LIBELLE = pHIP_A_LIBELLE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE l_clone = new clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE(base.c_ID, true);
			l_clone.Initialise(c_HIP_D_DATE, c_HIP_A_LIBELLE);
		}
	}

	public override void AnnuleModification()
	{
		clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE l_clone = (clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE) this.Clone;
		c_HIP_D_DATE = l_clone.HIP_D_DATE;
		c_HIP_A_LIBELLE = l_clone.HIP_A_LIBELLE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE.Dictionnaire.Remove(base.c_ID);
	}

	public DateTime HIP_D_DATE
	{
		get { return c_HIP_D_DATE; }
		set {
			c_HIP_D_DATE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_PUT_PUISSANCE_THERMIQUE> ListePUT_PUISSANCE_THERMIQUE
	{
		get { return c_ListePUT_PUISSANCE_THERMIQUE; }
	}

	public string HIP_A_LIBELLE
	{
		get { return c_HIP_A_LIBELLE; }
		set {
			c_HIP_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE
{
	Dictionary<Int64, clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE> c_DicHIP_HISTORIQUE_PUISSANCETHERMIQUE;

	public clg_ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE()
	{
		c_DicHIP_HISTORIQUE_PUISSANCETHERMIQUE = new Dictionary<Int64, clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE>();
	}

	public Dictionary<Int64, clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE> Dictionnaire
	{
		get { return c_DicHIP_HISTORIQUE_PUISSANCETHERMIQUE; }
	}
}
