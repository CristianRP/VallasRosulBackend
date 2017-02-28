using System.Web;
using System.Web.Optimization;

namespace AdminLteMvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                      "~/Scripts/knockout-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/visitas").Include(
                       "~/Scripts/VisitasPublicidad.js"));


            bundles.Add(new ScriptBundle("~/bundles/visitasDetalle").Include(
                       "~/Scripts/VistaDetalleVisita.js"));

            bundles.Add(new ScriptBundle("~/bundles/MapaProyecto").Include(
                  "~/Scripts/BusquedaPorMapaJS.js"));



            bundles.Add(new ScriptBundle("~/bundles/ContratosVistaSP").Include(
                    "~/Scripts/ContratosPagosJS.js"));


            bundles.Add(new ScriptBundle("~/bundles/VistaPagosContratoSP").Include(
                    "~/Scripts/VistaPagosContratoJS.js"));


            bundles.Add(new ScriptBundle("~/bundles/MapaGoogle").Include(
                    "~/Scripts/Mapa.js"));

            bundles.Add(new ScriptBundle("~/bundles/loginjs").Include(
                        "~/Scripts/login.js"));

            bundles.Add(new StyleBundle("~/Content/logincss").Include(
                        "~/Content/loginStyle.css"));

              

            bundles.Add(new ScriptBundle("~/bundles/GeoposicionJavaScript").Include(
                   "~/Scripts/GeoposicionJS.js"));



            bundles.Add(new ScriptBundle("~/bundles/GeoposicionContratoJavaScript").Include(
       "~/Scripts/AdminLTE/GeoposicionContratoJS.js"));


        }
    }
}
