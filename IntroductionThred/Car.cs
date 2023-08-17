using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IntroductionThred
{
    class Car
    {
        public int CurrentPosition { get; set; }
        public int Speed { get; set; }
        private object locker = new();
        public Car(int Speed)
        {
            this.Speed = Speed;
        }
        public void Move(int trackLength)
        {
            while (CurrentPosition < trackLength)
            {
                if (!RaceTrack.IsOccupatingPosition(CurrentPosition))
                {
                    RaceTrack.OccupyPosition(CurrentPosition);
                    CurrentPosition += Speed;                    
                    RaceTrack.ReleasePosition(CurrentPosition - Speed);                   
                    RaceTrack.DisplayRaceState();
                    

                }
            }
        }
    }
}
