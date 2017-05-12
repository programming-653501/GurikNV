using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Prog7
{
    class Program
    {
        static Dictionary<string, List<string[]>> Hotels = GetInput();

        static Dictionary<string, List<string[]>> GetInput()
        {
            var ByteHotelQuest = File.ReadAllBytes(@"HotelQuest.gcf");
            var ByteTravelWeb = File.ReadAllBytes(@"TravelWeb.gcf");
            var Byteopodo = File.ReadAllBytes(@"opodo.gcf");
            var Bytehotels = File.ReadAllBytes(@"hotels.gcf");
            var Byteorbitz = File.ReadAllBytes(@"orbitz.gcf");
            var ByteAllHotels = File.ReadAllBytes(@"AllHotels.gcf");
            var ByteTravelWorm = File.ReadAllBytes(@"TravelWorm.gcf");

            Encoding encoder = Encoding.Default;

            var RawHotelQuest = encoder.GetString(ByteHotelQuest);
            var RawTravelWeb = encoder.GetString(ByteTravelWeb);
            var Rawopodo = encoder.GetString(Byteopodo);
            var Rawhotels = encoder.GetString(Bytehotels);
            var Raworbitz = encoder.GetString(Byteorbitz);
            var RawAllHotels = encoder.GetString(ByteAllHotels);
            var RawTravelWorm = encoder.GetString(ByteTravelWorm);

            var HotelQuest = RawHotelQuest.Split('*');
            var TravelWeb = RawTravelWeb.Split('*');
            var opodo = Rawopodo.Split('*');
            var hotels = Rawhotels.Split('*');
            var orbitz = Raworbitz.Split('*');
            var AllHotels = RawAllHotels.Split('*');
            var TravelWorm = RawTravelWorm.Split('*');

            var TempHotels = new Dictionary<string, List<string[]>>();

            TempHotels["HotelQuest"] = new List<string[]>();
            TempHotels["TravelWeb"] = new List<string[]>();
            TempHotels["opodo"] = new List<string[]>();
            TempHotels["hotels"] = new List<string[]>();
            TempHotels["orbitz"] = new List<string[]>();
            TempHotels["AllHotels"] = new List<string[]>();
            TempHotels["TravelWorm"] = new List<string[]>();

            foreach (var HotelQuestItem in HotelQuest)
            {
                TempHotels["HotelQuest"].Add(HotelQuestItem.Split(' '));
            }
            foreach (var TravelWebItem in TravelWeb)
            {
                TempHotels["TravelWeb"].Add(TravelWebItem.Split(' '));
            }
            foreach (var opodoItem in opodo)
            {
                TempHotels["opodo"].Add(opodoItem.Split(' '));
            }
            foreach (var hotelsItem in hotels)
            {
                TempHotels["hotels"].Add(hotelsItem.Split(' '));
            }
            foreach (var orbitzItem in orbitz)
            {
                TempHotels["orbitz"].Add(orbitzItem.Split(' '));
            }
            foreach (var AllHotelsItem in AllHotels)
            {
                TempHotels["AllHotels"].Add(AllHotelsItem.Split(' '));
            }
            foreach (var TravelWormItem in TravelWorm)
            {
                TempHotels["TravelWorm"].Add(TravelWormItem.Split(' '));
            }
            return TempHotels;
        }

        static void ShowMenu()
        {
            WriteLine("1.Add new room\n2.Save files\n3.Find rooms\n4.Show rooms\n0.Exit");
        }

        static void ShowRooms(Dictionary<string, List<string[]>> Hotels)
        {
            Clear();
            foreach (var db in Hotels)
            {
                WriteLine(db.Key);
                foreach (var room in db.Value)
                {
                    foreach (var s in room)
                    {
                        Write(s + '\t');
                    }
                    WriteLine();
                }
            }
            ReadKey();
        }

        static void AddRoom()
        {
            Clear();
            WriteLine("Enter the name of database");
            string DB;
            while (true)
            {
                DB = ReadLine();
                if (Hotels.ContainsKey(DB))
                {
                    break;
                }
                WriteLine("Database is not found");
            }
            string[] DBItem = new string[6];

            WriteLine("Enter hotel name");
            DBItem[0] = ReadLine();

            WriteLine("Enter hotel city");
            DBItem[1] = ReadLine();

            WriteLine("Enter hotel address");
            DBItem[2] = ReadLine();

            WriteLine("Enter room type");
            DBItem[3] = ReadLine();

            WriteLine("Enter room capacity");
            DBItem[4] = ReadLine();

            WriteLine("Enter room cost");
            DBItem[5] = ReadLine();

            Hotels[DB].Add(DBItem);
        }

        static void FindRoom()
        {
            Clear();
            WriteLine("1.Search by hotel name\n2.Search by hotel city\n3.Search by hotel address\n4.Search by room type\n5.Search by room capacity\n6.Search by room cost\n0.Quit");
            switch (ReadLine())
            {
                case "1":
                {
                    Clear();
                    WriteLine("Enter hotel name");
                    var filter = ReadLine();
                    foreach (var db in Hotels)
                    {
                        WriteLine(db.Key);
                        foreach (var room in db.Value)
                        {
                            if (room[0].Equals(""))
                            {
                                continue;
                            }
                            if (room[0] == filter)
                            {
                                foreach (var s in room)
                                {
                                    Write(s + '\t');
                                }
                                WriteLine();
                            }
                        }
                    }
                    ReadKey();
                    break;
                }
                case "2":
                {
                    Clear();
                    WriteLine("Enter hotel city");
                    var filter = ReadLine();
                    foreach (var db in Hotels)
                    {
                        WriteLine(db.Key);
                        foreach (var room in db.Value)
                        {
                            if (room[0].Equals(""))
                            {
                                continue;
                            }
                            if (room[1] == filter)
                            {
                                foreach (var s in room)
                                {
                                    Write(s + '\t');
                                }
                                WriteLine();
                            }
                        }
                    }
                    ReadKey();
                    break;
                }
                case "3":
                {
                    Clear();
                    WriteLine("Enter hotel address");
                    var filter = ReadLine();
                    foreach (var db in Hotels)
                    {
                        WriteLine(db.Key);
                        foreach (var room in db.Value)
                        {
                            if (room[0].Equals(""))
                            {
                                continue;
                            }
                                if (room[2] == filter)
                            {
                                foreach (var s in room)
                                {
                                    Write(s + '\t');
                                }
                                WriteLine();
                            }
                        }
                    }
                    ReadKey();
                    break;
                    }
                case "4":
                {
                    Clear();
                    WriteLine("Enter room type");
                    var filter = ReadLine();
                    foreach (var db in Hotels)
                    {
                        WriteLine(db.Key);
                        foreach (var room in db.Value)
                        {
                            if (room[0].Equals(""))
                            {
                                continue;
                            }
                            if (room[3] == filter)
                            {
                                foreach (var s in room)
                                {
                                    Write(s + '\t');
                                }
                                WriteLine();
                            }
                        }
                    }
                    ReadKey();
                    break;
                    }
                case "5":
                {
                    Clear();
                    WriteLine("Enter room capacity");
                    var filter = ReadLine();
                    foreach (var db in Hotels)
                    {
                        WriteLine(db.Key);
                        foreach (var room in db.Value)
                        {
                            if (room[0].Equals(""))
                            {
                                continue;
                            }
                            if (room[4] == filter)
                            {
                                foreach (var s in room)
                                {
                                    Write(s + '\t');
                                }
                                WriteLine();
                            }
                        }
                    }
                    ReadKey();
                    break;
                    }
                case "6":
                {
                    Clear();
                    WriteLine("Enter room cost");
                    var filter = ReadLine();
                    foreach (var db in Hotels)
                    {
                        WriteLine(db.Key);
                        foreach (var room in db.Value)
                        {
                            if (room[0].Equals(""))
                            {
                                continue;
                            }
                            if (room[5] == filter)
                            {
                                foreach (var s in room)
                                {
                                    Write(s + '\t');
                                }
                                WriteLine();
                            }
                        }
                    }
                    ReadKey();
                    break;
                    }
                case "0":
                {
                    return;
                }
                default:
                {
                    WriteLine("Wrong command");
                    break;
                }
            }
        }

        static void SaveFile(Dictionary<string, List<string[]>> Hotels)
        {
            Encoding encoder = Encoding.Default;

            var HotelQuestFile = "";

            foreach (var room in Hotels["HotelQuest"])
            {
                foreach (var s in room)
                {
                    HotelQuestFile = string.Concat(HotelQuestFile, s, " ");
                }
                if (HotelQuestFile != "") {HotelQuestFile.Remove(HotelQuestFile.Length - 1);} 
                HotelQuestFile = string.Concat(HotelQuestFile, "*");
            }
            if (HotelQuestFile != "") { HotelQuestFile.Remove(HotelQuestFile.Length - 1); }

            File.WriteAllBytes(@"HotelQuest.gcf", encoder.GetBytes(HotelQuestFile));

            var TravelWebFile = "";

            foreach (var room in Hotels["TravelWeb"])
            {
                foreach (var s in room)
                {
                    TravelWebFile = string.Concat(TravelWebFile, s, " ");
                }
                if (TravelWebFile != "") { TravelWebFile.Remove(TravelWebFile.Length - 1); }
                TravelWebFile = string.Concat(TravelWebFile, "*");
            }
            if (TravelWebFile != "") { TravelWebFile.Remove(TravelWebFile.Length - 1); }

            File.WriteAllBytes(@"TravelWeb.gcf", encoder.GetBytes(TravelWebFile));

            var opodo = "";

            foreach (var room in Hotels["opodo"])
            {
                foreach (var s in room)
                {
                    opodo = string.Concat(opodo, s, " ");
                }
                if (opodo != "") { opodo.Remove(opodo.Length - 1); }
                opodo = string.Concat(opodo, "*");
            }
            if (opodo != "") { opodo.Remove(opodo.Length - 1); }

            File.WriteAllBytes(@"opodo.gcf", encoder.GetBytes(opodo));

            var hotels = "";

            foreach (var room in Hotels["hotels"])
            {
                foreach (var s in room)
                {
                    hotels = string.Concat(hotels, s, " ");
                }
                if (hotels != "") { hotels.Remove(hotels.Length - 1); }
                hotels = string.Concat(hotels, "*");
            }
            if (hotels != "") { hotels.Remove(hotels.Length - 1); }

            File.WriteAllBytes(@"hotels.gcf", encoder.GetBytes(hotels));

            var orbitz = "";

            foreach (var room in Hotels["orbitz"])
            {
                foreach (var s in room)
                {
                    orbitz = string.Concat(orbitz, s, " ");
                }
                if (orbitz != "") { orbitz.Remove(orbitz.Length - 1); }
                orbitz = string.Concat(orbitz, "*");
            }
            if (orbitz != "") { orbitz.Remove(orbitz.Length - 1); }

            File.WriteAllBytes(@"orbitz.gcf", encoder.GetBytes(orbitz));

            var AllHotels = "";

            foreach (var room in Hotels["AllHotels"])
            {
                foreach (var s in room)
                {
                    AllHotels = string.Concat(AllHotels, s, " ");
                }
                if (AllHotels != "") { AllHotels.Remove(AllHotels.Length - 1); }
                AllHotels = string.Concat(AllHotels, "*");
            }
            if (AllHotels != "") { AllHotels.Remove(AllHotels.Length - 1); }

            File.WriteAllBytes(@"AllHotels.gcf", encoder.GetBytes(AllHotels));

            var TravelWorm = "";

            foreach (var room in Hotels["TravelWorm"])
            {
                foreach (var s in room)
                {
                    TravelWorm = string.Concat(TravelWorm, s, " ");
                }
                if (TravelWorm != "") { TravelWorm.Remove(TravelWorm.Length - 1); }
                TravelWorm = string.Concat(TravelWorm, "*");
            }
            if (TravelWorm != "") { TravelWorm.Remove(TravelWorm.Length - 1); }

            File.WriteAllBytes(@"TravelWorm.gcf", encoder.GetBytes(TravelWorm));
        }

        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                switch (ReadLine())
                {
                    case "1":
                    {
                        AddRoom();
                        break;
                    }
                    case "2":
                    {
                        SaveFile(Hotels);
                        break;
                    }
                    case "3":
                    {
                        FindRoom();
                        break;
                    }
                    case "4":
                    {
                        ShowRooms(Hotels);
                        break;
                    }
                    case "0":
                    {
                        return;
                    }
                    default:
                    {
                        WriteLine("Incorrect input!");
                        break;
                    }
                }
                Clear();
            }
        }
    }
}
