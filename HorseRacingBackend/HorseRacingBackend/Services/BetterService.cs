using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using HorseRacingBackend.DAL.Entities;
using HorseRacingBackend.DAL.Repositories;
using HorseRacingBackend.Dtos;

namespace HorseRacingBackend.Services
{
    public class BetterService
    {
        private readonly IGenericRepository<Better> _betterRepository;
        private readonly IMapper _mapper;

        public BetterService(IGenericRepository<Better> betterRepository, IMapper mapper)
        {
            _betterRepository = betterRepository;
            _mapper = mapper;
        }

        public async Task<List<BetterDto>> GetAllAsync(int? horseId = null)
        {
            Expression<Func<Better, bool>> filterBy = (horseId != null) ?
                                                          r => r.HorseId == horseId :
                                                          null;

            List<Better> betters = await _betterRepository.GetAllAsync(filterBy, q => q.OrderByDescending(s => s.Bet));
            return _mapper.Map<List<Better>, List<BetterDto>>(betters);
        }

        public async Task<BetterDto> GetByIdAsync(int id)
        {
            Better better = await _betterRepository.GetByIDAsync(id);
            return _mapper.Map<Better, BetterDto>(better);
        }

        public async Task<BetterDto> CreateAsync(BetterDto better)
        {
            Better entity = _mapper.Map<BetterDto, Better>(better);
            entity = await _betterRepository.CreateAsync(entity);
            return _mapper.Map<Better, BetterDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            Better better = await _betterRepository.GetByIDAsync(id);
            await _betterRepository.DeleteAsync(better);
        }

        public async Task<BetterDto> UpdateAsync(BetterDto better)
        {
            Better entity = _mapper.Map<BetterDto, Better>(better);
            entity = await _betterRepository.UpdateAsync(entity);
            return _mapper.Map<Better, BetterDto>(entity);
        }
    }
}
