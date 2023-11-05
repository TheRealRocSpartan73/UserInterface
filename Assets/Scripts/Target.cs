using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    private float zSpawnPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        targetRb= GetComponent<Rigidbody>();  //grab this objects RigidBody component.
        
        //Move object up based on random range. Use Impulse for instant Force Power
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        //Rotate and Move based on random ranges on X, Y & Z axis. Use Impulse for instant Force Power
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        //RandomSpawn Point
        this.transform.position = RandomSpawnPos();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    Vector3 RandomSpawnPos()
    {
      return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, zSpawnPos);
    }


    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }


}
