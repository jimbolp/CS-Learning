using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PrintersDataWebMVC.Models;

namespace PrintersDataWebMVC.Controllers
{
    public class PrinterMasterDatasController : Controller
    {
        private PrintersDBContext db = new PrintersDBContext();

        // GET: PrinterMasterDatas
        public ViewResult Index(string sortOrder, string searchString, int page = 1)
        {

            int rows = 20;
            if (page <= 0) page = 1;

            ViewBag.NameSortParm = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewBag.PrintIDSortParm = sortOrder == "printID_asc" ? "printID_desc" : "printID_asc";
            ViewBag.BranchSortParm = sortOrder == "branch_asc"? "branch_desc" : "branch_asc";
            ViewBag.IPAddSortParm = sortOrder == "IPAdd_asc" ? "IPAdd_desc" : "IPAdd_asc";
            ViewBag.PrinterModelSortParm = sortOrder == "PrinterModel_asc" ? "PrinterModel_desc" : "PrinterModel_asc";
            ViewBag.DNSSortParm = sortOrder == "DNS_asc" ? "DNS_desc" : "DNS_asc";
            ViewBag.DescSortParm = sortOrder == "Desc_asc" ? "Desc_desc" : "Desc_asc";
            ViewBag.IDSortParm = string.IsNullOrEmpty(sortOrder) ? "ID_desc" : "";
            ViewBag.TotalPages = Math.Ceiling((double)db.PrinterMasterData.Select(p => p.ID).Count()) / rows;
            ViewBag.CurrentPage = page;

            var printers = db.PrinterMasterData.OrderBy(p => p.ID).Skip((page - 1) * rows).Take(rows);
            //printers = from p in db.PrinterMasterData orderby p.ID select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                page = 1;
                printers = db.PrinterMasterData.Where(s => (s.PrinterName).ToLower().Contains(searchString.ToLower()));
            }
            else
            {

                switch (sortOrder)
                {
                    case "name_desc":
                        printers = db.PrinterMasterData.OrderByDescending(p => p.PrinterName).Skip((page - 1) * rows).Take(rows);
                        break;
                    case "name_asc":
                        printers = db.PrinterMasterData.OrderBy(p => p.PrinterName).Skip((page - 1) * rows).Take(rows);
                        break;
                    case "printID_desc":
                        printers = db.PrinterMasterData.OrderByDescending(p => p.PrintID).Skip((page - 1) * rows).Take(rows);
                        break;
                    case "printID_asc":
                        printers = db.PrinterMasterData.OrderBy(p => p.PrintID).Skip((page - 1) * rows).Take(rows);
                        break;
                    case "branch_desc":
                        printers = db.PrinterMasterData.OrderByDescending(p => p.Branches.BranchName).Skip((page - 1) * rows).Take(rows);
                        break;
                    case "branch_asc":
                        printers = db.PrinterMasterData.OrderBy(p => p.Branches.BranchName).Skip((page - 1) * rows).Take(rows);
                        break;
                    case "IPAdd_desc":
                        printers = db.PrinterMasterData.OrderByDescending(p => p.IPAddress).Skip((page - 1) * rows).Take(rows);
                        break;
                    case "IPAdd_asc":
                        printers = db.PrinterMasterData.OrderBy(p => p.IPAddress).Skip((page - 1) * rows).Take(rows);
                        break;
                    case "PrinterModel_desc":
                        printers = db.PrinterMasterData.OrderByDescending(p => p.PrinterModels.PrinterModel).Skip((page - 1) * rows).Take(rows);
                        break;
                    case "PrinterModel_asc":
                        printers = db.PrinterMasterData.OrderBy(p => p.PrinterModels.PrinterModel).Skip((page - 1) * rows).Take(rows);
                        break;
                    case "DNS_desc":
                        printers = db.PrinterMasterData.OrderByDescending(p => p.DNSName).Skip((page - 1) * rows).Take(rows);
                        break;
                    case "DNS_asc":
                        printers = db.PrinterMasterData.OrderBy(p => p.DNSName).Skip((page - 1) * rows).Take(rows);
                        break;
                    case "Desc_desc":
                        printers = db.PrinterMasterData.OrderByDescending(p => p.Description).Skip((page - 1) * rows).Take(rows);
                        break;
                    case "Desc_asc":
                        printers = db.PrinterMasterData.OrderBy(p => p.Description).Skip((page - 1) * rows).Take(rows);
                        break;
                    case "ID_desc":
                        printers = db.PrinterMasterData.OrderByDescending(p => p.ID).Skip((page - 1) * rows).Take(rows);
                        break;
                    default:
                        printers = db.PrinterMasterData.OrderBy(p => p.ID).Skip((page - 1) * rows).Take(rows);
                        break;
                }
            }  

            return View(printers);
        }

        // GET: PrinterMasterDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrinterMasterData printerMasterData = db.PrinterMasterData.Find(id);
            if (printerMasterData == null)
            {
                return HttpNotFound();
            }
            return View(printerMasterData);
        }

        // GET: PrinterMasterDatas/Create
        public ActionResult Create()
        {
            ViewBag.BranchID = new SelectList(db.Branches, "ID", "BranchName");
            ViewBag.PrinterModeID = new SelectList(db.PrinterModels, "ID", "PrinterModel");
            return View();
        }

        // POST: PrinterMasterDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PrinterName,IPAddress,PrintID,PrinterModeID,BranchID,Description,Active,DNSName")] PrinterMasterData printerMasterData)
        {
            if (ModelState.IsValid)
            {
                db.PrinterMasterData.Add(printerMasterData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchID = new SelectList(db.Branches, "ID", "BranchName", printerMasterData.BranchID);
            ViewBag.PrinterModeID = new SelectList(db.PrinterModels, "ID", "PrinterModel", printerMasterData.PrinterModeID);
            return View(printerMasterData);
        }

        // GET: PrinterMasterDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrinterMasterData printerMasterData = db.PrinterMasterData.Find(id);
            if (printerMasterData == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchID = new SelectList(db.Branches, "ID", "BranchName", printerMasterData.BranchID);
            ViewBag.PrinterModeID = new SelectList(db.PrinterModels, "ID", "PrinterModel", printerMasterData.PrinterModeID);
            return View(printerMasterData);
        }

        // POST: PrinterMasterDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PrinterName,IPAddress,PrintID,PrinterModeID,BranchID,Description,Active,DNSName")] PrinterMasterData printerMasterData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(printerMasterData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchID = new SelectList(db.Branches, "ID", "BranchName", printerMasterData.BranchID);
            ViewBag.PrinterModeID = new SelectList(db.PrinterModels, "ID", "PrinterModel", printerMasterData.PrinterModeID);
            return View(printerMasterData);
        }

        // GET: PrinterMasterDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PrinterMasterData printerMasterData = db.PrinterMasterData.Find(id);
            if (printerMasterData == null)
            {
                return HttpNotFound();
            }
            return View(printerMasterData);
        }

        // POST: PrinterMasterDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrinterMasterData printerMasterData = db.PrinterMasterData.Find(id);
            db.PrinterMasterData.Remove(printerMasterData);
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
