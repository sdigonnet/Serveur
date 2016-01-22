using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_PAR_CARACTERISTIQUE: clg_TableBase
{
	public const int ID_Table = 44;
	public static clg_CTL_PAR_CARACTERISTIQUE c_CTL_PAR_CARACTERISTIQUE;
	private Int16 c_CAR_B_OBLIGATOIRE;
	private Int16 c_CAR_N_ORDRE;
	private Int32 c_CAR_CN;
	private List<clg_GROUPER> c_ListeGROUPER = new List<clg_GROUPER>();
	private clg_TYV_TYPE_VARIABLE c_TYV_CN;
	private string c_CAR_A_COMMENTAIRE;

	public clg_PAR_CARACTERISTIQUE(Int64 pID, bool pIsClone=false) : base(c_CTL_PAR_CARACTERISTIQUE)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListePAR_CARACTERISTIQUE.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int16 pCAR_B_OBLIGATOIRE, Int16 pCAR_N_ORDRE, Int32 pCAR_CN, clg_TYV_TYPE_VARIABLE pTYV_CN, string pCAR_A_COMMENTAIRE)
	{
		c_CAR_B_OBLIGATOIRE = pCAR_B_OBLIGATOIRE;
		c_CAR_N_ORDRE = pCAR_N_ORDRE;
		c_CAR_CN = pCAR_CN;
		c_TYV_CN = pTYV_CN;
		c_TYV_CN.ListePAR_CARACTERISTIQUE.Add(this);
		c_CAR_A_COMMENTAIRE = pCAR_A_COMMENTAIRE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_PAR_CARACTERISTIQUE l_clone = new clg_PAR_CARACTERISTIQUE(base.c_ID, true);
			l_clone.Initialise(c_CAR_B_OBLIGATOIRE, c_CAR_N_ORDRE, c_CAR_CN, c_TYV_CN, c_CAR_A_COMMENTAIRE);
		}
	}

	public override void AnnuleModification()
	{
		clg_PAR_CARACTERISTIQUE l_clone = (clg_PAR_CARACTERISTIQUE) this.Clone;
		c_CAR_B_OBLIGATOIRE = l_clone.CAR_B_OBLIGATOIRE;
		c_CAR_N_ORDRE = l_clone.CAR_N_ORDRE;
		c_CAR_CN = l_clone.CAR_CN;
		c_TYV_CN = l_clone.TYV_CN;
		c_CAR_A_COMMENTAIRE = l_clone.CAR_A_COMMENTAIRE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListePAR_CARACTERISTIQUE.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListePAR_CARACTERISTIQUE.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListePAR_CARACTERISTIQUE.Dictionnaire.Remove(base.c_ID);
	}

	public Int16 CAR_B_OBLIGATOIRE
	{
		get { return c_CAR_B_OBLIGATOIRE; }
		set {
			c_CAR_B_OBLIGATOIRE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public Int16 CAR_N_ORDRE
	{
		get { return c_CAR_N_ORDRE; }
		set {
			c_CAR_N_ORDRE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public Int32 CAR_CN
	{
		get { return c_CAR_CN; }
		set {
			c_CAR_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_GROUPER> ListeGROUPER
	{
		get { return c_ListeGROUPER; }
	}

	public clg_TYV_TYPE_VARIABLE TYV_CN
	{
		get { return c_TYV_CN; }
		set {
			c_TYV_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string CAR_A_COMMENTAIRE
	{
		get { return c_CAR_A_COMMENTAIRE; }
		set {
			c_CAR_A_COMMENTAIRE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListePAR_CARACTERISTIQUE
{
	Dictionary<Int64, clg_PAR_CARACTERISTIQUE> c_DicPAR_CARACTERISTIQUE;

	public clg_ListePAR_CARACTERISTIQUE()
	{
		c_DicPAR_CARACTERISTIQUE = new Dictionary<Int64, clg_PAR_CARACTERISTIQUE>();
	}

	public Dictionary<Int64, clg_PAR_CARACTERISTIQUE> Dictionnaire
	{
		get { return c_DicPAR_CARACTERISTIQUE; }
	}
}
