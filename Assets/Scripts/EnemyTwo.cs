using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    private Transform player;
    private Ray ray;
    public float countdown = 5f;
    public float bulletSpeed = 30f;

    public GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        
        ray = new Ray(transform.position, player.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        countdown -= Time.deltaTime;

        if(countdown <= 0)
        {
            GameObject clone_bullet = Instantiate(bullet, transform.position, Quaternion.LookRotation(ray.direction));
            Rigidbody rb_bullet = clone_bullet.GetComponent<Rigidbody>();
            rb_bullet.AddForce(clone_bullet.transform.forward * bulletSpeed);
            countdown = 5f;
            Debug.Log("ENEMY FIRE!");
        }
    }
}
