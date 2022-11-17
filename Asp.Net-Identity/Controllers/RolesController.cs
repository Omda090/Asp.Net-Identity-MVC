﻿using Asp.Net_Identity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.Net_Identity.Controllers
{
    //Or => [Authorize(Roles = "Admins")]
    [Authorize]
    public class RolesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Roles
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(string id)
        {
            var role = db.Roles.Find(id);
            if(role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            try
            {
                // TODO: Add insert logic here

                if(ModelState.IsValid)
                {
                    db.Roles.Add(role);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                return View(role);
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {
            var role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include ="Id,Name")] IdentityRole role)
        {
            
                // TODO: Add update logic here
                if(ModelState.IsValid)
                {
                    db.Entry(role).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                return View(role);
           
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            var role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(IdentityRole myRole)
        {
          
                // TODO: Add delete logic here

                IdentityRole role = db.Roles.Find(myRole.Id);
                db.Roles.Remove(role);
                db.SaveChanges();
                return RedirectToAction("Index");
           
        }
    }
}
