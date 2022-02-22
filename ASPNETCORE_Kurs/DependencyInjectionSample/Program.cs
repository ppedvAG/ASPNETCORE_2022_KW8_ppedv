// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

//ServiceCollection wird verwendet um den IOC - Container aufzubauen (Services, weitere Funktionalitäten werden freigeschaltet) 
IServiceCollection serviceCollection = new ServiceCollection();

//CarService in die ServiceCollection hinzugefügt
serviceCollection.AddSingleton<ICarService, CarService>();
//... weitere Services können wir hinzufügen

//Wenn wir fertig sind
IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(); //Ein IOC Container wird erstellt. 

//Wenn wir den IOC Container verwenden wollen
using (IServiceScope scope = serviceProvider.CreateScope())
{
    ICarService myCarService = scope.ServiceProvider.GetService<ICarService>(); //Wenn Eintrag nicht gefunden wird, dann wird NULL zurück gegeben

    ICarService myCarService2 = scope.ServiceProvider.GetRequiredService<ICarService>();//Wenn Eintrag nicht gefunden wird, -> wird eine Exception geworfen.
}




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