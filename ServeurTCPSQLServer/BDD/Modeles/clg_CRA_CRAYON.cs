using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_CRA_CRAYON: clg_TableBase
{
	public const int ID_Table = 20;
	public static clg_CTL_CRA_CRAYON c_CTL_CRA_CRAYON;
	private Int32 c_CRA_CN;
	private clg_ETU_ETUI c_ETU_CN;
	private clg_TN_TN c_CLS_CN;

	public clg_CRA_CRAYON(Int64 pID, bool pIsClone=false) : base(c_CTL_CRA_CRAYON)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeCRA_CRAYON.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pCRA_CN, clg_ETU_ETUI pETU_CN, clg_TN_TN pCLS_CN)
	{
		c_CRA_CN = pCRA_CN;
		c_ETU_CN = pETU_CN;
		c_ETU_CN.ListeCRA_CRAYON.Add(this);
		c_CLS_CN = pCLS_CN;
		c_CLS_CN.ListeCRA_CRAYON.Add(this);
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_CRA_CRAYON l_clone = new clg_CRA_CRAYON(base.c_ID, true);
			l_clone.Initialise(c_CRA_CN, c_ETU_CN, c_CLS_CN);
		}
	}

	public override void AnnuleModification()
	{
		clg_CRA_CRAYON l_clone = (clg_CRA_CRAYON) this.Clone;
		c_CRA_CN = l_clone.CRA_CN;
		c_ETU_CN = l_clone.ETU_CN;
		c_CLS_CN = l_clone.CLS_CN;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeCRA_CRAYON.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeCRA_CRAYON.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeCRA_CRAYON.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 CRA_CN
	{
		get { return c_CRA_CN; }
		set {
			c_CRA_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public clg_ETU_ETUI ETU_CN
	{
		get { return c_ETU_CN; }
		set {
			c_ETU_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public clg_TN_TN CLS_CN
	{
		get { return c_CLS_CN; }
		set {
			c_CLS_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeCRA_CRAYON
{
	Dictionary<Int64, clg_CRA_CRAYON> c_DicCRA_CRAYON;

	public clg_ListeCRA_CRAYON()
	{
		c_DicCRA_CRAYON = new Dictionary<Int64, clg_CRA_CRAYON>();
	}

	public Dictionary<Int64, clg_CRA_CRAYON> Dictionnaire
	{
		get { return c_DicCRA_CRAYON; }
	}
}
