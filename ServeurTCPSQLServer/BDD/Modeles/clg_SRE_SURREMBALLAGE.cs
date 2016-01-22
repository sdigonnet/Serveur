using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_SRE_SURREMBALLAGE: clg_TableBase
{
	public const int ID_Table = 8;
	public static clg_CTL_SRE_SURREMBALLAGE c_CTL_SRE_SURREMBALLAGE;
	private clg_CLS_COLIS c_CLS_CN;
	private string c_SRE_A_LIBELLE;

	public clg_SRE_SURREMBALLAGE(Int64 pID, bool pIsClone=false) : base(c_CTL_SRE_SURREMBALLAGE)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeSRE_SURREMBALLAGE.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (clg_CLS_COLIS pCLS_CN, string pSRE_A_LIBELLE)
	{
		c_CLS_CN = pCLS_CN;
		c_CLS_CN.ListeSRE_SURREMBALLAGE.Add(this);
		c_SRE_A_LIBELLE = pSRE_A_LIBELLE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_SRE_SURREMBALLAGE l_clone = new clg_SRE_SURREMBALLAGE(base.c_ID, true);
			l_clone.Initialise(c_CLS_CN, c_SRE_A_LIBELLE);
		}
	}

	public override void AnnuleModification()
	{
		clg_SRE_SURREMBALLAGE l_clone = (clg_SRE_SURREMBALLAGE) this.Clone;
		c_CLS_CN = l_clone.CLS_CN;
		c_SRE_A_LIBELLE = l_clone.SRE_A_LIBELLE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeSRE_SURREMBALLAGE.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeSRE_SURREMBALLAGE.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeSRE_SURREMBALLAGE.Dictionnaire.Remove(base.c_ID);
	}

	public clg_CLS_COLIS CLS_CN
	{
		get { return c_CLS_CN; }
		set {
			c_CLS_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string SRE_A_LIBELLE
	{
		get { return c_SRE_A_LIBELLE; }
		set {
			c_SRE_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeSRE_SURREMBALLAGE
{
	Dictionary<Int64, clg_SRE_SURREMBALLAGE> c_DicSRE_SURREMBALLAGE;

	public clg_ListeSRE_SURREMBALLAGE()
	{
		c_DicSRE_SURREMBALLAGE = new Dictionary<Int64, clg_SRE_SURREMBALLAGE>();
	}

	public Dictionary<Int64, clg_SRE_SURREMBALLAGE> Dictionnaire
	{
		get { return c_DicSRE_SURREMBALLAGE; }
	}
}
