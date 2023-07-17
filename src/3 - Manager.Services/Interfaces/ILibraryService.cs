using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.Services.DTO;

namespace Manager.Services.Interfaces
{
    public interface ILibraryService
    {
        Task<LibraryDTO> Create(LibraryDTO libraryDTO);

        Task<LibraryDTO> Update(LibraryDTO libraryDTO);

        Task Remove(long id);

        Task<LibraryDTO> Get(long id);

        Task<List<LibraryDTO>> GetAll();

        Task<List<LibraryDTO>> SearchByBooks(string book);

        Task<List<LibraryDTO>> SearchBySerial( long code);
    }
}