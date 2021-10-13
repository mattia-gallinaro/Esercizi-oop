//Nickname: matgal
//Data 9/10/2021
//Consegna: Dopo aver acquisito da tastiera una serie di prezzi
//relativi ai cellulari in vendita in un negozio, scrivere il 
//codice di un programma(OOP) in C# che visualizzi i prezzi maggiori di 100€.

using System;
using System.Collections.Generic;

namespace PrezziSmartphone
{
    //la classe Cellulare contiene il nome ed il prezzo del cellulare inserito
    //e possiede il metodo ToString per ottenere una stringa contenente i dati del cellulare
    public class Cellulare
    {
        public string nome { get; }
        public double prezzo { get; }
        //il costruttore riceve in ingresso il nome ed il prezzo 
        public Cellulare(string nome, double prezzo)
        {
            this.nome = nome;
            this.prezzo = prezzo;
        }
        //ritorna una stringa con nome e prezzo del cellulare che si trova 
        public override string ToString()
        {
            return $"Modello: {nome} , Prezzo: {prezzo}";
        }
    }
    //la classe Prezzi contiene il controllo del prezzo inserito per il cellulare
    //il metodo VerificaPrezzo controlla che l'utente abbia effettivamente inserito un numero 
    //il metodo OrdineArray riordina ,in modo crescente tramite bubble sort, i cellulari in base al prezzo
    //il metodo TrovaPrimo100 che cerca l'indice dell'array in cui il prezzo è pari a 100€
    class Prezzi
    {
        
        public Prezzi()
        {
           
        }
        //controlla che il prezzo inserito dall'utente sia un numero maggiore di 0
        public bool VerificaPrezzo(string prezzo)
        {
            try
            {
                double verifica = Double.Parse(prezzo);
                if(verifica < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        //tramite bubble sort, viene riordinato l'array di cellulari in ordine crescente
        public Cellulare[] OrdinaArray(Cellulare[] smartphones)
        {
            int flag;
            do
            {
                flag = 0;

                for (int i = 0; i < (smartphones.Length - 1); i++)
                    if (smartphones[i].prezzo > smartphones[i + 1].prezzo)
                    {
                        Cellulare temp = smartphones[i];
                        smartphones[i] = smartphones[i + 1];
                        smartphones[i + 1] = temp;
                        flag = 1;
                    }

            } while (flag == 1);
            return smartphones;
        }
        //ritorna l'indice dell'array da dove iniziano i cellulari con più di 100€
        public int TrovaPrimo100(Cellulare[] telefoni)
        {
            int indice = 0;
            bool termina = false;
            for(int i = 0; i < telefoni.Length && termina == false; i++)
            {
                if(telefoni[i].prezzo >= 100)
                {
                    indice = i;
                    termina = true;
                }
            }
            if (termina)
            {
                return indice;
            }
            else
            {
                indice = -1;
                return indice;
            }
            
        }
        /*nel main l'utente inserisce da tastiera il nome ed il prezzo del cellulare
         *e lo aggiunge nella lista, dopo mette i dati della lista in un'array lo riordina
         *e dopo mostra i telefoni con il prezzo da 100€ in sù*/
        static void Main(string[] args)
        {
            List<Cellulare> dispositivi = new List<Cellulare>();
            string nomedispositivo;
            string prezzodispositivo;
            string controllo;
            Prezzi p = new Prezzi();
            Console.WriteLine("Hello World!");
            do
            {
                Console.WriteLine("Inserisci il nome del dispositivo: ");
                nomedispositivo = Console.ReadLine();
                do
                {
                    Console.WriteLine("Inserisci il prezzo del dispositivo: ");
                    prezzodispositivo = Console.ReadLine();
                } while (!p.VerificaPrezzo(prezzodispositivo));

                dispositivi.Add(new Cellulare(nomedispositivo, Double.Parse(prezzodispositivo)));
                Console.WriteLine("inserisci y per continuare ad inserire telefoni");
                controllo = Console.ReadLine();

            } while (controllo == "y");

            Cellulare[] smartphonesArray = dispositivi.ToArray();
            smartphonesArray = p.OrdinaArray(smartphonesArray);

            int i = p.TrovaPrimo100(smartphonesArray);
            if(i == -1)
            {
                Console.WriteLine("Non ci sono telefoni da più di 100");
            }
            else
            {
                for (; i < smartphonesArray.Length; i++)
                {
                    Console.WriteLine(smartphonesArray[i].ToString());
                }
            }
            
        }
    }
}
