﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MethodWakfuGuideWriter.Properties {
    using System;
    
    
    /// <summary>
    ///   Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.
    /// </summary>
    // Cette classe a été générée automatiquement par la classe StronglyTypedResourceBuilder
    // à l'aide d'un outil, tel que ResGen ou Visual Studio.
    // Pour ajouter ou supprimer un membre, modifiez votre fichier .ResX, puis réexécutez ResGen
    // avec l'option /str ou régénérez votre projet VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Retourne l'instance ResourceManager mise en cache utilisée par cette classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MethodWakfuGuideWriter.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Remplace la propriété CurrentUICulture du thread actuel pour toutes
        ///   les recherches de ressources à l'aide de cette classe de ressource fortement typée.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à &lt;!-- wp:paragraph --&gt;
        ///&lt;p&gt;&lt;em&gt;Astuce : Le NOM_DU_DONJON se trouve&lt;strong&gt; ZONE_PRECISE&lt;/strong&gt;, au POINT_CARDINAL de ZONE_PRINCIPALE.&lt;/em&gt;&lt;/p&gt;
        ///&lt;!-- /wp:paragraph --&gt;
        ///
        ///&lt;!-- wp:image {&quot;id&quot;:9182,&quot;sizeSlug&quot;:&quot;large&quot;} --&gt;
        ///&lt;figure class=&quot;wp-block-image size-large&quot;&gt;&lt;img src=&quot;https://methodwakfu.com/wp-content/uploads/2020/11/petit_cadre-1024x291.png&quot; alt=&quot;&quot; class=&quot;wp-image-9182&quot;/&gt;&lt;/figure&gt;
        ///&lt;!-- /wp:image --&gt;
        ///
        ///&lt;!-- wp:separator --&gt;
        ///&lt;hr class=&quot;wp-block-separator&quot;/&gt;
        ///&lt;!-- /wp:separator --&gt;
        ///
        ///&lt;!-- wp:paragrap [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        public static string TemplateGlobal {
            get {
                return ResourceManager.GetString("TemplateGlobal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à &lt;!-- wp:list --&gt;
        ///&lt;ul&gt;&lt;li&gt;« &lt;strong&gt;NomDuSort&lt;/strong&gt; » : Sort monocible (X-X PO [modifiable] [condition : en ligne/en diagonale] [sans ligne de vue]), pour X PA. Inflige des [lourds] dégâts &lt;strong&gt;&lt;span style=&quot;color:#CODE_HEXA&quot;&gt;ELEM&lt;/span&gt;&lt;/strong&gt;et EFFETS. [Limité à X/cible et à X/tour. &lt;strong&gt;OU&lt;/strong&gt; X tours de relance.]&lt;/li&gt;&lt;/ul&gt;
        ///&lt;!-- /wp:list --&gt;.
        /// </summary>
        public static string TemplateMono {
            get {
                return ResourceManager.GetString("TemplateMono", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à 
        ///&lt;!-- wp:heading {&quot;level&quot;:3} --&gt;
        ///&lt;h3&gt;&lt;strong&gt;Num_Monstre - &lt;/strong&gt;Nom_du_Monstre&lt;/h3&gt;
        ///&lt;!-- /wp:heading --&gt;
        ///
        ///&lt;div style=&quot;max-width:35%;float:right; margin-left:10px;text-align:center;&quot;&gt;&lt;img src=&quot;https://methodwakfu.com/wp-content/uploads/2020/06/fiche_monstre.png&quot;&gt;
        ///&lt;div style&quot;clear:both;&quot;=&quot;&quot;&gt;&lt;/div&gt;&lt;img src=&quot;https://methodwakfu.com/wp-content/uploads/2020/06/achetype_base.png&quot;&gt;&lt;/div&gt;
        ///
        ///&lt;!-- wp:paragraph --&gt;
        ///&lt;p&gt;Il possède XXX sorts, XXX passifs et sa plus basse résistance est l&apos;élément &lt;strong&gt;ELEM &lt; [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        public static string TemplateMonstre {
            get {
                return ResourceManager.GetString("TemplateMonstre", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à 
        ///&lt;!-- wp:heading {&quot;level&quot;:3} --&gt;
        ///&lt;h3&gt;&lt;strong&gt;2.1 - &lt;/strong&gt;Num_Salle&lt;/h3&gt;
        ///&lt;!-- /wp:heading --&gt;
        ///
        ///&lt;!-- wp:html --&gt;
        ///&lt;figure class=&quot;wp-block-image diapo1&quot;&gt;&lt;img src=&quot;URL_SANS_VUE_TACTIQUE&quot; alt=&quot;&quot;&gt;&lt;figcaption&gt;&lt;strong&gt;Composition :&amp;nbsp;&lt;/strong&gt;Xx NomDuMonstre, Xx NomDuMonstre, Xx NomDuMonstre&lt;/figcaption&gt;&lt;/figure&gt;
        ///&lt;!-- /wp:html --&gt;
        ///
        ///&lt;!-- wp:html --&gt;
        ///&lt;script&gt;
        ///    document.getElementsByClassName(&quot;diapo1&quot;)[0].firstChild.onmouseenter = function() {
        ///        document.getElementsByClassName(&quot;diapo1&quot;)[0].fi [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        public static string TemplateSalle {
            get {
                return ResourceManager.GetString("TemplateSalle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à [TemplateMono]
        ///
        ///[TemplateZone]
        ///
        ///&lt;!-- wp:html --&gt;
        ///&lt;ul&gt;
        ///&lt;li&gt;
        ///« &lt;strong&gt;NomDuPassifouEtat&lt;/strong&gt; » (passif) :&lt;/br&gt;
        ///DECLENCHEMENT :&lt;/br&gt;
        ///&lt;ul&gt;
        ///&lt;li&gt;EFFETS&lt;/li&gt;
        ///&lt;li&gt;EFFETS&lt;/li&gt;
        ///&lt;/ul&gt;
        ///&lt;/li&gt;
        ///&lt;/ul&gt;
        ///&lt;!-- /wp:html --&gt;.
        /// </summary>
        public static string TemplateSort {
            get {
                return ResourceManager.GetString("TemplateSort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à &lt;!-- wp:html --&gt;
        ///&lt;ul&gt;
        ///&lt;li&gt;
        ///« &lt;strong&gt;NomDuSort&lt;/strong&gt; » : Sort de zone (&lt;a class=&quot;ZONE-PO-TAILLE&quot;&gt;ZONE&lt;/a&gt; [sur cible] [condition : en ligne/en diagonale] [sans ligne de vue], X-X PO [modifiable]), pour X PA. Inflige des [lourds] dégâts &lt;b&gt;&lt;span style=&quot;color:#CODE_HEXA&quot;&gt;ELEM&lt;/span&gt;&lt;/b&gt; et EFFETS. [Limité à X/cible et à X/tour. OU X tours de relance.]
        ///&lt;/li&gt;
        ///&lt;/ul&gt;
        ///&lt;!-- /wp:html --&gt;.
        /// </summary>
        public static string TemplateZone {
            get {
                return ResourceManager.GetString("TemplateZone", resourceCulture);
            }
        }
    }
}
