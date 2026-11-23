namespace OOP_Arena
{
    class Felcar : Bojovnik, IHealer
    {

        public Felcar(string jmeno, int zivot, int utok, int obrana, Kostka kostka) : base(jmeno, zivot, utok, obrana, kostka)
        {
        }

        public override void Utoc(Bojovnik souper, Tym spojenci)
        {
            Bojovnik koho = spojenci.Nahodny(); // muze i sebe, naschval
            int leceni = ((IHealer)this).Uzdrav(koho, _utok);
            Zprava = $"{_jmeno} uzdravuje {koho} za {leceni} hp";
        }
    }
}
