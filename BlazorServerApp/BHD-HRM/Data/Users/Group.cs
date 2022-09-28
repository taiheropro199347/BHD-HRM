namespace BHD_HRM.Data.Users
{
    public class Group
{
        public int id { get; set; }
        public string name { get; set; }
        public string userCreate { get; set; }
        public object userEdit { get; set; }
        public string timeModify { get; set; }
        public string timeCreate { get; set; }
        public List<object> bhdAccount { get; set; }
        public List<object> bhdRoles { get; set; }
    }
}
