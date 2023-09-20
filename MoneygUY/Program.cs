using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyGuy
{
    class Program
    {
        static void Main(string[] args)
        {

            Guy jacek = new Guy
            {
                Cash = 50,
                Name = "Jacek"
            };

            Guy bartek = new Guy
            {
                Cash = 100,
                Name = "Bartek"
            };

            while (true)
            {

                jacek.WriteMyInfo();
                bartek.WriteMyInfo();

                Console.Write("Podaj kwotę: ");
                string howMuch = Console.ReadLine();
                if (howMuch == "")
                {
                    return;
                }
                if (int.TryParse(howMuch, out int amount))
                {

                    Console.Write("Pieniądze ma przekazać: ");
                    string whichGuy = Console.ReadLine();

                    if (whichGuy == "Jacek")
                    {
                        int cashGiven = jacek.GiveCash(amount);

                        //nie mogę dać amount, bo wtedy mi wczytuje pierwotną wartość, a nie tą po zmianach :DD
                        //dlatego wyżej jest nowa zmienna cashGiven
                        bartek.ReceiveCash(cashGiven);
                    }
                    else if (whichGuy == "Bartek")
                    {
                        int cashGiven = bartek.GiveCash(amount);
                        jacek.ReceiveCash(cashGiven);
                    }
                    else
                    {
                        Console.WriteLine("Wpisz 'Jacek' lub 'Bartek'");
                    }
                }

                else
                {
                    Console.WriteLine("Wpisz kwotę (lub parzysty wierz, aby zakończyć)");
                }
            }
        }
    }
}
