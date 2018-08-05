using MY7W.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MY7W.Web.Controllers
{
    public class HomeController : Controller
    {
        private MY7W.Application.UserInfoService userService;
        public HomeController()
        {
            userService = new Application.UserInfoService();
        }
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                var allmodel = userService.ExecuteQuertAll();
                //var orderList = allmodel[0].OrderInfo.ToList();
                var temp = AutoMapper.Mapper.Map<List<MY7W.Web.Models.UserInfoViewModel>>(allmodel);
                return View(temp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET: Home/Details/5
        public ActionResult Details(string name)
        {
            //var temp = userService.ExecuteQuertAll(t => t.Name == name).FirstOrDefault();

            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(UserInfoViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (userService.ExecuteInsertModel(AutoMapper.Mapper.Map<MY7W.ModelDto.Dto.UserInfoDto>(model)))
                {
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(string id)
        {
            var model = AutoMapper.Mapper.Map<UserInfoViewModel>(userService.ExecuteQuertAll(id).FirstOrDefault());
            return View(model);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(UserInfoViewModel model)
        {
            try
            {
                if (userService.ExecuteQuertAll(model.Id).FirstOrDefault()==null)
                {
                    return Content("找不到相关数据");
                }
                userService.ExcuteUpdateModel(AutoMapper.Mapper.Map<MY7W.ModelDto.Dto.UserInfoDto>(model));

                return Redirect("/Home/Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
