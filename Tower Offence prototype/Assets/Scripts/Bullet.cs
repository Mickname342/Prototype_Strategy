using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Goblin goblin;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            goblin = other.GetComponent<Goblin>();
            goblin.HPDown();
            Destroy(gameObject);
        }
    }
}
