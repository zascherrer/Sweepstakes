using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class SweepstakesManagerFactory : ICreateSweepstakesManager
    {


        public ISweepstakesManager CreateSweepstakesManager(string userInput)
        {
            switch(userInput)
            {
                case "1":
                    return new SweepstakesStackManager();
                case "2":
                    return new SweepstakesQueueManager();
                default:
                    return new SweepstakesStackManager();
            }
        }
    }
}
