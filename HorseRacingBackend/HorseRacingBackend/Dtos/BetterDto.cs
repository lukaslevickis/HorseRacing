using System;
using HorseRacingBackend.DAL.Entities;

namespace HorseRacingBackend.Dtos
{
    public class BetterDto: HorseBetter
    {
        public string Surname { get; set; }
        public decimal Bet { get; set; }
        public int? HorseId { get; set; }
    }
}
