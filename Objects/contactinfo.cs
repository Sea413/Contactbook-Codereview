using System.Collections.Generic;

namespace ContactBook
{
  public class cinfo
  {
    private string _cname;
    private string _caddress;
    private string _cphone;
    private int _id;
    private static List<cinfo> _instances = new List<cinfo> {};

    public cinfo (string cname, string caddress, string cphone)
    {
      _cname = cname;
      _caddress = caddress;
      _cphone = cphone;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetContactName()
    {
      return _cname;
    }
    public void SetContactName(string cname)
    {
      _cname = cname;
    }
    public string GetAddress()
    {
      return _caddress;
    }
    public void SetAddress(string caddress)
    {
      _caddress = caddress;
    }
    public string GetPhone()
    {
      return _cphone;
    }
    public void SetPhone(string cphone)
    {
      _cphone = cphone;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<cinfo> GetMost()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static cinfo Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
