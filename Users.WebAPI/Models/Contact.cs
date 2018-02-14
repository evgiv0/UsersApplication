namespace Users.WebAPI.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Value { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}