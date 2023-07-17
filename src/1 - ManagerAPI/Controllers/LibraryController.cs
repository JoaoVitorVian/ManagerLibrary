using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManagerAPI.ViewModels;
using Manager.Core.Exceptions;
using Manager.Services.Interfaces;
using AutoMapper;
using Manager.Services.DTO;

namespace ManagerAPI.Controllers
{
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        private readonly IMapper _mapper;

        public LibraryController(ILibraryService libraryService, IMapper mapper)
        {
            _libraryService = libraryService;
            _mapper = mapper;
        }

     [HttpGet]
        [Route("/api/v1/library/getAll")]
        public async Task<IActionResult> GetAll(){
            try{
                var allBooks = await _libraryService.GetAll();
                
                return Ok(new ResultViewModel{
                    Message = "Successfully",
                    Success = true,
                    Data = allBooks
                });
            }
            catch(DomainExceptions ex){
                return BadRequest();
            }
            catch(Exception){
                return StatusCode(500, "Erro");
            }
        } 

     [HttpGet]
        [Route("/api/v1/library/getById/{id}")]
        public async Task<IActionResult> GetById(long id){
            try{ 
                var booksById = await _libraryService.Get(id);
                
                return Ok(new ResultViewModel{
                    Message = "Successfully",
                    Success = true,
                    Data = booksById
                });
            }
            catch(DomainExceptions ex){
                return BadRequest();
            }
            catch(Exception){
                return StatusCode(500, "Erro");
            }
        } 

     [HttpPost]
        [Route("/api/v1/library/create")]
        public async Task<IActionResult> Create([FromBody] CreateLibraryViewModel libraryViewModel){
            try{
                var libraryDTO = _mapper.Map<LibraryDTO>(libraryViewModel);
                var libraryCreated = await _libraryService.Create(libraryDTO);
                
                return Ok(new ResultViewModel{
                    Message = "library created successfully",
                    Success = true,
                    Data = libraryCreated
                });
            }
            catch(DomainExceptions ex){
                return BadRequest();
            }
            catch(Exception){
                return StatusCode(500, "Erro");
            }
        }   
    }
}