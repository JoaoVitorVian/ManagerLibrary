using Manager.Domain.Entities;

namespace Manager.Infra.Interfaces
{
    public interface ILibraryRepository : IBaseRepository<Library>
    {
        Task<List<Library>> SearchByBooks(string books);

        Task<List<Library>> SearchBySerial(long serial);
    }
}