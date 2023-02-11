namespace ActivitatiVoluntariatWEB.Models
{
    public class Activitate
    {
        public int ID { get; set; }
        public string NumeActivitate { get; set; }
        public int? ResponsabilID { get; set; }
        public Responsabil? Responsabil { get; set; }
        public DateTime Data { get; set; }
        public int Punctaj { get; set; }
        public Departament? Departament { get; set; }
    }
}
