using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected List<GameObject> spawners;
    protected int numberOfSlots;
    
    protected virtual void Start()
    {
        Spawn();
    }
    
    void Spawn()
    {
        List<GameObject> availableSpawn = new List<GameObject>(spawners);

        for (int i = 0; i < numberOfSlots && availableSpawn.Count > 0; i++)
        {
            int index = Random.Range(0, availableSpawn.Count);
            GameObject spawner = availableSpawn[index];
            
            Instantiate(prefab, spawner.transform.position, spawner.transform.rotation);
            availableSpawn.Remove(spawner);
        }
    }
}
