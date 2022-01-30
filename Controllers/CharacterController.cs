using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetRPG.Dtos.Character;
using dotnetRPG.Models;
using dotnetRPG.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnetRPG.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
       
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
            
        }

        [HttpGet("GetAll")]

        public async Task<ActionResult<ServiceResponse<List<GetCharacterDtop>>>> GetAllCharacters()  //get all characters
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDtop>>> GetCharacterByID(int id){        //get one characters

            return Ok(await _characterService.GetCharaterbyID(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDtop>>>> AddCharacter(AddCharacterDto newCharacter)
        {
               return Ok(await _characterService.AddCharacter(newCharacter));
                
        }

        [HttpPut]

        public async Task<ActionResult<ServiceResponse<GetCharacterDtop>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if(response.Data == null){
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDtop>>> Delete(int id){        //get one characters

            return Ok(await _characterService.GetCharaterbyID(id));
            var response = await _characterService.DeleteCharacter(id);
            if(response.Data == null){
                return NotFound(response);
            }
            return Ok(response);
        }


        
        
    }
}