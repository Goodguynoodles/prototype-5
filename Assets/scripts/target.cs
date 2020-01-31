using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class target : MonoBehaviour
{

    private Rigidbody targetRB;
    private Gamemanager gamemanager;
    private float minSpeed = 12; 
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnpos = -6;
    public int pointValue;
    public ParticleSystem explosionParticle;
    
    
    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(),RandomTorque() , Random.Range(-maxTorque,maxTorque), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gamemanager = GameObject.Find("Gamemanager").GetComponent<Gamemanager>();

    }

    private void OnMouseDown()
    {
        if (gamemanager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gamemanager.Updatescore(pointValue);
        }
      
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        
        if (!gameObject.CompareTag("bad"))
        {
            gamemanager.gameover();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
       return new Vector3(Random.Range(-xRange, xRange), ySpawnpos);
    }

    
    
}
