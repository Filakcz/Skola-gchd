namespace OOP_Arena
{
    class Carodej : Bojovnik, IManaUser
    {
        public int Mana {get; protected set;}
        public int MaxMana {get; }

        public Carodej(string jmeno, int zivot, int utok, int obrana, Kostka kostka, int mana) : base(jmeno, zivot, utok, obrana, kostka)
        {
            Mana = mana;
            MaxMana = mana;
        }

        public override void Utoc(Bojovnik souper, Tym spojenci)
        {
            if (Mana == MaxMana)
            {
                int uder = Math.Min(_utok * _kostka.HodSebou(), _maxZivot / 2);
                Mana = 0;
                Zprava = $"{_jmeno} magicky útočí za {uder} hp";
                souper.BranSe(uder);
            }
            else
            {
                Mana = Math.Min(Mana + 10, MaxMana);
                base.Utoc(souper, spojenci);
            }
        }

        public override void PeknyVypis()
        {
            base.PeknyVypis();
            Console.WriteLine("{0} {1}", _jmeno, ((IManaUser)this).VratGrafickyPekneManu());
        }

        public override void Reset()
        {
            base.Reset();
            Mana = MaxMana;
        }
    }
}
