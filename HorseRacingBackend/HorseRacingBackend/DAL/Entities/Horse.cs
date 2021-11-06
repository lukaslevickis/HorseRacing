using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HorseRacingBackend.DAL.Entities
{
    public class Horse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Runs { get; set; }
        public int Wins { get; set; }
        public string About { get; set; }
        public List<Better> Betters { get; set; }
    }
}
