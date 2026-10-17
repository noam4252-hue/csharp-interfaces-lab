using System;

public class Program
{
    public static void Main()
    {
        // משימה 2: צרו כאן את אובייקט ה-Drone לאחר מימוש המחלקה.
        Drone drone = new Drone("noam", 0);

        IFlyable[] flyers =
        {
            new Bird(),
            new Airplane(),
            new Superman(),
            // משימה 2: הוסיפו גם את ההפניה לרחפן שיצרתם.
            drone
        };

        IChargeable[] devices =
        {
            new ElectricCar(),
            new Phone(),
            new RobotVacuum(),
            // משימה 2: הוסיפו את ההפניה לאותו רחפן.
            drone
        };

        // טוענים תחילה, כדי שכלי שדורש טעינה יוכל לעוף בהמשך.
        // משימה 3: הדפיסו כאן מצבי סוללה דרך devices לפני הטעינה.
        foreach (IChargeable d in devices)
        {
            Console.WriteLine(d.ChargingStatus());
        }
        Console.WriteLine("--- Charge through IChargeable[] ---");
        ChargeAll(devices);
        // משימה 3: הדפיסו שוב מצבי סוללה דרך devices לאחר הטעינה.
        foreach (IChargeable d in devices)
        {
            Console.WriteLine(d.ChargingStatus());
        }
        Console.WriteLine("--- Fly through IFlyable[] ---");
        FlyAll(flyers);
        // משימה 2: הדפיסו כאן את אחוז הסוללה של הרחפן לאחר הטיסה.
        Console.WriteLine("Drone battery after flight:" + drone.Battery + "%");
        object[] items =
        {
            new Phone(),
            new GasolineCar(),
            new RobotVacuum()
        };

        Console.WriteLine("--- is: type check ---");
        object item = new GasolineCar();
        bool canCharge = item is IChargeable;
        Console.WriteLine(canCharge);

        Console.WriteLine("--- is: check and interface reference ---");
        foreach (object current in items)
        {
            if (current is IChargeable chargeable)
            {
                chargeable.Charge();
            }
        }

        Console.WriteLine("--- as: interface reference or null ---");
        object phone = new Phone();
        IChargeable? phoneChargeable = phone as IChargeable;
        if (phoneChargeable != null)
        {
            phoneChargeable.Charge();
        }

        // אותו דפוס על המערך המעורב: מכונית הבנזין אינה נטענת.
        foreach (object current in items)
        {
            IChargeable? chargeable = current as IChargeable;
            if (chargeable != null)
            {
                chargeable.Charge();
            }
        }
        Console.WriteLine("--- Boundary tests ---");
        Drone t1 = new Drone("Test", 0);
        int[] v1 = { 0, 9, 10, 29, 30, 100 };
        foreach (int v in v1) { t1.Battery = v; Console.WriteLine("Drone " + v + ": " + t1.ChargingStatus()); }
        RobotVacuum t2 = new RobotVacuum();
        int[] v2 = { 0, 4, 5, 19, 20, 100 };
        foreach (int v in v2) { t2.Battery = v; Console.WriteLine("Vacuum " + v + ": " + t2.ChargingStatus()); }
        Phone t3 = new Phone();
        int[] v3 = { 0, 14, 15, 39, 40, 100 };
        foreach (int v in v3) { t3.Battery = v; Console.WriteLine("Phone " + v + ": " + t3.ChargingStatus()); }
        ElectricCar t4 = new ElectricCar();
        int[] v4 = { 0, 19, 20, 49, 50, 100 };
        foreach (int v in v4) { t4.Battery = v; Console.WriteLine("Car " + v + ": " + t4.ChargingStatus()); }
        t1.Battery = 5;
        t1.Charge();
        Console.WriteLine(t1.Battery + " " + t1.ChargingStatus());
    }

    // לולאת התעופה מהסרטון נארזה בפעולה לקבלת מערך כפרמטר.
    public static void FlyAll(IFlyable[] flyers)
    {
        foreach (IFlyable flyer in flyers)
        {
            flyer.Fly();
        }
    }

    // לולאת הטעינה מהסרטון נארזה בפעולה לקבלת מערך כפרמטר.
    public static void ChargeAll(IChargeable[] devices)
    {
        foreach (IChargeable device in devices)
        {
            device.Charge();
        }
    }
}
