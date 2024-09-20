using System;
using System.Collections.Generic;

public class Vehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Vehicle(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
    }

    public virtual void StartEngine()
    {
        Console.WriteLine($"{Brand} {Model}: двигатель заведён.");
    }

    public virtual void StopEngine()
    {
        Console.WriteLine($"{Brand} {Model}: двигатель остановлен.");
    }

    public override string ToString()
    {
        return $"{Brand} {Model}, {Year} года";
    }
}

public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }
    public string TransmissionType { get; set; }

    public Car(string brand, string model, int year, int numberOfDoors, string transmissionType)
        : base(brand, model, year)
    {
        NumberOfDoors = numberOfDoors;
        TransmissionType = transmissionType;
    }

    public override void StartEngine()
    {
        Console.WriteLine($"{Brand} {Model} (Автомобиль): двигатель заведён.");
    }

    public override void StopEngine()
    {
        Console.WriteLine($"{Brand} {Model} (Автомобиль): двигатель остановлен.");
    }

    public override string ToString()
    {
        return base.ToString() + $", {NumberOfDoors} дверей, трансмиссия {TransmissionType}";
    }
}

public class Motorcycle : Vehicle
{
    public string BodyType { get; set; }
    public bool HasStorageBox { get; set; }

    public Motorcycle(string brand, string model, int year, string bodyType, bool hasStorageBox)
        : base(brand, model, year)
    {
        BodyType = bodyType;
        HasStorageBox = hasStorageBox;
    }

    public override void StartEngine()
    {
        Console.WriteLine($"{Brand} {Model} (Мотоцикл): двигатель заведён.");
    }

    public override void StopEngine()
    {
        Console.WriteLine($"{Brand} {Model} (Мотоцикл): двигатель остановлен.");
    }

    public override string ToString()
    {
        return base.ToString() + $", тип кузова: {BodyType}, бокс: {(HasStorageBox ? "есть" : "нет")}";
    }
}

public class Garage
{
    private List<Vehicle> vehicles = new List<Vehicle>();
    
    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
        Console.WriteLine($"{vehicle} добавлен в гараж.");
    }
    
    public void RemoveVehicle(Vehicle vehicle)
    {
        vehicles.Remove(vehicle);
        Console.WriteLine($"{vehicle} удален из гаража.");
    }
    
    public void DisplayVehicles()
    {
        Console.WriteLine("Транспортные средства в гараже:");
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle);
        }
    }
}

public class Fleet
{
    private List<Garage> garages = new List<Garage>();
    
    public void AddGarage(Garage garage)
    {
        garages.Add(garage);
        Console.WriteLine("Гараж добавлен в автопарк.");
    }
    
    public void RemoveGarage(Garage garage)
    {
        garages.Remove(garage);
        Console.WriteLine("Гараж удален из автопарка.");
    }
    
    public void DisplayFleet()
    {
        Console.WriteLine("Содержимое автопарка:");
        foreach (var garage in garages)
        {
            garage.DisplayVehicles();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car("Toyota", "Supra", 2002, 4, "Автомат");
        Car car2 = new Car("Honda", "Accord", 2019, 4, "Механика");
        Motorcycle motorcycle1 = new Motorcycle("Harley-Sasi", "Sportster", 2018, "Щоппер", true);
        
        Garage garage1 = new Garage();
        Garage garage2 = new Garage();
        
        garage1.AddVehicle(car1);
        garage1.AddVehicle(motorcycle1);
        garage2.AddVehicle(car2);
        
        Fleet fleet = new Fleet();
        fleet.AddGarage(garage1);
        fleet.AddGarage(garage2);
        
        fleet.DisplayFleet();
        
        garage1.RemoveVehicle(car1);
        
        fleet.DisplayFleet();
    }
}