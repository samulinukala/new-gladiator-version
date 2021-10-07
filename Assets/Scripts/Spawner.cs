using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

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
    public float eliteCooldown = 90;
    public float coolDownTimer = 0;
    public bool limitSpawning = false;
    public float BreakTime = 60;
    public float BreakTimer = 0;
    public bool BreakIsOn=false;
    public float playerPreviousKillCount=0;
    public float playerKillCount=0;
    public float BreakInterval=200;
    public Text text;
    
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (BreakIsOn == true)
        {
            foreach(GameObject e in enemies)
            {
                DestroyImmediate(e);
            }
            foreach(GameObject e in eliteEnemies)
            {
                DestroyImmediate(e);
            }
            text.text = "BREAK " + (((int)(BreakTime - BreakTimer))).ToString();
        }
        if (BreakIsOn == false)
        {
            text.text = " ";
        }
        playerKillCount = GameObject.FindObjectOfType<playerMovement>().score;
        if (playerKillCount - playerPreviousKillCount > BreakInterval)
        {
            BreakIsOn = true;
            playerPreviousKillCount = playerKillCount;
        }
        if (BreakIsOn ==true & BreakTimer < BreakTime)
        {
            BreakTimer += 1*Time.deltaTime;
        }
        if(BreakIsOn == true & BreakTimer > BreakTime)
        {
            BreakIsOn = false;
            BreakTimer = 0;
        }
        if (eliteEnemies.Count > 1 & limitSpawning == false)
        {
            limitSpawning = true;
        }

        if (limitSpawning == true&coolDownTimer<eliteCooldown)
        {
            coolDownTimer += 1 * Time.deltaTime;
        }
        if (limitSpawning == true & coolDownTimer > eliteCooldown)
        {
            coolDownTimer = 0;
            limitSpawning = false;
        }
        
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
        
        if (BreakIsOn==false&limitSpawning==false&(int)Random.Range(0, chanceForEnemy + 1) == chanceForEnemy) { enemyToSpawn = 1; Debug.Log("enemy 2"); }
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
        
        if (timer > spawnTimer&enemies.Count<enemyLimit+1&BreakIsOn==false)
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
