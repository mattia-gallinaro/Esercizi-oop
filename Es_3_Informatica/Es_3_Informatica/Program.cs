using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_3_Informatica
{
    class Aerei
    {
        public string codaereo;
        public string tipo;
        public string nome;
        public Aerei() { }
        public void Valori(string[] risposte) 
        {
            codaereo = risposte[0];
            tipo = risposte[1];
            nome = risposte[2];
        }
        public virtual double CostoMezzo()
        {
            return 5000000;
        }
        public virtual int CostoUtilizzo(int km)
        {
            return km;
        }
    }
    class Cargo : Aerei
    {
        public Cargo() { }
        public override double CostoMezzo()
        {
            return (base.CostoMezzo() * 1.35);
        }
        public override int CostoUtilizzo(int km)
        {
            return km * 500;
        }
    }
    class Passeggeri : Aerei
    {
        public Passeggeri(){}
        public override double CostoMezzo()
        {
            return (base.CostoMezzo()*1.45);
        }
        public override int CostoUtilizzo(int km)
        {
            return km * 750;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cargo cargo = new Cargo();
            Passeggeri passeggeri = new Passeggeri();
            GetDati(cargo);
            GetDati(passeggeri);
            int km;
            bool controllo = int.TryParse(Console.ReadLine(), out km);
            while (!controllo)
            {
                controllo = int.TryParse(Console.ReadLine(), out km);
            }
            cargo.CostoUtilizzo(km);
            passeggeri.CostoUtilizzo(km);
        }
        private static void GetDati<T>(T mezzo) where T : Aerei 
        {
            string[] risposte = new string[3];
            risposte[0] = Console.ReadLine();
            risposte[1] = Console.ReadLine();
            risposte[2] = Console.ReadLine();
            mezzo.Valori(risposte);
        }
    }
}
