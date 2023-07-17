using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Infra.Context;

namespace Manager.Infra.Repositories
{
    public class LibraryRepository : BaseRepository<Library>, ILibraryRepository
    {
        private readonly ManagerContext _context;

    public LibraryRepository(ManagerContext context) : base(context)
    {
      _context = context;
    }

    public async Task<List<Library>> SearchByBooks(string books)
    {
            var allBooks = await _context.Librarys
                                         .Where(
                                          x => x.NameBook.ToLower().Contains(books.ToLower())
                                         )
                                         .AsNoTracking()
                                         .ToListAsync();
                                     
            return allBooks;
    }

    public async Task<List<Library>> SearchBySerial(long serial)
    {
        var allBooks = await _context.Librarys
                                     .Where(x => x.CodeSerial == serial)
                                     .AsNoTracking()
                                     .ToListAsync();
                                        
        return allBooks;
    }   

  }
}