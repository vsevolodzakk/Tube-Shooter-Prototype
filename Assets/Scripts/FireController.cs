using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject parentBullet;
    public GameObject bullet;
    public Transform target;
    public Transform spawnLocation;
    public Rigidbody rb_bullet;
    public float bulletSpeed;
    private float bulletCount;
    public float maxBullet;

    private float searchCountdown = 1f;
    private Quaternion shootDirection;

    void Start()
    {
        shootDirection = target.localRotation;
        bulletCount = maxBullet;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))// && bulletCount > 0)
        {
            Fire();
            bulletCount--;
        }
        if (bulletCount < maxBullet)
            BulletCheck();
    }
    private void Fire()
    {
        // bullet Pool way
        //bullet = ObjectPooler.Instance.SpawnFromPool("Bullet", spawnLocation.position, shootDirection);


        // Spawn Destroy way
        bullet = Instantiate(parentBullet, spawnLocation.position, shootDirection);
        bullet.tag = "Bullet";
        rb_bullet = bullet.GetComponent<Rigidbody>();
        rb_bullet.AddForce(spawnLocation.transform.up * bulletSpeed);
    }
    void BulletCheck()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0)
        {
            searchCountdown = .5f;
            if (GameObject.FindGameObjectWithTag("Bullet") == null)
            {
                bulletCount = maxBullet;
            }
        }
    }
    
}
