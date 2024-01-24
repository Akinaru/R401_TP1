using System.ComponentModel.DataAnnotations;

namespace WSConvertisseur.Models
{
    public class Devise
    {

        private int id;
        private string? nomDevise;
        private double taux;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        [Required]
        public string? NomDevise
        {
            get { return this.nomDevise; }
            set { this.nomDevise = value; }
        }

        public double Taux
        {
            get { return this.taux; }
            set { this.taux = value; }
        }

        public Devise(int id, string? nomDevise, double taux)
        {
            Id = id;
            NomDevise = nomDevise;
            Taux = taux;
        }

        public Devise() { }
    }
}
