using System;

public class Bird : Animal, IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Flapping wings");
    }
}

public class Airplane : Vehicle, IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Jet engines");
    }
}

public class Superman : SuperHero, IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Up, up and away");
    }
}

public class ElectricCar : Vehicle, IChargeable
{
    private int battery;
    public ElectricCar()
    {
        battery = 0;
    }
    public int Battery
    {
        get { return battery; }
        set { battery = value; }
    }
    public void Charge()
    {
        Console.WriteLine("Charging electric car");
    }
    public string ChargingStatus()
    {
        if (battery < 20) return "Empty";
        if (battery < 50) return "Low";
        return "Ready";
    }
}

public class Phone : Device, IChargeable
{
    private int battery;
    public Phone()
    {
        battery = 0;
    }
    public int Battery
    {
        get { return battery; }
        set { battery = value; }
    }
    public void Charge()
    {
        battery = 100;
        Console.WriteLine("Charging phone");
    }
    public string ChargingStatus()
    {
        if (battery < 15) return "Empty";
        if (battery < 40) return "Low";
        return "Ready";
    }
}

public class RobotVacuum : Appliance, IChargeable
{
    private int battery;
    public RobotVacuum()
    {
        battery = 0;
    }
    public int Battery
    {
        get { return battery; }
        set { battery = value; }
    }
    public void Charge()
    {
        battery = 100;
        Console.WriteLine("Charging robot vacuum");
    }
    public string ChargingStatus()
    {
        if (battery < 5) return "Empty";
        if (battery < 20) return "Low";
        return "Ready";
    }
}
