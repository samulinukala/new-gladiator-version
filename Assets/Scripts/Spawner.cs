using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float enemyToSpawn;
    public GameObject enemy0;
    public GameObject enemy1;
    public GameObject enemy2;
    public float spawnTimer=10;
    private float timer; 
    private int randomizedSpawn;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        enemyToSpawn = Random.Range(0F, 2F);
        randomizedSpawn = (int) enemyToSpawn;
        if (timer < spawnTimer)
        {
            timer=timer + 1 * Time.deltaTime;
        }
        
        if (timer > spawnTimer)
        {
            
            timer = 0;
            switch (randomizedSpawn)
            {
                case 2:
                    Instantiate(enemy0 ,this.gameObject.transform);
                    break;
                case 1:
                    Instantiate(enemy1, this.gameObject.transform);
                    break;
                case 0:
                    Instantiate(enemy2, this.gameObject.transform);
                    break;
            }
            
            
        }
        
    }
}
