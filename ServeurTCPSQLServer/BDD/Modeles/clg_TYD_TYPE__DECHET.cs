using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_TYD_TYPE__DECHET: clg_TableBase
{
	public const int ID_Table = 11;
	public static clg_CTL_TYD_TYPE__DECHET c_CTL_TYD_TYPE__DECHET;
	private Int32 c_TYD_CN;
	private List<clg_CLS_COLIS> c_ListeCLS_COLIS = new List<clg_CLS_COLIS>();
	private string c_TYD_A_LIBELLE;
	private string c_TYD_A_COMMENTAIRE;

	public clg_TYD_TYPE__DECHET(Int64 pID, bool pIsClone=false) : base(c_CTL_TYD_TYPE__DECHET)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeTYD_TYPE__DECHET.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pTYD_CN, string pTYD_A_LIBELLE, string pTYD_A_COMMENTAIRE)
	{
		c_TYD_CN = pTYD_CN;
		c_TYD_A_LIBELLE = pTYD_A_LIBELLE;
		c_TYD_A_COMMENTAIRE = pTYD_A_COMMENTAIRE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_TYD_TYPE__DECHET l_clone = new clg_TYD_TYPE__DECHET(base.c_ID, true);
			l_clone.Initialise(c_TYD_CN, c_TYD_A_LIBELLE, c_TYD_A_COMMENTAIRE);
		}
	}

	public override void AnnuleModification()
	{
		clg_TYD_TYPE__DECHET l_clone = (clg_TYD_TYPE__DECHET) this.Clone;
		c_TYD_CN = l_clone.TYD_CN;
		c_TYD_A_LIBELLE = l_clone.TYD_A_LIBELLE;
		c_TYD_A_COMMENTAIRE = l_clone.TYD_A_COMMENTAIRE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeTYD_TYPE__DECHET.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeTYD_TYPE__DECHET.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeTYD_TYPE__DECHET.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 TYD_CN
	{
		get { return c_TYD_CN; }
		set {
			c_TYD_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_CLS_COLIS> ListeCLS_COLIS
	{
		get { return c_ListeCLS_COLIS; }
	}

	public string TYD_A_LIBELLE
	{
		get { return c_TYD_A_LIBELLE; }
		set {
			c_TYD_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string TYD_A_COMMENTAIRE
	{
		get { return c_TYD_A_COMMENTAIRE; }
		set {
			c_TYD_A_COMMENTAIRE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeTYD_TYPE__DECHET
{
	Dictionary<Int64, clg_TYD_TYPE__DECHET> c_DicTYD_TYPE__DECHET;

	public clg_ListeTYD_TYPE__DECHET()
	{
		c_DicTYD_TYPE__DECHET = new Dictionary<Int64, clg_TYD_TYPE__DECHET>();
	}

	public Dictionary<Int64, clg_TYD_TYPE__DECHET> Dictionnaire
	{
		get { return c_DicTYD_TYPE__DECHET; }
	}
}
