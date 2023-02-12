namespace ActivitatiVoluntariatWEB.Models
{
    public class Voluntar
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int? DepartamentID { get; set; }
        public Departament? Departament { get; set; }
        public string? NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Inscriere>? Inscrieri { get; set; }
    }
}
