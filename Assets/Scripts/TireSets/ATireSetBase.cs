using System.Collections.Generic;
using UnityEngine;

/// Base class for tire sets
public abstract class ATireSetBase : MonoBehaviour
{
    // Tires that accelerate the car
    public readonly List<Tire> acceleraterTires = new();
    
    // Tires that routes the car
    public readonly List<Tire> steererWheels = new();

    // Tires that accelerate the car
    public readonly List<Tire> brakerTires = new();

    public readonly HashSet<Tire> tires = new();

    public void ConfigureTire(Tire tire)
    {
        if(tire.IsBraker)
            brakerTires.Add(tire);
        if(tire.IsAccelerater)
            acceleraterTires.Add(tire);
        if(tire.IsSteerer)
            steererWheels.Add(tire);
        
        tires.Add(tire);
    }
}
