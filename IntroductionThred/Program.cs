using System;
using System.Threading;

namespace IntroductionThred
{
    class Program
    {
        static void Main(string[] args)
        {
            RaceSimulator raceSimulator = new(10, 78);
            raceSimulator.StartRace();
        }
    }
}
