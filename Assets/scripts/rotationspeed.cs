using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationspeed : MonoBehaviour
{
    private float rspeed = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rspeed * Time.deltaTime);
    }
}
