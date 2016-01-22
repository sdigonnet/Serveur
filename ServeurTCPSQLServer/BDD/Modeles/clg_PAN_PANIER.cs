using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_PAN_PANIER: clg_TableBase
{
	public const int ID_Table = 43;
	public static clg_CTL_PAN_PANIER c_CTL_PAN_PANIER;
	private clg_CLS_COLIS c_CLS_CN;
	private List<clg_COU_COULIS> c_ListeCOU_COULIS = new List<clg_COU_COULIS>();
	private string c_PAN_A_LIBELLE;

	public clg_PAN_PANIER(Int64 pID, bool pIsClone=false) : base(c_CTL_PAN_PANIER)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListePAN_PANIER.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (clg_CLS_COLIS pCLS_CN, string pPAN_A_LIBELLE)
	{
		c_CLS_CN = pCLS_CN;
		c_CLS_CN.ListePAN_PANIER.Add(this);
		c_PAN_A_LIBELLE = pPAN_A_LIBELLE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_PAN_PANIER l_clone = new clg_PAN_PANIER(base.c_ID, true);
			l_clone.Initialise(c_CLS_CN, c_PAN_A_LIBELLE);
		}
	}

	public override void AnnuleModification()
	{
		clg_PAN_PANIER l_clone = (clg_PAN_PANIER) this.Clone;
		c_CLS_CN = l_clone.CLS_CN;
		c_PAN_A_LIBELLE = l_clone.PAN_A_LIBELLE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListePAN_PANIER.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListePAN_PANIER.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListePAN_PANIER.Dictionnaire.Remove(base.c_ID);
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

	public List<clg_COU_COULIS> ListeCOU_COULIS
	{
		get { return c_ListeCOU_COULIS; }
	}

	public string PAN_A_LIBELLE
	{
		get { return c_PAN_A_LIBELLE; }
		set {
			c_PAN_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListePAN_PANIER
{
	Dictionary<Int64, clg_PAN_PANIER> c_DicPAN_PANIER;

	public clg_ListePAN_PANIER()
	{
		c_DicPAN_PANIER = new Dictionary<Int64, clg_PAN_PANIER>();
	}

	public Dictionary<Int64, clg_PAN_PANIER> Dictionnaire
	{
		get { return c_DicPAN_PANIER; }
	}
}
