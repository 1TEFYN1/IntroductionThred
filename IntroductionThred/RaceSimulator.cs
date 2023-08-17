using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionThred
{
    class RaceSimulator
    {
        private int carsCount;
        private int lengthTrack;

        public RaceSimulator(int carsCount, int lengthTrack)
        {
            this.carsCount = carsCount;
            this.lengthTrack = lengthTrack;
        }
        public void StartRace()
        {
            RaceTrack raceTrack = new RaceTrack(carsCount, lengthTrack);
            raceTrack.StartRace();
        }
    }
}
