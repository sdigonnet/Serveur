using System;
using System.Collections.Generic;
using clg_ReflexionV3;

public partial class clg_EMI_EMBALLAGE_IP2: clg_TableBase
{
	public const int ID_Table = 28;
	public static clg_CTL_EMI_EMBALLAGE_IP2 c_CTL_EMI_EMBALLAGE_IP2;
	private Int32 c_EML_CN;
	private List<clg_SORTIR> c_ListeSORTIR = new List<clg_SORTIR>();
	private string c_EML_A_LIBELLE;

	public clg_EMI_EMBALLAGE_IP2(Int64 pID, bool pIsClone=false) : base(c_CTL_EMI_EMBALLAGE_IP2)
	{
		base.c_ID = pID;
		if (pIsClone == false)
		{
			clg_ChargementBase.Modele.ListeEMI_EMBALLAGE_IP2.Dictionnaire.Add(base.c_ID, this);
		}
	}

	public void Initialise (Int32 pEML_CN, string pEML_A_LIBELLE)
	{
		c_EML_CN = pEML_CN;
		c_EML_A_LIBELLE = pEML_A_LIBELLE;
	}

	private void CreerClone()
	{
		if (base.Clone == null)
		{
			clg_EMI_EMBALLAGE_IP2 l_clone = new clg_EMI_EMBALLAGE_IP2(base.c_ID, true);
			l_clone.Initialise(c_EML_CN, c_EML_A_LIBELLE);
		}
	}

	public override void AnnuleModification()
	{
		clg_EMI_EMBALLAGE_IP2 l_clone = (clg_EMI_EMBALLAGE_IP2) this.Clone;
		c_EML_CN = l_clone.EML_CN;
		c_EML_A_LIBELLE = l_clone.EML_A_LIBELLE;
	}

	public override void AnnuleInsert()
	{
		clg_ChargementBase.Modele.ListeEMI_EMBALLAGE_IP2.Dictionnaire.Remove(base.c_ID);
	}

	public override void AnnuleSuppression()
	{
		clg_ChargementBase.Modele.ListeEMI_EMBALLAGE_IP2.Dictionnaire.Add(base.c_ID, this);
	}

	public override void Supprime()
	{
		base.Supprime();
		clg_ChargementBase.Modele.ListeEMI_EMBALLAGE_IP2.Dictionnaire.Remove(base.c_ID);
	}

	public Int32 EML_CN
	{
		get { return c_EML_CN; }
		set {
			c_EML_CN = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}

	public List<clg_SORTIR> ListeSORTIR
	{
		get { return c_ListeSORTIR; }
	}

	public string EML_A_LIBELLE
	{
		get { return c_EML_A_LIBELLE; }
		set {
			c_EML_A_LIBELLE = value;
			CreerClone();
			base.ControleurBase.AjouteUpdate(base.c_ID, this);
		}
	}
}

public class clg_ListeEMI_EMBALLAGE_IP2
{
	Dictionary<Int64, clg_EMI_EMBALLAGE_IP2> c_DicEMI_EMBALLAGE_IP2;

	public clg_ListeEMI_EMBALLAGE_IP2()
	{
		c_DicEMI_EMBALLAGE_IP2 = new Dictionary<Int64, clg_EMI_EMBALLAGE_IP2>();
	}

	public Dictionary<Int64, clg_EMI_EMBALLAGE_IP2> Dictionnaire
	{
		get { return c_DicEMI_EMBALLAGE_IP2; }
	}
}
