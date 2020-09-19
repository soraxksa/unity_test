using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    public GameObject coin;
    private int myTimer = 5;
    private int myUpTime = 4;
    int ggg = 0;
    void Start()
    {
        
    }

    void Update()
    {

        if (Time.time > myTimer)
        {
            myTimer += myUpTime;
            Vector3 rnd = new Vector3(Random.Range(-100f, 40), 0.5f, Random.Range(-125f, 10));
            Instantiate(coin, rnd, Quaternion.identity);
            ggg = ggg + 1;
            print(ggg);
        }

    }
}
