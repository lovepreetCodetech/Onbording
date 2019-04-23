using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Onbording.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onbording.Controllers
{
    public class StoreController : Controller
    {
		public ReactContext Db;
		public StoreController()
		{
			
			Db = new ReactContext();
		}
		protected override void Dispose(bool disposing)
		{
			Db.Dispose();
		}
		

		//GET: Store
		public ActionResult Index()
		{
				
			return View();
			
		}
		public JsonResult GetStore()
		{

			var Storelist = Db.Stores.ToList();
			return new JsonResult { Data = Storelist, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

		}
		//CREATE Store
		public JsonResult CreateStore(store sto)
		{
			if (ModelState.IsValid)
			{
				Db.Stores.Add(sto);
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

		//Delete Store
		public JsonResult DelStore(int id)
		{
			try
			{
				using (ReactContext dBContext = new ReactContext())
				{
					store Record = dBContext.Stores.Where(x => x.Id == id).FirstOrDefault();
					if (Record != null)
					{
						dBContext.Stores.Remove(Record);
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
			store UpdatedRec = Db.Stores.Find(id);
			return new JsonResult { Data = UpdatedRec, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

		}

	
		//Update Store
		public JsonResult UpdatedRec(store rec)
		{

			try
			{
				store UpdatedRec = Db.Stores.Find(rec.Id);
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