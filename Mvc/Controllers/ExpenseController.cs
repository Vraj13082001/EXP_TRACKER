using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        public ActionResult Index()
        {
         

            IEnumerable<mvcExpenseModel> ExpenseList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Expense").Result;
            ExpenseList = response.Content.ReadAsAsync<IEnumerable<mvcExpenseModel>>().Result;
            return View(ExpenseList);
            //return View();
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcExpenseModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Expense/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcExpenseModel>().Result);
            }
            //return View(new mvcExpenseModel());
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcExpenseModel Exp)
        {
            if (Exp.ExpenseId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Expense", Exp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Expense/" + Exp.ExpenseId, Exp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Expense/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}