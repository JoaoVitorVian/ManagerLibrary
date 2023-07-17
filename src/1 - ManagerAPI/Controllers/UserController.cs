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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
      _userService = userService;
      _mapper = mapper;
    }

    [HttpGet]
        [Route("/api/v1/users/getAll")]
        public async Task<IActionResult> GetAll(){
            try{
                var allUsers = await _userService.GetAll();
                
                return Ok(new ResultViewModel{
                    Message = "Successfully",
                    Success = true,
                    Data = allUsers
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
        [Route("/api/v1/users/getById/{id}")]
        public async Task<IActionResult> GetById(long id){
            try{ 
                var usersById = await _userService.Get(id);
                
                return Ok(new ResultViewModel{
                    Message = "Successfully",
                    Success = true,
                    Data = usersById
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
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel){
            try{
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                var userCreated = await _userService.Create(userDTO);
                
                return Ok(new ResultViewModel{
                    Message = "User created successfully",
                    Success = true,
                    Data = userCreated
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