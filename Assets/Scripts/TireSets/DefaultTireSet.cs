using System.Collections.Generic;
using UnityEngine;

// Standart 4 wheel car
public class DefaultTireSet : ATireSetBase
{
    public Tire BackLeftTire;
    public Tire BackRightTire;
    public Tire FrontLeftTire;
    public Tire FrontRightTire;

    private void Awake()
    {
        ConfigureTire(BackLeftTire);
        ConfigureTire(BackRightTire);
        ConfigureTire(FrontLeftTire);
        ConfigureTire(FrontRightTire);
    }
}
