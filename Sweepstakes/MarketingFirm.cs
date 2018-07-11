using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class MarketingFirm
    {
        public ISweepstakesManager sweepstakesManager;
        private ICreateSweepstakesManager sweepstakesManagerFactory;

        public MarketingFirm()
        {
            sweepstakesManagerFactory = new SweepstakesManagerFactory();
            ISweepstakesManager chosenSweepstakesManager = ChooseSweepstakesManager();

            this.sweepstakesManager = chosenSweepstakesManager;
        }

        public ISweepstakesManager ChooseSweepstakesManager()
        {
            ISweepstakesManager sweepstakesManager;

            Console.WriteLine("Would you like to use a stack or a queue to manage your sweepstakes? \n" +
                " 1. Stack \n" +
                " 2. Queue \n");
            string userInput = Console.ReadLine();
            sweepstakesManager = sweepstakesManagerFactory.CreateSweepstakesManager(userInput);

            return sweepstakesManager;
        }
    }
}
