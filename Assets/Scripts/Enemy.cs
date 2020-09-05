using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int sideSpeed;

    public GameObject[] targets;

    public GameObject center;
    //public GameObject target;


    private Vector3 heading;
    private Vector3 initial;

    private ParticleSystem ps;

    private int rand;
    private int modifier;

    public void Start()
    {
        //target = GameObject.Find("ExitPointA");
        targets = GameObject.FindGameObjectsWithTag("Exit");
        center = GameObject.Find("Center");
        ps = GetComponentInChildren<ParticleSystem>();
        rand = Random.Range(0, 2);
        heading = (targets[rand].transform.position - transform.position);
        initial = transform.position;

    }

    void Update()
    {
        modifier = Random.Range(-1, 2);
        transform.position += heading * speed * Time.deltaTime;
        transform.RotateAround(center.transform.position, Vector3.forward, sideSpeed * modifier * Time.fixedDeltaTime);
        if(transform.position.z < 0)
        {
            transform.position = initial;
            heading = (targets[rand].transform.position - transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            ps.Play();
            Destroy(gameObject, .3f);
        }
    }
}
