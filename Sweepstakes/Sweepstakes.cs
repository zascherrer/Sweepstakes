using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Sweepstakes
    {
        Dictionary<Guid, Contestant> registration;
        List<Guid> registrationNumbers;
        Random random;
        string name;

        public Sweepstakes(string name)
        {
            this.name = name;
            registration = new Dictionary<Guid, Contestant>();
            registrationNumbers = new List<Guid>();
            random = new Random();

            Console.WriteLine("Welcome to the {0} Sweepstakes!");
        }

        public void RegisterContestant(Contestant contestant)
        {
            registrationNumbers.Add(contestant.registrationNumber);
            registration.Add(contestant.registrationNumber, contestant);
        }

        public string PickWinner()
        {
            int indexOfTicketDrawn = random.Next(registrationNumbers.Count);
            Guid ticketDrawn = registrationNumbers[indexOfTicketDrawn];
            Contestant winner;

            if(registration.TryGetValue(ticketDrawn, out winner))
            {
                Console.WriteLine("We have a winner!");
            }
            else
            {
                Console.WriteLine("Winner not found... for some reason.");
            }
            string winnerName = winner.firstName + " " + winner.lastName;

            return winnerName;
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine("\n" +
                "Name: {0} {1} \n" +
                "Email: {2} \n" +
                "Registration Number: {3}",
                contestant.firstName, contestant.lastName, contestant.email, contestant.registrationNumber);
        }
    }
}
