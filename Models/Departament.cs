namespace ActivitatiVoluntariatWEB.Models
{
    public class Departament
    {
        public int ID { get; set; }
        public string NumeDepartament { get; set; }
        public string Coordonator { get; set; }
        public int NumarVoluntari { get; set; }
        public ICollection<Activitate>? Activitati { get; set; }
    }
}
