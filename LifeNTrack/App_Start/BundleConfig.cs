using System.Web;
using System.Web.Optimization;

namespace LifeNTrack
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/jspublic").Include(
                    "~/Scripts/public/jquery-{version}.min.js",
                    "~/Scripts/bootsrap.min.js",
                    "~/Scripts/public/owl-carousel.js",
                    "~/Scripts/public/animation.js",
                    "~/Scripts/public/imagesloaded.js",
                    "~/Scripts/public/popup.js",
                    "~/Scripts/public/custom.js",
                    "~/Scripts/public/loginRegister.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                   "~/Scripts/main.js",
                   "~/Scripts/user.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"));



            bundles.Add(new StyleBundle("~/Content/public").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/animated.css",
                      "~/Content/fontawesome.css",
                      "~/Content/loginRegister.css",
                      "~/Content/owl.css",
                      "~/Content/templatemo-chain-app-dev.css"));

            bundles.Add(new StyleBundle("~/Content/style").Include(
                      "~/Content/bootstrap.min.css",
                    "~/Content/bootstrap-icons/bootstrap-icons.css",
                     "~/Content/style.css"));
        }
    }
}
