using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_ETU_ETUI: clg_TableBase
{
	public const int ID_Table = 32;
	public static clg_CTL_ETU_ETUI c_CTL_ETU_ETUI;
	private Int32 c_ETU_CN;
	private List<clg_CRA_CRAYON> c_ListeCRA_CRAYON = new List<clg_CRA_CRAYON>();
	private clg_PUS_PUITS_STOCKAGE c_PUS_CN;

	public clg_ETU_ETUI(Int64 pID, bool pIsClone=false) : base(c_CTL_ETU_ETUI)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeETU_ETUI.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pETU_CN, clg_PUS_PUITS_STOCKAGE pPUS_CN)
	{
		c_ETU_CN = pETU_CN;
		c_PUS_CN = pPUS_CN;
		c_PUS_CN.ListeETU_ETUI.Add(this);
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_ETU_ETUI l_clone = new clg_ETU_ETUI(base.c_ID, true);
			l_clone.Initialise(c_ETU_CN, c_PUS_CN);
		}
	}

	public override void AnnuleModification()
	{
		clg_ETU_ETUI l_clone = (clg_ETU_ETUI) this.Clone;
		c_ETU_CN = l_clone.ETU_CN;
		c_PUS_CN = l_clone.PUS_CN;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeETU_ETUI.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeETU_ETUI.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeETU_ETUI.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 ETU_CN
	{
		get { return c_ETU_CN; }
		set {
			c_ETU_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_CRA_CRAYON> ListeCRA_CRAYON
	{
		get { return c_ListeCRA_CRAYON; }
	}

	public clg_PUS_PUITS_STOCKAGE PUS_CN
	{
		get { return c_PUS_CN; }
		set {
			c_PUS_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeETU_ETUI
{
	Dictionary<Int64, clg_ETU_ETUI> c_DicETU_ETUI;

	public clg_ListeETU_ETUI()
	{
		c_DicETU_ETUI = new Dictionary<Int64, clg_ETU_ETUI>();
	}

	public Dictionary<Int64, clg_ETU_ETUI> Dictionnaire
	{
		get { return c_DicETU_ETUI; }
	}
}
