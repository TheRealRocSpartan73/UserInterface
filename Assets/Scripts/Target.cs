using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    private float zSpawnPos = 0;
    private GameManager gameManager;  //Ref to Game Manager


    public int pointValue; //Unique score value for each object
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb= GetComponent<Rigidbody>();  //grab this objects RigidBody component.
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); //Grab a Reference to the GameManager Object, then grab the script component.
        
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

    //If object hits sensor then get rid of it -- no longer required
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.Gameover();
        }

    }

    //If Object gets clicked on then remove it
    private void OnMouseDown()
    {
        Destroy(this.gameObject); //Wipe it out if clicked on
        gameManager.UpdateScore(pointValue); //Update the Score when object clicked on and destroyed
        Instantiate(explosionParticle, this.transform.position, this.transform.rotation);
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
