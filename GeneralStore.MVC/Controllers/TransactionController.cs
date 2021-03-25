using GeneralStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneralStore.MVC.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Transaction
        public ActionResult Index()
        {
            List<TransactionListItem> transactions = _db.Transactions.Select(t => new TransactionListItem()
            {
                CustomerName = t.Customer.LastName,
                ProductName = t.Product.Name,
                Quantity = t.Quantity,
                DateOfTransaction = t.DateOfTransaction
            }).ToList();
            return View(transactions);
        }

        // GET: Transaction
        public ActionResult Create()
        {
            TransactionCreate model = new TransactionCreate();

            var products = _db.Products.ToArray();



            model.Products = new SelectList(products, "ProductId", "Name");

            // model.Products = (SelectList) products.Select(p => new SelectListItem() { Value = p.ProductId.ToString(), Text = p.Name });




            model.CustomerId = 1;
            return View(model);
        }

        // POST: Transaction
        [HttpPost]
        public ActionResult Create(TransactionCreate model)
        {
            if (ModelState.IsValid)
            {
                Transaction transaction = new Transaction()
                {
                    ProductId = model.ProductId,
                    CustomerId = model.CustomerId,
                    Quantity = model.Quantity,
                    DateOfTransaction = DateTimeOffset.Now
                };
                _db.Transactions.Add(transaction);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}