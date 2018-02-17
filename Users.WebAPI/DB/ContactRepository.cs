using Users.WebAPI.Models;

namespace Users.WebAPI.DB
{
    public class ContactRepository
    {
        private readonly UsersDbContext _context;

        public ContactRepository(UsersDbContext context)
        {
            _context = context;
        }

        public void DeleteContact(int id)
        {
            var contactForDelete = new Contact { ContactId = id };

            _context.Contacts.Attach(contactForDelete);
            _context.Contacts.Remove(contactForDelete);

            _context.SaveChanges();
        }
    }
}