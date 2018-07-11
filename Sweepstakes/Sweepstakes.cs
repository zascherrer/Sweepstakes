using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Sweepstakes
    {
        public Dictionary<Guid, Contestant> registration;
        public List<Guid> registrationNumbers;
        public string name;

        public Sweepstakes(string name)
        {
            this.name = name;
            registration = new Dictionary<Guid, Contestant>();
            registrationNumbers = new List<Guid>();

            Console.WriteLine("The {0} Sweepstakes has been created!", name);
        }

        public void RegisterContestant(Contestant contestant)
        {
            registrationNumbers.Add(contestant.registrationNumber);
            registration.Add(contestant.registrationNumber, contestant);
        }

        public string PickWinner()
        {
            Random random = new Random();
            int indexOfTicketDrawn = random.Next(registrationNumbers.Count);
            Guid ticketDrawn = registrationNumbers[indexOfTicketDrawn];
            Contestant winner;

            if(registration.TryGetValue(ticketDrawn, out winner))
            {
                Console.WriteLine("\nWe have a winner!");
            }
            else
            {
                Console.WriteLine("\nWinner not found... for some reason.");
            }
            string winnerName = winner.firstName + " " + winner.lastName;

            NotifyContestants(winner);
            MailSender.SendMail("Congratulations, " + winnerName + " you've won the " + name + " Sweepstakes!!!", winner.email);

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

        public void NotifyContestants(Contestant winner)
        {
            List<Contestant> contestantsWithoutDuplicates = new List<Contestant>();

            foreach(KeyValuePair<Guid, Contestant> contestant in registration)
            {
                bool duplicateContestantFound = false;

                for (int i = 0; i < contestantsWithoutDuplicates.Count; i++)
                {
                    if(contestantsWithoutDuplicates[i].firstName == contestant.Value.firstName && contestantsWithoutDuplicates[i].lastName == contestant.Value.lastName)
                    {
                        duplicateContestantFound = true;
                    }
                }

                if (!duplicateContestantFound)
                {
                    contestantsWithoutDuplicates.Add(contestant.Value);
                }
            }

            for(int i = 0; i < contestantsWithoutDuplicates.Count; i++)
            {
                if(contestantsWithoutDuplicates[i].firstName == winner.firstName && contestantsWithoutDuplicates[i].lastName == winner.lastName)
                {
                    Console.WriteLine("Congratulations, {0} {1}, you won the {2} Sweepstakes!!!", winner.firstName, winner.lastName, name);
                }
                else
                {
                    Console.WriteLine("Sorry, {0} {1}, you are not the winner.", contestantsWithoutDuplicates[i].firstName, contestantsWithoutDuplicates[i].lastName);
                }
            }
        }
    }
}
