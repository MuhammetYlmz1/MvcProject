using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        WriterValidator validationRules = new WriterValidator();
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult WriterList()
        {
            var writerValues = writerManager.GetList();
            //Index

            return View(writerValues);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            
            ValidationResult result = validationRules.Validate(writer);
            if (result.IsValid)
            {
                writerManager.WriterAdd(writer);
                return RedirectToAction("WriterList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorCode);

                }
            }


            return View();
        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = writerManager.GetById(id);
            return View(writerValue);

        }
        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {

            ValidationResult result = validationRules.Validate(writer);
            if (result.IsValid)
            {
                writerManager.WriterUpdated(writer);
                return RedirectToAction("WriterList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }
    }
}