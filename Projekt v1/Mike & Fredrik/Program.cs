using System;
using System.Collections.Generic;

namespace MinProject
{
    class Program
    {        
        static void Main(string[] args)
        {
            List<List<string>> filmLista = new List<List<string>>();//multidimensionell Lista.
            FyllIInfo(filmLista); //här skickas en signal för att fylla listan med en förbered grund.
            Console.WriteLine("Min hemliga Topp Film lista\n"); 
            //här börjar programmet och skickar in användaren i menyn om inloggningen var korrekt.
            //Mike & Fredrik
            bool inmat = false;
            while (inmat != true)
            {
                inmat = Inloggning();
            }
            if (inmat == true)
            {
                Console.Clear();
                VisaMeny(filmLista);
            }         
        }
        #region inloggning
        static bool Inloggning()
        //inmatning av ID för att få åtkomst till programmet
        //inloggning eftersom det är en hemlig lista så kan man inte ge åtkomst till vem som helst.
        //Mike & Fredrik
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Användarnamn:");
            Console.ResetColor();
            string inlog = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Lösenord:");
            Console.ResetColor();
            string lösen = Console.ReadLine();            

            if (inlog == "Mike" && lösen == "glory")
            {
                Console.WriteLine("\nVälkommen");
                return true;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Du har skrivit fel\nFörsök igen\n");
                Console.ResetColor();
                return false;
            }
        }
        #endregion
        #region Visa meny
        public static void VisaMeny(List<List<string>> filmLista) 
        //Detta är huvudmenyn som styr hela programmet.
        //här implementerade vi felhantering med hjälp av både try,catch och if om talet skulle vara utanför menyns val.
        //Fredrik & Mike
        {
            bool Lyckades = false;
            int inmat = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nAnge ett av de följande alternativ \n");
            Console.ResetColor();
            Console.WriteLine(" 1- Visa alla mina favorit filmer \n" + " 2- Lägg till en ny favorit film " +
                "\n" + " 3- Radera en film \n" + " 4- Uppdatera \n" + " 5- Avsluta program \n ");
            while (!Lyckades)
            {
                try
                {
                    inmat = int.Parse(Console.ReadLine());//
                    Console.WriteLine(" ");
                    Lyckades = true;
                }
                catch (FormatException ex)
                {
                    if (!Lyckades)
                        Console.WriteLine("Du har anget felaktigt format \n" + ex.Message);//hantering av felformat
                }
                if (inmat == 1)
                {                    
                    VisaFilm(filmLista);// Visar film listan
                }
                else if (inmat == 2)
                {                    
                    Läggatill(filmLista);// ligga till en ny film
                }
                else if (inmat == 3)
                {
                    Raderat(filmLista);// Radera en film
                }
                else if (inmat == 4)
                {                    
                    UppdateratNamn(filmLista);// uppdatera filmen eller justera den
                }
                else if (inmat == 5)
                {                    
                    Console.WriteLine("\nTack och hejdå!");// avslutar programet
                    System.Environment.Exit(0);
                }
                else
                {
                    Lyckades = false;
                    Console.WriteLine("\nDu skrev in fel");// hantering av fel inskrivet tal
                }                
            }
        }
        #endregion
        #region Visa filmer        
        public static void VisaFilm(List<List<string>> filmLista)
        //Här skrivs filmlistan ut
        //En metod för att visa upp film lista. 
        //Mike
        {
            int count = 1;
            Console.Clear();            
            foreach (var list in filmLista)
            {
                Console.Write(count++ +" ");
                foreach (var element in list)
                {
                    Console.Write(element);
                    Console.Write("\t");
                }
            Console.Write("\n");
            }
            VisaMeny(filmLista);
        }
        #endregion
        #region Fyll i info        
        public static void FyllIInfo(List<List<string>> filmLista)
        //Här har vi valt 2 filmer var som utgör basen av listan.
        //grunden till film listan men man kan även ta bort och lägga till via menyn.
        //Mike & Fredrik
        {            
            List<string> film1 = new List<string>();
            film1.Add(Omvandlar("Me Befor You"));
            film1.Add("Drama");            
            filmLista.Add(film1);
            List<string> film2 = new List<string>();
            film2.Add(Omvandlar("Bohemian Rhapsody"));
            film2.Add("Musikal/Drama");
            filmLista.Add(film2);
            List<string> film3 = new List<string>();
            film3.Add(Omvandlar("Iron Man"));
            film3.Add("Action");
            filmLista.Add(film3);
            List<string> film4 = new List<string>();
            film4.Add(Omvandlar("Liftarens guide till galaxen"));
            film4.Add("Sci-fi/Äventyr");
            filmLista.Add(film4);
        }
        #endregion
        #region Lägga till
        public static void Läggatill(List<List<string>> filmLista)
        //Används för att fylla listan med fler filmer och deras kategorier
        //För att kunna göra våran application mer användarvänlig, behövde vi en funktion för att kunna lägga till fler filmer.
        //Fredrik
        {
            List<string> kategori = new List<string>();
            Console.Write("Ange en till film :");
            kategori.Add(Omvandlar(Console.ReadLine()));
            Console.Write("Ange filmens kategori :");
            kategori.Add(Omvandlar(Console.ReadLine()));
            filmLista.Add(kategori);
            Console.Clear();
            VisaMeny(filmLista);
            
        }
        #endregion
        #region Radera en film
        public static void Raderat(List<List<string>> filmLista) 
            //detta raderar befintliga filmer och kategorier med hjälp av index plats.
            // Att ta bort en film från film lista insåg vi kan vara en rimligt funktion. och även felhantering.
            // Fredrik & Mike
        {
            bool Lyckades = false;
            int bort = 0;
            while (!Lyckades)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Vilken film vill du ta bort?\n" +
                    "Nr: ");
                    Console.ResetColor();
                    bort = int.Parse(Console.ReadLine());
                    bort -= 1;
                                        
                }
                catch (FormatException ex)
                {
                    if (!Lyckades)
                        Console.WriteLine("\nDu har anget felaktigt format \n" + ex.Message);//hantering av felformat
                    bort =-1;
                }
                {
                    if (bort < filmLista.Count && bort >= 0)// hantering av fel inskrivet tal
                    {
                        filmLista.RemoveAt(bort);
                        Console.Clear();
                        VisaMeny(filmLista);
                    }
                    else
                    {
                        Console.WriteLine("\nDu skrev in fel");
                        Lyckades = false;
                    }
                }
            }  
        }
        #endregion
        #region Uppdatera film
        public static void UppdateratNamn(List<List<string>> filmLista)
        //detta ändrar på befintlig film och kategori med hjälp av index plats
        //En av punkterna i menyn kännde vi, bör kunna ändras eller uppdateras från användarens synvikel.
        //vi har även med try och catch som en felhantering om något skulle skrivas fel.
        //Fredrik & Mike 
        {
            bool Lyckades = false;
            int ändra = 0;
            while (!Lyckades)
            { 
                try
                {
                    Console.Write("Vilken film vill du ändra?\n" +
                    "Nr: ");
                    ändra = int.Parse(Console.ReadLine());
                    Lyckades = true;
                }
                catch (FormatException ex)
                {
                    if (!Lyckades)
                    Console.WriteLine("Du har anget felaktigt format \n" + ex.Message);//hantering av felformat
                }                
                {
                    if (ändra <= filmLista.Count && ändra > 0)// hantering av fel inskrivet tal
                    {
                        ändra -= 1;
                    }
                    else
                    {                    
                        Console.WriteLine("\nDu skrev in fel");
                        Lyckades = false;
                    }
                }
            }
            List<string> extra = new List<string>();
            Console.Write("skriv ny film :");
            extra.Add(Omvandlar(Console.ReadLine()));
            Console.Write("Ange filmens kategori :");
            extra.Add(Omvandlar(Console.ReadLine()));
            filmLista[ändra] = extra;

            Console.Clear();
            VisaMeny(filmLista);
        }
        #endregion
        #region Omvandlare        
        static string Omvandlar (string v) 
        //omvandlar inmatning så att filmlistan blir bättre läsbart vid utskrift
        //vi insåg att utskriften så inte visuelt bra ut och valde därför att göra expandera film namnen,
        //med mellanslag så det blev 30 tecken långt och därefter skrevs kategorierna snyggare ut./Fredrik & Mike
        {
            char[] omvandling = new char[30];
            char[] film = v.ToCharArray();
            for (int i = 0; i < 30; i++)
            {
                omvandling[i] = ' ';
            }
            for (int i = 0; i < film.Length; i++)
            {
                omvandling[i] = film[i];
            }                        
            string x = new string(omvandling);       
            return x;
        }
        #endregion
    }
}
