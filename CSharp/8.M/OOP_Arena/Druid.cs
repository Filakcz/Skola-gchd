namespace OOP_Arena
{
    class Druid : Bojovnik, IManaUser, IHealer
    {
        public int Mana {get; protected set;}
        public int MaxMana {get; }

        public Druid(string jmeno, int zivot, int utok, int obrana, Kostka kostka, int mana) : base(jmeno, zivot, utok, obrana, kostka)
        {
            Mana = mana;
            MaxMana = mana;
        }

        public override void Utoc(Bojovnik souper, Tym spojenci)
        {
            if (Mana == MaxMana)
            {
                Bojovnik koho = spojenci.Nahodny(); // muze i sebe, naschval
                int leceni = ((IHealer)this).Uzdrav(koho, _utok);
                Mana = 0;
                Zprava = $"{_jmeno} uzdravuje {koho} za {leceni} hp";
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
