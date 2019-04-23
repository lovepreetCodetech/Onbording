using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Onbording.Models;

namespace Onbording.Controllers
{
	public class ProductController : Controller
	{
		public ReactContext Db;
		public ProductController()
		{
			Db = new ReactContext();
		}
		protected override void Dispose(bool disposing)
		{
			Db.Dispose();
		}

		// GET: Product
		public ActionResult Index()
		{
			return View();
		}
		public JsonResult GetProduct()
		{

			var productlist = Db.Products.ToList();
			return new JsonResult { Data = productlist, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
			//return null;
		}

		//CREATE Product
		public JsonResult CreateProduct(Product prod)
		{
			if (ModelState.IsValid)
			{
				Db.Products.Add(prod);
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
		public JsonResult DelProducts(int id)
		{
			try
			{
				using (ReactContext dBContext = new ReactContext())
				{
					Product Record = dBContext.Products.Where(x => x.Id == id).FirstOrDefault();
					if (Record != null)
					{
						dBContext.Products.Remove(Record);
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
			Product UpdatedRec = Db.Products.Find(id);
			return new JsonResult { Data = UpdatedRec, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

		}


		public JsonResult UpdatedRec(Product rec)
		{

			try
			{
				Product UpdatedRec = Db.Products.Find(rec.Id);
				UpdatedRec.Name = rec.Name;
				UpdatedRec.Price = rec.Price;
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


