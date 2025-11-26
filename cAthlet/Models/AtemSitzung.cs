using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace cAthlet.Models
{
    public class AtemSitzung
    {
        public int Id { get; set; }

        [BindNever]
        public string BenutzerId { get; set; }
        public DateTime AbgeschlossenAm { get; set; }

        public int EinatmenSekunden { get; set; }
        public int AnhaltenSekunden { get; set; }
        public int AusatmenSekunden { get; set; }
        public int PauseSekunden { get; set; }
        public int GesamtMinuten { get; set; }
    }
}
