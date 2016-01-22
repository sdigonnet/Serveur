using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_TYV_TYPE_VARIABLE: clg_TableBase
{
	public const int ID_Table = 12;
	public static clg_CTL_TYV_TYPE_VARIABLE c_CTL_TYV_TYPE_VARIABLE;
	private Int32 c_TYV_CN;
	private List<clg_PAR_CARACTERISTIQUE> c_ListePAR_CARACTERISTIQUE = new List<clg_PAR_CARACTERISTIQUE>();
	private string c_TYV_A_REGEX;
	private string c_TYV_A_TYPECDIEZE;
	private string c_TYV_A_COMMENTAIRE;

	public clg_TYV_TYPE_VARIABLE(Int64 pID, bool pIsClone=false) : base(c_CTL_TYV_TYPE_VARIABLE)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeTYV_TYPE_VARIABLE.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pTYV_CN, string pTYV_A_REGEX, string pTYV_A_TYPECDIEZE, string pTYV_A_COMMENTAIRE)
	{
		c_TYV_CN = pTYV_CN;
		c_TYV_A_REGEX = pTYV_A_REGEX;
		c_TYV_A_TYPECDIEZE = pTYV_A_TYPECDIEZE;
		c_TYV_A_COMMENTAIRE = pTYV_A_COMMENTAIRE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_TYV_TYPE_VARIABLE l_clone = new clg_TYV_TYPE_VARIABLE(base.c_ID, true);
			l_clone.Initialise(c_TYV_CN, c_TYV_A_REGEX, c_TYV_A_TYPECDIEZE, c_TYV_A_COMMENTAIRE);
		}
	}

	public override void AnnuleModification()
	{
		clg_TYV_TYPE_VARIABLE l_clone = (clg_TYV_TYPE_VARIABLE) this.Clone;
		c_TYV_CN = l_clone.TYV_CN;
		c_TYV_A_REGEX = l_clone.TYV_A_REGEX;
		c_TYV_A_TYPECDIEZE = l_clone.TYV_A_TYPECDIEZE;
		c_TYV_A_COMMENTAIRE = l_clone.TYV_A_COMMENTAIRE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeTYV_TYPE_VARIABLE.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeTYV_TYPE_VARIABLE.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeTYV_TYPE_VARIABLE.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 TYV_CN
	{
		get { return c_TYV_CN; }
		set {
			c_TYV_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_PAR_CARACTERISTIQUE> ListePAR_CARACTERISTIQUE
	{
		get { return c_ListePAR_CARACTERISTIQUE; }
	}

	public string TYV_A_REGEX
	{
		get { return c_TYV_A_REGEX; }
		set {
			c_TYV_A_REGEX = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string TYV_A_TYPECDIEZE
	{
		get { return c_TYV_A_TYPECDIEZE; }
		set {
			c_TYV_A_TYPECDIEZE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string TYV_A_COMMENTAIRE
	{
		get { return c_TYV_A_COMMENTAIRE; }
		set {
			c_TYV_A_COMMENTAIRE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeTYV_TYPE_VARIABLE
{
	Dictionary<Int64, clg_TYV_TYPE_VARIABLE> c_DicTYV_TYPE_VARIABLE;

	public clg_ListeTYV_TYPE_VARIABLE()
	{
		c_DicTYV_TYPE_VARIABLE = new Dictionary<Int64, clg_TYV_TYPE_VARIABLE>();
	}

	public Dictionary<Int64, clg_TYV_TYPE_VARIABLE> Dictionnaire
	{
		get { return c_DicTYV_TYPE_VARIABLE; }
	}
}
