using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_DCT_DOCUMENT: clg_TableBase
{
	public const int ID_Table = 24;
	public static clg_CTL_DCT_DOCUMENT c_CTL_DCT_DOCUMENT;
	private DateTime c_DCT_D_DATE;
	private Int32 c_DCT_CN;
	private List<clg_DCO_DOCUMENT_COULIS> c_ListeDCO_DOCUMENT_COULIS = new List<clg_DCO_DOCUMENT_COULIS>();
	private List<clg_DDR_DOCUMENT_DRA> c_ListeDDR_DOCUMENT_DRA = new List<clg_DDR_DOCUMENT_DRA>();
	private List<clg_DSP_DOCUMENT_SPECTRO> c_ListeDSP_DOCUMENT_SPECTRO = new List<clg_DSP_DOCUMENT_SPECTRO>();
	private List<clg_FNC_FICHE_NON_CONFORMITE> c_ListeFNC_FICHE_NON_CONFORMITE = new List<clg_FNC_FICHE_NON_CONFORMITE>();
	private List<clg_HID_HISTORIQUE_DOCUMENT> c_ListeHID_HISTORIQUE_DOCUMENT = new List<clg_HID_HISTORIQUE_DOCUMENT>();
	private string c_DCT_A_CHEMIN;
	private string c_DCT_A_TYPE;

	public clg_DCT_DOCUMENT(Int64 pID, bool pIsClone=false) : base(c_CTL_DCT_DOCUMENT)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeDCT_DOCUMENT.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (DateTime pDCT_D_DATE, Int32 pDCT_CN, string pDCT_A_CHEMIN, string pDCT_A_TYPE)
	{
		c_DCT_D_DATE = pDCT_D_DATE;
		c_DCT_CN = pDCT_CN;
		c_DCT_A_CHEMIN = pDCT_A_CHEMIN;
		c_DCT_A_TYPE = pDCT_A_TYPE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_DCT_DOCUMENT l_clone = new clg_DCT_DOCUMENT(base.c_ID, true);
			l_clone.Initialise(c_DCT_D_DATE, c_DCT_CN, c_DCT_A_CHEMIN, c_DCT_A_TYPE);
		}
	}

	public override void AnnuleModification()
	{
		clg_DCT_DOCUMENT l_clone = (clg_DCT_DOCUMENT) this.Clone;
		c_DCT_D_DATE = l_clone.DCT_D_DATE;
		c_DCT_CN = l_clone.DCT_CN;
		c_DCT_A_CHEMIN = l_clone.DCT_A_CHEMIN;
		c_DCT_A_TYPE = l_clone.DCT_A_TYPE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeDCT_DOCUMENT.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeDCT_DOCUMENT.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeDCT_DOCUMENT.Dictionnaire.Remove(base.c_ID);
	}

	public DateTime DCT_D_DATE
	{
		get { return c_DCT_D_DATE; }
		set {
			c_DCT_D_DATE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public Int32 DCT_CN
	{
		get { return c_DCT_CN; }
		set {
			c_DCT_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_DCO_DOCUMENT_COULIS> ListeDCO_DOCUMENT_COULIS
	{
		get { return c_ListeDCO_DOCUMENT_COULIS; }
	}

	public List<clg_DDR_DOCUMENT_DRA> ListeDDR_DOCUMENT_DRA
	{
		get { return c_ListeDDR_DOCUMENT_DRA; }
	}

	public List<clg_DSP_DOCUMENT_SPECTRO> ListeDSP_DOCUMENT_SPECTRO
	{
		get { return c_ListeDSP_DOCUMENT_SPECTRO; }
	}

	public List<clg_FNC_FICHE_NON_CONFORMITE> ListeFNC_FICHE_NON_CONFORMITE
	{
		get { return c_ListeFNC_FICHE_NON_CONFORMITE; }
	}

	public List<clg_HID_HISTORIQUE_DOCUMENT> ListeHID_HISTORIQUE_DOCUMENT
	{
		get { return c_ListeHID_HISTORIQUE_DOCUMENT; }
	}

	public string DCT_A_CHEMIN
	{
		get { return c_DCT_A_CHEMIN; }
		set {
			c_DCT_A_CHEMIN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string DCT_A_TYPE
	{
		get { return c_DCT_A_TYPE; }
		set {
			c_DCT_A_TYPE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeDCT_DOCUMENT
{
	Dictionary<Int64, clg_DCT_DOCUMENT> c_DicDCT_DOCUMENT;

	public clg_ListeDCT_DOCUMENT()
	{
		c_DicDCT_DOCUMENT = new Dictionary<Int64, clg_DCT_DOCUMENT>();
	}

	public Dictionary<Int64, clg_DCT_DOCUMENT> Dictionnaire
	{
		get { return c_DicDCT_DOCUMENT; }
	}
}
