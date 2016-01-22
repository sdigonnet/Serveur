using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_HIE_HISTORIQUE_EMPLACEMENT: clg_TableBase
{
	public const int ID_Table = 36;
	public static clg_CTL_HIE_HISTORIQUE_EMPLACEMENT c_CTL_HIE_HISTORIQUE_EMPLACEMENT;
	private DateTime c_HIE_D_DATE;
	private DateTime c_HIE_D_SUPPRESSION;
	private clg_EMP_EMPLACEMENT c_EMP_CN;

	public clg_HIE_HISTORIQUE_EMPLACEMENT(Int64 pID, bool pIsClone=false) : base(c_CTL_HIE_HISTORIQUE_EMPLACEMENT)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeHIE_HISTORIQUE_EMPLACEMENT.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (DateTime pHIE_D_DATE, DateTime pHIE_D_SUPPRESSION, clg_EMP_EMPLACEMENT pEMP_CN)
	{
		c_HIE_D_DATE = pHIE_D_DATE;
		c_HIE_D_SUPPRESSION = pHIE_D_SUPPRESSION;
		c_EMP_CN = pEMP_CN;
		c_EMP_CN.ListeHIE_HISTORIQUE_EMPLACEMENT.Add(this);
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_HIE_HISTORIQUE_EMPLACEMENT l_clone = new clg_HIE_HISTORIQUE_EMPLACEMENT(base.c_ID, true);
			l_clone.Initialise(c_HIE_D_DATE, c_HIE_D_SUPPRESSION, c_EMP_CN);
		}
	}

	public override void AnnuleModification()
	{
		clg_HIE_HISTORIQUE_EMPLACEMENT l_clone = (clg_HIE_HISTORIQUE_EMPLACEMENT) this.Clone;
		c_HIE_D_DATE = l_clone.HIE_D_DATE;
		c_HIE_D_SUPPRESSION = l_clone.HIE_D_SUPPRESSION;
		c_EMP_CN = l_clone.EMP_CN;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeHIE_HISTORIQUE_EMPLACEMENT.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeHIE_HISTORIQUE_EMPLACEMENT.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeHIE_HISTORIQUE_EMPLACEMENT.Dictionnaire.Remove(base.c_ID);
	}

	public DateTime HIE_D_DATE
	{
		get { return c_HIE_D_DATE; }
		set {
			c_HIE_D_DATE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public DateTime HIE_D_SUPPRESSION
	{
		get { return c_HIE_D_SUPPRESSION; }
		set {
			c_HIE_D_SUPPRESSION = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public clg_EMP_EMPLACEMENT EMP_CN
	{
		get { return c_EMP_CN; }
		set {
			c_EMP_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeHIE_HISTORIQUE_EMPLACEMENT
{
	Dictionary<Int64, clg_HIE_HISTORIQUE_EMPLACEMENT> c_DicHIE_HISTORIQUE_EMPLACEMENT;

	public clg_ListeHIE_HISTORIQUE_EMPLACEMENT()
	{
		c_DicHIE_HISTORIQUE_EMPLACEMENT = new Dictionary<Int64, clg_HIE_HISTORIQUE_EMPLACEMENT>();
	}

	public Dictionary<Int64, clg_HIE_HISTORIQUE_EMPLACEMENT> Dictionnaire
	{
		get { return c_DicHIE_HISTORIQUE_EMPLACEMENT; }
	}
}
