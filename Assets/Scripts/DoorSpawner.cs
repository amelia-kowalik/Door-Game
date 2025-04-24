using System.Collections.Generic;
using UnityEngine;

public class DoorSpawner : Spawner
{
    protected override void Start()
    {
        numberOfSlots = Random.Range(1, spawners.Count);
        base.Start();
    }
}
