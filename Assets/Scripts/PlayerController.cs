using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject target;
    private float direction;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = Input.GetAxisRaw("Horizontal");
        transform.RotateAround(target.transform.position, Vector3.forward, direction * speed * Time.fixedDeltaTime);

    }
}
