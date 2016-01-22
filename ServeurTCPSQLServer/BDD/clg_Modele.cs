class clg_Modele
{
	clg_ListePUS_PUITS_STOCKAGE c_ListePUS_PUITS_STOCKAGE;
	clg_ListePUT_PUISSANCE_THERMIQUE c_ListePUT_PUISSANCE_THERMIQUE;
	clg_ListeRAD_RADIO_ELEMENT c_ListeRAD_RADIO_ELEMENT;
	clg_ListeSIE_SITE_EXUTOIRE c_ListeSIE_SITE_EXUTOIRE;
	clg_ListeSORTIR c_ListeSORTIR;
	clg_ListeSPR_SITE_PRODUCTEUR c_ListeSPR_SITE_PRODUCTEUR;
	clg_ListeSQA_SEQUENCE_ACTION c_ListeSQA_SEQUENCE_ACTION;
	clg_ListeSRE_SURREMBALLAGE c_ListeSRE_SURREMBALLAGE;
	clg_ListeTN_TN c_ListeTN_TN;
	clg_ListeTYC_TYPE_CONTROLE c_ListeTYC_TYPE_CONTROLE;
	clg_ListeTYD_TYPE__DECHET c_ListeTYD_TYPE__DECHET;
	clg_ListeTYV_TYPE_VARIABLE c_ListeTYV_TYPE_VARIABLE;
	clg_ListeVER_VERIFICATION_CONTROLE c_ListeVER_VERIFICATION_CONTROLE;
	clg_ListeCOMPTEUR c_ListeCOMPTEUR;
	clg_ListeACT_ACTION c_ListeACT_ACTION;
	clg_ListeAGENT_ICEDA c_ListeAGENT_ICEDA;
	clg_ListeCHZ_CHOOZ c_ListeCHZ_CHOOZ;
	clg_ListeCLS_COLIS c_ListeCLS_COLIS;
	clg_ListeCOU_COULIS c_ListeCOU_COULIS;
	clg_ListeCRA_CRAYON c_ListeCRA_CRAYON;
	clg_ListeCTA_CONTROLE_ATTENDU c_ListeCTA_CONTROLE_ATTENDU;
	clg_ListeCTR_CONTROLE c_ListeCTR_CONTROLE;
	clg_ListeDCO_DOCUMENT_COULIS c_ListeDCO_DOCUMENT_COULIS;
	clg_ListeDCT_DOCUMENT c_ListeDCT_DOCUMENT;
	clg_ListeDDR_DOCUMENT_DRA c_ListeDDR_DOCUMENT_DRA;
	clg_ListeDEPLACER c_ListeDEPLACER;
	clg_ListeDSP_DOCUMENT_SPECTRO c_ListeDSP_DOCUMENT_SPECTRO;
	clg_ListeEMI_EMBALLAGE_IP2 c_ListeEMI_EMBALLAGE_IP2;
	clg_ListeEMP_EMPLACEMENT c_ListeEMP_EMPLACEMENT;
	clg_ListeEMT_EMBALLAGE_DE_TRANSPORT c_ListeEMT_EMBALLAGE_DE_TRANSPORT;
	clg_ListeEPS_EMPLACEMENT_PUITS_STOCKAGE c_ListeEPS_EMPLACEMENT_PUITS_STOCKAGE;
	clg_ListeETU_ETUI c_ListeETU_ETUI;
	clg_ListeFNC_FICHE_NON_CONFORMITE c_ListeFNC_FICHE_NON_CONFORMITE;
	clg_ListeGROUPER c_ListeGROUPER;
	clg_ListeHID_HISTORIQUE_DOCUMENT c_ListeHID_HISTORIQUE_DOCUMENT;
	clg_ListeHIE_HISTORIQUE_EMPLACEMENT c_ListeHIE_HISTORIQUE_EMPLACEMENT;
	clg_ListeHIL_HISTORIQUE_LOCAL c_ListeHIL_HISTORIQUE_LOCAL;
	clg_ListeHIM_HISTORIQUE_MOUVEMENT c_ListeHIM_HISTORIQUE_MOUVEMENT;
	clg_ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE c_ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE;
	clg_ListeINF_INFORMATION c_ListeINF_INFORMATION;
	clg_ListeLCL_LOCAL c_ListeLCL_LOCAL;
	clg_ListeMUT_MUTUALISATION c_ListeMUT_MUTUALISATION;
	clg_ListePAN_PANIER c_ListePAN_PANIER;
	clg_ListePAR_CARACTERISTIQUE c_ListePAR_CARACTERISTIQUE;
	clg_ListePROFIL c_ListePROFIL;

	public void ChargeStructure()
	{
		clg_ChargementBase.Controleur.c_CTL_PUS_PUITS_STOCKAGE.Initialise();
		clg_ChargementBase.Controleur.c_CTL_RAD_RADIO_ELEMENT.Initialise();
		clg_ChargementBase.Controleur.c_CTL_SIE_SITE_EXUTOIRE.Initialise();
		clg_ChargementBase.Controleur.c_CTL_SPR_SITE_PRODUCTEUR.Initialise();
		clg_ChargementBase.Controleur.c_CTL_SQA_SEQUENCE_ACTION.Initialise();
		clg_ChargementBase.Controleur.c_CTL_TYC_TYPE_CONTROLE.Initialise();
		clg_ChargementBase.Controleur.c_CTL_TYD_TYPE__DECHET.Initialise();
		clg_ChargementBase.Controleur.c_CTL_TYV_TYPE_VARIABLE.Initialise();
		clg_ChargementBase.Controleur.c_CTL_VER_VERIFICATION_CONTROLE.Initialise();
		clg_ChargementBase.Controleur.c_CTL_COMPTEUR.Initialise();
		clg_ChargementBase.Controleur.c_CTL_ACT_ACTION.Initialise();
		clg_ChargementBase.Controleur.c_CTL_COU_COULIS.Initialise();
		clg_ChargementBase.Controleur.c_CTL_CTA_CONTROLE_ATTENDU.Initialise();
		clg_ChargementBase.Controleur.c_CTL_CTR_CONTROLE.Initialise();
		clg_ChargementBase.Controleur.c_CTL_DCT_DOCUMENT.Initialise();
		clg_ChargementBase.Controleur.c_CTL_DDR_DOCUMENT_DRA.Initialise();
		clg_ChargementBase.Controleur.c_CTL_DSP_DOCUMENT_SPECTRO.Initialise();
		clg_ChargementBase.Controleur.c_CTL_EMI_EMBALLAGE_IP2.Initialise();
		clg_ChargementBase.Controleur.c_CTL_EMT_EMBALLAGE_DE_TRANSPORT.Initialise();
		clg_ChargementBase.Controleur.c_CTL_ETU_ETUI.Initialise();
		clg_ChargementBase.Controleur.c_CTL_FNC_FICHE_NON_CONFORMITE.Initialise();
		clg_ChargementBase.Controleur.c_CTL_GROUPER_ACTION.Initialise();
		clg_ChargementBase.Controleur.c_CTL_HID_HISTORIQUE_DOCUMENT.Initialise();
		clg_ChargementBase.Controleur.c_CTL_HIP_HISTORIQUE_PUISSANCETHERMIQUE.Initialise();
		clg_ChargementBase.Controleur.c_CTL_INF_INFORMATION.Initialise();
		clg_ChargementBase.Controleur.c_CTL_LCL_LOCAL.Initialise();
		clg_ChargementBase.Controleur.c_CTL_PAR_CARACTERISTIQUE.Initialise();
		clg_ChargementBase.Controleur.c_CTL_PROFIL.Initialise();
		clg_ChargementBase.Controleur.c_CTL_AGENT_ICEDA.Initialise();
		clg_ChargementBase.Controleur.c_CTL_CLS_COLIS.Initialise();
		clg_ChargementBase.Controleur.c_CTL_COMPOSER_DOCUMENT.Initialise();
		clg_ChargementBase.Controleur.c_CTL_COMPOSITION_RADIOELEMENTS.Initialise();
		clg_ChargementBase.Controleur.c_CTL_CONTROLER.Initialise();
		clg_ChargementBase.Controleur.c_CTL_CONTROLER_SAISIE.Initialise();
		clg_ChargementBase.Controleur.c_CTL_DCO_DOCUMENT_COULIS.Initialise();
		clg_ChargementBase.Controleur.c_CTL_DEFINIR_TYPE_DECHET.Initialise();
		clg_ChargementBase.Controleur.c_CTL_EMP_EMPLACEMENT.Initialise();
		clg_ChargementBase.Controleur.c_CTL_EPS_EMPLACEMENT_PUITS_STOCKAGE.Initialise();
		clg_ChargementBase.Controleur.c_CTL_GROUPER.Initialise();
		clg_ChargementBase.Controleur.c_CTL_HIE_HISTORIQUE_EMPLACEMENT.Initialise();
		clg_ChargementBase.Controleur.c_CTL_HIL_HISTORIQUE_LOCAL.Initialise();
		clg_ChargementBase.Controleur.c_CTL_HIM_HISTORIQUE_MOUVEMENT.Initialise();
		clg_ChargementBase.Controleur.c_CTL_MUT_MUTUALISATION.Initialise();
		clg_ChargementBase.Controleur.c_CTL_PAN_PANIER.Initialise();
		clg_ChargementBase.Controleur.c_CTL_PUT_PUISSANCE_THERMIQUE.Initialise();
		clg_ChargementBase.Controleur.c_CTL_SAISIR.Initialise();
		clg_ChargementBase.Controleur.c_CTL_SORTIR.Initialise();
		clg_ChargementBase.Controleur.c_CTL_SRE_SURREMBALLAGE.Initialise();
		clg_ChargementBase.Controleur.c_CTL_TN_TN.Initialise();
		clg_ChargementBase.Controleur.c_CTL_CALER.Initialise();
		clg_ChargementBase.Controleur.c_CTL_CHZ_CHOOZ.Initialise();
		clg_ChargementBase.Controleur.c_CTL_CONTROLE.Initialise();
		clg_ChargementBase.Controleur.c_CTL_COULER.Initialise();
		clg_ChargementBase.Controleur.c_CTL_CRA_CRAYON.Initialise();
		clg_ChargementBase.Controleur.c_CTL_DEPLACER.Initialise();
		clg_ChargementBase.Controleur.c_CTL_HISTORISER_PUISSANCETHERMIQUE.Initialise();
	}

	public clg_ListePUS_PUITS_STOCKAGE ListePUS_PUITS_STOCKAGE
	{
		get{return c_ListePUS_PUITS_STOCKAGE;}
		set{ c_ListePUS_PUITS_STOCKAGE = value; }
	}

	public clg_ListePUT_PUISSANCE_THERMIQUE ListePUT_PUISSANCE_THERMIQUE
	{
		get{return c_ListePUT_PUISSANCE_THERMIQUE;}
		set{ c_ListePUT_PUISSANCE_THERMIQUE = value; }
	}

	public clg_ListeRAD_RADIO_ELEMENT ListeRAD_RADIO_ELEMENT
	{
		get{return c_ListeRAD_RADIO_ELEMENT;}
		set{ c_ListeRAD_RADIO_ELEMENT = value; }
	}

	public clg_ListeSIE_SITE_EXUTOIRE ListeSIE_SITE_EXUTOIRE
	{
		get{return c_ListeSIE_SITE_EXUTOIRE;}
		set{ c_ListeSIE_SITE_EXUTOIRE = value; }
	}

	public clg_ListeSORTIR ListeSORTIR
	{
		get{return c_ListeSORTIR;}
		set{ c_ListeSORTIR = value; }
	}

	public clg_ListeSPR_SITE_PRODUCTEUR ListeSPR_SITE_PRODUCTEUR
	{
		get{return c_ListeSPR_SITE_PRODUCTEUR;}
		set{ c_ListeSPR_SITE_PRODUCTEUR = value; }
	}

	public clg_ListeSQA_SEQUENCE_ACTION ListeSQA_SEQUENCE_ACTION
	{
		get{return c_ListeSQA_SEQUENCE_ACTION;}
		set{ c_ListeSQA_SEQUENCE_ACTION = value; }
	}

	public clg_ListeSRE_SURREMBALLAGE ListeSRE_SURREMBALLAGE
	{
		get{return c_ListeSRE_SURREMBALLAGE;}
		set{ c_ListeSRE_SURREMBALLAGE = value; }
	}

	public clg_ListeTN_TN ListeTN_TN
	{
		get{return c_ListeTN_TN;}
		set{ c_ListeTN_TN = value; }
	}

	public clg_ListeTYC_TYPE_CONTROLE ListeTYC_TYPE_CONTROLE
	{
		get{return c_ListeTYC_TYPE_CONTROLE;}
		set{ c_ListeTYC_TYPE_CONTROLE = value; }
	}

	public clg_ListeTYD_TYPE__DECHET ListeTYD_TYPE__DECHET
	{
		get{return c_ListeTYD_TYPE__DECHET;}
		set{ c_ListeTYD_TYPE__DECHET = value; }
	}

	public clg_ListeTYV_TYPE_VARIABLE ListeTYV_TYPE_VARIABLE
	{
		get{return c_ListeTYV_TYPE_VARIABLE;}
		set{ c_ListeTYV_TYPE_VARIABLE = value; }
	}

	public clg_ListeVER_VERIFICATION_CONTROLE ListeVER_VERIFICATION_CONTROLE
	{
		get{return c_ListeVER_VERIFICATION_CONTROLE;}
		set{ c_ListeVER_VERIFICATION_CONTROLE = value; }
	}

	public clg_ListeCOMPTEUR ListeCOMPTEUR
	{
		get{return c_ListeCOMPTEUR;}
		set{ c_ListeCOMPTEUR = value; }
	}

	public clg_ListeACT_ACTION ListeACT_ACTION
	{
		get{return c_ListeACT_ACTION;}
		set{ c_ListeACT_ACTION = value; }
	}

	public clg_ListeAGENT_ICEDA ListeAGENT_ICEDA
	{
		get{return c_ListeAGENT_ICEDA;}
		set{ c_ListeAGENT_ICEDA = value; }
	}

	public clg_ListeCHZ_CHOOZ ListeCHZ_CHOOZ
	{
		get{return c_ListeCHZ_CHOOZ;}
		set{ c_ListeCHZ_CHOOZ = value; }
	}

	public clg_ListeCLS_COLIS ListeCLS_COLIS
	{
		get{return c_ListeCLS_COLIS;}
		set{ c_ListeCLS_COLIS = value; }
	}

	public clg_ListeCOU_COULIS ListeCOU_COULIS
	{
		get{return c_ListeCOU_COULIS;}
		set{ c_ListeCOU_COULIS = value; }
	}

	public clg_ListeCRA_CRAYON ListeCRA_CRAYON
	{
		get{return c_ListeCRA_CRAYON;}
		set{ c_ListeCRA_CRAYON = value; }
	}

	public clg_ListeCTA_CONTROLE_ATTENDU ListeCTA_CONTROLE_ATTENDU
	{
		get{return c_ListeCTA_CONTROLE_ATTENDU;}
		set{ c_ListeCTA_CONTROLE_ATTENDU = value; }
	}

	public clg_ListeCTR_CONTROLE ListeCTR_CONTROLE
	{
		get{return c_ListeCTR_CONTROLE;}
		set{ c_ListeCTR_CONTROLE = value; }
	}

	public clg_ListeDCO_DOCUMENT_COULIS ListeDCO_DOCUMENT_COULIS
	{
		get{return c_ListeDCO_DOCUMENT_COULIS;}
		set{ c_ListeDCO_DOCUMENT_COULIS = value; }
	}

	public clg_ListeDCT_DOCUMENT ListeDCT_DOCUMENT
	{
		get{return c_ListeDCT_DOCUMENT;}
		set{ c_ListeDCT_DOCUMENT = value; }
	}

	public clg_ListeDDR_DOCUMENT_DRA ListeDDR_DOCUMENT_DRA
	{
		get{return c_ListeDDR_DOCUMENT_DRA;}
		set{ c_ListeDDR_DOCUMENT_DRA = value; }
	}

	public clg_ListeDEPLACER ListeDEPLACER
	{
		get{return c_ListeDEPLACER;}
		set{ c_ListeDEPLACER = value; }
	}

	public clg_ListeDSP_DOCUMENT_SPECTRO ListeDSP_DOCUMENT_SPECTRO
	{
		get{return c_ListeDSP_DOCUMENT_SPECTRO;}
		set{ c_ListeDSP_DOCUMENT_SPECTRO = value; }
	}

	public clg_ListeEMI_EMBALLAGE_IP2 ListeEMI_EMBALLAGE_IP2
	{
		get{return c_ListeEMI_EMBALLAGE_IP2;}
		set{ c_ListeEMI_EMBALLAGE_IP2 = value; }
	}

	public clg_ListeEMP_EMPLACEMENT ListeEMP_EMPLACEMENT
	{
		get{return c_ListeEMP_EMPLACEMENT;}
		set{ c_ListeEMP_EMPLACEMENT = value; }
	}

	public clg_ListeEMT_EMBALLAGE_DE_TRANSPORT ListeEMT_EMBALLAGE_DE_TRANSPORT
	{
		get{return c_ListeEMT_EMBALLAGE_DE_TRANSPORT;}
		set{ c_ListeEMT_EMBALLAGE_DE_TRANSPORT = value; }
	}

	public clg_ListeEPS_EMPLACEMENT_PUITS_STOCKAGE ListeEPS_EMPLACEMENT_PUITS_STOCKAGE
	{
		get{return c_ListeEPS_EMPLACEMENT_PUITS_STOCKAGE;}
		set{ c_ListeEPS_EMPLACEMENT_PUITS_STOCKAGE = value; }
	}

	public clg_ListeETU_ETUI ListeETU_ETUI
	{
		get{return c_ListeETU_ETUI;}
		set{ c_ListeETU_ETUI = value; }
	}

	public clg_ListeFNC_FICHE_NON_CONFORMITE ListeFNC_FICHE_NON_CONFORMITE
	{
		get{return c_ListeFNC_FICHE_NON_CONFORMITE;}
		set{ c_ListeFNC_FICHE_NON_CONFORMITE = value; }
	}

	public clg_ListeGROUPER ListeGROUPER
	{
		get{return c_ListeGROUPER;}
		set{ c_ListeGROUPER = value; }
	}

	public clg_ListeHID_HISTORIQUE_DOCUMENT ListeHID_HISTORIQUE_DOCUMENT
	{
		get{return c_ListeHID_HISTORIQUE_DOCUMENT;}
		set{ c_ListeHID_HISTORIQUE_DOCUMENT = value; }
	}

	public clg_ListeHIE_HISTORIQUE_EMPLACEMENT ListeHIE_HISTORIQUE_EMPLACEMENT
	{
		get{return c_ListeHIE_HISTORIQUE_EMPLACEMENT;}
		set{ c_ListeHIE_HISTORIQUE_EMPLACEMENT = value; }
	}

	public clg_ListeHIL_HISTORIQUE_LOCAL ListeHIL_HISTORIQUE_LOCAL
	{
		get{return c_ListeHIL_HISTORIQUE_LOCAL;}
		set{ c_ListeHIL_HISTORIQUE_LOCAL = value; }
	}

	public clg_ListeHIM_HISTORIQUE_MOUVEMENT ListeHIM_HISTORIQUE_MOUVEMENT
	{
		get{return c_ListeHIM_HISTORIQUE_MOUVEMENT;}
		set{ c_ListeHIM_HISTORIQUE_MOUVEMENT = value; }
	}

	public clg_ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE
	{
		get{return c_ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE;}
		set{ c_ListeHIP_HISTORIQUE_PUISSANCETHERMIQUE = value; }
	}

	public clg_ListeINF_INFORMATION ListeINF_INFORMATION
	{
		get{return c_ListeINF_INFORMATION;}
		set{ c_ListeINF_INFORMATION = value; }
	}

	public clg_ListeLCL_LOCAL ListeLCL_LOCAL
	{
		get{return c_ListeLCL_LOCAL;}
		set{ c_ListeLCL_LOCAL = value; }
	}

	public clg_ListeMUT_MUTUALISATION ListeMUT_MUTUALISATION
	{
		get{return c_ListeMUT_MUTUALISATION;}
		set{ c_ListeMUT_MUTUALISATION = value; }
	}

	public clg_ListePAN_PANIER ListePAN_PANIER
	{
		get{return c_ListePAN_PANIER;}
		set{ c_ListePAN_PANIER = value; }
	}

	public clg_ListePAR_CARACTERISTIQUE ListePAR_CARACTERISTIQUE
	{
		get{return c_ListePAR_CARACTERISTIQUE;}
		set{ c_ListePAR_CARACTERISTIQUE = value; }
	}

	public clg_ListePROFIL ListePROFIL
	{
		get{return c_ListePROFIL;}
		set{ c_ListePROFIL = value; }
	}

	public static object ValeurDonnee(object pVal, bool Moins1SiNull = false)
	{
		if ((!object.ReferenceEquals(pVal, null)))
		{
			return pVal;
		}
		else
		{
			 if (Moins1SiNull)
			{
				return -1;
			}
			else
			{
				return "";
			}
		}
	}
}
