using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_VER_VERIFICATION_CONTROLE: clg_TableBase
{
	public const int ID_Table = 13;
	public static clg_CTL_VER_VERIFICATION_CONTROLE c_CTL_VER_VERIFICATION_CONTROLE;
	private Int16 c_VER_B_ACCEPTE;
	private Int32 c_VER_CN;
	private List<clg_AGENT_ICEDA> c_ListeAGENT_ICEDA = new List<clg_AGENT_ICEDA>();
	private List<clg_CTR_CONTROLE> c_ListeCTR_CONTROLE = new List<clg_CTR_CONTROLE>();

	public clg_VER_VERIFICATION_CONTROLE(Int64 pID, bool pIsClone=false) : base(c_CTL_VER_VERIFICATION_CONTROLE)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeVER_VERIFICATION_CONTROLE.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int16 pVER_B_ACCEPTE, Int32 pVER_CN)
	{
		c_VER_B_ACCEPTE = pVER_B_ACCEPTE;
		c_VER_CN = pVER_CN;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_VER_VERIFICATION_CONTROLE l_clone = new clg_VER_VERIFICATION_CONTROLE(base.c_ID, true);
			l_clone.Initialise(c_VER_B_ACCEPTE, c_VER_CN);
		}
	}

	public override void AnnuleModification()
	{
		clg_VER_VERIFICATION_CONTROLE l_clone = (clg_VER_VERIFICATION_CONTROLE) this.Clone;
		c_VER_B_ACCEPTE = l_clone.VER_B_ACCEPTE;
		c_VER_CN = l_clone.VER_CN;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeVER_VERIFICATION_CONTROLE.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeVER_VERIFICATION_CONTROLE.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeVER_VERIFICATION_CONTROLE.Dictionnaire.Remove(base.c_ID);
	}

	public Int16 VER_B_ACCEPTE
	{
		get { return c_VER_B_ACCEPTE; }
		set {
			c_VER_B_ACCEPTE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public Int32 VER_CN
	{
		get { return c_VER_CN; }
		set {
			c_VER_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_AGENT_ICEDA> ListeAGENT_ICEDA
	{
		get { return c_ListeAGENT_ICEDA; }
	}

	public List<clg_CTR_CONTROLE> ListeCTR_CONTROLE
	{
		get { return c_ListeCTR_CONTROLE; }
	}
}

public class clg_ListeVER_VERIFICATION_CONTROLE
{
	Dictionary<Int64, clg_VER_VERIFICATION_CONTROLE> c_DicVER_VERIFICATION_CONTROLE;

	public clg_ListeVER_VERIFICATION_CONTROLE()
	{
		c_DicVER_VERIFICATION_CONTROLE = new Dictionary<Int64, clg_VER_VERIFICATION_CONTROLE>();
	}

	public Dictionary<Int64, clg_VER_VERIFICATION_CONTROLE> Dictionnaire
	{
		get { return c_DicVER_VERIFICATION_CONTROLE; }
	}
}
