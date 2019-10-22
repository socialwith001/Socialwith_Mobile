using System.Web;
using System.Web.Optimization;

namespace Socialwith_Mobile
{
    public class BundleConfig
    {
        // 묶음에 대한 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=301862를 참조하세요.
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Modernizr의 개발 버전을 사용하여 개발하고 배우십시오. 그런 다음
            // 프로덕션에 사용할 준비를 하고 https://modernizr.com의 빌드 도구를 사용하여 필요한 테스트만 선택하세요.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

           // bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
               //       "~/Scripts/bootstrap.js"));
  
            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                     "~/Scripts/jquery-3.3.1.js",
                     "~/Scripts/jquery-3.3.1.min.js",
                     "~/Scripts/jquery.bxslider.min.js",
                     "~/Scripts/horizontal.js",
                     "~/Scripts/sly.min.js",
                     //"~/Scripts/common.js",
                     "~/Scripts/basic.js"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/jquery-ui-1.12.1.min.css",
                      //"~/Content/bootstrap.css",
                      "~/Content/jquery.bxslider.css",
                      //"~/Content/Site.css",
                      "~/Content/default.css",
                      "~/Content/common.css",
                      "~/Content/login.css"));
        }
    }
}
