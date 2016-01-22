using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_EMT_EMBALLAGE_DE_TRANSPORT: clg_TableBase
{
	public const int ID_Table = 30;
	public static clg_CTL_EMT_EMBALLAGE_DE_TRANSPORT c_CTL_EMT_EMBALLAGE_DE_TRANSPORT;
	private Int32 c_EMT_CN;
	private List<clg_CLS_COLIS> c_ListeCLS_COLIS = new List<clg_CLS_COLIS>();
	private string c_EMT_A_LIBELLE;

	public clg_EMT_EMBALLAGE_DE_TRANSPORT(Int64 pID, bool pIsClone=false) : base(c_CTL_EMT_EMBALLAGE_DE_TRANSPORT)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeEMT_EMBALLAGE_DE_TRANSPORT.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pEMT_CN, string pEMT_A_LIBELLE)
	{
		c_EMT_CN = pEMT_CN;
		c_EMT_A_LIBELLE = pEMT_A_LIBELLE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_EMT_EMBALLAGE_DE_TRANSPORT l_clone = new clg_EMT_EMBALLAGE_DE_TRANSPORT(base.c_ID, true);
			l_clone.Initialise(c_EMT_CN, c_EMT_A_LIBELLE);
		}
	}

	public override void AnnuleModification()
	{
		clg_EMT_EMBALLAGE_DE_TRANSPORT l_clone = (clg_EMT_EMBALLAGE_DE_TRANSPORT) this.Clone;
		c_EMT_CN = l_clone.EMT_CN;
		c_EMT_A_LIBELLE = l_clone.EMT_A_LIBELLE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeEMT_EMBALLAGE_DE_TRANSPORT.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeEMT_EMBALLAGE_DE_TRANSPORT.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeEMT_EMBALLAGE_DE_TRANSPORT.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 EMT_CN
	{
		get { return c_EMT_CN; }
		set {
			c_EMT_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_CLS_COLIS> ListeCLS_COLIS
	{
		get { return c_ListeCLS_COLIS; }
	}

	public string EMT_A_LIBELLE
	{
		get { return c_EMT_A_LIBELLE; }
		set {
			c_EMT_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeEMT_EMBALLAGE_DE_TRANSPORT
{
	Dictionary<Int64, clg_EMT_EMBALLAGE_DE_TRANSPORT> c_DicEMT_EMBALLAGE_DE_TRANSPORT;

	public clg_ListeEMT_EMBALLAGE_DE_TRANSPORT()
	{
		c_DicEMT_EMBALLAGE_DE_TRANSPORT = new Dictionary<Int64, clg_EMT_EMBALLAGE_DE_TRANSPORT>();
	}

	public Dictionary<Int64, clg_EMT_EMBALLAGE_DE_TRANSPORT> Dictionnaire
	{
		get { return c_DicEMT_EMBALLAGE_DE_TRANSPORT; }
	}
}
