using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 7), transform.position.z);
    }
}
