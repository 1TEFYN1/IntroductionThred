using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionThred
{
    class RaceTrack
    {
        private static List<Car> _cars;
        private int _trackLength;
        private int _carCount;
        private static bool[] _occupatedPosition;
        public RaceTrack(int carCount, int trackLength)
        {
            this._carCount = carCount;
            this._trackLength = trackLength;
            _occupatedPosition = new bool[_trackLength];
            _cars = new List<Car>();
            for(int i = 0; i < _carCount; i++)
            {
                _cars.Add(new Car(Speed: 1));
            }
        }

        public void StartRace()
        {
            Thread thread;
            for(int i = 0; i < _carCount; i++)
            {
                    int index = i;
                    thread = new(() => _cars[index].Move(_trackLength));
                    thread.Start();                               
            }
            
        }
        public static void DisplayRaceState()
        {
            
            for (int i = 0; i < _cars.Count; i++)
            {
                Console.WriteLine($"Car {i + 1}: Position {_cars[i].CurrentPosition}");
                
            }
        }
        public static bool IsOccupatingPosition(int position)
        {
            return _occupatedPosition[position];
        }
        public static void OccupyPosition(int position)
        {
            _occupatedPosition[position] = true;
        }
        public static void ReleasePosition(int position)
        {
            _occupatedPosition[position] = false;
        }
    }

}