using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_PUS_PUITS_STOCKAGE: clg_TableBase
{
	public const int ID_Table = 1;
	public static clg_CTL_PUS_PUITS_STOCKAGE c_CTL_PUS_PUITS_STOCKAGE;
	private Int32 c_PUS_CN;
	private List<clg_ETU_ETUI> c_ListeETU_ETUI = new List<clg_ETU_ETUI>();
	private string c_PUS_A_COMMENTAIRE;
	private string c_PUS_A_LIBELLE;

	public clg_PUS_PUITS_STOCKAGE(Int64 pID, bool pIsClone=false) : base(c_CTL_PUS_PUITS_STOCKAGE)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListePUS_PUITS_STOCKAGE.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pPUS_CN, string pPUS_A_COMMENTAIRE, string pPUS_A_LIBELLE)
	{
		c_PUS_CN = pPUS_CN;
		c_PUS_A_COMMENTAIRE = pPUS_A_COMMENTAIRE;
		c_PUS_A_LIBELLE = pPUS_A_LIBELLE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_PUS_PUITS_STOCKAGE l_clone = new clg_PUS_PUITS_STOCKAGE(base.c_ID, true);
			l_clone.Initialise(c_PUS_CN, c_PUS_A_COMMENTAIRE, c_PUS_A_LIBELLE);
		}
	}

	public override void AnnuleModification()
	{
		clg_PUS_PUITS_STOCKAGE l_clone = (clg_PUS_PUITS_STOCKAGE) this.Clone;
		c_PUS_CN = l_clone.PUS_CN;
		c_PUS_A_COMMENTAIRE = l_clone.PUS_A_COMMENTAIRE;
		c_PUS_A_LIBELLE = l_clone.PUS_A_LIBELLE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListePUS_PUITS_STOCKAGE.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListePUS_PUITS_STOCKAGE.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListePUS_PUITS_STOCKAGE.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 PUS_CN
	{
		get { return c_PUS_CN; }
		set {
			c_PUS_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_ETU_ETUI> ListeETU_ETUI
	{
		get { return c_ListeETU_ETUI; }
	}

	public string PUS_A_COMMENTAIRE
	{
		get { return c_PUS_A_COMMENTAIRE; }
		set {
			c_PUS_A_COMMENTAIRE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string PUS_A_LIBELLE
	{
		get { return c_PUS_A_LIBELLE; }
		set {
			c_PUS_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListePUS_PUITS_STOCKAGE
{
	Dictionary<Int64, clg_PUS_PUITS_STOCKAGE> c_DicPUS_PUITS_STOCKAGE;

	public clg_ListePUS_PUITS_STOCKAGE()
	{
		c_DicPUS_PUITS_STOCKAGE = new Dictionary<Int64, clg_PUS_PUITS_STOCKAGE>();
	}

	public Dictionary<Int64, clg_PUS_PUITS_STOCKAGE> Dictionnaire
	{
		get { return c_DicPUS_PUITS_STOCKAGE; }
	}
}
