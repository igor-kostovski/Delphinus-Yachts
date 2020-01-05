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
                "~/Client/Dependencies/Scripts/vue.min.js",
                "~/Client/Dependencies/Scripts/axios.min.js",
                "~/Client/Dependencies/Scripts/vue-bootstrap4-table.min.js",
                "~/Client/Dependencies/Scripts/moment.min.js",
                "~/Client/Dependencies/Scripts/bootstrap-datetimepicker.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/style-scripts").Include(
                "~/Content/vendor/jquery/jquery.min.js",
                "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/vendor/jquery-easing/jquery.easing.min.js",
                "~/Content/js/sb-admin-2.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/src").Include(
                "~/Client/Src/Constants.js",
                "~/Client/Src/Enums.js",
                "~/Client/Src/Utils.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-datetimepicker.css"));

            bundles.Add(new ScriptBundle("~/bundles/bookings/Index").Include(
                "~/Client/Src/ViewModels/Booking/list.vm.js",
                "~/Client/Src/Components/SearchBox.vm.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bookings/Edit").Include(
                "~/Client/Src/ViewModels/Booking/edit.vm.js"
            ));
        }
    }
}
