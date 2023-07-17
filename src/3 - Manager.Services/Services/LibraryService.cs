using AutoMapper;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  Manager.Services.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IMapper _mapper;
        private readonly ILibraryRepository _repository;

        public LibraryService(IMapper mapper, ILibraryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

         public async Task<LibraryDTO> Get(long id){
            var user = await _repository.Get(id);

            return _mapper.Map<LibraryDTO>(user);
        }

        public async Task<List<LibraryDTO>> GetAll(){
            var allBooks = await _repository.GetAll();

            return _mapper.Map<List<LibraryDTO>>(allBooks);
        }

         public async Task<List<LibraryDTO>> SearchByBooks(string book){
            var allBooks = await _repository.SearchByBooks(book);

            return _mapper.Map<List<LibraryDTO>>(allBooks);
        }

          public async Task<List<LibraryDTO>> SearchBySerial(long code){
            var allCodes = await _repository.SearchBySerial(code);

            return _mapper.Map<List<LibraryDTO>>(allCodes);
        }

        public async Task<LibraryDTO> Create(LibraryDTO libraryDTO){
            var bookExists = await _repository.SearchByBooks(libraryDTO.NameBook);

            if(bookExists != null){
                 throw new DomainExceptions("Já existe um book cadastrado com esse nome");
            }

            var book = _mapper.Map<Library>(libraryDTO);
            book.Validate();

            var bookCreated = await _repository.Create(book);

            return _mapper.Map<LibraryDTO>(bookCreated);
        }

        public async Task<LibraryDTO> Update(LibraryDTO libraryDTO){
            var bookExists = await _repository.Get(libraryDTO.Id);

            if(bookExists != null){
                 throw new DomainExceptions("Já existe um book cadastrado com esse nome");
            }

            var book = _mapper.Map<Library>(libraryDTO);
            book.Validate();

            var bookCreated = await _repository.Update(book);

            return _mapper.Map<LibraryDTO>(bookCreated);
        }
        public async Task Remove(long id){
            await _repository.Remove(id);
        }
  }
}