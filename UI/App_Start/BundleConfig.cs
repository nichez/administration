using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Itc.Am.UI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js").Include(
                "~/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/js").Include(
                "~/js/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/js").Include(
                "~/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/js").Include(
                "~/js/bootstrap.min.js",
                "~/js/respond.js"));

            bundles.Add(new StyleBundle("~/css").Include(
                "~/css/bootstrap.css",
                "~/css/site.css",
                "~/css/registerpage.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}