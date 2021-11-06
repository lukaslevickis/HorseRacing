using System;
namespace HorseRacingBackend.Dtos
{
    public class HorseDto: HorseBetter
    {
        public int Runs { get; set; }
        public int Wins { get; set; }
        public string About { get; set; }
    }
}
