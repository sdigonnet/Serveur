using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_LCL_LOCAL: clg_TableBase
{
	public const int ID_Table = 41;
	public static clg_CTL_LCL_LOCAL c_CTL_LCL_LOCAL;
	private Int32 c_LCL_CN;
	private List<clg_EMP_EMPLACEMENT> c_ListeEMP_EMPLACEMENT = new List<clg_EMP_EMPLACEMENT>();
	private List<clg_HIL_HISTORIQUE_LOCAL> c_ListeHIL_HISTORIQUE_LOCAL = new List<clg_HIL_HISTORIQUE_LOCAL>();
	private string c_LCL_A_LIBELLE;

	public clg_LCL_LOCAL(Int64 pID, bool pIsClone=false) : base(c_CTL_LCL_LOCAL)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeLCL_LOCAL.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pLCL_CN, string pLCL_A_LIBELLE)
	{
		c_LCL_CN = pLCL_CN;
		c_LCL_A_LIBELLE = pLCL_A_LIBELLE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_LCL_LOCAL l_clone = new clg_LCL_LOCAL(base.c_ID, true);
			l_clone.Initialise(c_LCL_CN, c_LCL_A_LIBELLE);
		}
	}

	public override void AnnuleModification()
	{
		clg_LCL_LOCAL l_clone = (clg_LCL_LOCAL) this.Clone;
		c_LCL_CN = l_clone.LCL_CN;
		c_LCL_A_LIBELLE = l_clone.LCL_A_LIBELLE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeLCL_LOCAL.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeLCL_LOCAL.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeLCL_LOCAL.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 LCL_CN
	{
		get { return c_LCL_CN; }
		set {
			c_LCL_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_EMP_EMPLACEMENT> ListeEMP_EMPLACEMENT
	{
		get { return c_ListeEMP_EMPLACEMENT; }
	}

	public List<clg_HIL_HISTORIQUE_LOCAL> ListeHIL_HISTORIQUE_LOCAL
	{
		get { return c_ListeHIL_HISTORIQUE_LOCAL; }
	}

	public string LCL_A_LIBELLE
	{
		get { return c_LCL_A_LIBELLE; }
		set {
			c_LCL_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeLCL_LOCAL
{
	Dictionary<Int64, clg_LCL_LOCAL> c_DicLCL_LOCAL;

	public clg_ListeLCL_LOCAL()
	{
		c_DicLCL_LOCAL = new Dictionary<Int64, clg_LCL_LOCAL>();
	}

	public Dictionary<Int64, clg_LCL_LOCAL> Dictionnaire
	{
		get { return c_DicLCL_LOCAL; }
	}
}
