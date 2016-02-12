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
      Get["/"] =_=> {
        var allCrew = Contact.GetAll();
        return View ["index.cshtml", allCrew];
      };
      Get["/New_contacts"]=_=> {
        return View["New_contacts.cshtml"];
      };
      Post["/"] = _ => {
        var newContact = new Contact(Request.Form["Contact-Name"]);
        var allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
      Get["/index/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedContact = Contact.Find(parameters.id);
        var contactinfo = selectedContact.GetAll();
        model.Add("Contact", selectedContact);
        model.Add("Info", contactinfo);
        return View["index.cshtml", model];
      };
      Get["/clear_contacts"] =_=> {
        Contact.ClearAll();
        return View ["view_all.cshtml"];
      };
    // };
  }
}
}
