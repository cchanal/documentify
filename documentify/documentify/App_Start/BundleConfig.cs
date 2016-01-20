using System.Web;
using System.Web.Optimization;

namespace documentify
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération (bluid) sur http://modernizr.com pour choisir uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/froalaJS").Include(
                      "~/Scripts/froala/froala_editor.min.js",
                      "~/Scripts/froala/plugins/align.min.js",
                      "~/Scripts/froala/plugins/char_counter.min.js",
                      "~/Scripts/froala/plugins/code_view.min.js",
                      "~/Scripts/froala/plugins/colors.min.js",
                      "~/Scripts/froala/plugins/emoticons.min.js",
                      "~/Scripts/froala/plugins/entities.min.js",
                      "~/Scripts/froala/plugins/file.min.js",
                      "~/Scripts/froala/plugins/font_family.min.js",
                      "~/Scripts/froala/plugins/font_size.min.js",
                      "~/Scripts/froala/plugins/fullscreen.min.js",
                      "~/Scripts/froala/plugins/image.min.js",
                      "~/Scripts/froala/plugins/image_manager.min.js",
                      "~/Scripts/froala/plugins/inline_style.min.js",
                      "~/Scripts/froala/plugins/line_breaker.min.js",
                      "~/Scripts/froala/plugins/link.min.js",
                      "~/Scripts/froala/plugins/lists.min.js",
                      "~/Scripts/froala/plugins/paragraph_format.min.js",
                      "~/Scripts/froala/plugins/paragraph_style.min.js",
                      "~/Scripts/froala/plugins/quote.min.js",
                      "~/Scripts/froala/plugins/table.min.js",
                      "~/Scripts/froala/plugins/save.min.js",
                      "~/Scripts/froala/plugins/url.min.js",
                      "~/Scripts/froala/plugins/video.min.js",
                      "~/Scripts/froala/languages/fr.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/froalaCSS").Include(
                      "~/Content/froala/froala_editor.css",
                      "~/Content/froala/froala_style.css",
                      "~/Content/froala/plugins/char_counter.min.css",
                      "~/Content/froala/plugins/code_view.min.css",
                      "~/Content/froala/plugins/colors.min.css",
                      "~/Content/froala/plugins/emoticons.min.css",
                      "~/Content/froala/plugins/file.min.css",
                      "~/Content/froala/plugins/fullscreen.min.css",
                      "~/Content/froala/plugins/image.min.css",
                      "~/Content/froala/plugins/image_manager.min.css",
                      "~/Content/froala/plugins/line_breaker.min.css",
                      "~/Content/froala/plugins/table.min.css",
                      "~/Content/froala/plugins/video.min.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/style.css"));

            // Définissez EnableOptimizations sur False pour le débogage. Pour plus d'informations,
            // visitez http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
