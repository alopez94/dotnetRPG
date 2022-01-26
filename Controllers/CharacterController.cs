using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ActionResult<List<Character>> GetAllCharacters()  //get all characters
        {
            return Ok(_characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public ActionResult <Character> GetCharacterByID(int id){        //get one characters

            return Ok(_characterService.GetCharaterbyID(id));
        }

        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter)
        {
               return Ok(_characterService.AddCharacter(newCharacter));
                
        }
    }
}