﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }
    private void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Enemy", transform.position, Quaternion.identity);
    }
}
