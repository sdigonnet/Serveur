using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_INF_INFORMATION: clg_TableBase
{
	public const int ID_Table = 40;
	public static clg_CTL_INF_INFORMATION c_CTL_INF_INFORMATION;
	private Int32 c_INF_CN;
	private List<clg_GROUPER> c_ListeGROUPER = new List<clg_GROUPER>();
	private string c_INF_A_COMMENTAIRE;

	public clg_INF_INFORMATION(Int64 pID, bool pIsClone=false) : base(c_CTL_INF_INFORMATION)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeINF_INFORMATION.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pINF_CN, string pINF_A_COMMENTAIRE)
	{
		c_INF_CN = pINF_CN;
		c_INF_A_COMMENTAIRE = pINF_A_COMMENTAIRE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_INF_INFORMATION l_clone = new clg_INF_INFORMATION(base.c_ID, true);
			l_clone.Initialise(c_INF_CN, c_INF_A_COMMENTAIRE);
		}
	}

	public override void AnnuleModification()
	{
		clg_INF_INFORMATION l_clone = (clg_INF_INFORMATION) this.Clone;
		c_INF_CN = l_clone.INF_CN;
		c_INF_A_COMMENTAIRE = l_clone.INF_A_COMMENTAIRE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeINF_INFORMATION.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeINF_INFORMATION.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeINF_INFORMATION.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 INF_CN
	{
		get { return c_INF_CN; }
		set {
			c_INF_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_GROUPER> ListeGROUPER
	{
		get { return c_ListeGROUPER; }
	}

	public string INF_A_COMMENTAIRE
	{
		get { return c_INF_A_COMMENTAIRE; }
		set {
			c_INF_A_COMMENTAIRE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeINF_INFORMATION
{
	Dictionary<Int64, clg_INF_INFORMATION> c_DicINF_INFORMATION;

	public clg_ListeINF_INFORMATION()
	{
		c_DicINF_INFORMATION = new Dictionary<Int64, clg_INF_INFORMATION>();
	}

	public Dictionary<Int64, clg_INF_INFORMATION> Dictionnaire
	{
		get { return c_DicINF_INFORMATION; }
	}
}
