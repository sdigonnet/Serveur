using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_COMPTEUR: clg_TableBase
{
	public const int ID_Table = 14;
	public static clg_CTL_COMPTEUR c_CTL_COMPTEUR;
	private Int32 c_CPT_CN;
	private Int32 c_CPT_N_VALEUR;

	public clg_COMPTEUR(Int64 pID, bool pIsClone=false) : base(c_CTL_COMPTEUR)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeCOMPTEUR.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pCPT_CN, Int32 pCPT_N_VALEUR)
	{
		c_CPT_CN = pCPT_CN;
		c_CPT_N_VALEUR = pCPT_N_VALEUR;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_COMPTEUR l_clone = new clg_COMPTEUR(base.c_ID, true);
			l_clone.Initialise(c_CPT_CN, c_CPT_N_VALEUR);
		}
	}

	public override void AnnuleModification()
	{
		clg_COMPTEUR l_clone = (clg_COMPTEUR) this.Clone;
		c_CPT_CN = l_clone.CPT_CN;
		c_CPT_N_VALEUR = l_clone.CPT_N_VALEUR;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeCOMPTEUR.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeCOMPTEUR.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeCOMPTEUR.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 CPT_CN
	{
		get { return c_CPT_CN; }
		set {
			c_CPT_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public Int32 CPT_N_VALEUR
	{
		get { return c_CPT_N_VALEUR; }
		set {
			c_CPT_N_VALEUR = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeCOMPTEUR
{
	Dictionary<Int64, clg_COMPTEUR> c_DicCOMPTEUR;

	public clg_ListeCOMPTEUR()
	{
		c_DicCOMPTEUR = new Dictionary<Int64, clg_COMPTEUR>();
	}

	public Dictionary<Int64, clg_COMPTEUR> Dictionnaire
	{
		get { return c_DicCOMPTEUR; }
	}
}
