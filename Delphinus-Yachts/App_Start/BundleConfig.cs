using System.Web;
using System.Web.Optimization;

namespace Delphinus_Yachts
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/dependencies").Include(
                "~/Client/Dependencies/Scripts/jquery-{version}.js",
                "~/Client/Dependencies/Scripts/jquery.validate*",
                "~/Client/Dependencies/Scripts/modernizr-*",
                "~/Client/Dependencies/Scripts/bootstrap.js",
                "~/Client/Dependencies/Scripts/respond.js",
                "~/Client/Dependencies/Scripts/vue-tables-2.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css"));
        }
    }
}
