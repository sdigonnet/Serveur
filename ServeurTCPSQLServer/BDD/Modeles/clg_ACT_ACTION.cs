using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_ACT_ACTION: clg_TableBase
{
	public const int ID_Table = 15;
	public static clg_CTL_ACT_ACTION c_CTL_ACT_ACTION;
	private Int32 c_ACT_CN;
	private List<clg_SQA_SEQUENCE_ACTION> c_ListeSQA_SEQUENCE_ACTION = new List<clg_SQA_SEQUENCE_ACTION>();
	private string c_ACT_A_LIBELLE;
	private string c_ACT_A_COMMENTAIRE;

	public clg_ACT_ACTION(Int64 pID, bool pIsClone=false) : base(c_CTL_ACT_ACTION)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeACT_ACTION.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pACT_CN, string pACT_A_LIBELLE, string pACT_A_COMMENTAIRE)
	{
		c_ACT_CN = pACT_CN;
		c_ACT_A_LIBELLE = pACT_A_LIBELLE;
		c_ACT_A_COMMENTAIRE = pACT_A_COMMENTAIRE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_ACT_ACTION l_clone = new clg_ACT_ACTION(base.c_ID, true);
			l_clone.Initialise(c_ACT_CN, c_ACT_A_LIBELLE, c_ACT_A_COMMENTAIRE);
		}
	}

	public override void AnnuleModification()
	{
		clg_ACT_ACTION l_clone = (clg_ACT_ACTION) this.Clone;
		c_ACT_CN = l_clone.ACT_CN;
		c_ACT_A_LIBELLE = l_clone.ACT_A_LIBELLE;
		c_ACT_A_COMMENTAIRE = l_clone.ACT_A_COMMENTAIRE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeACT_ACTION.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeACT_ACTION.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeACT_ACTION.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 ACT_CN
	{
		get { return c_ACT_CN; }
		set {
			c_ACT_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_SQA_SEQUENCE_ACTION> ListeSQA_SEQUENCE_ACTION
	{
		get { return c_ListeSQA_SEQUENCE_ACTION; }
	}

	public string ACT_A_LIBELLE
	{
		get { return c_ACT_A_LIBELLE; }
		set {
			c_ACT_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string ACT_A_COMMENTAIRE
	{
		get { return c_ACT_A_COMMENTAIRE; }
		set {
			c_ACT_A_COMMENTAIRE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeACT_ACTION
{
	Dictionary<Int64, clg_ACT_ACTION> c_DicACT_ACTION;

	public clg_ListeACT_ACTION()
	{
		c_DicACT_ACTION = new Dictionary<Int64, clg_ACT_ACTION>();
	}

	public Dictionary<Int64, clg_ACT_ACTION> Dictionnaire
	{
		get { return c_DicACT_ACTION; }
	}
}
