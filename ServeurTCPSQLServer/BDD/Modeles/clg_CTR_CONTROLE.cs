using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_CTR_CONTROLE: clg_TableBase
{
	public const int ID_Table = 22;
	public static clg_CTL_CTR_CONTROLE c_CTL_CTR_CONTROLE;
	private DateTime c_CTR_D_DATE;
	private Int32 c_CTR_CN;
	private List<clg_CLS_COLIS> c_ListeCLS_COLIS = new List<clg_CLS_COLIS>();
	private List<clg_AGENT_ICEDA> c_ListeAGENT_ICEDA = new List<clg_AGENT_ICEDA>();
	private clg_VER_VERIFICATION_CONTROLE c_VER_CN;
	private clg_TYC_TYPE_CONTROLE c_TYC_CN;
	private string c_CTR_A_VALEUR;
	private string c_CTR_A_COMMENTAIRE;

	public clg_CTR_CONTROLE(Int64 pID, bool pIsClone=false) : base(c_CTL_CTR_CONTROLE)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeCTR_CONTROLE.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (DateTime pCTR_D_DATE, Int32 pCTR_CN, clg_VER_VERIFICATION_CONTROLE pVER_CN, clg_TYC_TYPE_CONTROLE pTYC_CN, string pCTR_A_VALEUR, string pCTR_A_COMMENTAIRE)
	{
		c_CTR_D_DATE = pCTR_D_DATE;
		c_CTR_CN = pCTR_CN;
		c_VER_CN = pVER_CN;
		c_VER_CN.ListeCTR_CONTROLE.Add(this);
		c_TYC_CN = pTYC_CN;
		c_TYC_CN.ListeCTR_CONTROLE.Add(this);
		c_CTR_A_VALEUR = pCTR_A_VALEUR;
		c_CTR_A_COMMENTAIRE = pCTR_A_COMMENTAIRE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_CTR_CONTROLE l_clone = new clg_CTR_CONTROLE(base.c_ID, true);
			l_clone.Initialise(c_CTR_D_DATE, c_CTR_CN, c_VER_CN, c_TYC_CN, c_CTR_A_VALEUR, c_CTR_A_COMMENTAIRE);
		}
	}

	public override void AnnuleModification()
	{
		clg_CTR_CONTROLE l_clone = (clg_CTR_CONTROLE) this.Clone;
		c_CTR_D_DATE = l_clone.CTR_D_DATE;
		c_CTR_CN = l_clone.CTR_CN;
		c_VER_CN = l_clone.VER_CN;
		c_TYC_CN = l_clone.TYC_CN;
		c_CTR_A_VALEUR = l_clone.CTR_A_VALEUR;
		c_CTR_A_COMMENTAIRE = l_clone.CTR_A_COMMENTAIRE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeCTR_CONTROLE.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeCTR_CONTROLE.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeCTR_CONTROLE.Dictionnaire.Remove(base.c_ID);
	}

	public DateTime CTR_D_DATE
	{
		get { return c_CTR_D_DATE; }
		set {
			c_CTR_D_DATE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public Int32 CTR_CN
	{
		get { return c_CTR_CN; }
		set {
			c_CTR_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_CLS_COLIS> ListeCLS_COLIS
	{
		get { return c_ListeCLS_COLIS; }
	}

	public List<clg_AGENT_ICEDA> ListeAGENT_ICEDA
	{
		get { return c_ListeAGENT_ICEDA; }
	}

	public clg_VER_VERIFICATION_CONTROLE VER_CN
	{
		get { return c_VER_CN; }
		set {
			c_VER_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public clg_TYC_TYPE_CONTROLE TYC_CN
	{
		get { return c_TYC_CN; }
		set {
			c_TYC_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string CTR_A_VALEUR
	{
		get { return c_CTR_A_VALEUR; }
		set {
			c_CTR_A_VALEUR = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string CTR_A_COMMENTAIRE
	{
		get { return c_CTR_A_COMMENTAIRE; }
		set {
			c_CTR_A_COMMENTAIRE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeCTR_CONTROLE
{
	Dictionary<Int64, clg_CTR_CONTROLE> c_DicCTR_CONTROLE;

	public clg_ListeCTR_CONTROLE()
	{
		c_DicCTR_CONTROLE = new Dictionary<Int64, clg_CTR_CONTROLE>();
	}

	public Dictionary<Int64, clg_CTR_CONTROLE> Dictionnaire
	{
		get { return c_DicCTR_CONTROLE; }
	}
}
