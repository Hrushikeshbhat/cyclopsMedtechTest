using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 0.08f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "kill")
        {
            Destroy(this.gameObject);
        }
    }
}
