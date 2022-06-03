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
        private Passenger passenger = new Passenger();
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
            int passengers = passenger.CreatePassengers();

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
            int PassengerPlace = 54;
            int railcarNumber = PassengerPlace / passenger.CreatePassengers();
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
        Passenger passenger = new Passenger();
        private int _passengerNumber;
        private int _railcarNumber;
        private string _placeOfDeparture;
        private string _destination;

        public Train(int PassengerNumber, int RailcarNumber, string PlaceOfDeparture, string Destination)
        {
            _passengerNumber = PassengerNumber;
            _railcarNumber = RailcarNumber;
            _placeOfDeparture = PlaceOfDeparture;
            _destination = Destination;
        }

        public void GetInfo()
        {
            Console.WriteLine($"На маршрут {_placeOfDeparture} - {_destination}, зарегистрированно {_passengerNumber} пассажиров, поезд состоит из {_railcarNumber} вагонов");
        }
    }

    class Passenger
    {
        public int CreatePassengers()
        {
            Random random = new Random();
            int passengers = random.Next(1, 250);
            return passengers;
        }
    }
}