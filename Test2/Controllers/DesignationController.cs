using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Test2.Data;
using Test2.Models;

namespace Test2.Controllers
{
	public class DesignationController : Controller
	{
		private DatabaseContext db = new DatabaseContext();

		// GET: Designation
		public ActionResult Index()
		{
			return View(db.Designations.ToList());
		}

		// GET: Designation/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Designations designations = db.Designations.Find(id);
			if (designations == null)
			{
				return HttpNotFound();
			}
			return View(designations);
		}

		// GET: Designation/Create
		public ActionResult Create()
		{
			return View(new Designations());
		}

		// POST: Designation/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

		// GET: Designation/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Designations designations = db.Designations.Find(id);
			if (designations == null)
			{
				return HttpNotFound();
			}
			return View(designations);
		}

		// POST: Designation/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

		// GET: Designation/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Designations designations = db.Designations.Find(id);
			if (designations == null)
			{
				return HttpNotFound();
			}
			return View(designations);
		}

		// POST: Designation/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Designations designations = db.Designations.Find(id);
			db.Designations.Remove(designations);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
