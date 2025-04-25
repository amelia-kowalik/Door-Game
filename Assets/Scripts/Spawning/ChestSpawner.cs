using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : Spawner
{
    protected override void Start()
    {
        numberOfSlots = 1;
        base.Start();
    }
    
}
