using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLauncher : MonoBehaviour
{

    public GameObject Projectile;

    public Transform spawnLocation;
    
    public Quaternion spawnRotation;

    public Detection detection;

    public float spawnTime = 1f;
    private float timeSinceSpawned = 0.5f;

    void Update()
    {

        if (detection.objectDetected)
        {
            timeSinceSpawned += Time.deltaTime;            

            if (timeSinceSpawned >= spawnTime)
            {
                Instantiate(Projectile, spawnLocation.position, spawnRotation);
                timeSinceSpawned = 0f;

            }

            //timeSinceSpawned = 0.5f;
        }        
    }
}
