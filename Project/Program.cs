using Microsoft.VisualBasic;
using Project.Enums;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Inspector> list = new List<Inspector>();
            int i = 0;
            while (true)
            {
                Console.WriteLine("1 - Rate the restaurant\n2 - Add a restaurant to the check list\n3 - Remove a restaurant from the check list\n4 - Change owner\n5 - Check list\n0 - Exit");
                int choose = Convert.ToInt32(Console.ReadLine());
                if (choose == 0) { break; }
                switch (choose)
                {
                    case 1:
                        i = 0;
                        if (list.Count == 0)
                        {
                            Console.WriteLine("Empty check list!");  //переделать в Exception
                            break;
                        }
                        Console.WriteLine("Choose:\n");
                        foreach (Inspector rating in list)
                        {
                            Console.WriteLine(++i + " " + rating.ToString() + "\n");
                        }
                        i = Convert.ToInt32(Console.ReadLine());
                        if (i <= list.Count && list[i - 1].Rating != null) 
                        {
                            Console.WriteLine("Already rated!");  //переделать в Exception
                            break;
                        }
                        Console.WriteLine("Please rate the restaurant:");
                        choose = Convert.ToInt32(Console.ReadLine());
                        if (choose >= 0 && choose <= 10)
                        {
                            list[i - 1].Rating = choose;
                            Console.WriteLine("Rated");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter the name of the restaurant:");
                        string? name = Console.ReadLine();
                        bool enough = false;
                        Inspector added;
                        Restaurant restaurant;
                        Owner owner;
                        List<Worker> workers = new List<Worker>();
                        if (name != null)
                        {
                            restaurant = new Restaurant(name);
                            string[] strings;
                            do
                            {
                                Console.WriteLine("Enter the name, surname, age & income of the restaurant owner:\nExample: Ryan Gosling 43 20000000");
                                name = Console.ReadLine();
                                strings = name.Split();
                                if (strings.Length < 4 || strings.Length > 4)
                                {
                                    Console.WriteLine("Invalid type");  //переделать в Exception
                                    break;
                                }
                                enough = true;
                            } while (!enough);
                            owner = new Owner(strings[0], strings[1], Convert.ToInt32(strings[2]), Convert.ToInt32(strings[3]));
                            Console.WriteLine("Owner added!");
                            Console.WriteLine("Write below restaurant workers");
                            choose = Convert.ToInt32(Console.ReadLine());
                            for (int k = 0; k < choose; k++)
                            {
                                Worker worker;
                                enough = false;
                                while (!enough)
                                {
                                    Console.WriteLine("Enter the name, surname, age & type job(Barmen, Cook, Waiter) of the restaurant worker:\nExample: Michaele Smitt 23 Barmen");
                                    name = Console.ReadLine();
                                    strings = name.Split();
                                    if (strings.Length < 4 || strings.Length > 4)
                                    {
                                        Console.WriteLine("Invalid type");  //переделать в Exception
                                        break;
                                    }
                                    int choise = 0;
                                    switch (strings[3])
                                    {
                                        case "Barmen":
                                            enough = true;
                                            choise = 1;
                                            break;
                                        case "Cook":
                                            enough = true;
                                            choise = 2;
                                            break;
                                        case "Waiter":
                                            enough = true;
                                            choise = 3;
                                            break;
                                        default:
                                            Console.WriteLine("Innvalid Type!");  //переделать в Exception
                                            break;
                                    }
                                    if (enough)
                                    {
                                        worker = new Worker(k+1, strings[0], strings[1], Convert.ToInt32(strings[2]), (Job)choise);
                                        workers.Add(worker);
                                        Console.WriteLine("Worker added!");
                                    }
                                }
                            }
                            name = restaurant.Name;
                            restaurant = new Restaurant(name, owner, workers);
                            added = new Inspector(restaurant, null);
                            list.Add(added);
                        }
                        break;
                    case 3:
                        if (list.Count == 0)
                            Console.WriteLine("Empty check list!");  //переделать в Exception
                        else
                        {
                            i = 0;
                            Console.WriteLine("Choose:\n");
                            foreach (Inspector rating in list)
                            {
                                Console.WriteLine(++i + " " + rating.ToString() + "\n");
                            }
                            i = Convert.ToInt32(Console.ReadLine());
                            list.RemoveAt(i-1);
                            Console.WriteLine("Removed!");
                        }
                        break;
                    case 4:
                        if (list.Count == 0)
                            Console.WriteLine("Empty check list!");  //переделать в Exception
                        else
                        {
                            if (list.Count > 1)
                            {
                                i = 0;
                                Console.WriteLine("Choose owner:\n");
                                foreach (Inspector rating in list)
                                {
                                    Console.WriteLine(++i + " " + rating.ToString() + $"\n{rating.Restaurant.OwnerToSyring()}\n");
                                }
                                i = Convert.ToInt32(Console.ReadLine());
                                Owner copy = (Owner)list[i - 1].Restaurant.Owner.Clone();
                                int sort = 0;
                                Console.WriteLine("Choose owner to change:\n");
                                foreach (Inspector rating in list)
                                {
                                    sort++;
                                    if (sort != i)
                                        Console.WriteLine(sort + " " + rating.ToString() + $"\n{rating.Restaurant.OwnerToSyring()}\n");
                                }
                                sort = Convert.ToInt32(Console.ReadLine());
                                if (sort != i)
                                {
                                    list[sort - 1].Restaurant.Owner = copy;
                                    Console.WriteLine("Changed!");
                                }
                                else
                                    Console.WriteLine("Invalid Option!");  //переделать в Exception
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine();
                        if (list.Count == 0)
                            Console.WriteLine("Empty check list!");  //переделать в Exception
                        else
                            foreach (Inspector inspec in list)
                                Console.WriteLine(inspec.PrintToDisplay());
                        break;
                    default:
                        Console.WriteLine("Invalid Option!");  //переделать в Exception
                        break;
                }
            }
        }
    }
}