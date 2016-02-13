using Nancy;
using System.Collections.Generic;
using System;
using ContactBook.Objects;

namespace ContactBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
      {
        Get["/"] = _ => {
            return View["index.cshtml"];
        };
        Get["/categories"]=_=> {
          var allContacts = Contact.GetAll();
         return View["categories.cshtml", allContacts];
       };

       Get["/categories/new"] = _ => {
             return View["category_form.cshtml"];
           };
       Post["/categories"] = _ => {
           var newContact = new Contact(Request.Form["contact-name"]);
           var allContacts = Contact.GetAll();
           return View["categories.cshtml", allContacts];
         };
        Get["/categories/{id}"] = parameters => {
          Dictionary<string, object> model = new Dictionary<string, object>();
          var selectedContact = Contact.Find(parameters.id);
          var contactinfo = selectedContact.GetContactinfo();
          model.Add("contact", selectedContact);
          model.Add("cinfo", contactinfo);
          return View["category.cshtml", model];
        };
        Get["/clear_categories"] =_=> {
          Contact.ClearAll();
          return View ["index.cshtml"];
        };
        Get["/categories/{id}/task/{taskId}"] = parameters => {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Contact selectedContact = Contact.Find(parameters.id);
          cinfo returncinfo = cinfo.Find(parameters.taskId);
          model.Add("Contact", selectedContact);
          model.Add("cinfo", returncinfo);
          return  View["task.cshtml",model];
        };
        Get["/categories/{id}/tasks/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Contact selectedContact = Contact.Find(parameters.id);
        List<cinfo> allcinfo = selectedContact.GetContactinfo();
        model.Add("contact", selectedContact);
        model.Add("cinfor", allcinfo);
        return View["category_tasks.cshtml", model];
      };
        Post["/categories/{id}/task/{taskId}"] = parameters => {
          Dictionary<string, object> model = new Dictionary<string, object>();
          var selectedContact = Contact.Find(parameters.id);
          var contactCinfo = selectedContact.GetContactinfo();
          cinfo cinfos = contactCinfo[parameters.taskId-1];
          model.Add("contact", selectedContact);
          model.Add("cinfo", contactCinfo);
          return View["category.cshtml", model];
        };
        Post["/tasks"] = _ => {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Contact selectedContact = Contact.Find(Request.Form["contact-id"]);
          List<cinfo> contactinfo = selectedContact.GetContactinfo();
          string cinfoname = Request.Form["cinfo-name"];
          string caddress = Request.Form["cinfo-address"];
          string cphone = Request.Form["cinfo-cphone"];
          cinfo newcinfo = new cinfo(cinfoname,caddress,cphone);
          contactinfo.Add(newcinfo);
          model.Add("cinfo", contactinfo);
          model.Add("contact", selectedContact);
          return View["category.cshtml", model];
        };
      }
    }
  }
