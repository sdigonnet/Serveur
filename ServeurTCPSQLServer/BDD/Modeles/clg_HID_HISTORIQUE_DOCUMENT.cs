using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_HID_HISTORIQUE_DOCUMENT: clg_TableBase
{
	public const int ID_Table = 35;
	public static clg_CTL_HID_HISTORIQUE_DOCUMENT c_CTL_HID_HISTORIQUE_DOCUMENT;
	private Int32 c_HID_CN;
	private clg_DCT_DOCUMENT c_DCT_CN;

	public clg_HID_HISTORIQUE_DOCUMENT(Int64 pID, bool pIsClone=false) : base(c_CTL_HID_HISTORIQUE_DOCUMENT)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeHID_HISTORIQUE_DOCUMENT.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pHID_CN, clg_DCT_DOCUMENT pDCT_CN)
	{
		c_HID_CN = pHID_CN;
		c_DCT_CN = pDCT_CN;
		c_DCT_CN.ListeHID_HISTORIQUE_DOCUMENT.Add(this);
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_HID_HISTORIQUE_DOCUMENT l_clone = new clg_HID_HISTORIQUE_DOCUMENT(base.c_ID, true);
			l_clone.Initialise(c_HID_CN, c_DCT_CN);
		}
	}

	public override void AnnuleModification()
	{
		clg_HID_HISTORIQUE_DOCUMENT l_clone = (clg_HID_HISTORIQUE_DOCUMENT) this.Clone;
		c_HID_CN = l_clone.HID_CN;
		c_DCT_CN = l_clone.DCT_CN;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeHID_HISTORIQUE_DOCUMENT.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeHID_HISTORIQUE_DOCUMENT.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeHID_HISTORIQUE_DOCUMENT.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 HID_CN
	{
		get { return c_HID_CN; }
		set {
			c_HID_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
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
}

public class clg_ListeHID_HISTORIQUE_DOCUMENT
{
	Dictionary<Int64, clg_HID_HISTORIQUE_DOCUMENT> c_DicHID_HISTORIQUE_DOCUMENT;

	public clg_ListeHID_HISTORIQUE_DOCUMENT()
	{
		c_DicHID_HISTORIQUE_DOCUMENT = new Dictionary<Int64, clg_HID_HISTORIQUE_DOCUMENT>();
	}

	public Dictionary<Int64, clg_HID_HISTORIQUE_DOCUMENT> Dictionnaire
	{
		get { return c_DicHID_HISTORIQUE_DOCUMENT; }
	}
}
