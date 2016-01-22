using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_RAD_RADIO_ELEMENT: clg_TableBase
{
	public const int ID_Table = 3;
	public static clg_CTL_RAD_RADIO_ELEMENT c_CTL_RAD_RADIO_ELEMENT;
	private Int32 c_RAD_CN;
	private List<clg_DSP_DOCUMENT_SPECTRO> c_ListeDSP_DOCUMENT_SPECTRO = new List<clg_DSP_DOCUMENT_SPECTRO>();
	private string c_RAD_A_LIBELLE;
	private string c_RAD_A_FONCTIONDECROISSANCE;

	public clg_RAD_RADIO_ELEMENT(Int64 pID, bool pIsClone=false) : base(c_CTL_RAD_RADIO_ELEMENT)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeRAD_RADIO_ELEMENT.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pRAD_CN, string pRAD_A_LIBELLE, string pRAD_A_FONCTIONDECROISSANCE)
	{
		c_RAD_CN = pRAD_CN;
		c_RAD_A_LIBELLE = pRAD_A_LIBELLE;
		c_RAD_A_FONCTIONDECROISSANCE = pRAD_A_FONCTIONDECROISSANCE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_RAD_RADIO_ELEMENT l_clone = new clg_RAD_RADIO_ELEMENT(base.c_ID, true);
			l_clone.Initialise(c_RAD_CN, c_RAD_A_LIBELLE, c_RAD_A_FONCTIONDECROISSANCE);
		}
	}

	public override void AnnuleModification()
	{
		clg_RAD_RADIO_ELEMENT l_clone = (clg_RAD_RADIO_ELEMENT) this.Clone;
		c_RAD_CN = l_clone.RAD_CN;
		c_RAD_A_LIBELLE = l_clone.RAD_A_LIBELLE;
		c_RAD_A_FONCTIONDECROISSANCE = l_clone.RAD_A_FONCTIONDECROISSANCE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeRAD_RADIO_ELEMENT.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeRAD_RADIO_ELEMENT.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeRAD_RADIO_ELEMENT.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 RAD_CN
	{
		get { return c_RAD_CN; }
		set {
			c_RAD_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_DSP_DOCUMENT_SPECTRO> ListeDSP_DOCUMENT_SPECTRO
	{
		get { return c_ListeDSP_DOCUMENT_SPECTRO; }
	}

	public string RAD_A_LIBELLE
	{
		get { return c_RAD_A_LIBELLE; }
		set {
			c_RAD_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string RAD_A_FONCTIONDECROISSANCE
	{
		get { return c_RAD_A_FONCTIONDECROISSANCE; }
		set {
			c_RAD_A_FONCTIONDECROISSANCE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeRAD_RADIO_ELEMENT
{
	Dictionary<Int64, clg_RAD_RADIO_ELEMENT> c_DicRAD_RADIO_ELEMENT;

	public clg_ListeRAD_RADIO_ELEMENT()
	{
		c_DicRAD_RADIO_ELEMENT = new Dictionary<Int64, clg_RAD_RADIO_ELEMENT>();
	}

	public Dictionary<Int64, clg_RAD_RADIO_ELEMENT> Dictionnaire
	{
		get { return c_DicRAD_RADIO_ELEMENT; }
	}
}
