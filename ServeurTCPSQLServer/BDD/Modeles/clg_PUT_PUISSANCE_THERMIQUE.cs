using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_PUT_PUISSANCE_THERMIQUE: clg_TableBase
{
	public const int ID_Table = 2;
	public static clg_CTL_PUT_PUISSANCE_THERMIQUE c_CTL_PUT_PUISSANCE_THERMIQUE;
	private string c_PUT_N_VALEUR;
	private Int32 c_PUT_CN;
	private List<clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE> c_ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE = new List<clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE>();
	private clg_CLS_COLIS c_CLS_CN;

	public clg_PUT_PUISSANCE_THERMIQUE(Int64 pID, bool pIsClone=false) : base(c_CTL_PUT_PUISSANCE_THERMIQUE)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListePUT_PUISSANCE_THERMIQUE.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (string pPUT_N_VALEUR, Int32 pPUT_CN, clg_CLS_COLIS pCLS_CN)
	{
		c_PUT_N_VALEUR = pPUT_N_VALEUR;
		c_PUT_CN = pPUT_CN;
		c_CLS_CN = pCLS_CN;
		c_CLS_CN.ListePUT_PUISSANCE_THERMIQUE.Add(this);
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_PUT_PUISSANCE_THERMIQUE l_clone = new clg_PUT_PUISSANCE_THERMIQUE(base.c_ID, true);
			l_clone.Initialise(c_PUT_N_VALEUR, c_PUT_CN, c_CLS_CN);
		}
	}

	public override void AnnuleModification()
	{
		clg_PUT_PUISSANCE_THERMIQUE l_clone = (clg_PUT_PUISSANCE_THERMIQUE) this.Clone;
		c_PUT_N_VALEUR = l_clone.PUT_N_VALEUR;
		c_PUT_CN = l_clone.PUT_CN;
		c_CLS_CN = l_clone.CLS_CN;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListePUT_PUISSANCE_THERMIQUE.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListePUT_PUISSANCE_THERMIQUE.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListePUT_PUISSANCE_THERMIQUE.Dictionnaire.Remove(base.c_ID);
	}

	public string PUT_N_VALEUR
	{
		get { return c_PUT_N_VALEUR; }
		set {
			c_PUT_N_VALEUR = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public Int32 PUT_CN
	{
		get { return c_PUT_CN; }
		set {
			c_PUT_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_HIP_HISTORIQUE_PUISSANCETHERMIQUE> ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE
	{
		get { return c_ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE; }
	}

	public clg_CLS_COLIS CLS_CN
	{
		get { return c_CLS_CN; }
		set {
			c_CLS_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListePUT_PUISSANCE_THERMIQUE
{
	Dictionary<Int64, clg_PUT_PUISSANCE_THERMIQUE> c_DicPUT_PUISSANCE_THERMIQUE;

	public clg_ListePUT_PUISSANCE_THERMIQUE()
	{
		c_DicPUT_PUISSANCE_THERMIQUE = new Dictionary<Int64, clg_PUT_PUISSANCE_THERMIQUE>();
	}

	public Dictionary<Int64, clg_PUT_PUISSANCE_THERMIQUE> Dictionnaire
	{
		get { return c_DicPUT_PUISSANCE_THERMIQUE; }
	}
}
