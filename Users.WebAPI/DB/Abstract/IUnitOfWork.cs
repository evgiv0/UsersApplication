namespace Users.WebAPI.DB.Abstract
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; set; }
    }
}