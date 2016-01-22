using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_HIL_HISTORIQUE_LOCAL: clg_TableBase
{
	public const int ID_Table = 37;
	public static clg_CTL_HIL_HISTORIQUE_LOCAL c_CTL_HIL_HISTORIQUE_LOCAL;
	private DateTime c_HIL_D_DATE;
	private clg_LCL_LOCAL c_LCL_CN;
	private string c_HIL_A_VALEUR;

	public clg_HIL_HISTORIQUE_LOCAL(Int64 pID, bool pIsClone=false) : base(c_CTL_HIL_HISTORIQUE_LOCAL)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeHIL_HISTORIQUE_LOCAL.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (DateTime pHIL_D_DATE, clg_LCL_LOCAL pLCL_CN, string pHIL_A_VALEUR)
	{
		c_HIL_D_DATE = pHIL_D_DATE;
		c_LCL_CN = pLCL_CN;
		c_LCL_CN.ListeHIL_HISTORIQUE_LOCAL.Add(this);
		c_HIL_A_VALEUR = pHIL_A_VALEUR;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_HIL_HISTORIQUE_LOCAL l_clone = new clg_HIL_HISTORIQUE_LOCAL(base.c_ID, true);
			l_clone.Initialise(c_HIL_D_DATE, c_LCL_CN, c_HIL_A_VALEUR);
		}
	}

	public override void AnnuleModification()
	{
		clg_HIL_HISTORIQUE_LOCAL l_clone = (clg_HIL_HISTORIQUE_LOCAL) this.Clone;
		c_HIL_D_DATE = l_clone.HIL_D_DATE;
		c_LCL_CN = l_clone.LCL_CN;
		c_HIL_A_VALEUR = l_clone.HIL_A_VALEUR;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeHIL_HISTORIQUE_LOCAL.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeHIL_HISTORIQUE_LOCAL.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeHIL_HISTORIQUE_LOCAL.Dictionnaire.Remove(base.c_ID);
	}

	public DateTime HIL_D_DATE
	{
		get { return c_HIL_D_DATE; }
		set {
			c_HIL_D_DATE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public clg_LCL_LOCAL LCL_CN
	{
		get { return c_LCL_CN; }
		set {
			c_LCL_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string HIL_A_VALEUR
	{
		get { return c_HIL_A_VALEUR; }
		set {
			c_HIL_A_VALEUR = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeHIL_HISTORIQUE_LOCAL
{
	Dictionary<Int64, clg_HIL_HISTORIQUE_LOCAL> c_DicHIL_HISTORIQUE_LOCAL;

	public clg_ListeHIL_HISTORIQUE_LOCAL()
	{
		c_DicHIL_HISTORIQUE_LOCAL = new Dictionary<Int64, clg_HIL_HISTORIQUE_LOCAL>();
	}

	public Dictionary<Int64, clg_HIL_HISTORIQUE_LOCAL> Dictionnaire
	{
		get { return c_DicHIL_HISTORIQUE_LOCAL; }
	}
}
