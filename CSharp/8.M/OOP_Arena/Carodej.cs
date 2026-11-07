namespace OOP_Arena
{
    class Carodej : Bojovnik
    {
        protected int _mana;
        private int _maxMana;

        public Carodej(string jmeno, int zivot, int utok, int obrana, Kostka kostka, int mana) : base(jmeno, zivot, utok, obrana, kostka)
        {
            _mana = mana;
            _maxMana = mana;
        }

        public override void Utoc(Bojovnik souper)
        {
            if (_mana == _maxMana)
            {
                int uder = Math.Min(_utok * _kostka.HodSebou(), _maxZivot / 2);
                _mana = 0;
                Zprava = $"{_jmeno} magicky útočí za {uder} hp";
                souper.BranSe(uder);
            }
            else
            {
                _mana = Math.Min(_mana + 10, _maxMana);
                base.Utoc(souper);
            }
        }

        public override void Heal()
        {
            base.Heal();
            _mana = _maxMana;
        }

        public string VratGrafickyPekneManu()
        {
            int celkem = 20;
            double pocet = Math.Round(((double)_mana / _maxMana) * celkem);

            int zbyva = (int)pocet;
            int chybi = celkem - zbyva;

            // \u001b[101m = světlý červený podklad
            // \u001b[41m  = tmavě červený podklad
            // \u001b[0m   = reset barvy
            string zbyvajiciBloky = new string(' ', zbyva);
            string chybajiciBloky = new string(' ', chybi);
            return $"Mana: \u001b[44m{zbyvajiciBloky}\u001b[100m{chybajiciBloky}\u001b[0m";
            // return $"Život: \u001b[41m{zbyvajiciBloky}\u001b[101m{chybajiciBloky}\u001b[0m";
        }

    }
}
