using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class SweepstakesStackManager : ISweepstakesManager
    {
        Stack<Contestant> contestants;

        public SweepstakesStackManager()
        {
            contestants = new Stack<Contestant>();
        }

        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            Contestant contestant;

            for(int i = 0; i < sweepstakes.registrationNumbers.Count; i++)
            {
                sweepstakes.registration.TryGetValue(sweepstakes.registrationNumbers[i], out contestant);
                contestants.Push(contestant);
            }
        }

        public Sweepstakes GetSweepstakes()
        {
            Sweepstakes sweepstakes = new Sweepstakes("Stack");
            for (int i = 0; i < contestants.Count; i++)
            {
                sweepstakes.RegisterContestant(contestants.Pop());
            }
            return sweepstakes;
        }
    }
}
