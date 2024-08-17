using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    public List<BGSpawner> spawnPoints;

    float cometCooldown = 1f;
    float cometTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cometTimer > 0f) {
            cometTimer -= Time.deltaTime;
        }

        if (cometTimer <= 0f) {
            BGSpawner spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            spawnPoint.Spawn();
            cometTimer = cometCooldown;
        }
    }  
}
