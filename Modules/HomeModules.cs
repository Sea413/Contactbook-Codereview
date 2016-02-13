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
        Get["/officers"]=_=> {
          var allContacts = Contact.GetAll();
         return View["officers.cshtml", allContacts];
       };

       Get["/officers/new"] = _ => {
             return View["Officer_Rank_submit.cshtml"];
           };
       Post["/officers"] = _ => {
           var newContact = new Contact(Request.Form["contact-name"]);
           var allContacts = Contact.GetAll();
           return View["officers.cshtml", allContacts];
         };
        Get["/officers/{id}"] = parameters => {
          Dictionary<string, object> model = new Dictionary<string, object>();
          var selectedContact = Contact.Find(parameters.id);
          var contactinfo = selectedContact.GetContactinfo();
          model.Add("contact", selectedContact);
          model.Add("cinfo", contactinfo);
          return View["officer_rank_info.cshtml", model];
        };
        Get["/clear_officers"] =_=> {
          Contact.ClearAll();
          return View ["index.cshtml"];
        };
        Get["/officers/{id}/personal_info/{personal_infoId}"] = parameters => {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Contact selectedContact = Contact.Find(parameters.id);
          cinfo returncinfo = cinfo.Find(parameters.personal_infoId);
          model.Add("Contact", selectedContact);
          model.Add("cinfo", returncinfo);
          return  View["personal_info.cshtml",model];
        };
        Get["/officers/{id}/officers_info_specfic/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Contact selectedContact = Contact.Find(parameters.id);
        List<cinfo> allcinfo = selectedContact.GetContactinfo();
        model.Add("contact", selectedContact);
        model.Add("cinfor", allcinfo);
        return View["officer_info.cshtml", model];
      };
        Post["/officers/{id}/personal_info/{personal_infoId}"] = parameters => {
          Dictionary<string, object> model = new Dictionary<string, object>();
          var selectedContact = Contact.Find(parameters.id);
          var contactCinfo = selectedContact.GetContactinfo();
          cinfo cinfos = contactCinfo[parameters.personal_infoId-1];
          model.Add("contact", selectedContact);
          model.Add("cinfo", contactCinfo);
          return View["officer_rank_info.cshtml", model];
        };
        Post["/officers_info_specfic"] = _ => {
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
          return View["officer_rank_info.cshtml", model];
        };
      }
    }
  }
