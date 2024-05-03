using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strukture_Enumeratori
{
    internal class Program
    {
        
        //Zadatak 1
        struct Order {

            public string articleName;
            public int numberOfItems;
            public double price;
            public int registerNumber;
        
            //Ubacujem funkciju u strukturu Order

            public static double Bill (int num, double price, int cashRegister)
            {

                double priceWithDiscount;
                double sum;
                switch (cashRegister) {

                    case 1: priceWithDiscount = price - (price*10/100);
                        sum = num* priceWithDiscount;
                        Console.WriteLine("Popust na kasi {0} iznosi 10%, Vas racun je:", cashRegister);
                        break;

                    case 2: priceWithDiscount = price - (price*20/100);
                        sum=num* priceWithDiscount;
                        Console.WriteLine("Popust na kasi {0} iznosi 20%, Vas racun je:", cashRegister);
                        break;

                    case 3:
                        priceWithDiscount = price - (price * 30 / 100);
                        sum = num * priceWithDiscount;
                        Console.WriteLine("Popust na kasi {0} iznosi 30%, Vas racun je:", cashRegister);
                        break;

                    case 4:
                        priceWithDiscount = price - (price * 40 / 100);
                        sum = num * priceWithDiscount;
                        Console.WriteLine("Popust na kasi {0} iznosi 40%, Vas racun je:", cashRegister);
                        break;

                    default: Console.WriteLine("Market raspolaze samo sa kasama 1-4."); sum = 0;
                        break;

                }
                return sum;
            }
        }

            //Zadatak 2-opis problematike u Main-u

            struct Person {
            public string name;
            public dateOfBirth date;//struct datum rodjenja je deo strukta person
            }
        struct dateOfBirth {//mora biti poseban struct, jer se sastoji od vise varijabli

            public int day;
            public int month;
            public int year;
        }


        //Zadatak 3
        enum Semafor { 
            zeleno,
            zuto,
            crveno,
        };

        enum StanjeNaPutu{ 
        PrazanPut,
        Guzva,
        Pricekaj
        };

        //Zadatak 4
        struct Knjiga {
            public string naslov;//svaka knjiga sadrzi varijablu naslov
            public string autor;//svaka knjiga sadrzi varijablu autor
        }

        //----------------------------------------------------------------------------------------
        static void Main(string[] args)
        {
            //Zadatak 1

            Order ordered;
            Console.WriteLine ("Unesite naziv artikla");
            ordered.articleName = Console.ReadLine();
            Console.WriteLine("Unesite cenu artikla");
            ordered.price = double.Parse(Console.ReadLine());
            Console.WriteLine("Unesite broj komada artikala");
            ordered.numberOfItems =int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite broj kase");
            ordered.registerNumber = int.Parse(Console.ReadLine());
            Console.WriteLine(Order.Bill (ordered.numberOfItems,ordered.price,ordered.registerNumber) + " dinara.");
            Console.ReadKey();


            //Zadatak 2
            /*► Napraviti konzolnu aplikaciju koja omogućava beleženje podataka o dve osobe.
                Podaci koje je neopodno uneti za svaku osobu su ime i datum rođenja.
                ► Note: Datum rođenja mora biti druga struktura koja se sastoji od dana, meseca i godine.*/

            Person[] persons = new Person[2];//za 2 razlicite osobe
            for (int i = 0; i < persons.Length; i++) {

                Console.Write("Insert name: ");
                Console.WriteLine ();
                persons[i].name = Console.ReadLine();

                Console.Write("Insert day of birth: ");
                Console.WriteLine();
                persons[i].date.day = int.Parse(Console.ReadLine());

                Console.Write("Insert month of birth: ");
                Console.WriteLine();
                persons[i].date.month = int.Parse (Console.ReadLine());


                Console.Write("Insert year of birth: ");
                Console.WriteLine();
                persons[i].date.year = int.Parse(Console.ReadLine());
                
            } //kraj for loop-a

            for (int i=0; i<persons.Length;i++) {

                Console.WriteLine("\nIme:\t{0}\n\t Dan rodjenja:\t\t{1}\n\tMesec rodjenja:\t\t{2}\n\tGodina rodjenja:\t{3}"
                    , persons[i].name, persons[i].date.day, persons[i].date.month, persons[i].date.year);
            }
            Console.ReadKey();



            //Zadatak 3
            /*
                ► Napraviti konzolnu aplikaciju koja sadrži dva enumeratora.
                ► Enumerator Semafor koji sadrži konstante zeleno, žuto i crveno svetlo.
                ► Enumerator StanjeNaPutu koji sadrži konstante PrazanPut, Gužva i Pričekaj.
                ► Ukoliko je svetlo zeleno na komandnoj liniji će se ispisati “Kreni” i PrazanPut.
                ► Ukoliko je svetlo žuto ispisuje se “Priprema” i Pričekaj.
                ► Ukoliko je svetlo crveno ispisuje se “Čekaj” i Gužva.
                ► Setovati promenjivu tipa Semafor na zeleno.
             */

            Semafor boja=Semafor.zeleno;
            StanjeNaPutu stanje;
            if (boja == Semafor.zeleno) {//provera

                Console.WriteLine("Kreni");
                stanje = StanjeNaPutu.PrazanPut;
                Console.WriteLine(stanje);
            } else if (boja == Semafor.crveno) {
                Console.WriteLine("Cekaj");
                stanje = StanjeNaPutu.Guzva;
                Console.WriteLine(stanje);
            } else if (boja==Semafor.zuto) {
                Console.WriteLine("Priprema");
                stanje = StanjeNaPutu.Pricekaj;
                Console.WriteLine(stanje);
            }

            Console.ReadKey();


            //Zadatak 4
            /*► Napraviti konzolnu aplikaciju koja će predstavljati malu bazu podatka za čuvanje
                knjiga.
                ► Za svaku knjigu beleži se naslov i autor.
                ► Program treba da čuva do 1000 knjiga.
                ► Korisniku treba biti omogućen:
                - unos nove knjige,
                - prikaz svih unesenih knjiga (samo naslov i autor u istom redu),
                - pretraga za određenom knjigom po naslovu,
                - brisanje knjiga na određenoj poziciji (na primer - obriši knjigu na poziciji 4),
                - izlaz iz programa.
                */
            int kapacitet = 1000; //program cuva max ovoliko knjiga u bazi
            Knjiga[] knjige = new Knjiga[kapacitet];
            bool ponovi = true;
            string opcija;
            int kolicina = 0;
            string trazi;
            bool pronadjeno;


        do { 
                Console.WriteLine();
                Console.WriteLine("Baza knjiga");
                Console.WriteLine();
                Console.WriteLine("1-Dodaj novu knjigu");
                Console.WriteLine("2-Prikazi sve knjige");
                Console.WriteLine("3-Pronadji odredjenu knjigu");
                Console.WriteLine("4-Obrisi knjigu");
                Console.WriteLine("0-Izlaz");
                Console.Write("Unesite opciju: ");
                opcija = Console.ReadLine();

            switch (opcija) {

                case"1": //Dodaj novu knjigu
                    if (kolicina < kapacitet)//ne smemo prekoraciti kapacitet
                    {

                        Console.WriteLine("Unesite podatke o knjizi {0}", kolicina + 1);
                        Console.Write("Unesite ime knjige ");
                        knjige[kolicina].naslov = Console.ReadLine();

                        kolicina++;
                        Console.WriteLine();
                    }
                    else
                        Console.WriteLine("Baza je puna."); //kraj if-a
                    break;//kraj 1. slucaja

                case"2"://Prikazi sve knjige na stanju/u bazi
                    if (kolicina == 0)
                    
                        Console.WriteLine("Nema podataka.");
                    
                    else {
                        for (int i = 0; i < kolicina; i++) {

                            Console.WriteLine("{0}:Naslov={1}, Autor={2}", i+1, knjige[i].naslov, knjige[i].autor);

                            Console.WriteLine();    
                        }
                    }

                    break;
                        
                case "3"://Pretrazi specificnu knjigu, da li se nalazi u bazi
                    Console.WriteLine("Unesite ime knjige ");
                    trazi = Console.ReadLine();
                    pronadjeno = false;

                    for (int i = 0; i < kolicina; i++) {

                        if (knjige[i].naslov == trazi) {
                            Console.WriteLine("Knjiga {0} pronadjena", knjige[i].naslov);
                            pronadjeno = true;
                        }

                        if (!pronadjeno)
                            Console.WriteLine("Knjiga nije pronadjena.");

                    
                    }Console.WriteLine();

                    break;

                case "4":

                    if (kolicina == 0)
                        Console.WriteLine("Nema podataka za brisanje.");

                    else
                    {

                        Console.WriteLine("Unesite broj knjige koju zelite da obrisete od 1 do {0}",kolicina);
                        int posToDelete = int.Parse(Console.ReadLine()) - 1;

                        for (int i = posToDelete; i < kolicina - 1; i++)

                            knjige[i] = knjige[i + 1];

                        kolicina--;
                    }
                    break;


                case "0":

                    ponovi = false;
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Pogresna opcija. Odaberite poziciju iz menija.\n");
                    break;

            }// kraj switch-a

        } while(ponovi);//do while

    }//kraj main-a
    }//class
    }//namespace

