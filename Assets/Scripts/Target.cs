using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    // Start is called before the first frame update
    void Start()
    {
        targetRb= GetComponent<Rigidbody>();  //grab this objects RigidBody component.
        
        //Move object up based on random range. Use Impulse for instant Force Power
        targetRb.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);

        //Rotate and Move based on random ranges on X, Y & Z axis.
        targetRb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);

        //RandomSpawn Point
        this.transform.position = new Vector3(Random.Range(-4, 4), -6, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
