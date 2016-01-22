using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_AGENT_ICEDA: clg_TableBase
{
	public const int ID_Table = 16;
	public static clg_CTL_AGENT_ICEDA c_CTL_AGENT_ICEDA;
	private Int32 c_AGN_CN;
	private List<clg_VER_VERIFICATION_CONTROLE> c_ListeVER_VERIFICATION_CONTROLE = new List<clg_VER_VERIFICATION_CONTROLE>();
	private List<clg_CTR_CONTROLE> c_ListeCTR_CONTROLE = new List<clg_CTR_CONTROLE>();
	private clg_PROFIL c_PRO_CN;
	private string c_AGN_A_NOM;
	private string c_AGN_A_LOGIN;
	private string c_AGN_A_COMMENTAIRE;

	public clg_AGENT_ICEDA(Int64 pID, bool pIsClone=false) : base(c_CTL_AGENT_ICEDA)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeAGENT_ICEDA.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pAGN_CN, clg_PROFIL pPRO_CN, string pAGN_A_NOM, string pAGN_A_LOGIN, string pAGN_A_COMMENTAIRE)
	{
		c_AGN_CN = pAGN_CN;
		c_PRO_CN = pPRO_CN;
		c_PRO_CN.ListeAGENT_ICEDA.Add(this);
		c_AGN_A_NOM = pAGN_A_NOM;
		c_AGN_A_LOGIN = pAGN_A_LOGIN;
		c_AGN_A_COMMENTAIRE = pAGN_A_COMMENTAIRE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_AGENT_ICEDA l_clone = new clg_AGENT_ICEDA(base.c_ID, true);
			l_clone.Initialise(c_AGN_CN, c_PRO_CN, c_AGN_A_NOM, c_AGN_A_LOGIN, c_AGN_A_COMMENTAIRE);
		}
	}

	public override void AnnuleModification()
	{
		clg_AGENT_ICEDA l_clone = (clg_AGENT_ICEDA) this.Clone;
		c_AGN_CN = l_clone.AGN_CN;
		c_PRO_CN = l_clone.PRO_CN;
		c_AGN_A_NOM = l_clone.AGN_A_NOM;
		c_AGN_A_LOGIN = l_clone.AGN_A_LOGIN;
		c_AGN_A_COMMENTAIRE = l_clone.AGN_A_COMMENTAIRE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeAGENT_ICEDA.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeAGENT_ICEDA.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeAGENT_ICEDA.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 AGN_CN
	{
		get { return c_AGN_CN; }
		set {
			c_AGN_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_VER_VERIFICATION_CONTROLE> ListeVER_VERIFICATION_CONTROLE
	{
		get { return c_ListeVER_VERIFICATION_CONTROLE; }
	}

	public List<clg_CTR_CONTROLE> ListeCTR_CONTROLE
	{
		get { return c_ListeCTR_CONTROLE; }
	}

	public clg_PROFIL PRO_CN
	{
		get { return c_PRO_CN; }
		set {
			c_PRO_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string AGN_A_NOM
	{
		get { return c_AGN_A_NOM; }
		set {
			c_AGN_A_NOM = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string AGN_A_LOGIN
	{
		get { return c_AGN_A_LOGIN; }
		set {
			c_AGN_A_LOGIN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public string AGN_A_COMMENTAIRE
	{
		get { return c_AGN_A_COMMENTAIRE; }
		set {
			c_AGN_A_COMMENTAIRE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeAGENT_ICEDA
{
	Dictionary<Int64, clg_AGENT_ICEDA> c_DicAGENT_ICEDA;

	public clg_ListeAGENT_ICEDA()
	{
		c_DicAGENT_ICEDA = new Dictionary<Int64, clg_AGENT_ICEDA>();
	}

	public Dictionary<Int64, clg_AGENT_ICEDA> Dictionnaire
	{
		get { return c_DicAGENT_ICEDA; }
	}
}
