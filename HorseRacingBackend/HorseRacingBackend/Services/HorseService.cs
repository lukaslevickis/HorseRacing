using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HorseRacingBackend.DAL.Entities;
using HorseRacingBackend.DAL.Repositories;
using HorseRacingBackend.Dtos;

namespace HorseRacingBackend.Services
{
    public class HorseService
    {
        private readonly IGenericRepository<Horse> _horseRepository;
        private readonly IMapper _mapper;

        public HorseService(IGenericRepository<Horse> horseRepository, IMapper mapper)
        {
            _horseRepository = horseRepository;
            _mapper = mapper;
        }

        public async Task<List<HorseDto>> GetAllAsync()
        {
            List<Horse> horses = await _horseRepository.GetAllAsync(null, q => q.OrderBy(s => s.Name));
            return _mapper.Map<List<Horse>, List<HorseDto>>(horses);
        }

        public async Task<HorseDto> GetByIdAsync(int id)
        {
            Horse horse = await _horseRepository.GetByIDAsync(id);
            return _mapper.Map<Horse, HorseDto>(horse);
        }

        public async Task<HorseDto> CreateAsync(HorseDto horse)
        {
            Horse entity = _mapper.Map<HorseDto, Horse>(horse);
            entity = await _horseRepository.CreateAsync(entity);
            return _mapper.Map<Horse, HorseDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            Horse horse = await _horseRepository.GetByIDAsync(id);
            await _horseRepository.DeleteAsync(horse);
        }

        public async Task<HorseDto> UpdateAsync(HorseDto horse)
        {
            Horse entity = _mapper.Map<HorseDto, Horse>(horse);
            entity = await _horseRepository.UpdateAsync(entity);
            return _mapper.Map<Horse, HorseDto>(entity);
        }
    }
}
