using System;
using Factory;
namespace CreationalDesignPatterns
{
    class Program
    {
        static void Main()
        {
            Provider providerKiev = new KievProvider("Kiev provider");
            Provider providerLviv = new LvivProvider("Lviv provider");
            Provider providerOdessa = new OdessaProvider("Odessa provider");
            Order order = new Order();
            Material concrete = new Concrete();
            Material brick = new Brick();
            Material slabs = new ReinforcedConcreteSlabs();

            concrete.SetDayRequirement(100);
            brick.SetDayRequirement(100);
            slabs.SetDayRequirement(50);
            bool flag = true;
            while (flag)
            {
                Console.WriteLine(" 1. Show product info\t 2. Make order\t 3. Show order\t 4. Show daily requirment\t 5. Exit\t ");
                Console.WriteLine();
                try
                {
                    int pickNumber = Convert.ToInt32(Console.ReadLine());
                    if (pickNumber <= 0 || pickNumber > 5)
                        throw new Exception("Invalid pick number of category. Please, try again");
                    else
                        try
                        {
                            switch (pickNumber)
                            {
                                case 1:
                                    Console.WriteLine("-----{0}------",providerKiev.Name);
                                     foreach (var material in order.GetInfo(providerKiev))
                                        Console.WriteLine("Material: {0}\n Type: {1}\n Price: {2}$\n Max Amount: {3} pc \n",
                                material.Name, material.Type, material.Price, material.MaxAmount);
                                    Console.WriteLine();

                                    Console.WriteLine("-----{0}------", providerLviv.Name);
                                    foreach (var material in order.GetInfo(providerLviv))
                                        Console.WriteLine("Material: {0}\n Type: {1}\n Price: {2}$\n Max Amount: {3} pc \n",
                                material.Name, material.Type, material.Price, material.MaxAmount);
                                    Console.WriteLine();

                                    Console.WriteLine("-----{0}------", providerOdessa.Name);
                                    foreach (var material in order.GetInfo(providerLviv))
                                        Console.WriteLine("Material: {0}\n Type: {1}\n Price: {2}$\n Max Amount: {3} pc \n",
                                material.Name, material.Type, material.Price, material.MaxAmount);
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    SelectProvider(order, providerKiev, providerLviv, providerOdessa);
                                    break;
                                case 3:
                                    ShowOrder(order);
                                    break;
                                case 4:
                                    Console.WriteLine(" 1.Concrete: {0}\n 2.Brick: {1}\n 3.Slabs: {2}\n ", concrete.DayRequirement, brick.DayRequirement, slabs.DayRequirement);
                                    break;
                                case 5:
                                    Exit();
                                    break;
                            }
                        }
                        catch (ArgumentException)
                        {
                            ConsoleColor color = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid pick number of category");
                            Console.ForegroundColor = color;
                        }
                }
                catch (Exception ex)
                {
                    ConsoleColor color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }
            Console.ReadKey();
        }
        static void Exit()
        {
            Environment.Exit(0);
        }
        static void SelectProvider(Order order, Provider provider1, Provider provider2, Provider provider3 )
        {
            Console.WriteLine(" 1. {0}\n 2. {1}\n 3. {2}\n 4. Back ", provider1.Name, provider2.Name, provider3.Name);
            Console.WriteLine("Select Provider");
            int pickNumber = Convert.ToInt32(Console.ReadLine());
            if (pickNumber >= 0 || pickNumber < 4)
            {
                switch (pickNumber)
                {
                    case 1:
                        foreach (var material in order.GetInfo(provider1))
                            Console.WriteLine("Material: {0}\n Type: {1}\n Price: {2}$\n Max Amount: {3} pc \n",
                    material.Name, material.Type, material.Price, material.MaxAmount);
                        SelectMaterial(order, provider1);
                        break;
                    case 2:
                        foreach (var material in order.GetInfo(provider2))
                            Console.WriteLine("Material: {0}\n Type: {1}\n Price: {2}$\n Max Amount: {3} pc \n",
                    material.Name, material.Type, material.Price, material.MaxAmount);
                        SelectMaterial(order, provider2);
                        break;
                    case 3:
                        foreach (var material in order.GetInfo(provider3))
                            Console.WriteLine("Material: {0}\n Type: {1}\n Price: {2}$\n Max Amount: {3} pc \n",
                    material.Name, material.Type, material.Price, material.MaxAmount);
                        SelectMaterial(order, provider3);
                        break;
                    case 4:
                        Main();
                        break;
                }
            }
        }
        static void SelectMaterial(Order order, Provider provider)
        {
            Console.WriteLine(" 1.Concrete \n 2.Brick \n 3.Slabs \n 4.Back\n ");
            Console.WriteLine("Select material");
            int pickNumber = Convert.ToInt32(Console.ReadLine());
            if (pickNumber >= 0 || pickNumber < 4)
            {
                switch (pickNumber)
                {
                    case 1:
                        SelectPieces(order, provider.GetConcrete());
                        break;
                    case 2:
                        SelectPieces(order,  provider.GetBrick());
                        break;
                    case 3:
                        SelectPieces(order,  provider.GetReinforcedConcreteSlabs());
                        break;
                    case 4:
                        Main();
                        break;
                }
            }
        }

        static void SelectPieces(Order order, Material material)
        {
            Console.WriteLine();
            Console.WriteLine("Select pieces of: {0}", material.Name);
            int pickNumber = Convert.ToInt32(Console.ReadLine());
            order.SetOrder( material, pickNumber);
            ShowOrder(order);
        }

        static void ShowOrder(Order order)
        {
            if (order.ListOfOrdersMaterials != null)
            {
                foreach (var item in order.ListOfOrdersMaterials)
                {
                    Console.WriteLine("Order materials: {0}, price: {1} $/pc, pieces:{2}, Total price:{3}$\n ",
                       item.Name, item.Price, item.NumberNow, item.Price * item.NumberNow);

                }
            }
            else throw new Exception("Order is empty");
        }
    }
}
