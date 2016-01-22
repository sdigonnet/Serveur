using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_DDR_DOCUMENT_DRA: clg_TableBase
{
	public const int ID_Table = 25;
	public static clg_CTL_DDR_DOCUMENT_DRA c_CTL_DDR_DOCUMENT_DRA;
	private clg_DCT_DOCUMENT c_DCT_CN;
	private string c_DDR_A_LIBELLE;

	public clg_DDR_DOCUMENT_DRA(Int64 pID, bool pIsClone=false) : base(c_CTL_DDR_DOCUMENT_DRA)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeDDR_DOCUMENT_DRA.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (clg_DCT_DOCUMENT pDCT_CN, string pDDR_A_LIBELLE)
	{
		c_DCT_CN = pDCT_CN;
		c_DCT_CN.ListeDDR_DOCUMENT_DRA.Add(this);
		c_DDR_A_LIBELLE = pDDR_A_LIBELLE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_DDR_DOCUMENT_DRA l_clone = new clg_DDR_DOCUMENT_DRA(base.c_ID, true);
			l_clone.Initialise(c_DCT_CN, c_DDR_A_LIBELLE);
		}
	}

	public override void AnnuleModification()
	{
		clg_DDR_DOCUMENT_DRA l_clone = (clg_DDR_DOCUMENT_DRA) this.Clone;
		c_DCT_CN = l_clone.DCT_CN;
		c_DDR_A_LIBELLE = l_clone.DDR_A_LIBELLE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeDDR_DOCUMENT_DRA.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeDDR_DOCUMENT_DRA.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeDDR_DOCUMENT_DRA.Dictionnaire.Remove(base.c_ID);
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

	public string DDR_A_LIBELLE
	{
		get { return c_DDR_A_LIBELLE; }
		set {
			c_DDR_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeDDR_DOCUMENT_DRA
{
	Dictionary<Int64, clg_DDR_DOCUMENT_DRA> c_DicDDR_DOCUMENT_DRA;

	public clg_ListeDDR_DOCUMENT_DRA()
	{
		c_DicDDR_DOCUMENT_DRA = new Dictionary<Int64, clg_DDR_DOCUMENT_DRA>();
	}

	public Dictionary<Int64, clg_DDR_DOCUMENT_DRA> Dictionnaire
	{
		get { return c_DicDDR_DOCUMENT_DRA; }
	}
}
