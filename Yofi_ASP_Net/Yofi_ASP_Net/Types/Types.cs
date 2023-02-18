namespace Yofi_ASP_Net.Types
{

    public class AllTypes
    {
        ICollection<string> lolo = new List<string>();
    }
    public class EnumApiRes
    {
        public static readonly string Ok = "Ok";
        public static readonly string NotOk = "Not_Ok";
    }


    public class Types
    {
        public int MyType { get; set; }
    }
    public class User
    {
        public string UserName { get; set; }
    }

    public class APIBaseRes
    {
        public string Res { get; set; }
        public int SatatusCode { get; set; }
        public User Data { get; set; }
    }
}
