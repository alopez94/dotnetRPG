using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnetRPG.Dtos.Character;
using dotnetRPG.Models;

namespace dotnetRPG.Services.CharacterService
{     
    public class CharacterService : ICharacterService
    {

        private static List<Character> characters = new List<Character>{

            new Character(),
            new Character { Id = 1, Name = "Sam"}
        };

        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDtop>>> AddCharacter(AddCharacterDto newCharacter)
        {

            var serviceResponse = new ServiceResponse<List<GetCharacterDtop>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDtop>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDtop>> GetCharaterbyID(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDtop>();
            serviceResponse.Data = _mapper.Map<GetCharacterDtop>(characters.FirstOrDefault(c => c.Id == id));
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCharacterDtop>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDtop>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDtop>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDtop>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDtop>();
            try{
            Character character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

            character.Name = updatedCharacter.Name;
            character.HitPoints = updatedCharacter.HitPoints;
            character.Strength = updatedCharacter.Strength;
            character.Defense = updatedCharacter.Defense;
            character.Intelligence = updatedCharacter.Intelligence;
            character.Class = updatedCharacter.Class;

            serviceResponse.Data = _mapper.Map<GetCharacterDtop>(character);
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDtop>>> DeleteCharacter(int id)
        {

            var serviceResponse = new ServiceResponse<List<GetCharacterDtop>>();
            try
            {
            Character character = characters.First(c => c.Id == id);
            characters.Remove(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDtop>(c)).ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
            
        }
    }
}