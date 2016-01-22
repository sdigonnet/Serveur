using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_DCO_DOCUMENT_COULIS: clg_TableBase
{
	public const int ID_Table = 23;
	public static clg_CTL_DCO_DOCUMENT_COULIS c_CTL_DCO_DOCUMENT_COULIS;
	private clg_DCT_DOCUMENT c_DCT_CN;
	private string c_DCO_A_LIBELLE;

	public clg_DCO_DOCUMENT_COULIS(Int64 pID, bool pIsClone=false) : base(c_CTL_DCO_DOCUMENT_COULIS)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeDCO_DOCUMENT_COULIS.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (clg_DCT_DOCUMENT pDCT_CN, string pDCO_A_LIBELLE)
	{
		c_DCT_CN = pDCT_CN;
		c_DCT_CN.ListeDCO_DOCUMENT_COULIS.Add(this);
		c_DCO_A_LIBELLE = pDCO_A_LIBELLE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_DCO_DOCUMENT_COULIS l_clone = new clg_DCO_DOCUMENT_COULIS(base.c_ID, true);
			l_clone.Initialise(c_DCT_CN, c_DCO_A_LIBELLE);
		}
	}

	public override void AnnuleModification()
	{
		clg_DCO_DOCUMENT_COULIS l_clone = (clg_DCO_DOCUMENT_COULIS) this.Clone;
		c_DCT_CN = l_clone.DCT_CN;
		c_DCO_A_LIBELLE = l_clone.DCO_A_LIBELLE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeDCO_DOCUMENT_COULIS.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeDCO_DOCUMENT_COULIS.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeDCO_DOCUMENT_COULIS.Dictionnaire.Remove(base.c_ID);
	}

	public clg_DCT_DOCUMENT DCT_CN
	{
		get { return c_DCT_CN; }
		set {
			c_DCT_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string DCO_A_LIBELLE
	{
		get { return c_DCO_A_LIBELLE; }
		set {
			c_DCO_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeDCO_DOCUMENT_COULIS
{
	Dictionary<Int64, clg_DCO_DOCUMENT_COULIS> c_DicDCO_DOCUMENT_COULIS;

	public clg_ListeDCO_DOCUMENT_COULIS()
	{
		c_DicDCO_DOCUMENT_COULIS = new Dictionary<Int64, clg_DCO_DOCUMENT_COULIS>();
	}

	public Dictionary<Int64, clg_DCO_DOCUMENT_COULIS> Dictionnaire
	{
		get { return c_DicDCO_DOCUMENT_COULIS; }
	}
}
