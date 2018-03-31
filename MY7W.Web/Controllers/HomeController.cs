using System;
using System.Collections.Generic;
using System.Linq;
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
                var temp = AutoMapper.Mapper.Map<List<MY7W.Web.Models.UserInfoViewModel>>(userService.ExecuteQuertAll());

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
        public ActionResult Create(MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto model)
        {
            try
            {
                // TODO: Add insert logic here
                if (userService.ExecuteInsertModel(model))
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
