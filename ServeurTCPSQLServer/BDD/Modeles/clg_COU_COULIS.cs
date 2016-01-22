using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_COU_COULIS: clg_TableBase
{
	public const int ID_Table = 19;
	public static clg_CTL_COU_COULIS c_CTL_COU_COULIS;
	private Int32 c_COU_CN;
	private List<clg_CLS_COLIS> c_ListeCLS_COLIS = new List<clg_CLS_COLIS>();
	private List<clg_PAN_PANIER> c_ListePAN_PANIER = new List<clg_PAN_PANIER>();
	private string c_COU_A_LIBELLE;
	private string c_COU_A_COMMENTAIRE;

	public clg_COU_COULIS(Int64 pID, bool pIsClone=false) : base(c_CTL_COU_COULIS)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeCOU_COULIS.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pCOU_CN, string pCOU_A_LIBELLE, string pCOU_A_COMMENTAIRE)
	{
		c_COU_CN = pCOU_CN;
		c_COU_A_LIBELLE = pCOU_A_LIBELLE;
		c_COU_A_COMMENTAIRE = pCOU_A_COMMENTAIRE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_COU_COULIS l_clone = new clg_COU_COULIS(base.c_ID, true);
			l_clone.Initialise(c_COU_CN, c_COU_A_LIBELLE, c_COU_A_COMMENTAIRE);
		}
	}

	public override void AnnuleModification()
	{
		clg_COU_COULIS l_clone = (clg_COU_COULIS) this.Clone;
		c_COU_CN = l_clone.COU_CN;
		c_COU_A_LIBELLE = l_clone.COU_A_LIBELLE;
		c_COU_A_COMMENTAIRE = l_clone.COU_A_COMMENTAIRE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeCOU_COULIS.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeCOU_COULIS.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeCOU_COULIS.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 COU_CN
	{
		get { return c_COU_CN; }
		set {
			c_COU_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_CLS_COLIS> ListeCLS_COLIS
	{
		get { return c_ListeCLS_COLIS; }
	}

	public List<clg_PAN_PANIER> ListePAN_PANIER
	{
		get { return c_ListePAN_PANIER; }
	}

	public string COU_A_LIBELLE
	{
		get { return c_COU_A_LIBELLE; }
		set {
			c_COU_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string COU_A_COMMENTAIRE
	{
		get { return c_COU_A_COMMENTAIRE; }
		set {
			c_COU_A_COMMENTAIRE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeCOU_COULIS
{
	Dictionary<Int64, clg_COU_COULIS> c_DicCOU_COULIS;

	public clg_ListeCOU_COULIS()
	{
		c_DicCOU_COULIS = new Dictionary<Int64, clg_COU_COULIS>();
	}

	public Dictionary<Int64, clg_COU_COULIS> Dictionnaire
	{
		get { return c_DicCOU_COULIS; }
	}
}
