using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{


    public GameObject[] enemyprifabs;
    private GameObject[] islands;

    
    void Start()
    {
        islands = GameObject.FindGameObjectsWithTag("Ground");
        for (int i = 0; i < islands.Length; i++)
        {
          //  Debug.Log(i); 
            int rnd = Random.Range(1, 5);
            Debug.Log(rnd);
            if (rnd == 1)
            {
                Vector3 offset = new Vector3(Random.Range(-5, 5), Random.Range(2, 5), Random.Range(-5, 5));
                Vector3 position = islands[i].transform.position + offset;
                int indeks = Random.Range(0, 1);

                Instantiate(enemyprifabs[indeks], position, Quaternion.identity);
                Debug.Log("враг заспавнился");
                
            }
           if (rnd == 2)
            {
                Vector3 offset = new Vector3(Random.Range(-2, 3), Random.Range(1, 3), Random.Range(-2, 3));
                Vector3 position = islands[i].transform.position + offset;
                int indeks = Random.Range(2, enemyprifabs.Length);

                Instantiate(enemyprifabs[indeks], position, Quaternion.identity);
                Debug.Log("враг заспавнился");
            }
        }
    }

    
}
