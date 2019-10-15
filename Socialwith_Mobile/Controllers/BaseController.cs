using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialWith.Biz.DistCss;
using SocialWith.Biz.User;
using SocialWith.Core;
using SocialWith.Data.DistCSS;
using SocialWith.Data.User;

namespace Socialwith_Mobile.Controllers
{
    public class BaseController : Controller
    {
        protected UserService userService = new UserService();
        protected DistCssService distCssService = new DistCssService();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.UploadFolder = ConfigurationManager.AppSettings["UpLoadFolder"].AsText();
            string url = Request.Url.Host; //현재 url 갖고온다(d-uri 체크)
            if (url.Trim().StartsWith("www"))
            {
                url = url.Trim().Split('.')[1];
            }
            else
            {
                url = url.Trim().Split('.')[0];
            }


            filterContext.Controller.ViewBag.SiteName = url;
            filterContext.Controller.ViewBag.SvidUser = Svid_User;
            filterContext.Controller.ViewBag.DistBrowserTag = DistCssObject.BrowserTag;
            filterContext.Controller.ViewBag.DistCssPath = DistCssObject.CssPath;
            filterContext.Controller.ViewBag.DistLoginTopBannerPath = DistCssObject.LoginTopBannerPath;
            filterContext.Controller.ViewBag.DistLoginCopyrightPath = DistCssObject.LoginCopyrightPath;
            filterContext.Controller.ViewBag.DistLoginCompnayLogoPath = DistCssObject.LoginCompnayLogoPath;
        }

        //로그인 계정 아이디(세션)
        private string _userId;
        public string UserId
        {
            get
            {

                if (Request.Cookies["LoginID"] != null && Request.Cookies["LoginID"].Value.ToString().Length > 0)
                {
                    return _userId = Request.Cookies["LoginID"].Value.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                _userId = value;
            }
        }

        private string _svid_user;
        public string Svid_User
        {
            get
            {

                if (Request.Cookies["Svid_User"] != null && Request.Cookies["Svid_User"].Value.ToString().Length > 0)
                {
                    return _svid_user = Request.Cookies["Svid_User"].Value.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                _svid_user = value;
            }
        }

        private string _siteName;
        public string SiteName
        {
            get
            {
                string url = Request.Url.Host;
                if (url.Trim().StartsWith("www"))
                {
                    url = url.Trim().Split('.')[1];
                }
                else
                {
                    url = url.Trim().Split('.')[0];
                }

                return _siteName = url;
            }
            set
            {
                _siteName = value;
            }
        }

        private UserDTO _user;
        public UserDTO UserInfoObject
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(UserId))
                {
                    var paramList = new Dictionary<string, object>() {
                    {"nvar_P_ID", UserId}
                };
                    return _user = userService.GetUser(paramList);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _user = value;
            }
        }

        private DistCssInfo _distCss;
        public DistCssInfo DistCssObject
        {

            get
            {
                string url = Request.Url.Host;
                string siteType = ConfigurationManager.AppSettings["SiteType"].AsText("LocalHost");
                string saleCompCode = UserInfoObject != null ? UserInfoObject.UserInfo.SaleCompCode.AsText() : "";
                string buyCompCode = UserInfoObject != null ? UserInfoObject.UserInfo.Company_Code.AsText() : "";
                string rmpCode = UserInfoObject != null ? UserInfoObject.UserInfo.RmpCompany_Code.AsText() : "";

                if (!url.StartsWith("www") && siteType != "TestServer")
                {
                    if (url.Split('.').Length <= 2) //심사중인 판매사 서브도메인은 www안붙임
                    {
                        url = "www." + Request.Url.Host;
                    }

                }

                var paramList = new Dictionary<string, object>() {
                    { "nvar_P_URL", url},
                    { "nvar_P_RMPCOMPCODE", rmpCode},
                    { "nvar_P_SALECOMPCODE",saleCompCode},
                    { "nvar_P_BUYCOMPCODE", buyCompCode},
                };
                return _distCss = distCssService.GetSiteDistCssInfo(paramList);
            }
            set
            {
                _distCss = value;
            }
        }
    }
}