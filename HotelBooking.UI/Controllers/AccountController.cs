using AutoMapper;
using HotelBooking.Core.Domain.Entities.IdentityEntities;
using HotelBooking.Core.DTOs;
using HotelBooking.UI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public AccountController(IMapper _mapper , UserManager<AppUser> userManager)
        {
            mapper = _mapper;
            this.userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Registration(RegistrationDTO Regdto)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(ms => ms.Value.Errors.Count > 0)
                    .Select(ms => new ErrorDetail
                    {
                        Field = ms.Key,
                        Message = ms.Value.Errors.First().ErrorMessage
                    }).ToList();

                return BadRequest(new APIResponse<object>() { Success = false, Errors = null, Message = "Invalied Model State", Result = null });
           
            
            }


            AppUser user = mapper.Map<AppUser>(Regdto);

            IdentityResult Result = await userManager.CreateAsync(user, Regdto.Password);

            if (!Result.Succeeded)
            {
                var errors = Result.Errors.Select(E => new ErrorDetail { Field = E.Code, Message = E.Description });

                return StatusCode(500, new APIResponse<object>()
                {
                    Success = false,
                    Message = "Internal Server Error , Error while saving proccess",
                    Errors = errors.ToList()
                });

            }


            Result = await userManager.AddToRoleAsync(user , "CUSTOMER");

            if (!Result.Succeeded)
            {
                var errors = Result.Errors.Select(E => new ErrorDetail { Field = E.Code, Message = E.Description });

                return StatusCode(500, new APIResponse<object>()
                {
                    Success = false,
                    Message = "Internal Server Error , Error while set a role",
                    Errors = errors.ToList()
                });

            }

            //Applling Email confirmation later


            return Ok(new APIResponse<RegistrationDTO>()
            { 
                Success = true,
                Errors = null,
                Message = "User added Successfully",
                Result = Regdto
            
            });
        }

    } 
}

