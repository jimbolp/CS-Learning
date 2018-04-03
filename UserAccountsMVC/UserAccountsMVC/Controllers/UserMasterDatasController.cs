using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserAccountsMVC.Models;

namespace UserAccountsMVC.Controllers
{
    public class UserMasterDatasController : Controller
    {
        private UserDBContext db = new UserDBContext();

        // GET: UserMasterDatas
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PosSortParam = sortOrder == "Position" ? "pos_desc" : "Position";
            ViewBag.EmailSortParam = sortOrder == "Email" ? "email_decs" : "Email";
            ViewBag.PharmNameSortParam = sortOrder == "Pharmos" ? "pharm_decs" : "Pharmos";
            ViewBag.UadmSortParam = sortOrder == "UadmName" ? "uadm_decs" : "UadmName";
            var userMasterDatas = db.UserMasterDatas.Include(u => u.Branch).Include(u => u.Position);
            if (!string.IsNullOrEmpty(searchString))
            {
                userMasterDatas = userMasterDatas.Where(u => u.UserName.ToLower().Contains(searchString.ToLower()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    userMasterDatas = userMasterDatas.OrderByDescending(u => u.UserName);
                    break;
                case "Position":
                    userMasterDatas = userMasterDatas.OrderBy(u => u.Position.Position1);
                    break;
                case "pos_desc":
                    userMasterDatas = userMasterDatas.OrderByDescending(u => u.Position.Position1);
                    break;
                case "Email":
                    userMasterDatas = userMasterDatas.OrderBy(u => u.Email);
                    break;
                case "email_decs":
                    userMasterDatas = userMasterDatas.OrderByDescending(u => u.Email);
                    break;
                case "Pharmos":
                    userMasterDatas = userMasterDatas.OrderBy(u => u.PharmosUserName);
                    break;
                case "pharm_desc":
                    userMasterDatas = userMasterDatas.OrderByDescending(u => u.PharmosUserName);
                    break;
                case "UadmName":
                    userMasterDatas = userMasterDatas.OrderBy(u => u.UADMUserName);
                    break;
                case "uadm_decs":
                    userMasterDatas = userMasterDatas.OrderByDescending(u => u.UADMUserName);
                    break;
                default:
                    userMasterDatas = userMasterDatas.OrderBy(u => u.UserName);
                    break; ;
            }
            
            return View(userMasterDatas.ToList());
        }

        // GET: UserMasterDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMasterData userMasterData = db.UserMasterDatas.Find(id);
            if (userMasterData == null)
            {
                return HttpNotFound();
            }
            return View(userMasterData);
        }

        // GET: UserMasterDatas/Create
        public ActionResult Create()
        {
            ViewBag.BranchID = new SelectList(db.Branches, "ID", "BranchName");
            ViewBag.PositionID = new SelectList(db.Positions, "ID", "Position1");
            return View();
        }

        // POST: UserMasterDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Email,BranchID,PositionID,PharmosUserName,UADMUserName,GI,Purchase,Tender,Phibra,Active,Description")] UserMasterData userMasterData)
        {
            if (ModelState.IsValid)
            {
                db.UserMasterDatas.Add(userMasterData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchID = new SelectList(db.Branches, "ID", "BranchName", userMasterData.BranchID);
            ViewBag.PositionID = new SelectList(db.Positions, "ID", "Position1", userMasterData.PositionID);
            return View(userMasterData);
        }

        // GET: UserMasterDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMasterData userMasterData = db.UserMasterDatas.Find(id);
            if (userMasterData == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchID = new SelectList(db.Branches, "ID", "BranchName", userMasterData.BranchID);
            ViewBag.PositionID = new SelectList(db.Positions, "ID", "Position1", userMasterData.PositionID);
            return View(userMasterData);
        }

        // POST: UserMasterDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Email,BranchID,PositionID,PharmosUserName,UADMUserName,GI,Purchase,Tender,Phibra,Active,Description")] UserMasterData userMasterData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userMasterData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchID = new SelectList(db.Branches, "ID", "BranchName", userMasterData.BranchID);
            ViewBag.PositionID = new SelectList(db.Positions, "ID", "Position1", userMasterData.PositionID);
            return View(userMasterData);
        }

        // GET: UserMasterDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMasterData userMasterData = db.UserMasterDatas.Find(id);
            if (userMasterData == null)
            {
                return HttpNotFound();
            }
            return View(userMasterData);
        }

        // POST: UserMasterDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserMasterData userMasterData = db.UserMasterDatas.Find(id);
            db.UserMasterDatas.Remove(userMasterData);
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
