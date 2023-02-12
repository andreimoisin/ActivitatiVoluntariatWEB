namespace ActivitatiVoluntariatWEB.Models
{
    public class Inscriere
    {
        public int ID { get; set; }
        public int? VoluntarID { get; set; }
        public Voluntar? Voluntar { get; set; }
        public int? ActivitateID { get; set; }
        public Activitate? Activitate { get; set; }
    }
}
