using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clg_ReflexionV3;

namespace ServeurTCPSQLServer
{
    class clg_ExporteObjetsCSV
    {
        public static string GenereLigne(List<clg_TableBase> pListeObjets)
        {
            StringBuilder l_Contenu = new StringBuilder();
            String l_TypeObjet = "";
            if (pListeObjets.Count > 0)
            {
                foreach (clg_TableBase obj in pListeObjets)
                {
                    if (obj.GetType().ToString() != l_TypeObjet)
                    {
                        l_Contenu.AppendLine(obj.ListeTypesProprietesCSV());
                    }
                    l_Contenu.AppendLine(obj.ListeValeursProprietesCSV());
                }
            }

            return l_Contenu.ToString();
        }
    }
}
