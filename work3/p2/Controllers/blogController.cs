﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace p2.Controllers
{
    public class BlogController : Controller
    {
     
        public ActionResult Index(string a)
        {
            var db = new BlogDatabase();

            db.Database.CreateIfNotExists();

            var lst = db.BlogArticles.AsQueryable();
            if (!string.IsNullOrWhiteSpace(a))
            {
                lst = lst.Where(o => o.Subject.Contains(a));
            }
            ViewBag.BlogArticles = lst.OrderByDescending(o => o.Id).ToList();
            ViewBag.a = a;

            return View();
        }


        public ActionResult Add()
        {
                        if (Request.Cookies["isauth"] != null && Request.Cookies["isauth"].Value == "true")
                            {
                                return View();
                            }
                        else
                           {
                                return RedirectToAction("login", "cookiedemo");
                            }
        }

        public ActionResult Save(BlogArticle model)
        {
            if (ModelState.IsValid)
                  {
                var article = new BlogArticle();
                article.Subject = model.Subject;
                article.Body = model.Body;
                article.DateCreated = DateTime.Now;
                
                var db = new BlogDatabase();
                db.BlogArticles.Add(article);
                db.SaveChanges();
                     }

            return Redirect("Index");
        }

        public ActionResult Show(int id)
        {
            var db = new BlogDatabase();
            var article = db.BlogArticles.First(o => o.Id == id);

            ViewData.Model = article;
            return View();
        }

        public ActionResult Edit(int id)
        {
            var db = new BlogDatabase();
            var article = db.BlogArticles.First(o => o.Id == id);

            ViewData.Model = article;
            return View();
        }

        public ActionResult EditSave(int id, string subject, string body)
        {
            var db = new BlogDatabase();
            var article = db.BlogArticles.First(o => o.Id == id);

            article.Subject = subject;
            article.Body = body;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var db = new BlogDatabase();
            var article = db.BlogArticles.First(o => o.Id == id);

            db.BlogArticles.Remove(article);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}