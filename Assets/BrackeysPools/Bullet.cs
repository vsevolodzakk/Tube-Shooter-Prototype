using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    //private float bulletSpeed = 500f;
    //private Rigidbody rb_bullet;
    //private Transform spawnLocation;

    public void OnObjectSpawn()
    {
        //rb_bullet = GetComponent<Rigidbody>();
        //spawnLocation = GameObject.Find("Shooter").transform;
        
        //rb_bullet.AddForce(spawnLocation.forward * bulletSpeed);
    }
}
