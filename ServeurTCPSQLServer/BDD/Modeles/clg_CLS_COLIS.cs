using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_CLS_COLIS: clg_TableBase
{
	public const int ID_Table = 18;
	public static clg_CTL_CLS_COLIS c_CTL_CLS_COLIS;
	private Int32 c_CLS_CN;
	private List<clg_COU_COULIS> c_ListeCOU_COULIS = new List<clg_COU_COULIS>();
	private List<clg_CHZ_CHOOZ> c_ListeCHZ_CHOOZ = new List<clg_CHZ_CHOOZ>();
	private List<clg_DSP_DOCUMENT_SPECTRO> c_ListeDSP_DOCUMENT_SPECTRO = new List<clg_DSP_DOCUMENT_SPECTRO>();
	private List<clg_CTR_CONTROLE> c_ListeCTR_CONTROLE = new List<clg_CTR_CONTROLE>();
	private List<clg_TYD_TYPE__DECHET> c_ListeTYD_TYPE__DECHET = new List<clg_TYD_TYPE__DECHET>();
	private List<clg_DEPLACER> c_ListeDEPLACER = new List<clg_DEPLACER>();
	private List<clg_MUT_MUTUALISATION> c_ListeMUT_MUTUALISATION = new List<clg_MUT_MUTUALISATION>();
	private List<clg_PAN_PANIER> c_ListePAN_PANIER = new List<clg_PAN_PANIER>();
	private List<clg_PUT_PUISSANCE_THERMIQUE> c_ListePUT_PUISSANCE_THERMIQUE = new List<clg_PUT_PUISSANCE_THERMIQUE>();
	private List<clg_SORTIR> c_ListeSORTIR = new List<clg_SORTIR>();
	private List<clg_SRE_SURREMBALLAGE> c_ListeSRE_SURREMBALLAGE = new List<clg_SRE_SURREMBALLAGE>();
	private List<clg_TN_TN> c_ListeTN_TN = new List<clg_TN_TN>();
	private clg_SPR_SITE_PRODUCTEUR c_SPR_CN;
	private clg_SIE_SITE_EXUTOIRE c_SIE_CN;
	private clg_EMT_EMBALLAGE_DE_TRANSPORT c_EMT_CN;
	private string c_CLS_A_COMMENTAIRE;

	public clg_CLS_COLIS(Int64 pID, bool pIsClone=false) : base(c_CTL_CLS_COLIS)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeCLS_COLIS.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pCLS_CN, clg_SPR_SITE_PRODUCTEUR pSPR_CN, clg_SIE_SITE_EXUTOIRE pSIE_CN, clg_EMT_EMBALLAGE_DE_TRANSPORT pEMT_CN, string pCLS_A_COMMENTAIRE)
	{
		c_CLS_CN = pCLS_CN;
		c_SPR_CN = pSPR_CN;
		c_SPR_CN.ListeCLS_COLIS.Add(this);
		c_SIE_CN = pSIE_CN;
		c_SIE_CN.ListeCLS_COLIS.Add(this);
		c_EMT_CN = pEMT_CN;
		c_EMT_CN.ListeCLS_COLIS.Add(this);
		c_CLS_A_COMMENTAIRE = pCLS_A_COMMENTAIRE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_CLS_COLIS l_clone = new clg_CLS_COLIS(base.c_ID, true);
			l_clone.Initialise(c_CLS_CN, c_SPR_CN, c_SIE_CN, c_EMT_CN, c_CLS_A_COMMENTAIRE);
		}
	}

	public override void AnnuleModification()
	{
		clg_CLS_COLIS l_clone = (clg_CLS_COLIS) this.Clone;
		c_CLS_CN = l_clone.CLS_CN;
		c_SPR_CN = l_clone.SPR_CN;
		c_SIE_CN = l_clone.SIE_CN;
		c_EMT_CN = l_clone.EMT_CN;
		c_CLS_A_COMMENTAIRE = l_clone.CLS_A_COMMENTAIRE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeCLS_COLIS.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeCLS_COLIS.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeCLS_COLIS.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 CLS_CN
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

	public List<clg_CHZ_CHOOZ> ListeCHZ_CHOOZ
	{
		get { return c_ListeCHZ_CHOOZ; }
	}

	public List<clg_DSP_DOCUMENT_SPECTRO> ListeDSP_DOCUMENT_SPECTRO
	{
		get { return c_ListeDSP_DOCUMENT_SPECTRO; }
	}

	public List<clg_CTR_CONTROLE> ListeCTR_CONTROLE
	{
		get { return c_ListeCTR_CONTROLE; }
	}

	public List<clg_TYD_TYPE__DECHET> ListeTYD_TYPE__DECHET
	{
		get { return c_ListeTYD_TYPE__DECHET; }
	}

	public List<clg_DEPLACER> ListeDEPLACER
	{
		get { return c_ListeDEPLACER; }
	}

	public List<clg_MUT_MUTUALISATION> ListeMUT_MUTUALISATION
	{
		get { return c_ListeMUT_MUTUALISATION; }
	}

	public List<clg_PAN_PANIER> ListePAN_PANIER
	{
		get { return c_ListePAN_PANIER; }
	}

	public List<clg_PUT_PUISSANCE_THERMIQUE> ListePUT_PUISSANCE_THERMIQUE
	{
		get { return c_ListePUT_PUISSANCE_THERMIQUE; }
	}

	public List<clg_SORTIR> ListeSORTIR
	{
		get { return c_ListeSORTIR; }
	}

	public List<clg_SRE_SURREMBALLAGE> ListeSRE_SURREMBALLAGE
	{
		get { return c_ListeSRE_SURREMBALLAGE; }
	}

	public List<clg_TN_TN> ListeTN_TN
	{
		get { return c_ListeTN_TN; }
	}

	public clg_SPR_SITE_PRODUCTEUR SPR_CN
	{
		get { return c_SPR_CN; }
		set {
			c_SPR_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public clg_SIE_SITE_EXUTOIRE SIE_CN
	{
		get { return c_SIE_CN; }
		set {
			c_SIE_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public clg_EMT_EMBALLAGE_DE_TRANSPORT EMT_CN
	{
		get { return c_EMT_CN; }
		set {
			c_EMT_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string CLS_A_COMMENTAIRE
	{
		get { return c_CLS_A_COMMENTAIRE; }
		set {
			c_CLS_A_COMMENTAIRE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeCLS_COLIS
{
	Dictionary<Int64, clg_CLS_COLIS> c_DicCLS_COLIS;

	public clg_ListeCLS_COLIS()
	{
		c_DicCLS_COLIS = new Dictionary<Int64, clg_CLS_COLIS>();
	}

	public Dictionary<Int64, clg_CLS_COLIS> Dictionnaire
	{
		get { return c_DicCLS_COLIS; }
	}
}
