namespace interface_oefening.Models
{
    internal class Docent : Person
    {
        private long _personeelsNummer;
        public long PersoneelsNummer
        {
            get
            {
                return this._personeelsNummer;
            }
            set
            {
                this._personeelsNummer = value; 
            }   
        }
        public Docent(string naam, long personeelsNummer) : base(naam)
        {
            _personeelsNummer = personeelsNummer;
        }

        public override string PrintInfo()
        {
            return $"Naam: {_naam}, personeelsnummer {_personeelsNummer}";
        }
    }
}

// public vs internal
// field vs property

