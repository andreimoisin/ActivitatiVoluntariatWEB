using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ActivitatiVoluntariatWEB.Models
{
    public class Departament
    {
        public int ID { get; set; }
        [Display(Name = "Departament")]
        public string NumeDepartament { get; set; }
        public string Coordonator { get; set; }
        [Display(Name = "Numar voluntari")]
        public int NumarVoluntari { get; set; }
        public ICollection<Activitate>? Activitati { get; set; }
    }
}
