using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_SORTIR: clg_TableBase
{
	public const int ID_Table = 5;
	public static clg_CTL_SORTIR c_CTL_SORTIR;
	private clg_EMI_EMBALLAGE_IP2 c_EML_CN;
	private clg_CLS_COLIS c_CLS_CN;
	private Int32 c_SRT_CN;

	public clg_SORTIR(Int64 pID, bool pIsClone=false) : base(c_CTL_SORTIR)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeSORTIR.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (clg_EMI_EMBALLAGE_IP2 pEML_CN, clg_CLS_COLIS pCLS_CN, Int32 pSRT_CN)
	{
		c_EML_CN = pEML_CN;
		c_EML_CN.ListeSORTIR.Add(this);
		c_CLS_CN = pCLS_CN;
		c_CLS_CN.ListeSORTIR.Add(this);
		c_SRT_CN = pSRT_CN;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_SORTIR l_clone = new clg_SORTIR(base.c_ID, true);
			l_clone.Initialise(c_EML_CN, c_CLS_CN, c_SRT_CN);
		}
	}

	public override void AnnuleModification()
	{
		clg_SORTIR l_clone = (clg_SORTIR) this.Clone;
		c_EML_CN = l_clone.EML_CN;
		c_CLS_CN = l_clone.CLS_CN;
		c_SRT_CN = l_clone.SRT_CN;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeSORTIR.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeSORTIR.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeSORTIR.Dictionnaire.Remove(base.c_ID);
	}

	public clg_EMI_EMBALLAGE_IP2 EML_CN
	{
		get { return c_EML_CN; }
		set {
			c_EML_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
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

	public Int32 SRT_CN
	{
		get { return c_SRT_CN; }
		set {
			c_SRT_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeSORTIR
{
	Dictionary<Int64, clg_SORTIR> c_DicSORTIR;

	public clg_ListeSORTIR()
	{
		c_DicSORTIR = new Dictionary<Int64, clg_SORTIR>();
	}

	public Dictionary<Int64, clg_SORTIR> Dictionnaire
	{
		get { return c_DicSORTIR; }
	}
}
