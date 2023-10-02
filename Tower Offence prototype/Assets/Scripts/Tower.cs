using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int HP = 3;
    public GameObject Shooter;
    Shoot shoot;
    int i = 1;
    public Goblin[] goblin = new Goblin[27];
    [SerializeField] private PlacementSystem Income; // Line added by Rhys
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            
            /*for(int j = 0; j < goblin.Length; j++)
            {
                if (goblin[j] == null)
                {
                    if (goblin[j + 2] == null) 
                    {
                        break;
                    } 
                }
                else
                {
                    goblin[j].ChangeWaypoint();
                }
                
            }*/
            GameObject.Destroy(gameObject);
            Income.Gold+=150; // Line added by Rhys
        }
    }

    public void Hit()
    {
        HP = HP - 2;
    }

    public void Hit2()
    {
        HP--;
    }
}
