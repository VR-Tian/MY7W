using MY7W.Application;
using MY7W.ModelDto.Dto;
using MY7W.Tools.Cache;
using MY7W.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY7W.Web.App_Start
{
    ///TODO:
    public class RBACAuthAttribute : AuthorizeAttribute
    {
        private bool IsLogin;
        private bool IsPass;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            return IsPass;
        }


        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            IsLogin = false;
            IsPass = false;
            var cookie = filterContext.HttpContext.Request.Cookies.Get("UserID");
            if (cookie!=null )
            {
                var websession = filterContext.HttpContext.Session[cookie.Value];
                if (websession == null)
                {
                    filterContext.HttpContext.Response.StatusCode = 401;//无权限状态码
                }
                else
                {
                    var user = websession as UserInfoDto;
                    if (user == null)
                    {
                        filterContext.HttpContext.Response.StatusCode = 401;//无权限状态码
                        IsPass = false;
                        IsLogin = false;
                    }
                    else if (!CheckUserRole(filterContext, user))
                    {
                        filterContext.HttpContext.Response.StatusCode = 401;//无权限状态码
                        IsPass = false;
                        IsLogin = true;
                    }
                    else
                    {
                        IsPass = true;
                    }
                }
            }
            base.OnAuthorization(filterContext);
        }

        private bool CheckUserRole(AuthorizationContext filterContext, UserInfoDto user)
        {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string action = filterContext.ActionDescriptor.ActionName;
            SysUserServices sysUserServices = new SysUserServices();
            var sysAccesses = sysUserServices.GetRoleOfUser(null);
            foreach (var item in sysAccesses)
            {
                var result = item.URL.Equals(string.Format("{0}/{1}", controller, action));
                if (result)
                {
                    return result;
                }
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            else
            {
                if (!IsLogin)
                {
                    string fromUrl = filterContext.HttpContext.Request.Url.PathAndQuery;
                    string strUrl = "~/Account/Login/?fromurl={0}";
                    filterContext.HttpContext.Response.Redirect(string.Format(strUrl, fromUrl), true);
                    //RedirectToRouteResult
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Account/NoPremission");
                }

            }
        }
    }
}