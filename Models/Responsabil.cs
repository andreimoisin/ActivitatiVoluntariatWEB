namespace ActivitatiVoluntariatWEB.Models
{
    public class Responsabil
    {
        public int ID { get; set; }
        public string NumeResponsabil { get; set; }
        public ICollection<Activitate>? Activitati { get; set; }
        public string Functie { get; set; }
        public string Bio { get; set; }
    }
}
