namespace Kino

{
    class Program
    {
        static void Main(string[] args)
        {
            int Rows = 8;
            int SeatsPerRow = 10;
            int DefaultPrice = 180;
            List<int> VipRows = new List<int> { 6, 7 };
            int VipFee = 70;

            bool[,] seatGrid = new bool[Rows, SeatsPerRow];

            PrintActions();

            bool running = true;

            while (running)
            {
                Console.Write("Akce: ");
                if (!char.TryParse(Console.ReadLine(), out char action))
                {
                    Console.WriteLine("Neplatná akce!");
                    continue;
                }

                if (action == 'z')
                {
                    PrintCinema(seatGrid, Rows, SeatsPerRow);
                }
                else if (action == 'r' || action == 's' || action == 'o' || action == 'c')
                {
                    HandleSeatAction(action, seatGrid, Rows, SeatsPerRow, DefaultPrice, VipFee, VipRows);
                }
                else if (action == 'm')
                {
                    PrintActions();
                }
                else if (action == 'u')
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("Neplatná akce!");
                }
            }
        }

        static void PrintActions()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("z = zobrazit kinosál");
            Console.WriteLine("r = rezervace sedadla");
            Console.WriteLine("s = storno rezervace");
            Console.WriteLine("o = ověřit dostupnost sedadla");
            Console.WriteLine("c = cena sedadla");
            Console.WriteLine("m = menu akcí");
            Console.WriteLine("u = ukončení programu");
            Console.WriteLine("----------------------");
        }

        static void HandleSeatAction(char action, bool[,] seatGrid, int rows, int seatsPerRow, int defaultPrice, int vipFee, List<int> vipRows)
        {
            int targetRow = InputInt("Řada", 1, rows);
            int targetColumn = InputInt("Sedadlo", 1, seatsPerRow);

            targetRow--;
            targetColumn--;

            int price = CalculatePrice(targetRow, defaultPrice, vipFee, vipRows);
            bool isFull = IsSeatFull(targetRow, targetColumn, seatGrid);

            if (action == 'r')
            {
                Console.WriteLine($"Cena vybraného sedadla je: {price} Kč");
                if (isFull)
                {
                    Console.WriteLine("Sedadlo je již obsazené!");
                }
                else
                {
                    ReserveSeat(targetRow, targetColumn, seatGrid);
                    Console.WriteLine("Rezervace byla úspěšná.");
                }
            }
            else if (action == 's')
            {
                if (!isFull)
                {
                    Console.WriteLine("Sedadlo není rezervované!");
                }
                else
                {
                    CancelSeat(targetRow, targetColumn, seatGrid);
                    Console.WriteLine("Rezervace zrušena!");
                }
            }
            else if (action == 'o')
            {
                if (isFull)
                {
                    Console.WriteLine("Sedalo je obsazené!");
                }
                else
                {
                    Console.WriteLine("Sedadlo je volné!");
                }
            }
            else if (action == 'c')
            {
                Console.WriteLine($"Cena sedadla: {price} Kč");
            }
        }

        static void PrintCinema(bool[,] seatGrid, int rows, int seatsPerRow)
        {
            Console.WriteLine();
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Řada {i + 1}: ");
                for (int j = 0; j < seatsPerRow; j++)
                {
                    if (IsSeatFull(i, j, seatGrid))
                    {
                        Console.Write("[X] ");
                    }
                    else
                    {
                        Console.Write($"[{j+1}] ");
                    }
                }
                Console.WriteLine();
            }
        }

        static int InputInt(string prompt, int minRange, int maxRange)
        {
            while (true)
            {
                Console.Write($"{prompt} ({minRange}-{maxRange}): ");
                if (int.TryParse(Console.ReadLine(), out int integer))
                {
                    if (integer >= minRange && integer <= maxRange)
                    {
                        return integer;
                    }
                }
                Console.WriteLine("Neplatný vstup!");
            }
        }

        static bool IsSeatFull(int targetRow, int targetColumn, bool[,] seatGrid)
        {
            return seatGrid[targetRow, targetColumn];
        }

        static void ReserveSeat(int targetRow, int targetColumn, bool[,] seatGrid)
        {
            seatGrid[targetRow, targetColumn] = true;
        }

        static void CancelSeat(int targetRow, int targetColumn, bool[,] seatGrid)
        {
            seatGrid[targetRow, targetColumn] = false;
        }

        static int CalculatePrice(int targetRow, int defaultPrice, int vipFee, List<int> vipRows)
        {
            if (vipRows.Contains(targetRow))
            {
                return defaultPrice + vipFee;
            }
            return defaultPrice;
        }
    }
}
