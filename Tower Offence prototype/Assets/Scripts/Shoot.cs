using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    Transform goblin;
    public GameObject bullet;
    bool shooting = false;
    float delayBetweenShots = 0;
    float timeLastShot;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shooting && Time.time > delayBetweenShots + timeLastShot)
        {
            timeLastShot = Time.time;
            delayBetweenShots = 3;
            float angle1 = Mathf.Atan2(goblin.position.x - transform.position.x, goblin.position.z - transform.position.z) * Mathf.Rad2Deg;
            //float angle2 = Mathf.Atan2(goblin.position.x - transform.position.x, goblin.position.y - transform.position.y) * Mathf.Rad2Deg;
            GameObject bulletShot = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0));
            Rigidbody rb = bulletShot.GetComponent<Rigidbody>();
            float zcomponent = Mathf.Cos(angle1 * Mathf.PI / 180) * 10;
            float xcomponent = Mathf.Sin(angle1 * Mathf.PI / 180) * 10;
            //float ycomponent = Mathf.Cos(angle2 * Mathf.PI / 180) * 10;
            Vector3 forceapplied = new Vector3(xcomponent, 0, zcomponent);
            rb.AddForce(forceapplied * 4, ForceMode.Impulse);
        }
        

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            goblin = collision.gameObject.GetComponent<Transform>();
            shooting = true;
        }
    }
}
