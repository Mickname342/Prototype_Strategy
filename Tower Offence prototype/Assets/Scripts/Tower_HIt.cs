using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_HIt : MonoBehaviour
{
    Tower tower_script;
    Goblin goblin;
    public GameObject tower;

    private void Start()
    {
        tower_script = tower.GetComponent<Tower>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tower_script.Hit();
            print(other);
            goblin = other.GetComponentInChildren<Goblin>();
            goblin.Stop();
        }
        
    }

}
