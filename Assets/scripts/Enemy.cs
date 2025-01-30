using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform player;
    private Vector3 direction;
    private float speed = 2f;
    private float atakarench = 6f;
    private float distanttoplayer; 




    



    private void Start()
    {
        player = GameObject.Find("Player").transform;

    }



    void Update()
    {
        distanttoplayer = Vector3.Distance(transform.position, player.position);
        if (distanttoplayer < atakarench)
        {
            direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
