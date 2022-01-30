using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzolova_aplikace_s_menu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Menu";
            Menu m = new Menu();
            m.Nabidka();

            Console.Read();
        }
    }
    class Okno
    {
        public void SetOkno()
        {
            Console.SetWindowSize(Console.LargestWindowWidth/2, Console.LargestWindowHeight/2);
        }
    }
    class Menu
    {
        public void Nabidka()
        {
            Console.Title = "Menu";

            Okno o = new Okno();
            o.SetOkno();

            while (true)
            {
                Console.WriteLine("Zdravím, prosím zvolte si podle čísla aplikaci, kterou chcete používat. Aplikaci můžete vypnout v nabídce.");
                Console.WriteLine("1 - Kalkulačka");
                Console.WriteLine("2 - Hádání čísla");
                Console.WriteLine("3 - Hod mincí");
                Console.WriteLine("4 - Konec");

                try
                {
                    int vyber = Convert.ToInt16(Console.ReadLine());

                    if (vyber == 1)
                    {
                        Aplikace kalk = new Aplikace();
                        kalk.Kalkulacka();
                    }
                    if (vyber == 2)
                    {
                        Aplikace hadej = new Aplikace();
                        hadej.HadaniCisla();
                    }
                    if (vyber == 3)
                    {
                        Aplikace hod_minci = new Aplikace();
                        hod_minci.HodMincí();
                    }
                    if (vyber == 4)
                    {
                        Environment.Exit(0);
                    }
                    if(vyber < 1 || vyber > 4)
                    {
                        Console.Clear();
                        Console.WriteLine("Vyber číslo v rozmezí od 1 - 4");
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Nenapsal jsi číslo.");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
        }
    }
    class Aplikace
    {
        public void Kalkulacka()
        {
            Console.Clear();
            Console.Title = "Kalkulačka";

            Okno o = new Okno();
            o.SetOkno();

            while (true)
            {
                try
                {
                    Console.WriteLine("Zvol si 1. číslo");
                    double cislo1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Operace: +, -, *, /");
                    string znamenko = Console.ReadLine();
                    Console.WriteLine("Zvol si 2. číslo");
                    double cislo2 = double.Parse(Console.ReadLine());

                    double vysledek = 0;

                    switch (znamenko)
                    {
                        default:
                            Console.Clear();
                            Console.WriteLine("Nezvolil si správné znaménko!");
                            break;
                        case "+":
                            vysledek = cislo1 + cislo2;
                            break;
                        case "-":
                            vysledek = cislo1 - cislo2;
                            break;
                        case "*":
                            vysledek = cislo1 * cislo2;
                            break;
                        case "/":
                            vysledek = cislo1 / cislo2;
                            if (cislo2 == 0)
                            {
                                Console.WriteLine("Nemůžeš dělit 0");
                                break;
                            }
                            break;
                    }
                    if(znamenko == "+" || znamenko == "-" || znamenko == "*" || znamenko == "/")
                    {
                        Console.WriteLine($"{cislo1} {znamenko} {cislo2} = {vysledek}");
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Nenapsal jste číslo");
                }
                while (true)
                {
                    Console.WriteLine("Chcete zpátky do nabídky?");
                    string nabidka = Console.ReadLine();
                    if (nabidka == "ano")
                    {
                        Console.Clear();
                        Menu menu = new Menu();
                        menu.Nabidka();
                    }
                    else if (nabidka == "ne")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Napište ano nebo ne");
                    }
                }
            }
        }
        public void HadaniCisla()
        {
            Console.Clear();
            Console.Title = "Hádání čísla";

            Okno o = new Okno();
            o.SetOkno();

            while (true)
            {

                Random nahod = new Random();
                int hadane_cis = 0;
                int cislo = nahod.Next(1, 100);

                Console.WriteLine("Hádej číslo od 1 - 100");

                int i = 1;

                while (hadane_cis != cislo)
                {
                    try
                    {
                        hadane_cis = Convert.ToInt32(Console.ReadLine());

                        if (hadane_cis > cislo)
                        {
                            Console.WriteLine("Hádej menší");
                        }
                        if (hadane_cis < cislo)
                        {
                            Console.WriteLine("Hádej větší");
                        }
                        if (hadane_cis == cislo)
                        {
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Musíš hádat číslo");
                        i--;
                    }
                    i++;
                }
                Console.WriteLine("Vyhrál jsi na " + i + ". pokus");

                while (true)
                {
                    Console.WriteLine("Chcete zpátky do nabídky?");
                    string nabidka = Console.ReadLine();
                    if (nabidka == "ano")
                    {
                        Console.Clear();
                        Menu menu = new Menu();
                        menu.Nabidka();
                    }
                    else if (nabidka == "ne")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Napište ano nebo ne");
                    }
                }
            }
        }
        public void HodMincí()
        {
            Console.Clear();
            Console.Title = "Hod mincí";

            while (true)
            {
                Okno o = new Okno();
                o.SetOkno();

                Console.WriteLine("Panna nebo orel?");
                string hrac_hod = Console.ReadLine();

                Random hod = new Random();
                int npc_hod = hod.Next(0, 2);

                Console.Clear();

                if (hrac_hod == "panna" && npc_hod == 0)
                {                    
                    Console.WriteLine($"padla {hrac_hod}");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (hrac_hod == "orel" && npc_hod == 1)
                {                  
                    Console.WriteLine($"padl {hrac_hod}");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (hrac_hod != "panna" && hrac_hod != "orel")
                {
                    Console.WriteLine("Nevybral si ani pannu ani orla");
                }
                else 
                {
                    if (npc_hod == 1) Console.WriteLine($"Smůla, padl orel");
                    if (npc_hod == 0) Console.WriteLine($"Smůla, padla panna");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                while (true)
                {
                    Console.WriteLine("Chcete zpátky do nabídky?");
                    string nabidka = Console.ReadLine();
                    if (nabidka == "ano")
                    {
                        Console.Clear();
                        Menu menu = new Menu();
                        menu.Nabidka();
                    }
                    else if (nabidka == "ne")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Napište ano nebo ne");
                    }
                }

            }
        }
    }
}
