using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float lifetime;

    void FixedUpdate()
    {
        if (lifetime <= 0)
        {
            //gameObject.SetActive(false);

            Destroy(gameObject);
        } else
        {
            lifetime--;
        }

    }
}
