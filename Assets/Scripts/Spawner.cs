using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour
{
    private float enemyToSpawn;
    public GameObject enemy0;
    public GameObject enemy1;
    public GameObject enemy2;
    public float spawnTimer=10;
    private float timer=0; 
    private int randomizedSpawn;
    private float timerQuickeningTimer=0;
    public float timerQuickeningTarget=12.5f;
    public float chanceForEnemy;
    public List<GameObject> eliteEnemies;
    public List<GameObject> enemies;
    public int enemyLimit;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       foreach(GameObject e in GameObject.FindGameObjectsWithTag("enemy"))
        {
            if (enemies.Contains(e) == false)
            {
                enemies.Add(e);
            }
        }
       foreach(GameObject e in enemies)
        {
            if (e == null)
            {
                enemies.Remove(e);
            }
        }

        eliteEnemies.Clear();
        eliteEnemies.AddRange( GameObject.FindGameObjectsWithTag("elite"));
        for(int i = 0; i < eliteEnemies.Count - 1; i++)
        {
            if (eliteEnemies[i] == null)
            {
                eliteEnemies.RemoveAt(i);
            }
        }
        enemyToSpawn = 0;
        
        if (eliteEnemies.Count<2&(int)Random.Range(0, chanceForEnemy + 1) == chanceForEnemy) { enemyToSpawn = 1; Debug.Log("enemy 2"); }
        randomizedSpawn = (int) enemyToSpawn;
        if (timer < spawnTimer)
        {
            timer=timer + 1 * Time.deltaTime;
        }
        if (timerQuickeningTarget > timerQuickeningTimer)
        {
            timerQuickeningTimer = timerQuickeningTimer + 1 * Time.deltaTime;
        }
        else if(timerQuickeningTarget<timerQuickeningTimer)
        {
            timerQuickeningTimer = 0;
            if (spawnTimer > 0.7f)
            {
                spawnTimer = spawnTimer / 2;
            }
        }
        
        if (timer > spawnTimer&enemies.Count<enemyLimit+1)
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
