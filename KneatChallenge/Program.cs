using KneatChallenge.ConsoleApp.Utils;
using KneatChallenge.DA.Starships;
using KneatChallenge.DA.Starships.impl;
using KneatChallenge.Models;
using KneatChallenge.Services.StopCalculator;
using KneatChallenge.Services.StopCalculator.impl;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Linq;

namespace KneatChallenge.ConsoleApp
{
    class Program
    {
        static StarshipsApiConsumer starshipsApiConsumer;
        static IStopCalculator iStopCalculator;
        static void Main(string[] args)
        {
            try
            {

                
                starshipsApiConsumer = new StarshipsSwapi(Configuration.Instance.getAppSettingValue("starshipsapiURI"));
                iStopCalculator = new StopCalculatorImpl();


                var t = Task.Run(() => app());
                t.Wait();

                Console.Clear();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        private static async Task app()
        {
            var getStarshipsTask = Task.Run(() => starshipsApiConsumer.GetStarships());
            char actionSelected = Menu.showMenu();
            List<Starship> listStarships = await getStarshipsTask;
            

            //if the charcater typed is not on the action dictionary the app will be closed.
            while (Menu.actions.Values.Contains(actionSelected))
            {
                if (actionSelected == Menu.actions["info"])
                {
                    Console.WriteLine("Starships Descriptions");
                    foreach (Starship starships in listStarships)
                    {
                        Console.WriteLine(starships.name + StringUtils.spaceGenerator(starships.name, 30) + "MGLT:" + starships.MGLT + ", Consumables:" + starships.consumables);
                    }
                }

                else
                if (actionSelected == Menu.actions["stop"])
                {
                    
                    Console.WriteLine("Please, enter a distance in mega lights (MGLT) to calculate the amount of stops for every starships.");
                    Console.Write("Distance: ");
                    string distanceString = Console.ReadLine();
                    long distance = long.Parse(distanceString, new CultureInfo("en-US"));
                    foreach (Starship starships in listStarships)
                    {
                        try
                        {
                            Console.WriteLine(starships.name + ": " + StringUtils.spaceGenerator(starships.name, 30) + iStopCalculator.getAmountStopRequired(starships, distance));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(starships.name + ": " + StringUtils.spaceGenerator(starships.name, 30) + ex.Message);
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press a key to continue.");
                Console.ReadKey();
                actionSelected = Menu.showMenu();
            }

        }


    }
}
