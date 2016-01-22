using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_TN_TN: clg_TableBase
{
	public const int ID_Table = 9;
	public static clg_CTL_TN_TN c_CTL_TN_TN;
	private clg_CLS_COLIS c_CLS_CN;
	private List<clg_CRA_CRAYON> c_ListeCRA_CRAYON = new List<clg_CRA_CRAYON>();
	private string c_TN_A_LIBELLE;

	public clg_TN_TN(Int64 pID, bool pIsClone=false) : base(c_CTL_TN_TN)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeTN_TN.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (clg_CLS_COLIS pCLS_CN, string pTN_A_LIBELLE)
	{
		c_CLS_CN = pCLS_CN;
		c_CLS_CN.ListeTN_TN.Add(this);
		c_TN_A_LIBELLE = pTN_A_LIBELLE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_TN_TN l_clone = new clg_TN_TN(base.c_ID, true);
			l_clone.Initialise(c_CLS_CN, c_TN_A_LIBELLE);
		}
	}

	public override void AnnuleModification()
	{
		clg_TN_TN l_clone = (clg_TN_TN) this.Clone;
		c_CLS_CN = l_clone.CLS_CN;
		c_TN_A_LIBELLE = l_clone.TN_A_LIBELLE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeTN_TN.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeTN_TN.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeTN_TN.Dictionnaire.Remove(base.c_ID);
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

	public List<clg_CRA_CRAYON> ListeCRA_CRAYON
	{
		get { return c_ListeCRA_CRAYON; }
	}

	public string TN_A_LIBELLE
	{
		get { return c_TN_A_LIBELLE; }
		set {
			c_TN_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeTN_TN
{
	Dictionary<Int64, clg_TN_TN> c_DicTN_TN;

	public clg_ListeTN_TN()
	{
		c_DicTN_TN = new Dictionary<Int64, clg_TN_TN>();
	}

	public Dictionary<Int64, clg_TN_TN> Dictionnaire
	{
		get { return c_DicTN_TN; }
	}
}
