using MY7W.Application;
using MY7W.ModelDto.Dto;
using MY7W.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY7W.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserInfoViewModel model)
        {
            UserInfoService userInfoService = new UserInfoService();
            var tempuser = AutoMapper.Mapper.Map<MY7W.ModelDto.Dto.UserInfoDto>(model);
            tempuser = userInfoService.ExecuteQuertAll(tempuser);
            if (tempuser != null)
            {
                HttpContext.Session[tempuser.Id.ToString()] = tempuser;
                HttpCookie cookie = new HttpCookie("UserID", tempuser.Id.ToString());
                HttpContext.Response.Cookies.Add(cookie);

                var openurl = HttpContext.Request.QueryString["fromurl"];
                if (openurl != null)
                {
                    return this.RedirectToAction(openurl.Split('/')[1], openurl.Split('/')[0]);
                }
            }

            return this.RedirectToAction("Index", "Home");
        }


        public ActionResult ShowRoleToUser(string id)
        {
            //TODO:一个razor页面如何操作多个复杂类型
            Guid uerid = Guid.Empty;
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out uerid))
            {
                this.RedirectToAction("Index", "Home", new { message = "传入id为空或有误，请检查" });
            }

            UserInfoService userInfoService = new UserInfoService();
            SysRoleServices sysRoleServices = new SysRoleServices();
            var userRole = userInfoService.ExecuteQuertRoleOfUser(uerid);
            var allRole = sysRoleServices.GetRole();
            foreach (var item in userRole)
            {
               allRole.Where(t => t.Id == item.Id).First().State = true;
            }
            //未完成：如何过滤存在情况
            ViewBag.AllRole = allRole;
            return View(userRole);

        }

        #region Role
        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole(SysRoleDto model)
        {
            SysRoleServices sysRoleServices = new SysRoleServices();
            var result = sysRoleServices.InertModel(model);
            return View("RoleIndex");
        }

        public ActionResult RoleIndex()
        {
            SysRoleServices sysRoleServices = new SysRoleServices();
            return View(sysRoleServices.GetRole());
        }
        #endregion

        public ActionResult LoginOut(string guid)
        {
            Session["123"] = 123;
            HttpContext.Session.Remove(guid);
            return View("Login");
        }
    }
}