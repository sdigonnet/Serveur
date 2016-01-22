using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_MUT_MUTUALISATION: clg_TableBase
{
	public const int ID_Table = 42;
	public static clg_CTL_MUT_MUTUALISATION c_CTL_MUT_MUTUALISATION;
	private clg_CLS_COLIS c_CLS_CN;
	private string c_MUT_A_LIBELLE;

	public clg_MUT_MUTUALISATION(Int64 pID, bool pIsClone=false) : base(c_CTL_MUT_MUTUALISATION)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeMUT_MUTUALISATION.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (clg_CLS_COLIS pCLS_CN, string pMUT_A_LIBELLE)
	{
		c_CLS_CN = pCLS_CN;
		c_CLS_CN.ListeMUT_MUTUALISATION.Add(this);
		c_MUT_A_LIBELLE = pMUT_A_LIBELLE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_MUT_MUTUALISATION l_clone = new clg_MUT_MUTUALISATION(base.c_ID, true);
			l_clone.Initialise(c_CLS_CN, c_MUT_A_LIBELLE);
		}
	}

	public override void AnnuleModification()
	{
		clg_MUT_MUTUALISATION l_clone = (clg_MUT_MUTUALISATION) this.Clone;
		c_CLS_CN = l_clone.CLS_CN;
		c_MUT_A_LIBELLE = l_clone.MUT_A_LIBELLE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeMUT_MUTUALISATION.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeMUT_MUTUALISATION.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeMUT_MUTUALISATION.Dictionnaire.Remove(base.c_ID);
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

	public string MUT_A_LIBELLE
	{
		get { return c_MUT_A_LIBELLE; }
		set {
			c_MUT_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeMUT_MUTUALISATION
{
	Dictionary<Int64, clg_MUT_MUTUALISATION> c_DicMUT_MUTUALISATION;

	public clg_ListeMUT_MUTUALISATION()
	{
		c_DicMUT_MUTUALISATION = new Dictionary<Int64, clg_MUT_MUTUALISATION>();
	}

	public Dictionary<Int64, clg_MUT_MUTUALISATION> Dictionnaire
	{
		get { return c_DicMUT_MUTUALISATION; }
	}
}
