using System.Collections.Generic;

namespace Contact.Objects
{
  public class Contact
  {
    private static List<Contact> _instances = new List<Contact> {};
    private string _name;
    private string _address;
    private string _phone;
    private int _id;

    public Contact(string name, string address, string phone)
    {
      _name = name;
      _instances.Add(this);
      _id = _instances.Count;
      _address = address;
      _phone = phone;
    }

    public string GetContactName()
    {
      return _name;
    }
    public void SetContactName(string name)
    {
      _name = name;
    }
    public string  GetAddress()
    {
      return _artists;
    }
    public void SetAddress(string address)
    {
      _address =address;
    }
    public string  GetPhone()
    {
      return _phone;
    }
    public void SetPhone(string phone)
    {
      _phone =phone;
    }

    public int GetId()
    {
      return _id;
    }
    public static List<Contact> GetAll()
    {
      return _instances;
    }
    public void Save()
    {
      _instances.Add(_name,_address,_phone);
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}
