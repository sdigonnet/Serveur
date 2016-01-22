using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_SPR_SITE_PRODUCTEUR: clg_TableBase
{
	public const int ID_Table = 6;
	public static clg_CTL_SPR_SITE_PRODUCTEUR c_CTL_SPR_SITE_PRODUCTEUR;
	private Int32 c_SPR_CN;
	private List<clg_CLS_COLIS> c_ListeCLS_COLIS = new List<clg_CLS_COLIS>();
	private string c_SPR_A_LIBELLE;
	private string c_SPR_A_COMMENAIRE;

	public clg_SPR_SITE_PRODUCTEUR(Int64 pID, bool pIsClone=false) : base(c_CTL_SPR_SITE_PRODUCTEUR)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeSPR_SITE_PRODUCTEUR.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pSPR_CN, string pSPR_A_LIBELLE, string pSPR_A_COMMENAIRE)
	{
		c_SPR_CN = pSPR_CN;
		c_SPR_A_LIBELLE = pSPR_A_LIBELLE;
		c_SPR_A_COMMENAIRE = pSPR_A_COMMENAIRE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_SPR_SITE_PRODUCTEUR l_clone = new clg_SPR_SITE_PRODUCTEUR(base.c_ID, true);
			l_clone.Initialise(c_SPR_CN, c_SPR_A_LIBELLE, c_SPR_A_COMMENAIRE);
		}
	}

	public override void AnnuleModification()
	{
		clg_SPR_SITE_PRODUCTEUR l_clone = (clg_SPR_SITE_PRODUCTEUR) this.Clone;
		c_SPR_CN = l_clone.SPR_CN;
		c_SPR_A_LIBELLE = l_clone.SPR_A_LIBELLE;
		c_SPR_A_COMMENAIRE = l_clone.SPR_A_COMMENAIRE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeSPR_SITE_PRODUCTEUR.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeSPR_SITE_PRODUCTEUR.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeSPR_SITE_PRODUCTEUR.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 SPR_CN
	{
		get { return c_SPR_CN; }
		set {
			c_SPR_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_CLS_COLIS> ListeCLS_COLIS
	{
		get { return c_ListeCLS_COLIS; }
	}

	public string SPR_A_LIBELLE
	{
		get { return c_SPR_A_LIBELLE; }
		set {
			c_SPR_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string SPR_A_COMMENAIRE
	{
		get { return c_SPR_A_COMMENAIRE; }
		set {
			c_SPR_A_COMMENAIRE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeSPR_SITE_PRODUCTEUR
{
	Dictionary<Int64, clg_SPR_SITE_PRODUCTEUR> c_DicSPR_SITE_PRODUCTEUR;

	public clg_ListeSPR_SITE_PRODUCTEUR()
	{
		c_DicSPR_SITE_PRODUCTEUR = new Dictionary<Int64, clg_SPR_SITE_PRODUCTEUR>();
	}

	public Dictionary<Int64, clg_SPR_SITE_PRODUCTEUR> Dictionnaire
	{
		get { return c_DicSPR_SITE_PRODUCTEUR; }
	}
}
