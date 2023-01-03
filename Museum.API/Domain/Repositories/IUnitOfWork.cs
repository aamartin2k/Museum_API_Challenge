using System.Threading.Tasks;

namespace MuseumAPI.Domain.Repositories
{

    public interface IUnitOfWork
    {
        Task SaveChangesCompleteAsync();
    }
}
