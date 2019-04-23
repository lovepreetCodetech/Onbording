using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Onbording.Models;

namespace Onbording.Controllers
{
	public class CustomerController : Controller
	{

		public ReactContext Db;
		public CustomerController()
		{
			 Db = new ReactContext();
		}
		protected override void Dispose(bool disposing)
		{
			Db.Dispose();
		}

		// GET: Customer
		public ActionResult Index()
		{
			return View();
		}
		public JsonResult GetCustomer()
		{

			var customerlist = Db.Customer.ToList();
				return new JsonResult { Data = customerlist, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
			
		}

		//CREATE customer
		public JsonResult CreateCustomers(Customer cust)
		{
			if (ModelState.IsValid)
			{
				Db.Customer.Add(cust);
				Db.SaveChanges();
				return new JsonResult { Data = "Sucess", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
			}
			else
			{
				//Console.Write(e.Data + "Exception Occured");
				var modelErrors = new List<string>();
				foreach (var modelState in ModelState.Values)
				{
					foreach (var modelError in modelState.Errors)
					{
						modelErrors.Add(modelError.ErrorMessage);
					}
				}
				return new JsonResult { Data = modelErrors, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
			}

		}

		public JsonResult DelCustomers(int id)
		{
			try
			{
				using (ReactContext dBContext = new ReactContext())
				{
					Customer Record = dBContext.Customer.Where(x => x.Id == id).FirstOrDefault();
					if (Record != null)
					{
						dBContext.Customer.Remove(Record);
						dBContext.SaveChanges();
					}
				}
			}
			catch (Exception e)
			{
				Console.Write(e.Data + "Exception Occured");
				return new JsonResult { Data = "Products Deletion Falied", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
			}

			return new JsonResult { Data = "Sucess", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}
		public JsonResult GetUpdatedRec(int id)
		{
				Customer UpdatedRec = Db.Customer.Find(id);
				return new JsonResult { Data = UpdatedRec, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
			
		}


		public JsonResult UpdatedRec(Customer rec)
		{
			
				try
				{
					Customer UpdatedRec = Db.Customer.Find(rec.Id);
					UpdatedRec.Name = rec.Name;
					UpdatedRec.Address = rec.Address;
					Db.SaveChanges();
				}
				catch (Exception e)
				{
					Console.Write(e.Data + "Exception Occured");
					return new JsonResult { Data = "Products Create Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
				}

			
			return new JsonResult { Data = "Sucess", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}
	}
}
	
