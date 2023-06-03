using System;
using System.Collections.Generic;

public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public bool IsAvailable { get; set; }
}

public class CarRentalService
{
    private List<Car> cars;

    public CarRentalService()
    {
        cars = new List<Car>();
    }

    public void AddCar(string brand, string model, int year)
    {
        Car car = new Car
        {
            Brand = brand,
            Model = model,
            Year = year,
            IsAvailable = true
        };

        cars.Add(car);
    }

    public void ShowAvailableCars()
    {
        Console.WriteLine("Available Cars:");
        for (int i = 0; i < cars.Count; i++)
        {
            Car car = cars[i];
            Console.WriteLine($"{i + 1}. {car.Brand} {car.Model} ({car.Year})");
        }
    }

    public void RentCar(int carIndex, int duration)
    {
        if (carIndex >= 0 && carIndex < cars.Count)
        {
            Car car = cars[carIndex];

            if (car.IsAvailable)
            {
                decimal rentalCost = CalculateRentalCost(duration);

                Console.WriteLine($"Rental cost: {rentalCost:C}");

                Console.WriteLine("Do you want to proceed? (yes/no)");
                string proceed = Console.ReadLine();

                if (proceed.ToLower() == "yes")
                {
                    Console.WriteLine("Enter your name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter the start date (dd/MM/yyyy):");
                    string startDateStr = Console.ReadLine();
                    DateTime startDate = DateTime.ParseExact(startDateStr, "dd/MM/yyyy", null);

                    Console.WriteLine("Enter the end date (dd/MM/yyyy):");
                    string endDateStr = Console.ReadLine();
                    DateTime endDate = DateTime.ParseExact(endDateStr, "dd/MM/yyyy", null);

                    Console.WriteLine("Enter your address:");
                    string address = Console.ReadLine();

                    Console.WriteLine("Enter your contact details:");
                    string contactDetails = Console.ReadLine();

                    car.IsAvailable = false;

                    Console.WriteLine("Reservation Details:");
                    Console.WriteLine($"Car: {car.Brand} {car.Model} ({car.Year})");
                    Console.WriteLine($"Duration: {duration} days");
                    Console.WriteLine($"Rental Cost: {rentalCost:C}");
                    Console.WriteLine($"Name: {name}");
                    Console.WriteLine($"Start Date: {startDate.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"End Date: {endDate.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"Contact Details: {contactDetails}");
                    Console.WriteLine("You reserved the car successfully.");
                }
                else
                {
                    Console.WriteLine("Reservation canceled.");
                }
            }
            else
            {
                Console.WriteLine("Selected car is not available for rental.");
            }
        }
        else
        {
            Console.WriteLine("Invalid car selection.");
        }
    }

    private decimal CalculateRentalCost(int duration)
    {
        decimal dailyRate = 100;
        decimal rentalCost = dailyRate * duration;
        return rentalCost;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CarRentalService carRentalService = new CarRentalService();

        carRentalService.AddCar("Toyota", "Corolla", 2020);
        carRentalService.AddCar("Honda", "Civic", 2019);
        carRentalService.AddCar("Ford", "Mustang", 2021);

        carRentalService.ShowAvailableCars();

        Console.WriteLine("Enter the number of the car you want to rent:");
        int carIndex = Convert.ToInt32(Console.ReadLine()) - 1;

        Console.WriteLine("Enter the duration of the rental (in days):");
        int duration = Convert.ToInt32(Console.ReadLine());

        carRentalService.RentCar(carIndex, duration);

        Console.ReadLine();
    }
}
