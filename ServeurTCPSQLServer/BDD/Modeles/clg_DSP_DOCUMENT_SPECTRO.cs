using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_DSP_DOCUMENT_SPECTRO: clg_TableBase
{
	public const int ID_Table = 27;
	public static clg_CTL_DSP_DOCUMENT_SPECTRO c_CTL_DSP_DOCUMENT_SPECTRO;
	private clg_DCT_DOCUMENT c_DCT_CN;
	private List<clg_RAD_RADIO_ELEMENT> c_ListeRAD_RADIO_ELEMENT = new List<clg_RAD_RADIO_ELEMENT>();
	private List<clg_CLS_COLIS> c_ListeCLS_COLIS = new List<clg_CLS_COLIS>();
	private string c_DSP_A_LIBELLE;

	public clg_DSP_DOCUMENT_SPECTRO(Int64 pID, bool pIsClone=false) : base(c_CTL_DSP_DOCUMENT_SPECTRO)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeDSP_DOCUMENT_SPECTRO.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (clg_DCT_DOCUMENT pDCT_CN, string pDSP_A_LIBELLE)
	{
		c_DCT_CN = pDCT_CN;
		c_DCT_CN.ListeDSP_DOCUMENT_SPECTRO.Add(this);
		c_DSP_A_LIBELLE = pDSP_A_LIBELLE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_DSP_DOCUMENT_SPECTRO l_clone = new clg_DSP_DOCUMENT_SPECTRO(base.c_ID, true);
			l_clone.Initialise(c_DCT_CN, c_DSP_A_LIBELLE);
		}
	}

	public override void AnnuleModification()
	{
		clg_DSP_DOCUMENT_SPECTRO l_clone = (clg_DSP_DOCUMENT_SPECTRO) this.Clone;
		c_DCT_CN = l_clone.DCT_CN;
		c_DSP_A_LIBELLE = l_clone.DSP_A_LIBELLE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeDSP_DOCUMENT_SPECTRO.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeDSP_DOCUMENT_SPECTRO.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeDSP_DOCUMENT_SPECTRO.Dictionnaire.Remove(base.c_ID);
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

	public List<clg_RAD_RADIO_ELEMENT> ListeRAD_RADIO_ELEMENT
	{
		get { return c_ListeRAD_RADIO_ELEMENT; }
	}

	public List<clg_CLS_COLIS> ListeCLS_COLIS
	{
		get { return c_ListeCLS_COLIS; }
	}

	public string DSP_A_LIBELLE
	{
		get { return c_DSP_A_LIBELLE; }
		set {
			c_DSP_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeDSP_DOCUMENT_SPECTRO
{
	Dictionary<Int64, clg_DSP_DOCUMENT_SPECTRO> c_DicDSP_DOCUMENT_SPECTRO;

	public clg_ListeDSP_DOCUMENT_SPECTRO()
	{
		c_DicDSP_DOCUMENT_SPECTRO = new Dictionary<Int64, clg_DSP_DOCUMENT_SPECTRO>();
	}

	public Dictionary<Int64, clg_DSP_DOCUMENT_SPECTRO> Dictionnaire
	{
		get { return c_DicDSP_DOCUMENT_SPECTRO; }
	}
}
