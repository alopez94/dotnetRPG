using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetRPG.Models;

namespace dotnetRPG.Services.CharacterService
{
    public interface ICharacterService
    {
        List<Character> GetAllCharacters();
        Character GetCharaterbyID(int id);
        List<Character> AddCharacter(Character newCharacter);
    }
}