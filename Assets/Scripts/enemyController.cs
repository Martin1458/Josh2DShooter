using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    void Start()
    {
        transform.Translate(UnityEngine.Random.Range(-10.5f, 10.5f), 6, 0);

    }

    void FixedUpdate()
    {
        transform.Translate(0,-0.1f,0);
    }

}
