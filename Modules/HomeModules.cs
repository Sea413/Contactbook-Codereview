using Nancy;
using System.Collections.Generic;
using System;
using Contact.Objects;

namespace Contact
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
        return View["categories.cshtml", allContacts];
      };
      Post["/"]=_=>{
        Contact newContact = new Contact (Request.Form["Cd-Name"],Request.Form["Cd-Artist"]);
        List<Cd> Cdlist = Cd.GetAll();
        return View["index.cshtml", Cdlist];
      };
      Get["/clear_contacts"] =_=> {
        Contact.ClearAll();
        return View ["view_all.cshtml"];
      };
      Post["/search"]=_=>{
        string returnString = Request.Form["searchString"];
        System.Console.WriteLine(returnString);
        List<Cd> Cdlist = Cd.SearchAll(returnString);
        return View["search.cshtml", Cdlist];
      };
    }
  }
}
