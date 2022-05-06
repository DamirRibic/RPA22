using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsinhroniTask
{
    class Coffee { }
    class Bacon { }
    class Egg { }
    class Toast { }
    class Juice { }
    class Program
    {
        static async Task Main(string[] args)
        {
            //SINHRONO:

            //Coffee cup = KuhajKavo();
            //Console.WriteLine("Kava je kuhana");
            //Egg eggs = CvriJajca(2);
            //Console.WriteLine("Jajca so ocvrta");
            //Bacon bacon = CvriSlanino(3);
            //Console.WriteLine("Slanina je pripravljena");
            //Toast toast = PečiKruh(2);
            //ApplyButter(toast);
            //ApplyJam(toast);
            //Console.WriteLine("Toasti so pripravljeni");
            //Juice juice = StisniSok();
            //Console.WriteLine("Sok je pripravljen");
            //Console.WriteLine("Zajtrk je pripravljen");


            //ASINHRONO: 

            var c = KuhajKavo();
            
            //Egg eggs =await CvriJajca(2);
            var eggs = CvriJajca(2);
            
            //Bacon bacon =await CvriSlanino(3);
            var bacon = CvriSlanino(3);

            var vsiTaski = new List<Task> { eggs, bacon, c };
            Toast toast = await PečiKruh(2);
            //Task<Toast> toast = PečiKruh(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("Toasti so pripravljeni");
            Juice juice = StisniSok();
            Console.WriteLine("Sok je pripravljen");
            //Coffee cup = await c;
            //Console.WriteLine("Kava je kuhana");
            //Egg egg = await eggs;
            //Console.WriteLine("Jajca so ocvrta");
            //Bacon b = await bacon;
            //Console.WriteLine("Slanina je pripravljena");
            while(vsiTaski.Count>0)
            {
                Task končan = await Task.WhenAny(vsiTaski);
                if (končan==eggs)
                {Console.WriteLine("Jajca so ocvrta"); }
                else
                    if(končan==bacon)
                {Console.WriteLine("Slanina je pripravljena"); }
                else
                    if(končan==c)
                {Console.WriteLine("Kava je kuhana"); }
                vsiTaski.Remove(končan);
            }
            Console.WriteLine("Zajtrk je pripravljen");
            Console.ReadLine();
        }

        private static Juice StisniSok()
        {
            Console.WriteLine("Stiskanje soka iz pomaranč");
            Task.Delay(3000).Wait();
            return new Juice();
        }

        private static void ApplyJam(Toast toast)
        {
            Console.WriteLine("Dodajanje marmelade na toast");
        }

        private static void ApplyButter(Toast toast)
        {
            Console.WriteLine("Dodajanje masla na toast");
        }

        private async static Task<Toast> PečiKruh(int v)
        {
            for(int k = 0; k < v; k++)
            {
                Console.WriteLine("Dodajam toast v toaster");
            }
            Console.WriteLine("Začenjam peči");
            await Task.Delay(3000);
            Console.WriteLine("Odstrani toast iz toasterja");
            return new Toast();
        }

        private async static Task<Bacon> CvriSlanino(int v)
        {
            Console.WriteLine("Dodajanje "+v+" kosov slanine v ponev");
            Console.WriteLine("Pečenje na eni strani");
            await Task.Delay(3000);
            for (int k=0;k<v;k++)
                Console.WriteLine("Obračanje slanine");
            Console.WriteLine("Pečenje druge strani");
            await Task.Delay(3000);
            Console.WriteLine("Daj slanino na krožnik");
            return new Bacon();
        }

        private async static Task<Egg> CvriJajca(int v)
        {
            Console.WriteLine("Segrevanje ponve....");
            await Task.Delay(3000);
            Console.WriteLine("Razbijanje "+v+" jajc");
            Console.WriteLine("Cvretje jajc....");
            await Task.Delay(3000);
            Console.WriteLine("Daj jajca na krožnik");
            return new Egg();
        }

        private async static Task<Coffee> KuhajKavo()
        {
            Console.WriteLine("Kuhanje kave");
            Task.Delay(3000).Wait();
            return new Coffee();
        }
    }
}
