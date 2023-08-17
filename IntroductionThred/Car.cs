using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IntroductionThred
{
    class Car
    {
        private int CurrentPosition { get; set; }
        private int Speed { get; set; }
        private RaceTrack RaceTrack { get; set; }

        private object locker = new();

        public Car(int Speed, RaceTrack RaceTrack)
        {
            this.Speed = Speed;
            this.RaceTrack = RaceTrack;
        }

        public void Move(int trackLength)
        {
            while (CurrentPosition < trackLength)
            {
                TryToOccupyNextPossiton();
                RaceTrack.DisplayRaceState();
            }
        }

        private void TryToOccupyNextPossiton()
        {
            if (!RaceTrack.IsOccupatingPosition(CurrentPosition))
            {
                OccupyNextPossiton();
            }
        }

        private void OccupyNextPossiton()
        {
            RaceTrack.OccupyPosition(CurrentPosition);
            CurrentPosition += Speed;
            RaceTrack.ReleasePosition(CurrentPosition - Speed);
        }
    }
}
