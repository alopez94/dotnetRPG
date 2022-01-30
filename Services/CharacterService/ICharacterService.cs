using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetRPG.Dtos.Character;
using dotnetRPG.Models;

namespace dotnetRPG.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDtop>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDtop>> GetCharaterbyID(int id);
        Task<ServiceResponse<List<GetCharacterDtop>>> AddCharacter(AddCharacterDto newCharacter);

        Task<ServiceResponse<GetCharacterDtop>> UpdateCharacter(UpdateCharacterDto updatedCharacter);

        Task<ServiceResponse<List<GetCharacterDtop>>> DeleteCharacter(int id);
        
    }
}