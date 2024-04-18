using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_Praktikum_PBO_Abstract
{

    public interface ISkill
    {
        void GunakanSkill(Karakter pengguna, Karakter target);
        string GetDeskripsi();
    }
    public abstract class Karakter
    {
        public string Nama { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int Kekuatan { get; set; }

        public Karakter(string nama, int hp, int mp, int kekuatan)
        {
            Nama = nama;
            HP = hp;
            MP = mp;
            Kekuatan = kekuatan;
        }

        public virtual void Serang(Karakter target)
        {
            Console.WriteLine($"{Nama} menyerang {target.Nama}!");
            target.Serang(this);
        }
        public abstract void GunakanSkill(ISkill skill, Karakter target);

        public virtual void CetakInformasi()
        {
            Console.WriteLine($"Nama: {Nama}, HP: {HP}, MP: {MP}, Kekuatan: {Kekuatan}");
        }

        public bool ApakahHidup()
        {
            return HP > 0;
        }
    }
    public class Hero : Karakter
    {
      
        public Hero(string nama, int hp, int mp, int kekuatan) : base(nama, hp, mp, kekuatan)
        {
        }

        public override void GunakanSkill(ISkill skill, Karakter target)
        {
            skill.GunakanSkill(this, target);
        }
    }

    public class Musuh : Karakter
    {
        public Musuh(string nama, int hp, int kekuatan) : base(nama, hp, 0, kekuatan)
        {
        }

 
        public override void Serang(Karakter karakter)
        {
            HP -= karakter.Kekuatan;
            Console.WriteLine($"{Nama} menerima serangan dari {karakter.Nama}!");
            if (!ApakahHidup())
                Mati();
        }

        public void Mati()
        {
            Console.WriteLine($"{Nama} telah mati.");
        }

       
        public override void GunakanSkill(ISkill skill, Karakter target)
        {
            Console.WriteLine($"{Nama} tidak dapat menggunakan skill.");
        }
    }

    public class HealSkill : ISkill
    {
        public void GunakanSkill(Karakter pengguna, Karakter target)
        {
            pengguna.HP += 25; 
            Console.WriteLine($"{pengguna.Nama} menggunakan skill Heal, HP bertambah menjadi {pengguna.HP}");
        }

        public string GetDeskripsi()
        {
            return "Heal: Memulihkan HP karakter.";
        }
    }

    
    public class FireballSkill : ISkill
    {
        public void GunakanSkill(Karakter pengguna, Karakter target)
        {
            target.HP -= 30; 
            Console.WriteLine($"Fireball dari {pengguna.Nama} mengenai {target.Nama}, HP berkurang menjadi {target.HP}");
        }

        public string GetDeskripsi()
        {
            return "Fireball: Menyerang musuh dengan damage api.";
        }
    }

    public class IceBlastSkill : ISkill
    {
        public void GunakanSkill(Karakter pengguna, Karakter target)
        {
            target.HP -= 25; 
            Console.WriteLine($"Ice Blast dari {pengguna.Nama} mengenai {target.Nama}, HP berkurang menjadi {target.HP}");
            Console.WriteLine($"{target.Nama} terkena efek memperlambat.");
        }

        public string GetDeskripsi()
        {
            return "Ice Blast: Menyerang musuh dengan damage es dan memperlambat mereka.";
        }
    }
}
