using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    private float fireRate = .5f;
    private float fireTimer = 0;

    [SerializeField]
    GameObjectPool gameObjectPool;

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            if (fireTimer >= fireRate)
            {
                fireTimer = 0;
                Fire();
            }
        }

    }
    private void Fire()
    {
        var shot = gameObjectPool.Get();
        shot.transform.rotation = transform.rotation;
        shot.transform.position = transform.position;
        shot.gameObject.SetActive(true);
    }
}
