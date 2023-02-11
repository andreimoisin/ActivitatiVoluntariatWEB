using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ActivitatiVoluntariatWEB.Models
{
    public class Responsabil
    {
        public int ID { get; set; }
        [Display(Name = "Nume responsabil")]
        public string NumeResponsabil { get; set; }
        public ICollection<Activitate>? Activitati { get; set; }
        public string Functie { get; set; }
        public string Bio { get; set; }
    }
}
