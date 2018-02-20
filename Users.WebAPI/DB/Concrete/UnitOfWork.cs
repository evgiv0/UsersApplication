using Users.WebAPI.DB.Abstract;

namespace Users.WebAPI.DB.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UsersDbContext _context;
        public IUserRepository Users { get; set; }

        public UnitOfWork(UsersDbContext context)
        {
            _context = context;
            Users = new UserRepository(context);
        }

    }
}