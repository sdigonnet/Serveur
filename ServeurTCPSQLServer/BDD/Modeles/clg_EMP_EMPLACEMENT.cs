using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_EMP_EMPLACEMENT: clg_TableBase
{
	public const int ID_Table = 29;
	public static clg_CTL_EMP_EMPLACEMENT c_CTL_EMP_EMPLACEMENT;
	private Int16 c_EMP_N_POSX;
	private Int16 c_EMP_N_POSY;
	private Int16 c_EMP_B_HISTORISE;
	private Int32 c_EMP_CN;
	private List<clg_CTA_CONTROLE_ATTENDU> c_ListeCTA_CONTROLE_ATTENDU = new List<clg_CTA_CONTROLE_ATTENDU>();
	private List<clg_EPS_EMPLACEMENT_PUITS_STOCKAGE> c_ListeEPS_EMPLACEMENT_PUITS_STOCKAGE = new List<clg_EPS_EMPLACEMENT_PUITS_STOCKAGE>();
	private List<clg_HIE_HISTORIQUE_EMPLACEMENT> c_ListeHIE_HISTORIQUE_EMPLACEMENT = new List<clg_HIE_HISTORIQUE_EMPLACEMENT>();
	private List<clg_HIM_HISTORIQUE_MOUVEMENT> c_ListeHIM_HISTORIQUE_MOUVEMENT = new List<clg_HIM_HISTORIQUE_MOUVEMENT>();
	private List<clg_HIM_HISTORIQUE_MOUVEMENT> c_Liste_NCHILD__EMP_CN = new List<clg_HIM_HISTORIQUE_MOUVEMENT>();
	private clg_LCL_LOCAL c_LCL_CN;

	public clg_EMP_EMPLACEMENT(Int64 pID, bool pIsClone=false) : base(c_CTL_EMP_EMPLACEMENT)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeEMP_EMPLACEMENT.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int16 pEMP_N_POSX, Int16 pEMP_N_POSY, Int16 pEMP_B_HISTORISE, Int32 pEMP_CN, clg_LCL_LOCAL pLCL_CN)
	{
		c_EMP_N_POSX = pEMP_N_POSX;
		c_EMP_N_POSY = pEMP_N_POSY;
		c_EMP_B_HISTORISE = pEMP_B_HISTORISE;
		c_EMP_CN = pEMP_CN;
		c_LCL_CN = pLCL_CN;
		c_LCL_CN.ListeEMP_EMPLACEMENT.Add(this);
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_EMP_EMPLACEMENT l_clone = new clg_EMP_EMPLACEMENT(base.c_ID, true);
			l_clone.Initialise(c_EMP_N_POSX, c_EMP_N_POSY, c_EMP_B_HISTORISE, c_EMP_CN, c_LCL_CN);
		}
	}

	public override void AnnuleModification()
	{
		clg_EMP_EMPLACEMENT l_clone = (clg_EMP_EMPLACEMENT) this.Clone;
		c_EMP_N_POSX = l_clone.EMP_N_POSX;
		c_EMP_N_POSY = l_clone.EMP_N_POSY;
		c_EMP_B_HISTORISE = l_clone.EMP_B_HISTORISE;
		c_EMP_CN = l_clone.EMP_CN;
		c_LCL_CN = l_clone.LCL_CN;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeEMP_EMPLACEMENT.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeEMP_EMPLACEMENT.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeEMP_EMPLACEMENT.Dictionnaire.Remove(base.c_ID);
	}

	public Int16 EMP_N_POSX
	{
		get { return c_EMP_N_POSX; }
		set {
			c_EMP_N_POSX = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public Int16 EMP_N_POSY
	{
		get { return c_EMP_N_POSY; }
		set {
			c_EMP_N_POSY = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public Int16 EMP_B_HISTORISE
	{
		get { return c_EMP_B_HISTORISE; }
		set {
			c_EMP_B_HISTORISE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public Int32 EMP_CN
	{
		get { return c_EMP_CN; }
		set {
			c_EMP_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_CTA_CONTROLE_ATTENDU> ListeCTA_CONTROLE_ATTENDU
	{
		get { return c_ListeCTA_CONTROLE_ATTENDU; }
	}

	public List<clg_EPS_EMPLACEMENT_PUITS_STOCKAGE> ListeEPS_EMPLACEMENT_PUITS_STOCKAGE
	{
		get { return c_ListeEPS_EMPLACEMENT_PUITS_STOCKAGE; }
	}

	public List<clg_HIE_HISTORIQUE_EMPLACEMENT> ListeHIE_HISTORIQUE_EMPLACEMENT
	{
		get { return c_ListeHIE_HISTORIQUE_EMPLACEMENT; }
	}

	public List<clg_HIM_HISTORIQUE_MOUVEMENT> ListeHIM_HISTORIQUE_MOUVEMENT
	{
		get { return c_ListeHIM_HISTORIQUE_MOUVEMENT; }
	}

	public List<clg_HIM_HISTORIQUE_MOUVEMENT> Liste_NCHILD__EMP_CN
	{
		get { return c_Liste_NCHILD__EMP_CN; }
	}

	public clg_LCL_LOCAL LCL_CN
	{
		get { return c_LCL_CN; }
		set {
			c_LCL_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeEMP_EMPLACEMENT
{
	Dictionary<Int64, clg_EMP_EMPLACEMENT> c_DicEMP_EMPLACEMENT;

	public clg_ListeEMP_EMPLACEMENT()
	{
		c_DicEMP_EMPLACEMENT = new Dictionary<Int64, clg_EMP_EMPLACEMENT>();
	}

	public Dictionary<Int64, clg_EMP_EMPLACEMENT> Dictionnaire
	{
		get { return c_DicEMP_EMPLACEMENT; }
	}
}
