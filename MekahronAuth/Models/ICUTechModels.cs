namespace MekahronAuth.Models
{
    public class SuccessLoginModel
    {
        public int EntityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string EmailConfirm { get; set; }
        public string MobileConfirm { get; set; }
        public int CountryID { get; set; }
        public string lid { get; set; }
        public string FTPHost { get; set; }
        public int FTPPort { get; set; }
    }

    public class BadLoginModel
    {
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }

    public class LoginResultModel
    {
        public SuccessLoginModel SuccessLoginModel { get; set; }
        public BadLoginModel BadLoginModel { get; set; }
    }
}