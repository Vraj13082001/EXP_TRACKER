using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class TotalExpenseLimitController : Controller
    {
        // GET: TotalExpenseLimit
        public ActionResult Index()
        {
            IEnumerable<mvcTotalExpenseLimit> TotalExpenseLimitList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TotalExpenseLimit").Result;
            TotalExpenseLimitList = response.Content.ReadAsAsync<IEnumerable<mvcTotalExpenseLimit>>().Result;
            return View(TotalExpenseLimitList);
            //return View();
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcTotalExpenseLimit());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TotalExpenseLimit/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcTotalExpenseLimit>().Result);
            }
            //return View(new mvcExpenseLimitModel());
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcTotalExpenseLimit TotalExpLimit)
        {
            if (TotalExpLimit.TotalExpenseId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("TotalExpenseLimit", TotalExpLimit).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("TotalExpenseLimit/" + TotalExpLimit.TotalExpenseId, TotalExpLimit).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
            //return View();
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("TotalExpenseLimit/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }


    }
}
