using System.ComponentModel.DataAnnotations;

namespace Tickets.Shared.Entites
{
    public class Ticket
    {
        public int Id { get; set; }

        [Display(Name = "Fecha Uso")]
        public DateTime? FechaUso { get; set; }

        [Display(Name = "¿Fue Usada?")]
        public bool? FueUsada { get; set; } = false!;

        [Display(Name = "Porteria")]
        public string? Porteria { get; set; }
    }

}
