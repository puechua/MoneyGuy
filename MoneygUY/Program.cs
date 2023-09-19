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


    class Guy
    {
        public string Name;
        public int Cash;

        /// <summary>
        /// Wyświetla w konsoli podane imię oraz posiadaną kwotę
        /// </summary>
        public void WriteMyInfo() {

            Console.WriteLine(Name + " ma " + Cash + " zł.");
        }

        /// <summary>
        /// Przekazuje pieniądze i usuwa je z portfela (lub wyświetla
        /// w konsoli komunikat o braku środków).
        /// </summary>
        /// <param name="amount">Przekazywana kwota</param>
        /// <returns>
        /// Ilość pieniędzy wyjmowanych z portfela lub 0, jeśli dostępne
        /// środki są za małe (lub parametr amount jest nieprawidłowy).
        /// </returns>
        public int GiveCash(int amount) {

            if (amount <=0) {
                Console.WriteLine(Name + " mówi: " + amount + " nie jest poprawną kwotą.");

            }

            if (amount > Cash) {

                Console.WriteLine(Name + " mówi: " + " nie mam wystarczajacych środków, aby dać ci " + amount + " zł.");
                return 0;
            }

            Cash -= amount;
            return amount;
        }


        public void ReceiveCash(int amount)
        {
            if(amount <= 0)
            {
                Console.WriteLine(Name + " mówi: " + "nie przyjmę" + amount + " zł.");
            }
            else
            {
                Cash += amount;
            }
        }

    }
}
