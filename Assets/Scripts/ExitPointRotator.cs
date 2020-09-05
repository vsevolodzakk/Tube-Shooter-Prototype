using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPointRotator : MonoBehaviour
{
    public GameObject center;
    public float direction;
    private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center.transform.position, Vector3.forward, direction * speed * Time.fixedDeltaTime);
    }
}
