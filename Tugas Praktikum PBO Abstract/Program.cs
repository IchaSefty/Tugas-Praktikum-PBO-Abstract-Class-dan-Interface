// See https://aka.ms/new-console-template for more information
/*Console.WriteLine("Hello, World!");*/

namespace Tugas_Praktikum_PBO_Abstract
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Game RPG");
            Console.WriteLine("----------------------------------");


            Hero Fanny = new Hero("Fanny", 100, 50, 20);

            Musuh musuh = new Musuh("Musuh", 100, 20);

            
            ISkill heal = new HealSkill();
            ISkill fireball = new FireballSkill();
            ISkill iceBlast = new IceBlastSkill();

            
            Console.WriteLine("\nInformasi Karakter:");
            Fanny.CetakInformasi();
            Console.WriteLine("\nInformasi Musuh   :");
            musuh.CetakInformasi();

            Console.WriteLine("\n--- Mulai Pertarungan ---\n");

            // Delay untuk efek dramatis
            Thread.Sleep(2000);

            while (Fanny.ApakahHidup() && musuh.ApakahHidup())
            {
               
                Console.WriteLine("Pilih skill yang ingin digunakan:");
                Console.WriteLine($"1. {heal.GetDeskripsi()}");
                Console.WriteLine($"2. {fireball.GetDeskripsi()}");
                Console.WriteLine($"3. {iceBlast.GetDeskripsi()}");

                int pilihanSkill = int.Parse(Console.ReadLine());

              
                switch (pilihanSkill)
                {
                    case 1:
                        Fanny.GunakanSkill(heal, musuh);
                        break;
                    case 2:
                        Fanny.GunakanSkill(fireball, musuh);
                        break;
                    case 3:
                        Fanny.GunakanSkill(iceBlast, musuh);
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }


                if (musuh.ApakahHidup())
                    musuh.Serang(Fanny);


                Console.WriteLine("\nInformasi setelah menggunakan skill dan serangan musuh:");
                Fanny.CetakInformasi();
                musuh.CetakInformasi();
            }

            if (Fanny.ApakahHidup())
                Console.WriteLine($"{Fanny.Nama} menang!");
            else
                Console.WriteLine($"{musuh.Nama} menang!");
        }
    }


}

