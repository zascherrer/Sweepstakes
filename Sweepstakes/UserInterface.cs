using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public static class UserInterface
    {
        public static MarketingFirm marketingFirm;

        static UserInterface()
        {
            marketingFirm = new MarketingFirm();
        }

        public static void MainMenu()
        {
            bool stillRunning = true;
            string userInput;
            Sweepstakes sweepstakes;

            while (stillRunning)
            {
                Console.WriteLine("\n" +
                    "What would you like to do? \n" +
                    " 1. Create a sweepstakes \n" +
                    " 2. Enter a contestant in a sweepstakes \n" +
                    " 3. Pick a winner for a sweepstakes \n");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateSweepstakes();
                        break;
                    case "2":
                        if (marketingFirm.sweepstakesManager.GetNumberOfSweepstakes() > 0)
                        {
                            sweepstakes = ChooseSweepstakes();
                            EnterContestant(sweepstakes);
                            marketingFirm.sweepstakesManager.InsertSweepstakes(sweepstakes);
                        }
                        else
                        {
                            Console.WriteLine("\nThere are no sweepstakes available.");
                        }
                        break;
                    case "3":
                        if (marketingFirm.sweepstakesManager.GetNumberOfSweepstakes() > 0)
                        {
                            sweepstakes = ChooseSweepstakes();
                            string winnerName = sweepstakes.PickWinner();
                            Console.WriteLine("{0} has won the {1} Sweepstakes!", winnerName, sweepstakes.name);
                        }
                        else
                        {
                            Console.WriteLine("\nThere are no sweepstakes available.");
                        }
                        break;
                    default:
                        Console.WriteLine("\nPlease enter 1-3.");
                        break;
                }

            }
        }

        private static Sweepstakes ChooseSweepstakes()
        {
            bool sweepstakesFound = false;
            Sweepstakes sweepstakes = null;

            while (!sweepstakesFound)
            {
                Console.WriteLine("\nPlease enter the name of the sweepstakes.");
                string userInput = Console.ReadLine();
                sweepstakesFound = FindSweepstakes(userInput, out sweepstakes);
                if (!sweepstakesFound)
                {
                    Console.WriteLine("\nSweepstakes not found.");
                }
            }
            
            return sweepstakes;
        }

        private static bool FindSweepstakes(string userInput, out Sweepstakes sweepstakes)
        {
            Stack<Sweepstakes> temporary = new Stack<Sweepstakes>();
            sweepstakes = null;
            bool sweepstakesFound = false;
            int numberOfSweepstakes = marketingFirm.sweepstakesManager.GetNumberOfSweepstakes();

            for (int i = 0; i < numberOfSweepstakes; i++)
            {
                temporary.Push(marketingFirm.sweepstakesManager.GetSweepstakes());
                if (temporary.Peek().name == userInput)
                {
                    sweepstakes = temporary.Peek();
                    sweepstakesFound = true;
                }
            }

            int temporaryTotalCount = temporary.Count;
            for (int i = 0; i < temporaryTotalCount; i++)
            {
                marketingFirm.sweepstakesManager.InsertSweepstakes(temporary.Pop());
            }

            return sweepstakesFound;
        }

        public static void CreateSweepstakes()
        {
            Console.WriteLine("\nWhat would you like this sweepstakes to be called?");
            string name = Console.ReadLine();
            Sweepstakes sweepstakes = new Sweepstakes(name);
            marketingFirm.sweepstakesManager.InsertSweepstakes(sweepstakes);
        }

        public static void EnterContestant(Sweepstakes sweepstakes)
        {
            Contestant contestant = EnterContestantInformation();
            int numberOfTickets = SetNumberOfTickets();
            
            for(int i = 0; i < numberOfTickets; i++)
            {
                Contestant newTicket = new Contestant(contestant.firstName, contestant.lastName, contestant.email);
                sweepstakes.RegisterContestant(newTicket);
            }
        }

        private static Contestant EnterContestantInformation()
        {
            Contestant contestant = new Contestant();

            contestant.firstName = GetUserInput("Please enter your first name: ");
            contestant.lastName = GetUserInput("Please enter your last name: ");
            contestant.email = GetUserInput("Please enter your email address: ");

            return contestant;
        }

        private static string GetUserInput(string message)
        {
            Console.WriteLine("\n" + message);
            string input = Console.ReadLine();
            return input;
        }

        private static int SetNumberOfTickets()
        {
            string numberOfTicketsString = GetUserInput("How many tickets would you like to buy?");
            int numberOfTickets = 1;
            bool numberHasBeenEntered = int.TryParse(numberOfTicketsString, out numberOfTickets);

            return numberOfTickets;
        }
    }
}
