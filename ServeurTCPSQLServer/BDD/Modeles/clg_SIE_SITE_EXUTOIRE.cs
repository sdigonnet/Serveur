using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_SIE_SITE_EXUTOIRE: clg_TableBase
{
	public const int ID_Table = 4;
	public static clg_CTL_SIE_SITE_EXUTOIRE c_CTL_SIE_SITE_EXUTOIRE;
	private Int32 c_SIE_CN;
	private List<clg_CLS_COLIS> c_ListeCLS_COLIS = new List<clg_CLS_COLIS>();
	private string c_SIE_A_NOM;
	private string c_SIE_A_COMMENTAIRE;

	public clg_SIE_SITE_EXUTOIRE(Int64 pID, bool pIsClone=false) : base(c_CTL_SIE_SITE_EXUTOIRE)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeSIE_SITE_EXUTOIRE.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pSIE_CN, string pSIE_A_NOM, string pSIE_A_COMMENTAIRE)
	{
		c_SIE_CN = pSIE_CN;
		c_SIE_A_NOM = pSIE_A_NOM;
		c_SIE_A_COMMENTAIRE = pSIE_A_COMMENTAIRE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_SIE_SITE_EXUTOIRE l_clone = new clg_SIE_SITE_EXUTOIRE(base.c_ID, true);
			l_clone.Initialise(c_SIE_CN, c_SIE_A_NOM, c_SIE_A_COMMENTAIRE);
		}
	}

	public override void AnnuleModification()
	{
		clg_SIE_SITE_EXUTOIRE l_clone = (clg_SIE_SITE_EXUTOIRE) this.Clone;
		c_SIE_CN = l_clone.SIE_CN;
		c_SIE_A_NOM = l_clone.SIE_A_NOM;
		c_SIE_A_COMMENTAIRE = l_clone.SIE_A_COMMENTAIRE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeSIE_SITE_EXUTOIRE.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeSIE_SITE_EXUTOIRE.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeSIE_SITE_EXUTOIRE.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 SIE_CN
	{
		get { return c_SIE_CN; }
		set {
			c_SIE_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_CLS_COLIS> ListeCLS_COLIS
	{
		get { return c_ListeCLS_COLIS; }
	}

	public string SIE_A_NOM
	{
		get { return c_SIE_A_NOM; }
		set {
			c_SIE_A_NOM = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string SIE_A_COMMENTAIRE
	{
		get { return c_SIE_A_COMMENTAIRE; }
		set {
			c_SIE_A_COMMENTAIRE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeSIE_SITE_EXUTOIRE
{
	Dictionary<Int64, clg_SIE_SITE_EXUTOIRE> c_DicSIE_SITE_EXUTOIRE;

	public clg_ListeSIE_SITE_EXUTOIRE()
	{
		c_DicSIE_SITE_EXUTOIRE = new Dictionary<Int64, clg_SIE_SITE_EXUTOIRE>();
	}

	public Dictionary<Int64, clg_SIE_SITE_EXUTOIRE> Dictionnaire
	{
		get { return c_DicSIE_SITE_EXUTOIRE; }
	}
}
