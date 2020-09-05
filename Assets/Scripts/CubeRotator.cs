﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{
  
    public float xAngle, yAngle, zAngle;

    void Start()
    {
        xAngle = 90f;
    }

    void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    }
}
