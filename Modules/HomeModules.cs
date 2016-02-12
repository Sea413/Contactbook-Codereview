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
        var newContact = new Contact(Request.Form["Contact-Name"], Request.Form["Contact-Address"],Request.Form["Contact-Phone"]);
        var allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
      Get["/index/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedContact = Contact.Find(parameters.id);
        model.Add("Contact", selectedContact);
        return View["index.cshtml", model];
      Get["/clear_contacts"] =_=> {
        Contact.ClearAll();
        return View ["view_all.cshtml"];
      };
    };
  }
}
}
