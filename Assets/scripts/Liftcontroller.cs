using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liftcontroller : MonoBehaviour
{
    public Transform lift;
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public bool movingUp = true;
    private Vector3 targetposition;





    void Update()
    {
        if (movingUp)
        {
            targetposition = pointB.position;

        }
        else
        {
            targetposition = pointA.position;
        }
        lift.position = Vector3.MoveTowards(lift.position, targetposition, speed * Time.deltaTime);
        if (Vector3.Distance(targetposition, lift.position) < 0.01f)
        {
            movingUp = !movingUp; // true меняется на fallse 
        }
    }
}