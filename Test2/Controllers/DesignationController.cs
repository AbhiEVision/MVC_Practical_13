using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Test2.Data;
using Test2.Models;

namespace Test2.Controllers
{
	public class DesignationController : Controller
	{
		private DatabaseContext db = new DatabaseContext();

		public ActionResult Index()
		{
			return View(db.Designations.ToList());
		}

		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return View("Error");
			}
			Designations designations = db.Designations.Find(id);
			if (designations == null)
			{
				return View("Error");
			}
			return View(designations);
		}
		public ActionResult Create()
		{
			return View(new Designations());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Designation")] Designations designations)
		{
			if (ModelState.IsValid)
			{
				db.Designations.Add(designations);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(designations);
		}

		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return View("Error");
			}
			Designations designations = db.Designations.Find(id);
			if (designations == null)
			{
				return View("Error");
			}
			return View(designations);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Designation")] Designations designations)
		{
			if (ModelState.IsValid)
			{
				db.Entry(designations).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(designations);
		}

		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return View("Error");
			}
			Designations designations = db.Designations.Find(id);
			if (designations == null)
			{
				return View("Error");
			}
			return View(designations);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Designations designations = db.Designations.Find(id);
			db.Designations.Remove(designations);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}
