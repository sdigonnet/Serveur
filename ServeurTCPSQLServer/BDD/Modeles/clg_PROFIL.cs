using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_PROFIL: clg_TableBase
{
	public const int ID_Table = 45;
	public static clg_CTL_PROFIL c_CTL_PROFIL;
	private Int32 c_PRO_CN;
	private List<clg_AGENT_ICEDA> c_ListeAGENT_ICEDA = new List<clg_AGENT_ICEDA>();
	private string c_PRO_A_LIBELLE;
	private string c_PRO_A_COMMENTAIRE;

	public clg_PROFIL(Int64 pID, bool pIsClone=false) : base(c_CTL_PROFIL)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListePROFIL.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pPRO_CN, string pPRO_A_LIBELLE, string pPRO_A_COMMENTAIRE)
	{
		c_PRO_CN = pPRO_CN;
		c_PRO_A_LIBELLE = pPRO_A_LIBELLE;
		c_PRO_A_COMMENTAIRE = pPRO_A_COMMENTAIRE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_PROFIL l_clone = new clg_PROFIL(base.c_ID, true);
			l_clone.Initialise(c_PRO_CN, c_PRO_A_LIBELLE, c_PRO_A_COMMENTAIRE);
		}
	}

	public override void AnnuleModification()
	{
		clg_PROFIL l_clone = (clg_PROFIL) this.Clone;
		c_PRO_CN = l_clone.PRO_CN;
		c_PRO_A_LIBELLE = l_clone.PRO_A_LIBELLE;
		c_PRO_A_COMMENTAIRE = l_clone.PRO_A_COMMENTAIRE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListePROFIL.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListePROFIL.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListePROFIL.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 PRO_CN
	{
		get { return c_PRO_CN; }
		set {
			c_PRO_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_AGENT_ICEDA> ListeAGENT_ICEDA
	{
		get { return c_ListeAGENT_ICEDA; }
	}

	public string PRO_A_LIBELLE
	{
		get { return c_PRO_A_LIBELLE; }
		set {
			c_PRO_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string PRO_A_COMMENTAIRE
	{
		get { return c_PRO_A_COMMENTAIRE; }
		set {
			c_PRO_A_COMMENTAIRE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListePROFIL
{
	Dictionary<Int64, clg_PROFIL> c_DicPROFIL;

	public clg_ListePROFIL()
	{
		c_DicPROFIL = new Dictionary<Int64, clg_PROFIL>();
	}

	public Dictionary<Int64, clg_PROFIL> Dictionnaire
	{
		get { return c_DicPROFIL; }
	}
}
