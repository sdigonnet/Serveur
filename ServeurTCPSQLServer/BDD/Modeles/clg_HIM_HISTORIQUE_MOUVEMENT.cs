using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_HIM_HISTORIQUE_MOUVEMENT: clg_TableBase
{
	public const int ID_Table = 38;
	public static clg_CTL_HIM_HISTORIQUE_MOUVEMENT c_CTL_HIM_HISTORIQUE_MOUVEMENT;
	private Int16 c_HIM_B_ANNULE;
	private DateTime c_HIM_D_DEBUT;
	private List<clg_DEPLACER> c_ListeDEPLACER = new List<clg_DEPLACER>();
	private DateTime c_HIM_D_FIN;
	private clg_EMP_EMPLACEMENT c_EMP_CN;
	private clg_EMP_EMPLACEMENT c__NCHILD__EMP_CN;

	public clg_HIM_HISTORIQUE_MOUVEMENT(Int64 pID, bool pIsClone=false) : base(c_CTL_HIM_HISTORIQUE_MOUVEMENT)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeHIM_HISTORIQUE_MOUVEMENT.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int16 pHIM_B_ANNULE, DateTime pHIM_D_DEBUT, DateTime pHIM_D_FIN, clg_EMP_EMPLACEMENT pEMP_CN, clg_EMP_EMPLACEMENT p_NCHILD__EMP_CN)
	{
		c_HIM_B_ANNULE = pHIM_B_ANNULE;
		c_HIM_D_DEBUT = pHIM_D_DEBUT;
		c_HIM_D_FIN = pHIM_D_FIN;
		c_EMP_CN = pEMP_CN;
		c_EMP_CN.ListeHIM_HISTORIQUE_MOUVEMENT.Add(this);
		c__NCHILD__EMP_CN = p_NCHILD__EMP_CN;
		c__NCHILD__EMP_CN.Liste_NCHILD__EMP_CN.Add(this);
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_HIM_HISTORIQUE_MOUVEMENT l_clone = new clg_HIM_HISTORIQUE_MOUVEMENT(base.c_ID, true);
			l_clone.Initialise(c_HIM_B_ANNULE, c_HIM_D_DEBUT, c_HIM_D_FIN, c_EMP_CN, c__NCHILD__EMP_CN);
		}
	}

	public override void AnnuleModification()
	{
		clg_HIM_HISTORIQUE_MOUVEMENT l_clone = (clg_HIM_HISTORIQUE_MOUVEMENT) this.Clone;
		c_HIM_B_ANNULE = l_clone.HIM_B_ANNULE;
		c_HIM_D_DEBUT = l_clone.HIM_D_DEBUT;
		c_HIM_D_FIN = l_clone.HIM_D_FIN;
		c_EMP_CN = l_clone.EMP_CN;
		c__NCHILD__EMP_CN = l_clone._NCHILD__EMP_CN;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeHIM_HISTORIQUE_MOUVEMENT.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeHIM_HISTORIQUE_MOUVEMENT.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeHIM_HISTORIQUE_MOUVEMENT.Dictionnaire.Remove(base.c_ID);
	}

	public Int16 HIM_B_ANNULE
	{
		get { return c_HIM_B_ANNULE; }
		set {
			c_HIM_B_ANNULE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public DateTime HIM_D_DEBUT
	{
		get { return c_HIM_D_DEBUT; }
		set {
			c_HIM_D_DEBUT = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_DEPLACER> ListeDEPLACER
	{
		get { return c_ListeDEPLACER; }
	}

	public DateTime HIM_D_FIN
	{
		get { return c_HIM_D_FIN; }
		set {
			c_HIM_D_FIN = value;
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

	public clg_EMP_EMPLACEMENT _NCHILD__EMP_CN
	{
		get { return c__NCHILD__EMP_CN; }
		set {
			c__NCHILD__EMP_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeHIM_HISTORIQUE_MOUVEMENT
{
	Dictionary<Int64, clg_HIM_HISTORIQUE_MOUVEMENT> c_DicHIM_HISTORIQUE_MOUVEMENT;

	public clg_ListeHIM_HISTORIQUE_MOUVEMENT()
	{
		c_DicHIM_HISTORIQUE_MOUVEMENT = new Dictionary<Int64, clg_HIM_HISTORIQUE_MOUVEMENT>();
	}

	public Dictionary<Int64, clg_HIM_HISTORIQUE_MOUVEMENT> Dictionnaire
	{
		get { return c_DicHIM_HISTORIQUE_MOUVEMENT; }
	}
}
