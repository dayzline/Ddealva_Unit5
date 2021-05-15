using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private const float minForce =5;
    private const float maxForce = 17;
    private const float minTorque = -10;
    private const float maxTorque = 10;
    private const float minXPos = -3;
    private const float maxXPos = 3;
    private const float ySpawnPos = -2;

    private Rigidbody targetRb;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        RandomForce();
        RandomTorque();
        RandomSpawnPos();
    }

    void RandomForce()
    {
        targetRb.AddForce(Vector3.up * Random.Range(minForce, maxForce), ForceMode.Impulse);
    }  
    
    void RandomTorque()
    {
        targetRb.AddTorque(Random.Range(-10, 10), Random.Range(minTorque, maxTorque),  
            Random.Range(minTorque, maxTorque), ForceMode.Impulse);
    }

    void RandomSpawnPos()
    {
        transform.position = new Vector3(Random.Range(minXPos, maxXPos), ySpawnPos);
    }
    // Update is called once per frame

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
