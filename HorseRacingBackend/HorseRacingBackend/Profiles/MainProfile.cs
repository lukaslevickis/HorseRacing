using System;
using AutoMapper;
using HorseRacingBackend.DAL.Entities;
using HorseRacingBackend.Dtos;

namespace HorseRacingBackend.Profiles
{
    public class MainProfile: Profile
    {
        public MainProfile()
        {
            CreateMap<HorseDto, Horse>().ReverseMap();
            CreateMap<BetterDto, Better>().ReverseMap();
        }
    }
}
