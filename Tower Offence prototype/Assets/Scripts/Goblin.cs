using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goblin : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public Transform waypoint;
    public Transform visuals;
    public GameObject collector;
    Waypoints waypoints;
    public Transform[] ends = new Transform[4];
    int speed = 20;
    bool stop = false;
    public Rigidbody rb;
    public Transform father;
    Animator animator;
    public Shoot shoot_script;
    int i = 0;

    public int hp = 5;
    // Start is called before the first frame update
    void Start()
    {
        collector = GameObject.Find("WaypontCollector");
        waypoints = collector.GetComponent<Waypoints>();
        for(int i = 0; i < 4; i++)
        {
            ends[i] = waypoints.waypoint[i];
        }
        //waypoint = ends[0];
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ends[i] == null)
        {
            i++;
            print("I'm going to waypoint " + i);
        }
        navAgent.SetDestination(ends[i].position);
        //navAgent.speed = speed;
        /*float angle = Mathf.Atan2(waypoint.position.x - father.position.x, waypoint.position.z - father.position.z) * Mathf.Rad2Deg;
        father.rotation = Quaternion.Euler(0, angle, 0);
        print(angle);*/
        if (!stop)
        {
            //animator.SetBool("attack", false);

        }
        else
        {
            //animator.SetBool("attack", true);
        }

        if (hp <= 0)
        {
            shoot_script.j++;
            Destroy(gameObject);
        }
    }

    public void Stop()
    {
        stop = true;        
    }

    public void HPDown()
    {
        hp--;
    }

    public void ChangeWaypoint()
    {
        i++;
    }
}
