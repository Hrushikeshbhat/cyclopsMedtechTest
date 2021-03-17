using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsGenerate : MonoBehaviour
{

    public GameObject[] cars;


    float count = 0;
    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if(count > 2)
        {
            generate(Random.Range(0, cars.Length));
            count = 0;
        }
    }

    void generate(int index)
    {
        Instantiate(cars[index], transform.position, Quaternion.Euler(0, -90, 0));
    }
}
