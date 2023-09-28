using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject goblin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        GameObject goblinSpawned = Instantiate(goblin, transform.position, Quaternion.Euler(0, 0, 0));
        transform.position = transform.position + new Vector3(3,0,0);
    }
}
