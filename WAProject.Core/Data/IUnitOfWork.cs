using System.Threading.Tasks;

namespace WAProject.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
