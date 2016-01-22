using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_SQA_SEQUENCE_ACTION: clg_TableBase
{
	public const int ID_Table = 7;
	public static clg_CTL_SQA_SEQUENCE_ACTION c_CTL_SQA_SEQUENCE_ACTION;
	private Int32 c_SQA_CN;
	private List<clg_ACT_ACTION> c_ListeACT_ACTION = new List<clg_ACT_ACTION>();
	private string c_SQA_A_LIBELLE;
	private string c_SQA_A_COMMENTAIRE;

	public clg_SQA_SEQUENCE_ACTION(Int64 pID, bool pIsClone=false) : base(c_CTL_SQA_SEQUENCE_ACTION)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeSQA_SEQUENCE_ACTION.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pSQA_CN, string pSQA_A_LIBELLE, string pSQA_A_COMMENTAIRE)
	{
		c_SQA_CN = pSQA_CN;
		c_SQA_A_LIBELLE = pSQA_A_LIBELLE;
		c_SQA_A_COMMENTAIRE = pSQA_A_COMMENTAIRE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_SQA_SEQUENCE_ACTION l_clone = new clg_SQA_SEQUENCE_ACTION(base.c_ID, true);
			l_clone.Initialise(c_SQA_CN, c_SQA_A_LIBELLE, c_SQA_A_COMMENTAIRE);
		}
	}

	public override void AnnuleModification()
	{
		clg_SQA_SEQUENCE_ACTION l_clone = (clg_SQA_SEQUENCE_ACTION) this.Clone;
		c_SQA_CN = l_clone.SQA_CN;
		c_SQA_A_LIBELLE = l_clone.SQA_A_LIBELLE;
		c_SQA_A_COMMENTAIRE = l_clone.SQA_A_COMMENTAIRE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeSQA_SEQUENCE_ACTION.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeSQA_SEQUENCE_ACTION.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeSQA_SEQUENCE_ACTION.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 SQA_CN
	{
		get { return c_SQA_CN; }
		set {
			c_SQA_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_ACT_ACTION> ListeACT_ACTION
	{
		get { return c_ListeACT_ACTION; }
	}

	public string SQA_A_LIBELLE
	{
		get { return c_SQA_A_LIBELLE; }
		set {
			c_SQA_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string SQA_A_COMMENTAIRE
	{
		get { return c_SQA_A_COMMENTAIRE; }
		set {
			c_SQA_A_COMMENTAIRE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeSQA_SEQUENCE_ACTION
{
	Dictionary<Int64, clg_SQA_SEQUENCE_ACTION> c_DicSQA_SEQUENCE_ACTION;

	public clg_ListeSQA_SEQUENCE_ACTION()
	{
		c_DicSQA_SEQUENCE_ACTION = new Dictionary<Int64, clg_SQA_SEQUENCE_ACTION>();
	}

	public Dictionary<Int64, clg_SQA_SEQUENCE_ACTION> Dictionnaire
	{
		get { return c_DicSQA_SEQUENCE_ACTION; }
	}
}
