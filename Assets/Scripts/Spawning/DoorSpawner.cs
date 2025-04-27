using System.Collections.Generic;
using UnityEngine;

public class DoorSpawner : Spawner
{
    protected override void Start()
    {
        NumberOfSlots = Random.Range(1, spawners.Count);
        base.Start();
    }
}
