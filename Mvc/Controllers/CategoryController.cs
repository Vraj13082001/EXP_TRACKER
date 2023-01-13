using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            IEnumerable<mvcCategoryModel> CategoryList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Category").Result;
            CategoryList = response.Content.ReadAsAsync<IEnumerable<mvcCategoryModel>>().Result;
            return View(CategoryList);
            //return View();
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcCategoryModel());
            }
            else
            {
                HttpResponseMessage respone = GlobalVariables.WebApiClient.GetAsync("Category/" + id.ToString()).Result;
                return View(respone.Content.ReadAsAsync<mvcCategoryModel>().Result);
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcCategoryModel Cat)
        {
            if (Cat.CategoryId == 0)
            {
                HttpResponseMessage respone = GlobalVariables.WebApiClient.PostAsJsonAsync("Category",Cat).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage respone = GlobalVariables.WebApiClient.PutAsJsonAsync("Category/" + Cat.CategoryId, Cat).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Category/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}