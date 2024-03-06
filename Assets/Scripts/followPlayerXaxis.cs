using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayerXaxis : MonoBehaviour
{
    Transform circle;

    void Start()
    {
        circle = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(circle.position.x, transform.position.y, transform.position.z);
    }
}