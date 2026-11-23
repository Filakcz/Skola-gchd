namespace OOP_Arena
{
    interface IManaUser
    {
        int Mana { get;}
        int MaxMana { get;}

        string VratGrafickyPekneManu()
        {
            int celkem = 20;
            double pocet = Math.Round(((double)Mana / MaxMana) * celkem);

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
