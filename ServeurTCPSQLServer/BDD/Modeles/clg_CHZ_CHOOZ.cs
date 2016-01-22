using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_CHZ_CHOOZ: clg_TableBase
{
	public const int ID_Table = 17;
	public static clg_CTL_CHZ_CHOOZ c_CTL_CHZ_CHOOZ;
	private clg_CLS_COLIS c_CLS_CN;
	private string c_CHZ_A_LIBELLE;

	public clg_CHZ_CHOOZ(Int64 pID, bool pIsClone=false) : base(c_CTL_CHZ_CHOOZ)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeCHZ_CHOOZ.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (clg_CLS_COLIS pCLS_CN, string pCHZ_A_LIBELLE)
	{
		c_CLS_CN = pCLS_CN;
		c_CLS_CN.ListeCHZ_CHOOZ.Add(this);
		c_CHZ_A_LIBELLE = pCHZ_A_LIBELLE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_CHZ_CHOOZ l_clone = new clg_CHZ_CHOOZ(base.c_ID, true);
			l_clone.Initialise(c_CLS_CN, c_CHZ_A_LIBELLE);
		}
	}

	public override void AnnuleModification()
	{
		clg_CHZ_CHOOZ l_clone = (clg_CHZ_CHOOZ) this.Clone;
		c_CLS_CN = l_clone.CLS_CN;
		c_CHZ_A_LIBELLE = l_clone.CHZ_A_LIBELLE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeCHZ_CHOOZ.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeCHZ_CHOOZ.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeCHZ_CHOOZ.Dictionnaire.Remove(base.c_ID);
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

	public string CHZ_A_LIBELLE
	{
		get { return c_CHZ_A_LIBELLE; }
		set {
			c_CHZ_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeCHZ_CHOOZ
{
	Dictionary<Int64, clg_CHZ_CHOOZ> c_DicCHZ_CHOOZ;

	public clg_ListeCHZ_CHOOZ()
	{
		c_DicCHZ_CHOOZ = new Dictionary<Int64, clg_CHZ_CHOOZ>();
	}

	public Dictionary<Int64, clg_CHZ_CHOOZ> Dictionnaire
	{
		get { return c_DicCHZ_CHOOZ; }
	}
}
