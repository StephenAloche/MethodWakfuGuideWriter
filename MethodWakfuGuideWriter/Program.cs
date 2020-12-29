using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace MethodWakfuGuideWriter
{
    class Program
    {
        public static string DateFile { get; set; }
        public static string UrlFile { get; set; }
        public static TemplateDonjon DonjonData { get; set; }

        static void Main(string[] args)
        {
            if (args.Length == 0)
                return; // return if no file was dragged onto exe
            var assembly = Assembly.GetExecutingAssembly();

            try
            {

            DateFile = DateTime.Now.ToString("yyyy/MM");

            //check l'extension
            string textJson = File.ReadAllText(args[0]);
            StringBuilder sbGlobal = new StringBuilder();
            string templateGlobal = Properties.Resources.TemplateGlobal;
            sbGlobal.Append(templateGlobal);

            //Exctraction des données Json.
            DonjonData = JsonConvert.DeserializeObject<TemplateDonjon>(textJson);
            UrlFile = $"/wp-content/uploads/{DateFile}/{DonjonData.NomDonjonUrl}";

            //Remplissage du template
            string nomDuDonjon = DonjonData.Nom;
            sbGlobal.Replace("NOM_DU_DONJON", nomDuDonjon);
            sbGlobal.Replace("ZONE_PRECISE", DonjonData.ZonePrecise);
            sbGlobal.Replace("ZONE_PRINCIPALE", DonjonData.ZonePrincipale);

            string urlMapDonjon = "https://methodwakfu.com/wp-content/uploads/2020/11/petit_cadre-1024x291.png";
            sbGlobal.Replace(urlMapDonjon.Replace("\\", ""), $"{UrlFile}_map.png");

            string urlEntreeDonjon = "https://methodwakfu.com/wp-content/uploads/2020/11/petit_cadre-1024x291.png";
            sbGlobal.Replace(urlEntreeDonjon.Replace("\\", ""), $"{UrlFile}_map.png");

            //partie monstre
            StringBuilder sbMonstre = new StringBuilder();
            int i = 1; //increment de numerotation dans le template
            foreach (Monstre monstre in DonjonData.Monstres)
            {
                //l'ajout des sorts se fait lors de la création du monstre
                string monstreString = CreateMonstre(monstre, i);
                sbMonstre.Append(monstreString);
                i++;
            }
            //on ajoute tout les monstres
            sbGlobal.Replace("[TemplateMonstre]", sbMonstre.ToString());

            //partie Salle

            StringBuilder sbSalle = new StringBuilder();
            i = 1; //increment de numerotation dans le template            
            foreach (Salle Salle in DonjonData.Donjon.Salles)
            {
                string SalleString = CreateSalle(Salle, i);
                sbSalle.Append(SalleString);
                i++;
            }
            //on ajoute toutes les salles
            sbGlobal.Replace("[TemplateSalle]", sbSalle.ToString());

            //partie Strategie
            //partie Drop
            //partie Croupier
            //partie Exploit
            sbGlobal.Replace("NOM_DE_L_EXPLOIT", DonjonData.Exploit.Nom);
            sbGlobal.Replace("TRANCHE_DE_NIVEAU", DonjonData.Exploit.TypeJetons);

            //traitement post écriture
            ProcessPostEcriture(sbGlobal);

            //Ecriture et retour du fichier
            string path = Path.GetDirectoryName(args[0])
               + Path.DirectorySeparatorChar
               + nomDuDonjon + ".txt";
            File.WriteAllText(path, sbGlobal.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Modifie les derniers éléments un fois l'article écrit au format final
        /// </summary>
        /// <param name="sbGlobal"></param>
        private static void ProcessPostEcriture(StringBuilder sbGlobal)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Retourne le code hexa d'une couleur à appliquer pour un élément
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public static string GetColorElement(string elem)
        {
            string color = "#000000";
            switch (elem)
            {
                case "terre":
                    color = " #98AE40";
                    break;
                case "air":
                    color = "#B990E6";
                    break;
                case "eau":
                    color = "#63C1E8";
                    break;
                case "feu":
                    color = "#F20000";
                    break;
                case "stasis":
                    color = "#EA12EE";
                    break;
                case "lumière":
                    color = "#F9CE43";
                    break;
                default:
                    color = " #F9CE43";
                    break;
            }
            return color;
        }

        /// <summary>
        /// Genere le text de la partie d'un monstre a partir du template et des infos du monstre passé en paramètre
        /// </summary>
        /// <param name="monstre"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string CreateMonstre(Monstre monstre, int num)
        {
            string defaultSrc = "https://methodwakfu.com/wp-content/uploads/2020/06/fiche_monstre.png";
            string Template = Properties.Resources.TemplateMonstre;
            StringBuilder sbMonstre = new StringBuilder(Template);

            if (monstre.Boss)
            {
                sbMonstre.Replace("Nom_du_Monstre", monstre.Nom + " (Boss)");
            }
            else
            {
                sbMonstre.Replace("Nom_du_Monstre", monstre.Nom);
                //suppression de l'image d'archetype
                string urlArchetype = "";
                switch (monstre.Archetype?.ToLower())
                {
                    case "melee":
                    case "melée":
                        urlArchetype = "/wp-content/uploads/2019/04/melee_archetype.png";
                        break;
                    case "tank":
                        urlArchetype = "/wp-content/uploads/2019/03/tank_archetype.png";
                        break;
                    case "invocateur":
                        urlArchetype = "/wp-content/uploads/2019/03/invocateur_archetype.png";
                        break;
                    default:
                        break;
                }
                sbMonstre.Replace("https://methodwakfu.com/wp-content/uploads/2020/06/achetype_base.png", urlArchetype);

                sbMonstre = new StringBuilder(Regex.Replace(sbMonstre.ToString(), @"<!-- TemplateBoss(.+\n)+-->", ""));
            }
            sbMonstre.Replace("Num_Monstre", "2." + num);

            sbMonstre.Replace(defaultSrc, $"{UrlFile}_{monstre.Nom}.png");

            int NbSort = monstre.sorts.Where(s => s.Passif == false && s.Etat == false).Count();
            int NbPassif = monstre.sorts.Where(s => s.Passif == true || s.Etat == true).Count();

            string sortReplace = $"{NbSort} sort{(NbSort > 1 ? "s" : "")}";
            sbMonstre.Replace("XXX sorts", sortReplace);

            string pluriel = $"{NbPassif} passif{ (NbPassif > 1 ? "s" : "")}";

            string passifReplace = $"{(NbPassif > 0 ? pluriel : "") }";
            sbMonstre.Replace("XXX passifs", passifReplace);

            string textRes = "et sa plus basse résistance est l'élément <strong>ELEM </strong>[OU] ses plus basses résistances sont les éléments <strong>ELEM </strong>et <strong>ELEM </strong>:";
            if (monstre.ResistanceBasse.Count > 1)
            {
                sbMonstre.Replace(textRes, $"et ses plus basses résistances sont les éléments {String.Join(" et ", monstre.ResistanceBasse.Select(res => $"<strong><span style=\"color:{GetColorElement(res.ToLower())}\">{res}</span></strong>"))} :");
            }
            else
            {
                sbMonstre.Replace(textRes, $"et sa plus basse résistance est l'élément {monstre.ResistanceBasse.Select(res => $"<strong><span style=\"color:{GetColorElement(res.ToLower())}\">{res}</span></strong>").FirstOrDefault()} :");
            }

            //partie sorts
            StringBuilder sbSorts = new StringBuilder();
            int i = 1; //increment de numerotation dans le template
            foreach (Sort sort in monstre.sorts)
            {
                //l'ajout des sorts se fait lors de la création du monstre
                string sortString = CreateSort(sort);
                sbSorts.Append(sortString);
                i++;
            }
            //on ajoute tout les monstres
            sbMonstre.Replace("[TemplateSort]", sbSorts.ToString());

            return sbMonstre.ToString();
        }

        /// <summary>
        /// Genere le text de la partie d'un sort a partir du template et des infos du sort passé en paramètre
        /// </summary>
        /// <param name="sort"></param>
        /// <returns></returns>
        public static string CreateSort(Sort sort)
        {
            string Template = Properties.Resources.TemplateSort;
            StringBuilder sbSort = new StringBuilder(Template);

            string partieMono = Properties.Resources.TemplateMono;
            string partieZone = Properties.Resources.TemplateZone;
            string partiePassif = Properties.Resources.TemplatePassif;

            if (sort.Passif || sort.Etat)
            {
                sbSort.Replace("[TemplateMono]", "");
                sbSort.Replace("[TemplateZone]", "");
                sbSort.Replace("[TemplatePassif]", partiePassif);

                sbSort.Replace("NomDuPassifouEtat", sort.Nom);
                sbSort.Replace("passif", $"{(sort.Passif ? "passif" : "état")}");
                sbSort.Replace("EFFETS", sort.Effets);

                return sbSort.ToString();
            }

            //on verifie le type d'attaque, on supprime la balise inutile on remplace la balise par le template et on modifie le template
            if (sort.Zone)
            {
                sbSort.Replace("[TemplateMono]", "");
                sbSort.Replace("[TemplatePassif]", "");
                sbSort.Replace("[TemplateZone]", partieZone);

                sbSort.Replace("[sur cible] [condition : en ligne/en diagonale] [sans ligne de vue], X-X PO [modifiable]", sort.PO);
                sbSort.Replace("ZONE-PO-TAILLE", sort.ZoneClass);
                sbSort.Replace(">ZONE<", $">{sort.ZoneText}<");

            }
            else // monocible
            {
                sbSort.Replace("[TemplateZone]", "");
                sbSort.Replace("[TemplatePassif]", "");
                sbSort.Replace("[TemplateMono]", partieMono);
                sbSort.Replace("X-X PO [modifiable] [condition : en ligne/en diagonale] [sans ligne de vue]", sort.PO);
            }

            sbSort.Replace("NomDuSort", sort.Nom);
            sbSort.Replace("X PA", sort.Cout);
            sbSort.Replace("#CODE_HEXA", GetColorElement(sort.ElemDegats));
            if (String.IsNullOrEmpty(sort.ElemDegats))
            {
                sbSort.Replace("Inflige des dégâts ", "");
            }
            else
            {
                sbSort.Replace("ELEM", sort.ElemDegats);
            }

            sbSort.Replace("et EFFETS", "et " + sort.Effets);


            return sbSort.ToString();
        }

        /// <summary>
        /// Genere le text de la partie d'une salle a partir du template et des infos d'une salle passé en paramètre
        /// </summary>
        /// <param name="salle"></param>
        /// <returns></returns>
        public static string CreateSalle(Salle salle, int num)
        {
            string defaultSrc = "https://methodwakfu.com/wp-content/uploads/2020/11/grand_cadre-1024x649.png";
            string Template = Properties.Resources.TemplateSalle;
            StringBuilder sbSalle = new StringBuilder(Template);

            sbSalle.Replace("NUM_SALLE", GetTermNumSalle(num));
            if (salle.Boss)
            {
                sbSalle.Replace("diapo1", "diapoboss");
                sbSalle.Replace("Num_Salle", GetTermNumSalle(0));
            }
            else
            {
                sbSalle.Replace("diapo1", "diapo" + num);
                sbSalle.Replace("Num_Salle", GetTermNumSalle(num));
            }


            sbSalle.Replace("URL_AVEC_VUE_TACTIQUE", $"{UrlFile}_salle_{num}_avec_vt");

            sbSalle.Replace(defaultSrc, $"{UrlFile}_salle_{num}_sans_vt");
            sbSalle.Replace("URL_SANS_VUE_TACTIQUE", $"{UrlFile}_salle_{num}_sans_vt");

            sbSalle.Replace("Xx NomDuMonstre, Xx NomDuMonstre, Xx NomDuMonstre", salle.Compo);

            return sbSalle.ToString();
        }

        public static string GetTermNumSalle(int num)
        {
            string retour = "Première";
            switch (num)
            {
                case 0:
                    return "Salle du Boss";
                case 1:
                    retour = "Première";
                    break;
                case 2:
                    retour = "Deuxième";
                    break;
                case 3:
                    retour = "Troisième";
                    break;
                case 4:
                    retour = "Quatrième";
                    break;
                case 5:
                    retour = "Cinquième";
                    break;
                case 6:
                    retour = "Sixième";
                    break;
                default:
                    retour = "Première";
                    break;
            }
            return retour + " salle";
        }
    }
}


public class Sort
{
    public string Nom { get; set; }
    public bool Passif { get; set; }
    public bool Etat { get; set; }
    public bool Zone { get; set; }
    public string ZoneText { get; set; }
    /// <summary>
    /// Class css de la zone definis par le site (Tempalte : ZONE-PO-TAILLE)
    /// </summary>
    public string ZoneClass { get; set; }
    public string PO { get; set; }
    public string Cout { get; set; }
    public string ElemDegats { get; set; }
    public string Effets { get; set; }
}

public class Monstre
{
    public string Nom { get; set; }
    public string Archetype { get; set; }
    public bool Boss { get; set; }
    public List<string> ResistanceBasse { get; set; }

    public List<Sort> sorts { get; set; }
}

public class Salle
{
    public bool Boss { get; set; }
    public string Compo { get; set; }
}

public class Donjon
{
    public List<Salle> Salles { get; set; }
}

public class Drop
{
    public string IdDrop { get; set; }
    public string UrlImageDrop { get; set; }
}

public class Exploit
{
    public string Nom { get; set; }
    public int NbJeton { get; set; }
    public string TypeJetons { get; set; }
}

public class TemplateDonjon
{
    public string Nom { get; set; }
    public string NomDonjonUrl { get; set; }
    public string ZonePrecise { get; set; }
    public string ZonePrincipale { get; set; }
    public List<Monstre> Monstres { get; set; }
    public Donjon Donjon { get; set; }
    public string Strategie { get; set; }
    public List<Drop> Drops { get; set; }
    public Exploit Exploit { get; set; }
}


