using System;

namespace WarmOderKalt
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variablen
            Random rnd = new Random();
            int zufall = 0, eingabeNeu, eingabeAlt, diffNeu, diffAlt, modus = 0, counter = 1;
            bool check, sieg = false;
            string wahl;

            //Wahl der Schwierigkeit
            do
            {
                check = true;
                Console.WriteLine("(1) Number between 1 and 100 (default)");
                Console.WriteLine("(2) Number between 1 and 1000 (hard mode)");
                Console.Write("Your choice: ");
                wahl = Console.ReadLine();

                if (wahl == "1")
                {
                    zufall = rnd.Next(1, 101);
                    modus = 100;
                }
                else if (wahl == "2")
                {
                    zufall = rnd.Next(1, 1001);
                    modus = 1000;
                }
                else
                {
                    Console.WriteLine("Please select only 1 or 2");
                    check = false;
                }
            } while (!check);


            //Erste User-Eingabe
            do
            {
                Console.Write("Please enter your number: ");
                check = int.TryParse(Console.ReadLine(), out eingabeNeu);
                if (!check || eingabeNeu < 1 || eingabeNeu > modus)
                {
                    check = false;
                    Console.WriteLine($"Please enter only numbers between 1 and {modus} (in digits!!!111).");
                }
            } while (!check);

            //Weitere Eingaben
            do
            {
                if (eingabeNeu != zufall)
                {
                    eingabeAlt = eingabeNeu;
                    do
                    {
                        Console.Write("Please enter your number: ");
                        check = int.TryParse(Console.ReadLine(), out eingabeNeu);
                        if (!check || eingabeNeu < 1 || eingabeNeu > modus)
                        {
                            check = false;
                            Console.WriteLine($"Please enter only numbers between 1 and {modus} (in digits!!!111).");
                        }
                    } while (!check);
                    counter++;

                    diffAlt = Math.Abs(zufall - eingabeAlt);
                    diffNeu = Math.Abs(zufall - eingabeNeu);

                    if (diffNeu < diffAlt && eingabeNeu != zufall)
                    {
                        Console.WriteLine("Warmer.");
                    }
                    else if (diffNeu > diffAlt && eingabeNeu != zufall)
                    {
                        Console.WriteLine("Colder.");
                    }
                    else if (eingabeNeu != zufall)
                    {
                        Console.WriteLine("No temperature fluctuation!");
                    }
                }
                else
                {
                    Console.WriteLine("You have won!");
                    Console.WriteLine($"You have needed {counter} attempts!");
                    Console.ReadKey();
                    sieg = true;
                }
            } while (!sieg);

        }
    }
}
