﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRotate : MonoBehaviour
{

    public float y_speed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, y_speed * Time.deltaTime,0);
    }
}
