#region Main 
// See https://aka.ms/new-console-template for more information
ICarService carService = new CarService();


ICar car = new Car() { Brand = "Mercedes", Model = "Silberpfeil", ConstructionYear = 1928 };

Car car2 = new Car() { Brand = "Mercedes", Model = "Silberpfeil 2", ConstructionYear = 1929 };
car2.Tanken();


carService.Repair(new MockCar()); //Testen Tag 4 und 5
carService.Repair(car);
carService.Repair(car2);

#endregion


#region Schlechte Variante


//Programmierer A: 5 Tage -> (von Tag 1 bis Tag5) 
public class BadCar //Entities.dll
{
    public string Brand { get; set; }   
    public string Model { get; set; }   
    public int ConstrutionYear { get; set; }
}


//Programmierer B: 3 Tage -> Von Tag 5/6 bis 8/9
public class BadCarService //Service.dll
{
    //Feste Kopplung (die eine Klasse kennt die andere Klasse)
    public void Repair (BadCar car)
    { 
        //ein Auto wird repariert 
    }
}
#endregion

#region DependecyInversion
//Contract First -> Definitionen von Schnittstellen 

public interface ICar
{
    string Brand { get; set; }  
    string Model { get; set; }
    int ConstructionYear { get; set; }
}

public interface ICarService
{
    void Repair(ICar car); //Lose Kopplung 
}

//Programmierer A: 5 Tage -> (von Tag 1 bis Tag5) 
public class Car : ICar
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int ConstructionYear { get; set; }

    public void Tanken()
    {
       //Auto tank
    }
}

//Programmierer B: 3 Tage -> (Von Tag 1 bis Tag3) 

public class CarService : ICarService
{
    public void Repair(ICar car)
    {
        //Repariere Auto
    }
}


// Testobjekt
public class MockCar : ICar
{
    public string Brand { get; set; } = "VW";
    public string Model { get; set; } = "POLO";
    public int ConstructionYear { get; set; } = 1999;
}
#endregion