using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator contactValidator = new ContactValidator();
        // GET: Contact
        public ActionResult ContactList()
        {
            var contacValue = contactManager.GetContactList();
            return View(contacValue);
        }
        public ActionResult GetContactDetail(int id)
        {
            var contactValues = contactManager.GetById(id);

            return View(contactValues);
        }
        public PartialViewResult ContactPartial()
        {
            var messageCountInbox = messageManager.GetListInbox().Count;
            ViewBag.message = messageCountInbox.ToString();

            var messageCountSendbox = messageManager.GetListSendbox().Count;
            ViewBag.messageSnd = messageCountSendbox.ToString();

            var contactCount = contactManager.GetContactList().Count;
            ViewBag.contact = contactCount.ToString();


            return PartialView();
        }
    }
}