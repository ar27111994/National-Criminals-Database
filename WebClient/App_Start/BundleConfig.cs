using System.Web;
using System.Web.Optimization;

namespace WebUIClient
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/FrontEnd/jquery/dist/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/FrontEnd/jquery-validation/dist/jquery.validate.js",
                        "~/Content/FrontEnd/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js",
                        "~/Content/FrontEnd/jquery-ajax-unobtrusive/jquery.unobtrusive-ajax.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                                  "~/Content/FrontEnd/bootstrap/dist/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/FrontEnd/bootstrap/dist/css/bootstrap.css",
                      "~/Content/FrontEnd/custom/css/Site.css"));
        }
    }
}
