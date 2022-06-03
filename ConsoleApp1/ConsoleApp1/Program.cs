using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Terminal terminal = new Terminal();
            terminal.Work();
        }
    }
    class Terminal
    {
        private List<Train> _sentTrains = new List<Train>();
        private Passengers _passenger = new Passengers();
        private bool _isWorking = true;

        public void Work()
        {
            while (_isWorking)
            {
                Console.WriteLine("Текущие рейсы:");
                ShowInfo();
                Console.WriteLine("1. Создать направление");
                Console.WriteLine("2. Выход");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SellTicket();
                        break;
                    case "2":
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Ошибка");
                        break;
                }
            }
        }

        private void SellTicket()
        {
            Console.WriteLine("Введите город отпавления");
            string placeOfDeparture = Console.ReadLine();
            Console.WriteLine("Введите город назначения");
            string destination = Console.ReadLine();
            int railcarNumber = GetRailcarNumber();
            int passengers = _passenger.CreatePassengers();

            if (placeOfDeparture.ToLower() == destination.ToLower())
            {
                Console.WriteLine("Ошибка");
            }
            else 
            {
                Console.WriteLine($"Создан маршрут {placeOfDeparture} - {destination}");
                _sentTrains.Add(new Train(passengers, railcarNumber, placeOfDeparture, destination));
            }
        }

        private int GetRailcarNumber()
        {
            int passengerPlace = 54;
            int railcarNumber = passengerPlace / _passenger.CreatePassengers();
            return railcarNumber;
        }

        private void ShowInfo()
        {
            if (_sentTrains.Count > 0)
            {
                for (int i = 0; i < _sentTrains.Count; i++)
                {
                    Console.Write($"{i + 1}.");
                    _sentTrains[i].GetInfo();
                }
            }
            else
            {
                Console.WriteLine("Пусто");
            }
        }

        private void Exit()
        {
            _isWorking = false;
        }
    }

    class Train
    {
        private int _passengerNumber;
        private int _railcarNumber;
        private string _placeOfDeparture;
        private string _destination;

        public Train(int passengerNumber, int railcarNumber, string placeOfDeparture, string destination)
        {
            _passengerNumber = passengerNumber;
            _railcarNumber = railcarNumber;
            _placeOfDeparture = placeOfDeparture;
            _destination = destination;
        }

        public void GetInfo()
        {
            Console.WriteLine($"На маршрут {_placeOfDeparture} - {_destination}, зарегистрированно {_passengerNumber} пассажиров, поезд состоит из {_railcarNumber} вагонов");
        }
    }

    class Passengers
    {
        private int _minPassengerNumber = 1;
        private int _maxPassengerNumber = 250;
        public int CreatePassengers()
        {
            Random random = new Random();
            int passengers = random.Next(_minPassengerNumber, _maxPassengerNumber);
            return passengers;
        }
    }
}