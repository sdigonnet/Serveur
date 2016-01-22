using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class clg_ConvertDonneesSQL
    {
        public static object ValeurBase(object pval, bool forceText = false)
        {
	        //Gerer les données de type chaine et date. 
	        if ((pval != null)) {
		        string l_Type = pval.GetType().Name;
		        if (!string.IsNullOrEmpty(pval.ToString())) {
			        switch (l_Type) {
				        case "String":
					        return "'" + pval.ToString().Replace("'", "''") + "'";
				        case "Single":
					        pval = pval.ToString().Replace(",", ".");
					        return pval;
				        case "Integer":
					        return pval;
				        case "DateTime":
					        if (forceText == false) {
						        //date
						        if ((DateTime) pval > System.DateTime.MinValue) {
                                    DateTime l_date = (DateTime)pval;
                                    pval = l_date.ToString("dd/MM/yyyy");
							        return "'" + pval + "'";
						        } else {
							        return "null";
						        }
					        } else {
						        return pval.ToString();
					        }
				        case "Boolean":
					        if ((bool) pval) {
						        return "True";
					        } else {
						        return "False";
					        }
				        case "Long":
					        return pval;
				        default:
					        return pval;
			        }
		        } else {
			        //chaine vide, retourne Null.
			        return "null";
		        }
	        } else {
		        //Valeur = à nothing, retourne Null.
		        return "null";
	        }
        }
    }