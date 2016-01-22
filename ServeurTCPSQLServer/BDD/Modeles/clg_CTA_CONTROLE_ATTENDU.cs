using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_CTA_CONTROLE_ATTENDU: clg_TableBase
{
	public const int ID_Table = 21;
	public static clg_CTL_CTA_CONTROLE_ATTENDU c_CTL_CTA_CONTROLE_ATTENDU;
	private Int32 c_CTA_CN;
	private List<clg_EMP_EMPLACEMENT> c_ListeEMP_EMPLACEMENT = new List<clg_EMP_EMPLACEMENT>();
	private Int32 c_CTA_TYP_CN;

	public clg_CTA_CONTROLE_ATTENDU(Int64 pID, bool pIsClone=false) : base(c_CTL_CTA_CONTROLE_ATTENDU)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeCTA_CONTROLE_ATTENDU.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pCTA_CN, Int32 pCTA_TYP_CN)
	{
		c_CTA_CN = pCTA_CN;
		c_CTA_TYP_CN = pCTA_TYP_CN;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_CTA_CONTROLE_ATTENDU l_clone = new clg_CTA_CONTROLE_ATTENDU(base.c_ID, true);
			l_clone.Initialise(c_CTA_CN, c_CTA_TYP_CN);
		}
	}

	public override void AnnuleModification()
	{
		clg_CTA_CONTROLE_ATTENDU l_clone = (clg_CTA_CONTROLE_ATTENDU) this.Clone;
		c_CTA_CN = l_clone.CTA_CN;
		c_CTA_TYP_CN = l_clone.CTA_TYP_CN;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeCTA_CONTROLE_ATTENDU.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeCTA_CONTROLE_ATTENDU.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeCTA_CONTROLE_ATTENDU.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 CTA_CN
	{
		get { return c_CTA_CN; }
		set {
			c_CTA_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_EMP_EMPLACEMENT> ListeEMP_EMPLACEMENT
	{
		get { return c_ListeEMP_EMPLACEMENT; }
	}

	public Int32 CTA_TYP_CN
	{
		get { return c_CTA_TYP_CN; }
		set {
			c_CTA_TYP_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeCTA_CONTROLE_ATTENDU
{
	Dictionary<Int64, clg_CTA_CONTROLE_ATTENDU> c_DicCTA_CONTROLE_ATTENDU;

	public clg_ListeCTA_CONTROLE_ATTENDU()
	{
		c_DicCTA_CONTROLE_ATTENDU = new Dictionary<Int64, clg_CTA_CONTROLE_ATTENDU>();
	}

	public Dictionary<Int64, clg_CTA_CONTROLE_ATTENDU> Dictionnaire
	{
		get { return c_DicCTA_CONTROLE_ATTENDU; }
	}
}
