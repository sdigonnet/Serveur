using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_FNC_FICHE_NON_CONFORMITE: clg_TableBase
{
	public const int ID_Table = 33;
	public static clg_CTL_FNC_FICHE_NON_CONFORMITE c_CTL_FNC_FICHE_NON_CONFORMITE;
	private DateTime c_FNC_D_DATE;
	private clg_DCT_DOCUMENT c_DCT_CN;
	private string c_FNC_A_IDENTIFIANT;

	public clg_FNC_FICHE_NON_CONFORMITE(Int64 pID, bool pIsClone=false) : base(c_CTL_FNC_FICHE_NON_CONFORMITE)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeFNC_FICHE_NON_CONFORMITE.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (DateTime pFNC_D_DATE, clg_DCT_DOCUMENT pDCT_CN, string pFNC_A_IDENTIFIANT)
	{
		c_FNC_D_DATE = pFNC_D_DATE;
		c_DCT_CN = pDCT_CN;
		c_DCT_CN.ListeFNC_FICHE_NON_CONFORMITE.Add(this);
		c_FNC_A_IDENTIFIANT = pFNC_A_IDENTIFIANT;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_FNC_FICHE_NON_CONFORMITE l_clone = new clg_FNC_FICHE_NON_CONFORMITE(base.c_ID, true);
			l_clone.Initialise(c_FNC_D_DATE, c_DCT_CN, c_FNC_A_IDENTIFIANT);
		}
	}

	public override void AnnuleModification()
	{
		clg_FNC_FICHE_NON_CONFORMITE l_clone = (clg_FNC_FICHE_NON_CONFORMITE) this.Clone;
		c_FNC_D_DATE = l_clone.FNC_D_DATE;
		c_DCT_CN = l_clone.DCT_CN;
		c_FNC_A_IDENTIFIANT = l_clone.FNC_A_IDENTIFIANT;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeFNC_FICHE_NON_CONFORMITE.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeFNC_FICHE_NON_CONFORMITE.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeFNC_FICHE_NON_CONFORMITE.Dictionnaire.Remove(base.c_ID);
	}

	public DateTime FNC_D_DATE
	{
		get { return c_FNC_D_DATE; }
		set {
			c_FNC_D_DATE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public clg_DCT_DOCUMENT DCT_CN
	{
		get { return c_DCT_CN; }
		set {
			c_DCT_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string FNC_A_IDENTIFIANT
	{
		get { return c_FNC_A_IDENTIFIANT; }
		set {
			c_FNC_A_IDENTIFIANT = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeFNC_FICHE_NON_CONFORMITE
{
	Dictionary<Int64, clg_FNC_FICHE_NON_CONFORMITE> c_DicFNC_FICHE_NON_CONFORMITE;

	public clg_ListeFNC_FICHE_NON_CONFORMITE()
	{
		c_DicFNC_FICHE_NON_CONFORMITE = new Dictionary<Int64, clg_FNC_FICHE_NON_CONFORMITE>();
	}

	public Dictionary<Int64, clg_FNC_FICHE_NON_CONFORMITE> Dictionnaire
	{
		get { return c_DicFNC_FICHE_NON_CONFORMITE; }
	}
}
