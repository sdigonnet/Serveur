using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_TYC_TYPE_CONTROLE: clg_TableBase
{
	public const int ID_Table = 10;
	public static clg_CTL_TYC_TYPE_CONTROLE c_CTL_TYC_TYPE_CONTROLE;
	private Int32 c_TYC_CN;
	private List<clg_CTR_CONTROLE> c_ListeCTR_CONTROLE = new List<clg_CTR_CONTROLE>();
	private string c_TYC_A_LIBELLE;
	private string c_TYC_A_COMMENTAIRE;

	public clg_TYC_TYPE_CONTROLE(Int64 pID, bool pIsClone=false) : base(c_CTL_TYC_TYPE_CONTROLE)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeTYC_TYPE_CONTROLE.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pTYC_CN, string pTYC_A_LIBELLE, string pTYC_A_COMMENTAIRE)
	{
		c_TYC_CN = pTYC_CN;
		c_TYC_A_LIBELLE = pTYC_A_LIBELLE;
		c_TYC_A_COMMENTAIRE = pTYC_A_COMMENTAIRE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_TYC_TYPE_CONTROLE l_clone = new clg_TYC_TYPE_CONTROLE(base.c_ID, true);
			l_clone.Initialise(c_TYC_CN, c_TYC_A_LIBELLE, c_TYC_A_COMMENTAIRE);
		}
	}

	public override void AnnuleModification()
	{
		clg_TYC_TYPE_CONTROLE l_clone = (clg_TYC_TYPE_CONTROLE) this.Clone;
		c_TYC_CN = l_clone.TYC_CN;
		c_TYC_A_LIBELLE = l_clone.TYC_A_LIBELLE;
		c_TYC_A_COMMENTAIRE = l_clone.TYC_A_COMMENTAIRE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeTYC_TYPE_CONTROLE.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeTYC_TYPE_CONTROLE.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeTYC_TYPE_CONTROLE.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 TYC_CN
	{
		get { return c_TYC_CN; }
		set {
			c_TYC_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_CTR_CONTROLE> ListeCTR_CONTROLE
	{
		get { return c_ListeCTR_CONTROLE; }
	}

	public string TYC_A_LIBELLE
	{
		get { return c_TYC_A_LIBELLE; }
		set {
			c_TYC_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string TYC_A_COMMENTAIRE
	{
		get { return c_TYC_A_COMMENTAIRE; }
		set {
			c_TYC_A_COMMENTAIRE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeTYC_TYPE_CONTROLE
{
	Dictionary<Int64, clg_TYC_TYPE_CONTROLE> c_DicTYC_TYPE_CONTROLE;

	public clg_ListeTYC_TYPE_CONTROLE()
	{
		c_DicTYC_TYPE_CONTROLE = new Dictionary<Int64, clg_TYC_TYPE_CONTROLE>();
	}

	public Dictionary<Int64, clg_TYC_TYPE_CONTROLE> Dictionnaire
	{
		get { return c_DicTYC_TYPE_CONTROLE; }
	}
}
