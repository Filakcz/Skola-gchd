namespace OOP_Arena
{
    interface IHealer
    {
        int Uzdrav(Bojovnik cil, int jakMoc)
        {
            return cil.PrijmiLeceni(jakMoc);
        }
    }
}
