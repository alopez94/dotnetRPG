using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetRPG.Models;

namespace dotnetRPG.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAllCharacters();
        Task<Character> GetCharaterbyID(int id);
        Task<List<Character>> AddCharacter(Character newCharacter);
    }
}