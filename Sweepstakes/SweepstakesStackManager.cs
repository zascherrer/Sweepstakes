using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class SweepstakesStackManager : ISweepstakesManager
    {
        Stack<Sweepstakes> sweepstakesStack;

        public SweepstakesStackManager()
        {
            sweepstakesStack = new Stack<Sweepstakes>();
        }

        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            sweepstakesStack.Push(sweepstakes);
        }

        public Sweepstakes GetSweepstakes()
        {
            Sweepstakes sweepstakes = sweepstakesStack.Pop();
            return sweepstakes;
        }

        public int GetNumberOfSweepstakes()
        {
            return sweepstakesStack.Count;
        }
    }
}
