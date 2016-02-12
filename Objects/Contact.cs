using System.Collections.Generic;

namespace ContactBook.Objects
{
  public class Contact
  {
    private static List<Contact> _instances = new List<Contact> {};
    private string _name;
    private int _id;
    private List<cinfo> _contactinfo;

    public Contact(string name)
    {
      _name = name;
      _instances.Add(this);
      _id = _instances.Count;
      _contactinfo = new List<cinfo>{};
    }

    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
  {
    _name = newName;
  }
  public List<cinfo> GetContactinfo()
    {
      return _contactinfo;
    }
    public void AddCinfo(cinfo cinfo)
    {
      _contactinfo.Add(cinfo);
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
