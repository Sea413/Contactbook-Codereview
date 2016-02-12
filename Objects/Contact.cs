using System.Collections.Generic;

namespace ContactBook.Objects
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
      return _address;
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
    public void SaveFormat()
    {
      _instances.Add(this);
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Contact Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
