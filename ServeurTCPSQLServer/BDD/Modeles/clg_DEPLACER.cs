using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_DEPLACER: clg_TableBase
{
	public const int ID_Table = 26;
	public static clg_CTL_DEPLACER c_CTL_DEPLACER;
	private clg_HIM_HISTORIQUE_MOUVEMENT c_HIM_D_DEBUT;
	private clg_CLS_COLIS c_CLS_CN;
	private Int32 c_DPL_CN;

	public clg_DEPLACER(Int64 pID, bool pIsClone=false) : base(c_CTL_DEPLACER)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeDEPLACER.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (clg_HIM_HISTORIQUE_MOUVEMENT pHIM_D_DEBUT, clg_CLS_COLIS pCLS_CN, Int32 pDPL_CN)
	{
		c_HIM_D_DEBUT = pHIM_D_DEBUT;
		c_HIM_D_DEBUT.ListeDEPLACER.Add(this);
		c_CLS_CN = pCLS_CN;
		c_CLS_CN.ListeDEPLACER.Add(this);
		c_DPL_CN = pDPL_CN;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_DEPLACER l_clone = new clg_DEPLACER(base.c_ID, true);
			l_clone.Initialise(c_HIM_D_DEBUT, c_CLS_CN, c_DPL_CN);
		}
	}

	public override void AnnuleModification()
	{
		clg_DEPLACER l_clone = (clg_DEPLACER) this.Clone;
		c_HIM_D_DEBUT = l_clone.HIM_D_DEBUT;
		c_CLS_CN = l_clone.CLS_CN;
		c_DPL_CN = l_clone.DPL_CN;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeDEPLACER.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeDEPLACER.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeDEPLACER.Dictionnaire.Remove(base.c_ID);
	}

	public clg_HIM_HISTORIQUE_MOUVEMENT HIM_D_DEBUT
	{
		get { return c_HIM_D_DEBUT; }
		set {
			c_HIM_D_DEBUT = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
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

	public Int32 DPL_CN
	{
		get { return c_DPL_CN; }
		set {
			c_DPL_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeDEPLACER
{
	Dictionary<Int64, clg_DEPLACER> c_DicDEPLACER;

	public clg_ListeDEPLACER()
	{
		c_DicDEPLACER = new Dictionary<Int64, clg_DEPLACER>();
	}

	public Dictionary<Int64, clg_DEPLACER> Dictionnaire
	{
		get { return c_DicDEPLACER; }
	}
}
