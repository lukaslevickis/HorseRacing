using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HorseRacingBackend.DAL.Entities
{
    public class Better
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal Bet { get; set; }

        [ForeignKey("Horse")]
        public int? HorseId { get; set; }
        public Horse Horse { get; set; }
    }
}
