using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public static class UserInterface
    {
        public static Sweepstakes sweepstakes;

        static UserInterface()
        {
            sweepstakes = new Sweepstakes("devCode");
        }


        public static void EnterContestant()
        {
            Contestant contestant = EnterContestantInformation();
            int numberOfTickets = SetNumberOfTickets();
            
            for(int i = 0; i < numberOfTickets; i++)
            {
                Contestant newTicket = new Contestant(contestant.firstName, contestant.lastName, contestant.email);
                sweepstakes.RegisterContestant(newTicket);
            }
        }

        public static Contestant EnterContestantInformation()
        {
            Contestant contestant = new Contestant();

            contestant.firstName = GetUserInput("Please enter your first name: ");
            contestant.lastName = GetUserInput("Please enter your last name: ");
            contestant.email = GetUserInput("Please enter your email address: ");

            return contestant;
        }

        private static string GetUserInput(string message)
        {
            Console.WriteLine("/n" + message);
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
