using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private const float minForce = 5;
    private const float maxForce = 15;
    private const float minTorque = -10;
    private const float maxTorque = 10;
    private const float minXPos = -3;
    private const float maxXPos = 3;
    private const float ySpawnPos = 0;

    private Rigidbody targetRb;
    private GameManager gameManager;

    public int pointValue;
    public ParticleSystem hitConfirm;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

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
        if (gameManager.gameActive)
        {
            gameManager.UpdateScore(pointValue);
            Instantiate(hitConfirm, transform.position, hitConfirm.transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bomb"))
        {
            gameManager.GameOver();
        }

    }
}
