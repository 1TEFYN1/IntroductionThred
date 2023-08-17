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
        private static bool[] _occupatedPositions;
        private int _trackLength;
        private int _carCount;

        public RaceTrack(int carCount, int trackLength)
        {
            this._carCount = carCount;
            this._trackLength = trackLength;
            init();
        }

        public void StartRace()
        {
            for(int i = 0; i < _carCount; i++)
            {
                StartCarByIndex(i);
            }
        }

        public void DisplayRaceState()
        {
            for (int i = 0; i < _cars.Count; i++)
            {
                Console.WriteLine($"Car {i + 1}: Position {_cars[i].CurrentPosition}");
            }
        }

        public bool IsOccupatingPosition(int position)
        {
            return _occupatedPositions[position];
        }

        public void OccupyPosition(int position)
        {
            _occupatedPositions[position] = true;
        }

        public void ReleasePosition(int position)
        {
            _occupatedPositions[position] = false;
        }

        private void init()
        {
            _occupatedPositions = new bool[_trackLength];
            _cars = new List<Car>();
            fillCarList();
        }

        private void fillCarList()
        {
            for(int i = 0; i < _carCount; i++)
            {
                _cars.Add(new Car(Speed: 1, RaceTrack: this));
            }
        }

        private void StartCarByIndex(int index)
        {
            Thread car = new(() => _cars[index].Move(_trackLength));
            car.Start();
        }
    }
}