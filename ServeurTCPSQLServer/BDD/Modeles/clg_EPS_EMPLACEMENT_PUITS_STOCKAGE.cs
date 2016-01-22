using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_EPS_EMPLACEMENT_PUITS_STOCKAGE: clg_TableBase
{
	public const int ID_Table = 31;
	public static clg_CTL_EPS_EMPLACEMENT_PUITS_STOCKAGE c_CTL_EPS_EMPLACEMENT_PUITS_STOCKAGE;
	private Int16 c_EPS_N_NUMERO;
	private clg_EMP_EMPLACEMENT c_EMP_CN;

	public clg_EPS_EMPLACEMENT_PUITS_STOCKAGE(Int64 pID, bool pIsClone=false) : base(c_CTL_EPS_EMPLACEMENT_PUITS_STOCKAGE)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeEPS_EMPLACEMENT_PUITS_STOCKAGE.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int16 pEPS_N_NUMERO, clg_EMP_EMPLACEMENT pEMP_CN)
	{
		c_EPS_N_NUMERO = pEPS_N_NUMERO;
		c_EMP_CN = pEMP_CN;
		c_EMP_CN.ListeEPS_EMPLACEMENT_PUITS_STOCKAGE.Add(this);
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_EPS_EMPLACEMENT_PUITS_STOCKAGE l_clone = new clg_EPS_EMPLACEMENT_PUITS_STOCKAGE(base.c_ID, true);
			l_clone.Initialise(c_EPS_N_NUMERO, c_EMP_CN);
		}
	}

	public override void AnnuleModification()
	{
		clg_EPS_EMPLACEMENT_PUITS_STOCKAGE l_clone = (clg_EPS_EMPLACEMENT_PUITS_STOCKAGE) this.Clone;
		c_EPS_N_NUMERO = l_clone.EPS_N_NUMERO;
		c_EMP_CN = l_clone.EMP_CN;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeEPS_EMPLACEMENT_PUITS_STOCKAGE.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeEPS_EMPLACEMENT_PUITS_STOCKAGE.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeEPS_EMPLACEMENT_PUITS_STOCKAGE.Dictionnaire.Remove(base.c_ID);
	}

	public Int16 EPS_N_NUMERO
	{
		get { return c_EPS_N_NUMERO; }
		set {
			c_EPS_N_NUMERO = value;
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

public class clg_ListeEPS_EMPLACEMENT_PUITS_STOCKAGE
{
	Dictionary<Int64, clg_EPS_EMPLACEMENT_PUITS_STOCKAGE> c_DicEPS_EMPLACEMENT_PUITS_STOCKAGE;

	public clg_ListeEPS_EMPLACEMENT_PUITS_STOCKAGE()
	{
		c_DicEPS_EMPLACEMENT_PUITS_STOCKAGE = new Dictionary<Int64, clg_EPS_EMPLACEMENT_PUITS_STOCKAGE>();
	}

	public Dictionary<Int64, clg_EPS_EMPLACEMENT_PUITS_STOCKAGE> Dictionnaire
	{
		get { return c_DicEPS_EMPLACEMENT_PUITS_STOCKAGE; }
	}
}
