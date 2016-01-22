using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_GROUPER: clg_TableBase
{
	public const int ID_Table = 34;
	public static clg_CTL_GROUPER c_CTL_GROUPER;
	private clg_PAR_CARACTERISTIQUE c_CAR_CN;
	private clg_INF_INFORMATION c_INF_CN;
	private Int32 c_GRP_CN;

	public clg_GROUPER(Int64 pID, bool pIsClone=false) : base(c_CTL_GROUPER)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeGROUPER.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (clg_PAR_CARACTERISTIQUE pCAR_CN, clg_INF_INFORMATION pINF_CN, Int32 pGRP_CN)
	{
		c_CAR_CN = pCAR_CN;
		c_CAR_CN.ListeGROUPER.Add(this);
		c_INF_CN = pINF_CN;
		c_INF_CN.ListeGROUPER.Add(this);
		c_GRP_CN = pGRP_CN;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_GROUPER l_clone = new clg_GROUPER(base.c_ID, true);
			l_clone.Initialise(c_CAR_CN, c_INF_CN, c_GRP_CN);
		}
	}

	public override void AnnuleModification()
	{
		clg_GROUPER l_clone = (clg_GROUPER) this.Clone;
		c_CAR_CN = l_clone.CAR_CN;
		c_INF_CN = l_clone.INF_CN;
		c_GRP_CN = l_clone.GRP_CN;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeGROUPER.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeGROUPER.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeGROUPER.Dictionnaire.Remove(base.c_ID);
	}

	public clg_PAR_CARACTERISTIQUE CAR_CN
	{
		get { return c_CAR_CN; }
		set {
			c_CAR_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public clg_INF_INFORMATION INF_CN
	{
		get { return c_INF_CN; }
		set {
			c_INF_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public Int32 GRP_CN
	{
		get { return c_GRP_CN; }
		set {
			c_GRP_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeGROUPER
{
	Dictionary<Int64, clg_GROUPER> c_DicGROUPER;

	public clg_ListeGROUPER()
	{
		c_DicGROUPER = new Dictionary<Int64, clg_GROUPER>();
	}

	public Dictionary<Int64, clg_GROUPER> Dictionnaire
	{
		get { return c_DicGROUPER; }
	}
}
