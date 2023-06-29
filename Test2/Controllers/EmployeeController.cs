using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Test2.Data;
using Test2.Models;

namespace Test2.Controllers
{
	public class EmployeeController : Controller
	{
		private DatabaseContext db = new DatabaseContext();

		public ActionResult Index()
		{
			var employees = db.Employees.Include(e => e.Designations);
			return View(employees.ToList());
		}

		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return View("Error");
			}
			Employee employee = db.Employees.Find(id);
			if (employee == null)
			{
				return View("Error");
			}
			return View(employee);
		}

		public ActionResult Create()
		{
			ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Designation");
			return View(new Employee());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,LastName,DOB,MobileNo,Address,Salary,DesignationId")] Employee employee)
		{
			if (ModelState.IsValid)
			{
				db.Employees.Add(employee);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Designation", employee.DesignationId);
			return View(employee);
		}

		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return View("Error");
			}
			Employee employee = db.Employees.Find(id);
			if (employee == null)
			{
				return View("Error");
			}
			ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Designation", employee.DesignationId);
			return View(employee);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,DOB,MobileNo,Address,Salary,DesignationId")] Employee employee)
		{
			if (ModelState.IsValid)
			{
				db.Entry(employee).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Designation", employee.DesignationId);
			return View(employee);
		}

		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return View("Error");
			}
			Employee employee = db.Employees.Find(id);
			if (employee == null)
			{
				return View("Error");
			}
			return View(employee);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Employee employee = db.Employees.Find(id);
			db.Employees.Remove(employee);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult LinqQuery1()
		{
			var employees = db.Employees
				.Join
				(
					db.Designations,
					emp => emp.DesignationId,
					deg => deg.Id,
					(emp, deg) => new EmployeeDetail()
					{
						EmployeeId = emp.Id,
						FirstName = emp.FirstName,
						LastName = emp.LastName,
						MiddleName = emp.MiddleName,
						DesignationName = deg.Designation,
						DOB = emp.DOB,
						MobileNo = emp.MobileNo,
						Address = emp.Address,
						Salary = emp.Salary,
					}
				);
			return View(employees);
		}

		[HttpGet]
		public ActionResult LinqQuery2()
		{
			var result = db.Designations
				.Join(
					db.Employees,
					x => x.Id,
					y => y.DesignationId,
					(deg, emp) => new EmployeeDetail
					{
						EmployeeId = emp.Id,
						FirstName = emp.FirstName,
						LastName = emp.LastName,
						MiddleName = emp.MiddleName,
						DesignationName = deg.Designation,
						DOB = emp.DOB,
						MobileNo = emp.MobileNo,
						Address = emp.Address,
						Salary = emp.Salary,
					}
				).GroupBy(
					emp => emp.DesignationName
				).Select(
					x => new EmployeePerDesignation()
					{
						Key = x.Key,
						Value = x.Count()
					}
				);


			return View(result);
		}
	}
}
