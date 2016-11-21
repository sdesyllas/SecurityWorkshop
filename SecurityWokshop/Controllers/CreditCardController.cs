using System;
using System.Configuration;
using System.Web.Mvc;
using SecurityWokshop.DataAccess;
using SecurityWokshop.Models;

namespace SecurityWokshop.Controllers
{
    public class CreditCardController : Controller
    {
        // GET: CreditCard
        public ActionResult Index()
        {
            var dataAccess = new CreditCardRepo(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            var model = dataAccess.GetAllCards();
            return View(model);
        }

        // GET: CreditCard/Details/5
        public ActionResult Details(int id)
        {
            var creditCardRepo = new CreditCardRepo(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            var model = creditCardRepo.GetCard(id);
            return View(model);
        }

        // GET: CreditCard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreditCard/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CreditCardModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var creditCardRepo =
                        new CreditCardRepo(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                    creditCardRepo.AddCard(model);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CreditCard/Edit/5
        public ActionResult Edit(int id)
        {
            var creditCardRepo = new CreditCardRepo(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            var model = creditCardRepo.GetCard(id);
            return View(model);
        }

        // POST: CreditCard/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, CreditCardModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var creditCardRepo =
                        new CreditCardRepo(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                    creditCardRepo.UpdateCard(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: CreditCard/Delete/5
        public ActionResult Delete(int id)
        {
            var creditCardRepo = new CreditCardRepo(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            var model = creditCardRepo.GetCard(id);
            return View(model);
        }

        // POST: CreditCard/Delete/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                var creditCardRepo = new CreditCardRepo(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                creditCardRepo.DeleteCard(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}